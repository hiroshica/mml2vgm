﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using Core;
using System.Diagnostics;

namespace mml2vgmIDE
{
    public partial class FrmMain : Form
    {
        private string appName = "mml2vgmIDE";
        private List<Form> FormBox = new List<Form>();
        private List<Document> DocumentBox = new List<Document>();
        private bool isSuccess = true;
        private string[] args;
        private Mml2vgm mv = null;
        private string title = "";
        private FrmLog frmLog = null;
        private FrmPartCounter frmPartCounter = null;
        private FrmFolderTree frmFolderTree = null;
        private FrmErrorList frmErrorList = null;
        private bool doPlay = false;
        private bool Compiling = false;

        public FrmMain()
        {
            InitializeComponent();

            this.KeyPreview = true;

            if (Directory.Exists(Path.Combine(Common.GetApplicationDataFolder(true), "temp")))
            {
                DirectoryInfo target = new DirectoryInfo(Path.Combine(Common.GetApplicationDataFolder(true), "temp"));
                foreach (FileInfo file in target.GetFiles())
                {
                    file.Delete();
                }
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(Common.GetApplicationDataFolder(true), "temp"));
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;

            frmPartCounter = new FrmPartCounter();
            frmPartCounter.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            frmPartCounter.parentUpdate = UpdateControl;
            FormBox.Add(frmPartCounter);

            frmLog = new FrmLog();
            frmLog.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);
            frmLog.parentUpdate = UpdateControl;
            FormBox.Add(frmLog);

            frmFolderTree = new FrmFolderTree();
            frmFolderTree.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.DockLeft);
            frmFolderTree.parentUpdate = UpdateControl;
            frmFolderTree.parentExecFile = ExecFile;
            FormBox.Add(frmFolderTree);

            frmErrorList = new FrmErrorList();
            frmErrorList.Show(dpMain, WeifenLuo.WinFormsUI.Docking.DockState.DockBottom);
            frmErrorList.parentUpdate = UpdateControl;
            frmErrorList.parentJumpDocument = JumpDocument;
            FormBox.Add(frmErrorList);

            UpdateControl();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool flg = false;
            foreach(Document d in DocumentBox)
            {
                if(d.isNew || d.edit)
                {
                    flg = true;
                    break;
                }
            }

