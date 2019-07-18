﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Sgry.Azuki;
using Sgry.Azuki.WinForms;
using WeifenLuo.WinFormsUI.Docking;

namespace mml2vgmIDE
{
    public partial class FrmEditor : DockContent
    {
        private FrmMain _main;
        public FrmMain main
        {
            get
            {
                return _main;
            }
            set
            {
                frmSien.parent = value;
                _main = value;
                main.LocationChanged += AzukiControl_CancelSien;
                main.SizeChanged += AzukiControl_CancelSien;
            }
        }
        public Document document = null;
        public FrmSien frmSien = null;
        //public int col = -1;
        public AzukiControl azukiControl;

        public FrmEditor(Setting setting)
        {
            InitializeComponent();

            Sgry.Azuki.Highlighter.KeywordHighlighter keywordHighlighter = new Sgry.Azuki.Highlighter.KeywordHighlighter();
            keywordHighlighter.AddRegex("^[^'].*", false, CharClass.DocComment);
            keywordHighlighter.AddRegex("^'[A-Za-z0-9\\-\\,]+ ", CharClass.Keyword);
            keywordHighlighter.AddRegex("^'@ ", CharClass.Keyword);
            keywordHighlighter.AddRegex("^'%\\S+ ", CharClass.Keyword);
            keywordHighlighter.AddEnclosure("'{", "}", CharClass.Comment, true);
            azukiControl = new AzukiControl();
            azukiControl.Font = new Font(setting.other.TextFontName, setting.other.TextFontSize, setting.other.TextFontStyle);
            azukiControl.Dock = DockStyle.Fill;
            azukiControl.ShowsIconBar = true;
            azukiControl.Highlighter = keywordHighlighter;
            azukiControl.IconBarImageList = imglstIconBar;
            azukiControl.IconBarClicked += AzukiControl_IconBarClicked;
            azukiControl.TextChanged += AzukiControl_TextChanged;
            azukiControl.KeyDown += AzukiControl_KeyDown;
            azukiControl.HScroll += AzukiControl_CancelSien;
            azukiControl.VScroll += AzukiControl_CancelSien;
            azukiControl.LocationChanged += AzukiControl_CancelSien;
            azukiControl.SizeChanged += AzukiControl_CancelSien;
            azukiControl.CaretMoved += AzukiControl_CaretMoved;
            azukiControl.AllowDrop = true;
            azukiControl.DragOver += AzukiControl_DragOver;
            azukiControl.DragDrop += AzukiControl_DragDrop;

            azukiControl.ColorScheme.ForeColor = Color.FromArgb(setting.ColorScheme.Azuki_ForeColor);
            azukiControl.ColorScheme.BackColor = Color.FromArgb(setting.ColorScheme.Azuki_BackColor);
            azukiControl.ColorScheme.IconBarBack = Color.FromArgb(setting.ColorScheme.Azuki_IconBarBack);
            azukiControl.ColorScheme.LineNumberBack = Color.FromArgb(setting.ColorScheme.Azuki_LineNumberBack_Normal);
            azukiControl.ColorScheme.LineNumberFore = Color.FromArgb(setting.ColorScheme.Azuki_LineNumberFore_Normal);
            azukiControl.ColorScheme.SetColor(CharClass.Keyword, Color.FromArgb(setting.ColorScheme.Azuki_Keyword), Color.Transparent);
            azukiControl.ColorScheme.SetColor(CharClass.Comment, Color.FromArgb(setting.ColorScheme.Azuki_Comment), Color.Transparent);
            azukiControl.ColorScheme.SetColor(CharClass.DocComment, Color.FromArgb(setting.ColorScheme.Azuki_DocComment), Color.Transparent);
            azukiControl.ColorScheme.SetColor(CharClass.Number, Color.FromArgb(setting.ColorScheme.Azuki_Number), Color.Transparent);

            MarkingInfo info = new MarkingInfo(1, "TraceInfo");
            Marking.Register(info);
            TextDecoration dec = new BgColorTextDecoration(Color.DarkGoldenrod);
            azukiControl.ColorScheme.SetMarkingDecoration(1, dec);

            azukiControl.SetKeyBind(Keys.Home, ActionHome);
            azukiControl.SetKeyBind((uint)(Keys.Shift | Keys.Enter), ActionShiftEnter);
            azukiControl.SetKeyBind((uint)(Keys.Control | Keys.Divide), ActionComment);
            azukiControl.SetKeyBind((uint)(Keys.Control | Keys.OemQuestion), ActionComment);

            this.Controls.Add(azukiControl);

            frmSien = new FrmSien(setting);
            frmSien.parent = main;
            frmSien.Show();
        }