            if (flg)
            {
                DialogResult res = MessageBox.Show("保存していないファイルがあります。終了しますか？"
                    , "終了確認"
                    , MessageBoxButtons.YesNo
                    , MessageBoxIcon.Question);
                if (res != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        public void RemoveForm(Form frm)
        {
            FormBox.Remove(frm);
        }

        public void RemoveDocument(Document parent)
        {
            DocumentBox.Remove(parent);
        }

        private void TsmiNew_Click(object sender, EventArgs e)
        {
            OpenFile("");
        }

        public void TsmiFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "gwiLファイル(*.gwi)|*.gwi|すべてのファイル(*.*)|*.*";
            ofd.Title = "ファイルを開く";
            ofd.RestoreDirectory = true;

            if (ofd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            OpenFile(ofd.FileName);
        }

        private void TsmiOpenFolder_Click(object sender, EventArgs e)
        {

        }

        public void TsmiSaveFile_Click(object sender, EventArgs e)
        {
            DockContent dc = null;
            Document d = null;
            if (dpMain.ActiveDocument is DockContent)
            {
                dc = (DockContent)dpMain.ActiveDocument;
                if (dc.Tag is Document)
                {
                    d = (Document)dc.Tag;
                }
            }
            if (d == null) return;

            File.WriteAllText(d.gwiFullPath, d.editor.azukiControl.Text, Encoding.UTF8);

            d.edit = false;
            d.editor.azukiControl.ClearHistory();
            if (d.editor.Text.Length>0 && d.editor.Text[d.editor.Text.Length - 1] == '*')
            {
                d.editor.Text = d.editor.Text.Substring(0, d.editor.Text.Length - 1);
            }
            d.isNew = false;
            UpdateControl();
        }

        private void TsmiSaveAs_Click(object sender, EventArgs e)
        {
            DockContent dc = null;
            Document d = null;
            if (dpMain.ActiveDocument is DockContent)
            {
                dc = (DockContent)dpMain.ActiveDocument;
                if (dc.Tag is Document)
                {
                    d = (Document)dc.Tag;
                }
            }
            if (d == null) return;

            SaveFileDialog sfd = new SaveFileDialog();
            string fn = d.gwiFullPath;
            if (fn.Length > 0 && fn[fn.Length - 1] == '*')
            {
                fn = fn.Substring(0, fn.Length - 1);
            }
            sfd.FileName = Path.GetFileName(fn);
            sfd.InitialDirectory = Path.GetDirectoryName(fn);
            sfd.Filter = "gwiファイル(*.gwi)|*.gwi|すべてのファイル(*.*)|*.*";
            sfd.Title = "名前を付けて保存";
            sfd.RestoreDirectory = true;
            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            fn = Path.Combine(Path.GetDirectoryName(fn), sfd.FileName);
            d.editor.Text = Path.GetFileName(sfd.FileName);
            d.gwiFullPath = fn;
            TsmiSaveFile_Click(null, null);
        }

        private void TsmiExport_Click(object sender, EventArgs e)
        {
            try
            {
                DockContent dc = null;
                Document d = null;
                if (dpMain.ActiveDocument is DockContent)
                {
                    dc = (DockContent)dpMain.ActiveDocument;
                    if (dc.Tag is Document)
                    {
                        d = (Document)dc.Tag;
                    }
                }
                if (d == null) return;

                Compile(false);
                while (Compiling) { Application.DoEvents(); }//待ち合わせ

                if (msgBox.getErr().Length > 0)
                {
                    MessageBox.Show("コンパイル時にエラーが発生しました。エクスポート処理を中断します。",
                        "エラー発生",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                string fn = d.gwiFullPath;
                if (fn.Length > 0 && fn[fn.Length - 1] == '*')
                {
                    fn = fn.Substring(0, fn.Length - 1);
                }
                sfd.FileName = Path.GetFileNameWithoutExtension(fn) + (FileInformation.format == enmFormat.VGM ? ".vgm" : ".xgm");
                sfd.InitialDirectory = Path.GetDirectoryName(fn);
                sfd.Filter = "vgmファイル(*.vgm)|*.vgm|すべてのファイル(*.*)|*.*";
                if (FileInformation.format == enmFormat.XGM)
                {
                    sfd.Filter = "xgmファイル(*.xgm)|*.xgm|すべてのファイル(*.*)|*.*";
                }
                sfd.Title = "エクスポート";
                sfd.RestoreDirectory = true;
                if (sfd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                fn = sfd.FileName;
                if (Path.GetExtension(fn) == "")
                {
                    fn = Path.GetFileNameWithoutExtension(fn) + (FileInformation.format == enmFormat.VGM ? ".vgm" : ".xgm");
                }

                File.Copy(Path.Combine(Common.GetApplicationDataFolder(true), "temp", sfd.FileName), fn);
            }
            catch(Exception )
            {
                MessageBox.Show("エクスポート処理に失敗しました。", "エクスポート失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TsmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void TsmiCompileAndPlay_Click(object sender, EventArgs e)
        {
            Compile(true);
        }

        private void TsmiCompile_Click(object sender, EventArgs e)
        {
            Compile(false);
        }

        private void TsmiUndo_Click(object sender, EventArgs e)
        {
            DockContent dc = null;
            Document d = null;
            if (dpMain.ActiveDocument is DockContent)
            {
                dc = (DockContent)dpMain.ActiveDocument;
                if (dc.Tag is Document)
                {
                    d = (Document)dc.Tag;
                }
            }

            if (d != null) d.editor.azukiControl.Undo();
            UpdateControl();
        }

        private void TsmiRedo_Click(object sender, EventArgs e)
        {
            DockContent dc = null;
            Document d = null;
            if (dpMain.ActiveDocument is DockContent)
            {
                dc = (DockContent)dpMain.ActiveDocument;
                if (dc.Tag is Document)
                {
                    d = (Document)dc.Tag;
                }
            }

            if (d != null) d.editor.azukiControl.Redo();
            UpdateControl();
        }

        private void TsmiShowPartCounter_Click(object sender, EventArgs e)
        {
            if (frmPartCounter.IsHidden) frmPartCounter.Show();
            else frmPartCounter.Hide();

            TsmiShowPartCounter.Checked = !frmPartCounter.IsHidden;
        }

        private void TsmiShowFolderTree_Click(object sender, EventArgs e)
        {
            if (frmFolderTree.IsHidden) frmFolderTree.Show();
            else frmFolderTree.Hide();

            TsmiShowFolderTree.Checked = !frmFolderTree.IsHidden;
        }

        private void TsmiShowErrorList_Click(object sender, EventArgs e)
        {
            if (frmErrorList.IsHidden) frmErrorList.Show();
            else frmErrorList.Hide();

            TsmiShowErrorList.Checked = !frmErrorList.IsHidden;
        }

        private void TsmiShowLog_Click(object sender, EventArgs e)
        {
            if (frmLog.IsHidden) frmLog.Show();
            else frmLog.Hide();

            TsmiShowLog.Checked = !frmLog.IsHidden;
        }

        private void TsmiTutorial_Click(object sender, EventArgs e)
        {
            Process.Start("Tutorial.txt");
        }

        private void TsmiReference_Click(object sender, EventArgs e)
        {
            Process.Start("CommandReference.txt");
        }

        private void TsmiAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.ShowDialog();
        }

        private void TssbOpen_ButtonClick(object sender, EventArgs e)
        {
            TsmiFileOpen_Click(null, null);
        }

        private void TssbSave_ButtonClick(object sender, EventArgs e)
        {
            TsmiSaveFile_Click(null, null);
        }

        private void TssbCompile_ButtonClick(object sender, EventArgs e)
        {
            TsmiCompileAndPlay_Click(null, null);
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                case Keys.Control | Keys.O:
                    TsmiFileOpen_Click(null, null);
                    break;
                case Keys.F2:
                case Keys.Control | Keys.S:
                    TsmiSaveFile_Click(null, null);
                    break;
                case Keys.F5:
                    TsmiCompileAndPlay_Click(null, null);
                    break;
            }
        }



        private void OpenFile(string fileName)
        {
            Document dc = new Document();
            if (fileName != "") dc.InitOpen(fileName);
            dc.editor.Show(dpMain, DockState.Document);
            dc.editor.main = this;
            dc.editor.parent = dc;

            frmFolderTree.treeView1.Nodes.Clear();
            frmFolderTree.treeView1.Nodes.Add(dc.gwiTree);
            frmFolderTree.basePath = Path.GetDirectoryName(dc.gwiFullPath);

            FormBox.Add(dc.editor);
            DocumentBox.Add(dc);
        }

        string wrkPath = "";

        private void Compile(bool doPlay)
        {
            IDockContent dc = dpMain.ActiveDocument;
            if (dc == null) return;
            if (!(dc is FrmEditor)) return;

            string text = ((FrmEditor)dc).azukiControl.Text;
            if (!Directory.Exists(Path.Combine(Common.GetApplicationDataFolder(true), "temp")))
            {
                Directory.CreateDirectory(Path.Combine(Common.GetApplicationDataFolder(true), "temp"));
            }
            string tempPath = Path.Combine(Common.GetApplicationDataFolder(true), "temp", Path.GetFileName(((Document)((FrmEditor)dc).Tag).gwiFullPath));
            File.WriteAllText(tempPath, text);
            args = new string[2];
            args[1] = tempPath;
            wrkPath = Path.GetDirectoryName(((Document)((FrmEditor)dc).Tag).gwiFullPath);

            isSuccess = true;
            this.doPlay = doPlay;
            frmPartCounter.dataGridView1.Rows.Clear();

            Thread trdStartCompile = new Thread(new ThreadStart(startCompile));
            trdStartCompile.Start();
            Compiling = true;
        }

        private void startCompile()
        {
            Core.log.Open();
            Core.log.Write("start compile thread");

            Action dmy = updateTitle;
            string stPath = System.Windows.Forms.Application.StartupPath;

            for (int i = 1; i < args.Length; i++)
            {
                string arg = args[i];
                if (!File.Exists(arg))
                {
                    continue;
                }


                title = Path.GetFileName(arg);
                this.Invoke(dmy);

                Core.log.Write(string.Format("  compile at [{0}]", args[i]));

                msgBox.clear();

                string desfn = Path.ChangeExtension(arg, Properties.Resources.ExtensionVGM);
                //if (tsbToVGZ.Checked)
                //{
                    //desfn = Path.ChangeExtension(arg, Properties.Resources.ExtensionVGZ);
                //}

                Core.log.Write("Call mml2vgm core");

                mv = new Mml2vgm(arg, desfn, stPath, Disp, wrkPath);
                if (mv.Start() != 0)
                {
                    isSuccess = false;
                    break;
                }

                Core.log.Write("Return mml2vgm core");
            }

            Core.log.Write("Disp Result");

            dmy = finishedCompile;
            this.Invoke(dmy);

            Core.log.Write("end compile thread");
            Core.log.Close();
        }

        private void updateTitle()
        {
            if (title == "")
            {
                this.Text = appName;
            }
            else
            {
                this.Text = string.Format("{0} - {1}", appName, title);
            }
        }
        private void Disp(string msg)
        {
            Action<string> msgDisp = MsgDisp;
            this.Invoke(msgDisp, msg);
            Core.log.Write(msg);
        }

        private void MsgDisp(string msg)
        {
            if (frmLog == null) return;
            if (frmLog.IsDisposed) return;

            frmLog.textBox1.AppendText(msg + "\r\n");
        }

        private void finishedCompile()
        {
            if (mv == null)
            {
                if (frmLog != null && !frmLog.IsDisposed) frmLog.textBox1.AppendText(msg.get("I0105"));
                //this.toolStrip1.Enabled = true;
                //this.tsslMessage.Text = msg.get("I0106");
                return;
            }

            if (isSuccess)
            {
                foreach (KeyValuePair<enmChipType, ClsChip[]> kvp in mv.desVGM.chips)
                {
                    foreach (ClsChip chip in kvp.Value)
                    {
                        List<partWork> pw = chip.lstPartWork;
                        for (int i = 0; i < pw.Count; i++)
                        {
                            if (pw[i].clockCounter == 0) continue;

                            DataGridViewRow row = new DataGridViewRow();
                            row.Cells.Add(new DataGridViewTextBoxCell());
                            row.Cells[0].Value = pw[i].PartName.Substring(0, 2).Replace(" ", "") + int.Parse(pw[i].PartName.Substring(2, 2)).ToString();
                            row.Cells.Add(new DataGridViewTextBoxCell());
                            row.Cells[1].Value = pw[i].chip.Name.ToUpper();
                            row.Cells.Add(new DataGridViewTextBoxCell());
                            row.Cells[2].Value = pw[i].clockCounter;
                            frmPartCounter.dataGridView1.Rows.Add(row);
                        }
                    }
                }
            }

            frmLog.textBox1.AppendText(msg.get("I0107"));

            foreach (msgInfo mes in msgBox.getErr())
            {
                frmErrorList.dataGridView1.Rows.Add("Error", mes.filename, mes.line == -1 ? "-" : mes.line.ToString(), mes.body);
                //frmConsole.textBox1.AppendText(string.Format(msg.get("I0109"), mes));
            }

            foreach (msgInfo mes in msgBox.getWrn())
            {
                frmErrorList.dataGridView1.Rows.Add("Warning", mes.filename, mes.line == -1 ? "-" : mes.line.ToString(), mes.body);
                //frmConsole.textBox1.AppendText(string.Format(msg.get("I0108"), mes));
            }

            frmLog.textBox1.AppendText("\r\n");
            frmLog.textBox1.AppendText(string.Format(msg.get("I0110"), msgBox.getErr().Length, msgBox.getWrn().Length));

            if (mv.desVGM.loopSamples != -1)
            {
                frmLog.textBox1.AppendText(string.Format(msg.get("I0111"), mv.desVGM.loopClock));
                if (mv.desVGM.info.format == enmFormat.VGM)
                    frmLog.textBox1.AppendText(string.Format(msg.get("I0112")
                        , mv.desVGM.loopSamples
                        , mv.desVGM.loopSamples / 44100L));
                else
                    frmLog.textBox1.AppendText(string.Format(msg.get("I0112")
                        , mv.desVGM.loopSamples
                        , mv.desVGM.loopSamples / (mv.desVGM.info.xgmSamplesPerSecond)));
            }

            frmLog.textBox1.AppendText(string.Format(msg.get("I0113"), mv.desVGM.lClock));
            if (mv.desVGM.info.format == enmFormat.VGM)
                frmLog.textBox1.AppendText(string.Format(msg.get("I0114")
                    , mv.desVGM.dSample
                    , mv.desVGM.dSample / 44100L));
            else
                frmLog.textBox1.AppendText(string.Format(msg.get("I0114")
                    , mv.desVGM.dSample
                    , mv.desVGM.dSample / (mv.desVGM.info.xgmSamplesPerSecond)));

            //if (mv.desVGM.ym2608[0].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0115"), mv.desVGM.ym2608[0].pcmDataEasy.Length - 15));
            //if (mv.desVGM.ym2608[1].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0116"), mv.desVGM.ym2608[1].pcmDataEasy.Length - 15));
            //if (mv.desVGM.ym2610b[0].pcmDataEasyA != null) textBox1.AppendText(string.Format(msg.get("I0117"), mv.desVGM.ym2610b[0].pcmDataEasyA.Length-15));
            //if (mv.desVGM.ym2610b[0].pcmDataEasyB != null) textBox1.AppendText(string.Format(msg.get("I0118"), mv.desVGM.ym2610b[0].pcmDataEasyB.Length-15));
            //if (mv.desVGM.ym2610b[1].pcmDataEasyA != null) textBox1.AppendText(string.Format(msg.get("I0119"), mv.desVGM.ym2610b[1].pcmDataEasyA.Length - 15));
            //if (mv.desVGM.ym2610b[1].pcmDataEasyB != null) textBox1.AppendText(string.Format(msg.get("I0120"), mv.desVGM.ym2610b[1].pcmDataEasyB.Length - 15));
            //if (mv.desVGM.segapcm[0].pcmData != null) textBox1.AppendText(string.Format(" PCM Data size(SEGAPCM)  : {0} byte\r\n", mv.desVGM.segapcm[0].pcmData.Length - 15));
            //if (mv.desVGM.segapcm[1].pcmData != null) textBox1.AppendText(string.Format(" PCM Data size(SEGAPCMSecondary)  : {0} byte\r\n", mv.desVGM.segapcm[1].pcmData.Length - 15));
            //if (mv.desVGM.ym2612[0].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0121"), mv.desVGM.ym2612[0].pcmDataEasy.Length));
            //if (mv.desVGM.rf5c164[0].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0122"), mv.desVGM.rf5c164[0].pcmDataEasy.Length-12));
            //if (mv.desVGM.rf5c164[1].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0123"), mv.desVGM.rf5c164[1].pcmDataEasy.Length-12));
            //if (mv.desVGM.huc6280[0].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0124"), mv.desVGM.huc6280[0].pcmDataEasy.Length));
            //if (mv.desVGM.huc6280[1].pcmDataEasy != null) textBox1.AppendText(string.Format(msg.get("I0125"), mv.desVGM.huc6280[1].pcmDataEasy.Length));


            frmLog.textBox1.AppendText(msg.get("I0126"));
            //this.toolStrip1.Enabled = true;
            //this.tsslMessage.Text = msg.get("I0106");

            if (isSuccess)
            {
                if (args.Length == 2 && doPlay && msgBox.getErr().Length < 1)
                {
                    try
                    {
                        Process.Start(Path.ChangeExtension(args[1], (mv.desVGM.info.format == enmFormat.VGM) ? Properties.Resources.ExtensionVGM : Properties.Resources.ExtensionXGM));
                    }
                    catch (Exception)
                    {
                        MessageBox.Show(msg.get("E0100"), "mml2vgm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            Compiling = false;
            UpdateControl();
        }

        private void DpMain_ActiveDocumentChanged(object sender, EventArgs e)
        {
            UpdateControl();
        }

        public void UpdateControl()
        {
            DockContent dc = null;
            Document d = null;
            if (dpMain.ActiveDocument is DockContent)
            {
                dc = (DockContent)dpMain.ActiveDocument;
                if (dc.Tag is Document)
                {
                    d = (Document)dc.Tag;
                }
            }

            if (d != null)
            {
                //メニューの有効無効を切り替え
                if (d.isNew)
                {
                    TsmiSaveFile.Enabled = false;
                    tssbSave.Enabled = false;
                    TsmiSaveAs.Enabled = true;
                }
                else
                {
                    TsmiSaveFile.Enabled = true;
                    tssbSave.Enabled = true;
                    TsmiSaveAs.Enabled = true;
                }

                TsmiUndo.Enabled = d.editor.azukiControl.CanUndo;
                TsmiRedo.Enabled = d.editor.azukiControl.CanRedo;

                if (frmFolderTree.treeView1.Nodes.Count==0 || frmFolderTree.treeView1.Nodes[0] != d.gwiTree)
                {
                    frmFolderTree.treeView1.Nodes.Clear();
                    frmFolderTree.treeView1.Nodes.Add(d.gwiTree);
                }

                this.Text = string.Format("{0} - {1}", appName, d.editor.Text);
            }
            else
            {
                TsmiSaveFile.Enabled = false;
                TsmiSaveAs.Enabled = false;
                TsmiUndo.Enabled = false;
                TsmiRedo.Enabled = false;

                this.Text = appName;
            }

            TsmiShowPartCounter.Checked = !frmPartCounter.IsHidden;
            TsmiShowFolderTree.Checked = !frmFolderTree.IsHidden;
            TsmiShowErrorList.Checked = !frmErrorList.IsHidden;
            TsmiShowLog.Checked = !frmLog.IsHidden;

            tsslCompileError.Text = string.Format(
                "{0}",
                msgBox.getErr().Length
                );
            tsslCompileWarning.Text = string.Format(
                "{0}",
                msgBox.getWrn().Length
                );
            tsslCompileStatus.Text = string.Format(
                "TCnt:{0} LCnt:{1}",
                FileInformation.totalCounter,
                FileInformation.loopCounter == -1 ? "-" : FileInformation.loopCounter.ToString()
                );
        }

        private System.Media.SoundPlayer player = null;
        private void ExecFile(string filename)
        {
            if (Path.GetExtension(filename).ToUpper() == ".WAV")
            {
                if (player != null)
                    StopSound();
                player = new System.Media.SoundPlayer(filename);
                player.Play();
                return;
            }
            try
            {
                Process.Start(filename);
            }
            catch
            {
            }
        }
        private void StopSound()
        {
            if (player != null)
            {
                player.Stop();
                player.Dispose();
                player = null;
            }
        }

        private void JumpDocument(string fn, long ln,bool wantFocus)
        {
            foreach(DockContent dc in dpMain.Documents)
            {
                if (Path.GetFileName(((Document)dc.Tag).gwiFullPath) != fn)
                {
                    continue;
                }
                
                Application.DoEvents();
                Sgry.Azuki.Document d = ((Document)dc.Tag).editor.azukiControl.Document;
                Sgry.Azuki.IView v = ((Document)dc.Tag).editor.azukiControl.View;
                int anc = d.GetLineHeadIndex((int)(ln - 1));
                int caret = d.GetLineHeadIndex((int)ln) - 2;//改行前までを選択する
                int ancM = d.GetLineHeadIndex((int)(ln - 2));
                anc = Math.Max(anc, 0);
                ancM = Math.Max(ancM, 0);
                caret = Math.Max(anc, caret);
                v.ScrollPos= v.GetVirPosFromIndex(ancM);//1行手前を画面の最上部になるようスクロールさせる。

                v.Scroll(1);//scroll barの表示を更新させるため
                v.Scroll(-1);//scroll barの表示を更新させるため

                d.SetSelection(anc, caret);
                if (wantFocus) ((Document)dc.Tag).editor.azukiControl.Focus();
            }
        }

    }
}