        private void AzukiControl_DragDrop(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがfileか調べる
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            if (e.Effect == DragDropEffects.None) return;

            string[] source = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (e.Effect== DragDropEffects.Move)
            {
                main.ExecFile(source);
                return;
            }

            IncludeFile(source);
        }

        private void IncludeFile(string[] source)
        {
            foreach (string fn in source) IncludeFile(fn);
        }

        private void IncludeFile(string source)
        {
            string ext = System.IO.Path.GetExtension(source).ToLower();
            if (ext != ".gwi"
                && ext != ".wav"
                && ext != ".bin" //mucom PCM data?
                && ext != ".dat" //mucom voice data?
                && ext != ".tfi" 
                )
            {
                log.dispMsg(string.Format("Can't include '{0}'.", source));
                return;
            }

            string basePath = System.IO.Path.GetDirectoryName(this.document.gwiFullPath) + "\\";
            if (source.IndexOf(basePath) == 0)
            {
                source = source.Substring(basePath.Length);
            }

            string define = "";
            switch (ext)
            {
                case ".gwi":
                    define = "'+ \"{0}\"";
                    break;
                case ".wav":
                    define = "'@ P n , \"{0}\" , 8000 , 100";
                    break;
                case ".bin":
                    define = "'@ MUCOM88ADPCM n , \"{0}\"";
                    break;
                case ".dat":
                    define = "'@ MUCOM88 n , \"{0}\"";
                    break;
                case ".tfi":
                    define = "'@ TFI n , \"{0}\"";
                    break;
            }

            azukiControl.Document.Replace(string.Format("\r\n" + define, source));

        }

        private void AzukiControl_DragOver(object sender, DragEventArgs e)
        {
            //ドラッグされているデータがfileか調べる
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            string[] source = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (!CanMoveFiles(source))
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            DragDropEffects efc = DragDropEffects.Move;
            //shift または ctrl が押されている場合はmove
            if ((e.KeyState & (8+4)) != 0)
            {

                if (CanDropFilesToEditor(source))
                {
                    efc = DragDropEffects.Copy;
                    int index = azukiControl.GetIndexFromPosition(azukiControl.PointToClient(new Point(e.X, e.Y)));
                    //int lin;
                    //int col;
                    //azukiControl.GetLineColumnIndexFromCharIndex(index,out lin,out col);
                    azukiControl.SetSelection(index, index);
                    //Console.WriteLine("{0} Line:{1} Column:{2}", index,lin,col);
                }
                else
                {
                    efc = DragDropEffects.None;
                }
            }

            e.Effect = efc;
        }

        private bool CanDropFilesToEditor(string[] source)
        {
            foreach (string fn in source)
            {
                string ext = System.IO.Path.GetExtension(fn).ToLower();
                if (ext==".gwi"
                    || ext == ".wav"
                    || ext == ".bin" //mucom PCM data?
                    || ext == ".dat" //mucom voice data?
                    )
                {
                    return true;
                }
            }

            return false;
        }

        private bool CanMoveFiles(string[] source)
        {
            //ひとつでも移動可能なファイルが含まれるならばtrue
            foreach(string fn in source)
            {
                string ext = System.IO.Path.GetExtension(fn).ToLower();
                if(ext==".gwi"
                    || ext == ".mwi" //fmp7 mml data
                    || ext == ".muc" //mucom mml data
                    || ext == ".mml" //common mml data
                    || ext == ".doc"
                    || ext == ".txt"
                    || ext == ".hed"
                    || ext == ".wav"
                    || ext == ".bin" //mucom PCM data?
                    || ext == ".dat" //mucom voice data?
                    )
                {
                    return true;
                }
            }

            return false;
        }

        private void AzukiControl_CaretMoved(object sender, EventArgs e)
        {
            int ci = azukiControl.CaretIndex;
            int row, col;
            azukiControl.GetLineColumnIndexFromCharIndex(ci, out row, out col);
            if (main != null) main.TsslLineCol.Text = string.Format("Line:{0} Col:{1}", row + 1, col + 1);
        }

        private void ActionComment(IUserInterface ui)
        {
            int b;
            int e;
            azukiControl.GetSelection(out b, out e);

            int st = azukiControl.GetLineHeadIndexFromCharIndex(b);
            b = azukiControl.GetLineHeadIndexFromCharIndex(e);
            int li = azukiControl.GetLineIndexFromCharIndex(e);
            int ed = b + azukiControl.GetLineLength(li);
            azukiControl.SetSelection(st, ed);
            string line = azukiControl.GetSelectedText();
            string[] lines = line.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //チェック
            bool flg = false;
            foreach (string s in lines)
            {
                if (s.Length < 1 || s[0] != '\'')
                {
                    flg = true;
                    break;
                }
            }
            line = "";
            if (flg)
            {
                // 'をつける
                foreach (string s in lines)
                {
                    line += "'" + s + "\r\n";
                }
                line = line.Substring(0, line.Length - 2);
            }
            else
            {
                // 'をカットする
                foreach (string s in lines)
                {
                    line += s.Substring(1) + "\r\n";
                }
                line = line.Substring(0, line.Length - 2);
            }
            azukiControl.Document.Replace(line, st, ed);
            azukiControl.SetSelection(st, st+line.Length);
        }

        private void ActionShiftEnter(IUserInterface ui)
        {
            int ci = azukiControl.CaretIndex;
            int st = azukiControl.GetLineHeadIndexFromCharIndex(ci);
            int li = azukiControl.GetLineIndexFromCharIndex(ci);
            int ed = st + azukiControl.GetLineLength(li);
            string line = azukiControl.GetTextInRange(st, ci);

            if (line == null || line.Length < 1) return;
            //先頭の文字が'ではないときは既存の動作
            if (line[0] != '\'')
            {
                return;
            }

            int a = -1;

            //1行を左からサーチし、初めに出現する空白又はタブの位置を取得する
            int s = line.IndexOf(' ');
            int t = line.IndexOf('\t');
            if (s < 0) a = t;
            if (t < 0) a = s;
            if (s >= 0 && t >= 0) a = Math.Min(s, t);


            //空白又はタブが見つからなかった場合は行末まで
            if (a < 0)
            {
                a = line.Length;
                a = (ci - st) < a ? (ci - st) : a;
            }
            else
            {
                if (a + st > ci) a = ci - st;

                while (a < line.Length && (line[a] == ' ' || line[a] == '\t'))
                {
                    a++;
                }
            }

            azukiControl.Document.Replace("\r\n" + line.Substring(0, a));
        }

        private void ActionHome(IUserInterface ui)
        {
            int ci = azukiControl.CaretIndex;
            int st = azukiControl.GetLineHeadIndexFromCharIndex(ci);
            int li = azukiControl.GetLineIndexFromCharIndex(ci);
            int ed = st + azukiControl.GetLineLength(li);
            string line = azukiControl.GetTextInRange(st, ed);
            int a = -1;

            if (line == null || line.Length < 1) return;
            //先頭の文字が'ではないときは既存の動作
            if (line[0] != '\'')
            {
                a = 0;
                while (a < line.Length && (line[a] == ' ' || line[a] == '\t'))
                {
                    a++;
                }

            }
            else
            {
                //1行を左からサーチし、初めに出現する空白又はタブの位置を取得する
                int s = line.IndexOf(' ');
                int t = line.IndexOf('\t');
                if (s < 0) a = t;
                if (t < 0) a = s;
                if (s >= 0 && t >= 0) a = Math.Min(s, t);

                //空白又はタブが見つからなかった場合は先頭へ移動
                if (a < 0)
                {
                    azukiControl.SetSelection(st, st);
                    return;
                }

                while (a < line.Length && (line[a] == ' ' || line[a] == '\t'))
                {
                    a++;
                }
            }

            //既に移動済みの場合は先頭へ移動
            if (st + a == ci)
            {
                azukiControl.SetSelection(st, st);
                return;
            }

            azukiControl.SetSelection(st + a, st + a);
        }

        protected override string GetPersistString()
        {
            return this.Name;
        }

        private void AzukiControl_IconBarClicked(object sender, IconBarClickedEventArgs e)
        {
            AzukiControl_CancelSien(null, null);
            int n = azukiControl.Document.GetLineIconIndex(e.clickedIndex);
            n++;
            if (n == imglstIconBar.Images.Count) n = -1;
            int c = azukiControl.GetLineHeadIndex(e.clickedIndex);
            azukiControl.SetSelection(c, c);
            azukiControl.Document.SetLineIconIndex(e.clickedIndex, n);
        }

        private void acDown(IUserInterface ui)
        {
            if (frmSien.Opacity == 0.0)
            {
                return;
            }

            if (frmSien.dgvItem.Rows.Count - 1 > frmSien.selRow) frmSien.selRow++;
            frmSien.dgvItem.Rows[frmSien.selRow].Selected = true;
        }

        private void AzukiControl_TextChanged(object sender, EventArgs e)
        {
            if (document == null) return;

            if (!document.edit)
            {
                if (!document.isNew)
                {
                    if (azukiControl.CanUndo) this.Text += "*";
                }
                document.edit = true;
            }

            //main.UpdateControl();

            int ci = azukiControl.CaretIndex;
            int st = azukiControl.GetLineHeadIndexFromCharIndex(ci);
            Point ciP = azukiControl.GetPositionFromIndex(Math.Max(ci - 1, 0));
            ciP = azukiControl.PointToScreen(new Point(ciP.X, ciP.Y + azukiControl.LineHeight));
            string line = azukiControl.GetTextInRange(st, ci).TrimStart();
            if (line != "" && line[0] == '\'')
            {
                frmSien.selRow = -1;
                frmSien.Request(line, ciP);
            }
        }

        private void FrmEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (document.isNew || document.edit)
                {
                    DialogResult res = MessageBox.Show("保存せずにファイルを閉じますか？"
                        , "ファイル保存確認"
                        , MessageBoxButtons.YesNo
                        , MessageBoxIcon.Question);
                    if (res != DialogResult.Yes)
                    {
                        e.Cancel = true;
                        return;
                    }
                }

                main.RemoveForm(this);
                main.RemoveDocument(document);

            }
        }

        private void FrmEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Hokan(string line,Point ciP)
        {
            if (line == "\'@")
            {
                Point r = azukiControl.PointToScreen(new Point(ciP.X, ciP.Y + azukiControl.LineHeight));
                frmSien.Location = new Point(r.X, r.Y);
                frmSien.Opacity = 1.0;
                frmSien.update();
                frmSien.dgvItem.Rows[0].Selected = false;
                frmSien.selRow = -1;
            }
            else
            {
                frmSien.Opacity = 0.0;
            }
        }

        private void AzukiControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.DockState== DockState.Float)
            {
                main.FrmMain_KeyDown(sender, e);
            }

            if (frmSien.Opacity == 0.0)
            {
                e.SuppressKeyPress = false;
                return;
            }
            e.SuppressKeyPress = true;
            
            switch (e.KeyCode)
            {
                case Keys.Down:
                    if (frmSien.selRow < 0) frmSien.selRow = -1;
                    if (frmSien.dgvItem.Rows.Count - 1 > frmSien.selRow) frmSien.selRow++;
                    frmSien.dgvItem.Rows[frmSien.selRow].Selected = true;
                    frmSien.dgvItem.FirstDisplayedScrollingRowIndex = Math.Max(frmSien.selRow, 0);
                    break;
                case Keys.Up:
                    if (frmSien.dgvItem.Rows.Count > -1) frmSien.selRow--;
                    if (frmSien.selRow < 0)
                        frmSien.Opacity = 0.0;
                    else
                    {
                        frmSien.dgvItem.Rows[frmSien.selRow].Selected = true;
                        frmSien.dgvItem.FirstDisplayedScrollingRowIndex = Math.Max(frmSien.selRow, 0);
                    }
                    break;
                case Keys.Enter:
                case Keys.Tab:
                    frmSien.Opacity = 0.0;
                    if (frmSien.dgvItem.SelectedRows.Count == 1)
                    {
                        int ci = azukiControl.CaretIndex;
                        SienItem si = (SienItem)frmSien.dgvItem.Rows[frmSien.dgvItem.SelectedRows[0].Index].Tag;
                        azukiControl.Document.Replace(
                            si.content,
                            ci - si.foundCnt,
                            ci);

                        azukiControl.SetSelection(ci - si.foundCnt + si.nextAnchor, ci - si.foundCnt + si.nextCaret);
                    }
                    break;
                case Keys.Right:
                case Keys.Left:
                case Keys.Home:
                case Keys.End:
                case Keys.Escape:
                    frmSien.Opacity = 0.0;
                    break;
                default:
                    e.SuppressKeyPress = false;
                    break;
            }
        }

        private void AzukiControl_CancelSien(object sender, EventArgs e)
        {
            if (frmSien == null) return;
            frmSien.Opacity = 0.0;
        }

        private void FrmEditor_Shown(object sender, EventArgs e)
        {
            AzukiControl_CaretMoved(null, null);
        }

        private void FrmEditor_Activated(object sender, EventArgs e)
        {
            if (main != null) main.activeDocument = this;
        }

        private void FrmEditor_Deactivate(object sender, EventArgs e)
        {
            if (main != null && main.activeDocument==this) main.activeDocument = null;
        }
    }
}
