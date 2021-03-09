﻿namespace mml2vgmIDE
{
    partial class FrmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSetting));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbWaveOut = new System.Windows.Forms.GroupBox();
            this.cmbWaveOutDevice = new System.Windows.Forms.ComboBox();
            this.rbWaveOut = new System.Windows.Forms.RadioButton();
            this.rbAsioOut = new System.Windows.Forms.RadioButton();
            this.rbWasapiOut = new System.Windows.Forms.RadioButton();
            this.gbAsioOut = new System.Windows.Forms.GroupBox();
            this.btnASIOControlPanel = new System.Windows.Forms.Button();
            this.cmbAsioDevice = new System.Windows.Forms.ComboBox();
            this.rbDirectSoundOut = new System.Windows.Forms.RadioButton();
            this.gbWasapiOut = new System.Windows.Forms.GroupBox();
            this.rbExclusive = new System.Windows.Forms.RadioButton();
            this.rbShare = new System.Windows.Forms.RadioButton();
            this.cmbWasapiDevice = new System.Windows.Forms.ComboBox();
            this.gbDirectSound = new System.Windows.Forms.GroupBox();
            this.cmbDirectSoundDevice = new System.Windows.Forms.ComboBox();
            this.tcSetting = new System.Windows.Forms.TabControl();
            this.tpOutput = new System.Windows.Forms.TabPage();
            this.cbUseRealChip = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage11 = new System.Windows.Forms.TabPage();
            this.rbSPPCM = new System.Windows.Forms.RadioButton();
            this.rbNullDevice = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbLatencyEmu = new System.Windows.Forms.TextBox();
            this.tbLatencySCCI = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblWaitTime = new System.Windows.Forms.Label();
            this.lblLatencyUnit = new System.Windows.Forms.Label();
            this.groupBox16 = new System.Windows.Forms.GroupBox();
            this.cmbSPPCMDevice = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.lblLatency = new System.Windows.Forms.Label();
            this.cmbWaitTime = new System.Windows.Forms.ComboBox();
            this.cmbLatency = new System.Windows.Forms.ComboBox();
            this.tabPage12 = new System.Windows.Forms.TabPage();
            this.groupBox27 = new System.Windows.Forms.GroupBox();
            this.rbManualDetect = new System.Windows.Forms.RadioButton();
            this.rbAutoDetect = new System.Windows.Forms.RadioButton();
            this.groupBox28 = new System.Windows.Forms.GroupBox();
            this.rbSCCIDetect = new System.Windows.Forms.RadioButton();
            this.rbC86ctlDetect = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ucSI = new mml2vgmIDE.ucSettingInstruments();
            this.tabPage13 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvMIDIoutPallet = new System.Windows.Forms.DataGridView();
            this.clmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmDeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSpacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcMIDIoutList = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvMIDIoutListA = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmIsVST = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmFileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.ClmBeforeSend = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUP_A = new System.Windows.Forms.Button();
            this.btnDOWN_A = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvMIDIoutListB = new System.Windows.Forms.DataGridView();
            this.btnUP_B = new System.Windows.Forms.Button();
            this.btnDOWN_B = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvMIDIoutListC = new System.Windows.Forms.DataGridView();
            this.btnUP_C = new System.Windows.Forms.Button();
            this.btnDOWN_C = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgvMIDIoutListD = new System.Windows.Forms.DataGridView();
            this.btnUP_D = new System.Windows.Forms.Button();
            this.btnDOWN_D = new System.Windows.Forms.Button();
            this.btnAddVST = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.btnAddMIDIout = new System.Windows.Forms.Button();
            this.btnSubMIDIout = new System.Windows.Forms.Button();
            this.tpNuked = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage14 = new System.Windows.Forms.TabPage();
            this.groupBox26 = new System.Windows.Forms.GroupBox();
            this.rbNukedOPN2OptionYM2612u = new System.Windows.Forms.RadioButton();
            this.rbNukedOPN2OptionYM2612 = new System.Windows.Forms.RadioButton();
            this.rbNukedOPN2OptionDiscrete = new System.Windows.Forms.RadioButton();
            this.rbNukedOPN2OptionASIClp = new System.Windows.Forms.RadioButton();
            this.rbNukedOPN2OptionASIC = new System.Windows.Forms.RadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox34 = new System.Windows.Forms.GroupBox();
            this.cbGensSSGEG = new System.Windows.Forms.CheckBox();
            this.cbGensDACHPF = new System.Windows.Forms.CheckBox();
            this.tpNSF = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage15 = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.cbNFSNes_DutySwap = new System.Windows.Forms.CheckBox();
            this.cbNFSNes_PhaseRefresh = new System.Windows.Forms.CheckBox();
            this.cbNFSNes_NonLinearMixer = new System.Windows.Forms.CheckBox();
            this.cbNFSNes_UnmuteOnReset = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.cbNSFDmc_TriNull = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_TriMute = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_RandomizeNoise = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_DPCMAntiClick = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_EnablePNoise = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_Enable4011 = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_NonLinearMixer = new System.Windows.Forms.CheckBox();
            this.cbNSFDmc_UnmuteOnReset = new System.Windows.Forms.CheckBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tbNSFFds_LPF = new System.Windows.Forms.TextBox();
            this.cbNFSFds_4085Reset = new System.Windows.Forms.CheckBox();
            this.cbNSFFDSWriteDisable8000 = new System.Windows.Forms.CheckBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.cbNSFN160_Serial = new System.Windows.Forms.CheckBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cbNSFMmc5_PhaseRefresh = new System.Windows.Forms.CheckBox();
            this.cbNSFMmc5_NonLinearMixer = new System.Windows.Forms.CheckBox();
            this.tabPage16 = new System.Windows.Forms.TabPage();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.rdSIDQ1 = new System.Windows.Forms.RadioButton();
            this.rdSIDQ3 = new System.Windows.Forms.RadioButton();
            this.rdSIDQ2 = new System.Windows.Forms.RadioButton();
            this.rdSIDQ4 = new System.Windows.Forms.RadioButton();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.btnSIDBasic = new System.Windows.Forms.Button();
            this.btnSIDCharacter = new System.Windows.Forms.Button();
            this.btnSIDKernal = new System.Windows.Forms.Button();
            this.tbSIDCharacter = new System.Windows.Forms.TextBox();
            this.tbSIDBasic = new System.Windows.Forms.TextBox();
            this.tbSIDKernal = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tbSIDOutputBufferSize = new System.Windows.Forms.TextBox();
            this.tabPage17 = new System.Windows.Forms.TabPage();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.btnBeforeSend_Default = new System.Windows.Forms.Button();
            this.tbBeforeSend_Custom = new System.Windows.Forms.TextBox();
            this.tbBeforeSend_XGReset = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tbBeforeSend_GSReset = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tbBeforeSend_GMReset = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tpPMDDotNET = new System.Windows.Forms.TabPage();
            this.rbPMDManual = new System.Windows.Forms.RadioButton();
            this.rbPMDAuto = new System.Windows.Forms.RadioButton();
            this.btnPMDResetDriverArguments = new System.Windows.Forms.Button();
            this.label47 = new System.Windows.Forms.Label();
            this.btnPMDResetCompilerArhguments = new System.Windows.Forms.Button();
            this.tbPMDDriverArguments = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbPMDCompilerArguments = new System.Windows.Forms.TextBox();
            this.gbPMDManual = new System.Windows.Forms.GroupBox();
            this.cbPMDSetManualVolume = new System.Windows.Forms.CheckBox();
            this.cbPMDUsePPZ8 = new System.Windows.Forms.CheckBox();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.rbPMD86B = new System.Windows.Forms.RadioButton();
            this.rbPMDSpbB = new System.Windows.Forms.RadioButton();
            this.rbPMDNrmB = new System.Windows.Forms.RadioButton();
            this.cbPMDUsePPSDRV = new System.Windows.Forms.CheckBox();
            this.gbPPSDRV = new System.Windows.Forms.GroupBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.rbPMDUsePPSDRVManualFreq = new System.Windows.Forms.RadioButton();
            this.label38 = new System.Windows.Forms.Label();
            this.rbPMDUsePPSDRVFreqDefault = new System.Windows.Forms.RadioButton();
            this.btnPMDPPSDRVManualWait = new System.Windows.Forms.Button();
            this.label40 = new System.Windows.Forms.Label();
            this.tbPMDPPSDRVFreq = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbPMDPPSDRVManualWait = new System.Windows.Forms.TextBox();
            this.gbPMDSetManualVolume = new System.Windows.Forms.GroupBox();
            this.label41 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.tbPMDVolumeAdpcm = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tbPMDVolumeRhythm = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tbPMDVolumeSSG = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tbPMDVolumeGIMICSSG = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.tbPMDVolumeFM = new System.Windows.Forms.TextBox();
            this.tpMIDIExp = new System.Windows.Forms.TabPage();
            this.cbUseMIDIExport = new System.Windows.Forms.CheckBox();
            this.gbMIDIExport = new System.Windows.Forms.GroupBox();
            this.cbMIDIKeyOnFnum = new System.Windows.Forms.CheckBox();
            this.cbMIDIUseVOPM = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbMIDIYM2612 = new System.Windows.Forms.CheckBox();
            this.cbMIDISN76489Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2612Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDISN76489 = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2151 = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2610BSec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2151Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2610B = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2203 = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2608Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2203Sec = new System.Windows.Forms.CheckBox();
            this.cbMIDIYM2608 = new System.Windows.Forms.CheckBox();
            this.cbMIDIPlayless = new System.Windows.Forms.CheckBox();
            this.btnMIDIOutputPath = new System.Windows.Forms.Button();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.tbMIDIOutputPath = new System.Windows.Forms.TextBox();
            this.tpMIDIKBD = new System.Windows.Forms.TabPage();
            this.cbMIDIKbdAlwaysTop = new System.Windows.Forms.CheckBox();
            this.cbUseMIDIKeyboard = new System.Windows.Forms.CheckBox();
            this.gbMIDIKeyboard = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbCCFadeout = new System.Windows.Forms.TextBox();
            this.tbCCPause = new System.Windows.Forms.TextBox();
            this.tbCCSlow = new System.Windows.Forms.TextBox();
            this.tbCCPrevious = new System.Windows.Forms.TextBox();
            this.tbCCNext = new System.Windows.Forms.TextBox();
            this.tbCCFast = new System.Windows.Forms.TextBox();
            this.tbCCStop = new System.Windows.Forms.TextBox();
            this.tbCCPlay = new System.Windows.Forms.TextBox();
            this.tbCCCopyLog = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbCCDelLog = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbCCChCopy = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gbUseChannel = new System.Windows.Forms.GroupBox();
            this.rbMONO = new System.Windows.Forms.RadioButton();
            this.rbPOLY = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbFM6 = new System.Windows.Forms.RadioButton();
            this.rbFM3 = new System.Windows.Forms.RadioButton();
            this.rbFM5 = new System.Windows.Forms.RadioButton();
            this.rbFM2 = new System.Windows.Forms.RadioButton();
            this.rbFM4 = new System.Windows.Forms.RadioButton();
            this.rbFM1 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFM1 = new System.Windows.Forms.CheckBox();
            this.cbFM6 = new System.Windows.Forms.CheckBox();
            this.cbFM2 = new System.Windows.Forms.CheckBox();
            this.cbFM5 = new System.Windows.Forms.CheckBox();
            this.cbFM3 = new System.Windows.Forms.CheckBox();
            this.cbFM4 = new System.Windows.Forms.CheckBox();
            this.cmbMIDIIN = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tpKeyBoard = new System.Windows.Forms.TabPage();
            this.btnInitializeShortCutKey = new System.Windows.Forms.Button();
            this.lblSKKey = new System.Windows.Forms.Label();
            this.dgvShortCutKey = new System.Windows.Forms.DataGridView();
            this.clmNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFunc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmShift = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmCtrl = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmAlt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmSet = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmClr = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clmKBDSpacer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpBalance = new System.Windows.Forms.TabPage();
            this.groupBox25 = new System.Windows.Forms.GroupBox();
            this.rbAutoBalanceNotSamePositionAsSongData = new System.Windows.Forms.RadioButton();
            this.rbAutoBalanceSamePositionAsSongData = new System.Windows.Forms.RadioButton();
            this.cbAutoBalanceUseThis = new System.Windows.Forms.CheckBox();
            this.groupBox18 = new System.Windows.Forms.GroupBox();
            this.groupBox24 = new System.Windows.Forms.GroupBox();
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.rbAutoBalanceNotSaveSongBalance = new System.Windows.Forms.RadioButton();
            this.rbAutoBalanceSaveSongBalance = new System.Windows.Forms.RadioButton();
            this.groupBox22 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.groupBox19 = new System.Windows.Forms.GroupBox();
            this.rbAutoBalanceNotLoadSongBalance = new System.Windows.Forms.RadioButton();
            this.rbAutoBalanceLoadSongBalance = new System.Windows.Forms.RadioButton();
            this.groupBox20 = new System.Windows.Forms.GroupBox();
            this.rbAutoBalanceNotLoadDriverBalance = new System.Windows.Forms.RadioButton();
            this.rbAutoBalanceLoadDriverBalance = new System.Windows.Forms.RadioButton();
            this.tpOther = new System.Windows.Forms.TabPage();
            this.cbWavSwitch = new System.Windows.Forms.CheckBox();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.tbImageExt = new System.Windows.Forms.TextBox();
            this.tbMMLExt = new System.Windows.Forms.TextBox();
            this.tbTextExt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUseGetInst = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cmbInstFormat = new System.Windows.Forms.ComboBox();
            this.lblInstFormat = new System.Windows.Forms.Label();
            this.cbDumpSwitch = new System.Windows.Forms.CheckBox();
            this.gbWav = new System.Windows.Forms.GroupBox();
            this.btnWavPath = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbWavPath = new System.Windows.Forms.TextBox();
            this.gbDump = new System.Windows.Forms.GroupBox();
            this.btnDumpPath = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDumpPath = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.tbScreenFrameRate = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.lblLoopTimes = new System.Windows.Forms.Label();
            this.btnDataPath = new System.Windows.Forms.Button();
            this.tbLoopTimes = new System.Windows.Forms.TextBox();
            this.tbDataPath = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnResetPosition = new System.Windows.Forms.Button();
            this.btnOpenSettingFolder = new System.Windows.Forms.Button();
            this.cbEmptyPlayList = new System.Windows.Forms.CheckBox();
            this.cbInitAlways = new System.Windows.Forms.CheckBox();
            this.cbAutoOpen = new System.Windows.Forms.CheckBox();
            this.cbUseLoopTimes = new System.Windows.Forms.CheckBox();
            this.tpOmake = new System.Windows.Forms.TabPage();
            this.cbClearHistory = new System.Windows.Forms.CheckBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.rbLoglevelINFO = new System.Windows.Forms.RadioButton();
            this.rbLoglevelDEBUG = new System.Windows.Forms.RadioButton();
            this.rbLoglevelTRACE = new System.Windows.Forms.RadioButton();
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.rbQueryPerformanceCounter = new System.Windows.Forms.RadioButton();
            this.rbDateTime = new System.Windows.Forms.RadioButton();
            this.rbStopWatch = new System.Windows.Forms.RadioButton();
            this.cbRequestCacheClear = new System.Windows.Forms.CheckBox();
            this.cbUseSIen = new System.Windows.Forms.CheckBox();
            this.cbInfiniteOfflineMode = new System.Windows.Forms.CheckBox();
            this.groupBox29 = new System.Windows.Forms.GroupBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btFont = new System.Windows.Forms.Button();
            this.label54 = new System.Windows.Forms.Label();
            this.lblFontName = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.lblFontSize = new System.Windows.Forms.Label();
            this.lblFontStyle = new System.Windows.Forms.Label();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.label52 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btVST = new System.Windows.Forms.Button();
            this.tbVST = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbSinWave = new System.Windows.Forms.CheckBox();
            this.cbPlayDeviceCB = new System.Windows.Forms.CheckBox();
            this.cbLogWarning = new System.Windows.Forms.CheckBox();
            this.cbDispFrameCounter = new System.Windows.Forms.CheckBox();
            this.tpAbout = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.labelProductName = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompanyName = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.llOpenGithub = new System.Windows.Forms.LinkLabel();
            this.cbHiyorimiMode = new System.Windows.Forms.CheckBox();
            this.tpMMLParameter = new System.Windows.Forms.TabPage();
            this.cbDispInstrumentName = new System.Windows.Forms.CheckBox();
            this.gbWaveOut.SuspendLayout();
            this.gbAsioOut.SuspendLayout();
            this.gbWasapiOut.SuspendLayout();
            this.gbDirectSound.SuspendLayout();
            this.tcSetting.SuspendLayout();
            this.tpOutput.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage11.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox16.SuspendLayout();
            this.tabPage12.SuspendLayout();
            this.groupBox27.SuspendLayout();
            this.groupBox28.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutPallet)).BeginInit();
            this.tbcMIDIoutList.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListA)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListB)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListC)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListD)).BeginInit();
            this.tpNuked.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage14.SuspendLayout();
            this.groupBox26.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox34.SuspendLayout();
            this.tpNSF.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage15.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.tabPage16.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.tabPage17.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.tpPMDDotNET.SuspendLayout();
            this.gbPMDManual.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.gbPPSDRV.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.gbPMDSetManualVolume.SuspendLayout();
            this.tpMIDIExp.SuspendLayout();
            this.gbMIDIExport.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tpMIDIKBD.SuspendLayout();
            this.gbMIDIKeyboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbUseChannel.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tpKeyBoard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortCutKey)).BeginInit();
            this.tpBalance.SuspendLayout();
            this.groupBox25.SuspendLayout();
            this.groupBox18.SuspendLayout();
            this.groupBox24.SuspendLayout();
            this.groupBox21.SuspendLayout();
            this.groupBox22.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox19.SuspendLayout();
            this.groupBox20.SuspendLayout();
            this.tpOther.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbWav.SuspendLayout();
            this.gbDump.SuspendLayout();
            this.tpOmake.SuspendLayout();
            this.groupBox31.SuspendLayout();
            this.groupBox30.SuspendLayout();
            this.groupBox29.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.tpAbout.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.tpMMLParameter.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(296, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(377, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "キャンセル";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // gbWaveOut
            // 
            this.gbWaveOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWaveOut.Controls.Add(this.cmbWaveOutDevice);
            this.gbWaveOut.Location = new System.Drawing.Point(6, 10);
            this.gbWaveOut.Name = "gbWaveOut";
            this.gbWaveOut.Size = new System.Drawing.Size(416, 48);
            this.gbWaveOut.TabIndex = 1;
            this.gbWaveOut.TabStop = false;
            // 
            // cmbWaveOutDevice
            // 
            this.cmbWaveOutDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWaveOutDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaveOutDevice.FormattingEnabled = true;
            this.cmbWaveOutDevice.Location = new System.Drawing.Point(6, 18);
            this.cmbWaveOutDevice.Name = "cmbWaveOutDevice";
            this.cmbWaveOutDevice.Size = new System.Drawing.Size(405, 20);
            this.cmbWaveOutDevice.TabIndex = 0;
            // 
            // rbWaveOut
            // 
            this.rbWaveOut.AutoSize = true;
            this.rbWaveOut.Checked = true;
            this.rbWaveOut.Location = new System.Drawing.Point(12, 6);
            this.rbWaveOut.Name = "rbWaveOut";
            this.rbWaveOut.Size = new System.Drawing.Size(68, 16);
            this.rbWaveOut.TabIndex = 0;
            this.rbWaveOut.TabStop = true;
            this.rbWaveOut.Text = "WaveOut";
            this.rbWaveOut.UseVisualStyleBackColor = true;
            this.rbWaveOut.CheckedChanged += new System.EventHandler(this.rbWaveOut_CheckedChanged);
            // 
            // rbAsioOut
            // 
            this.rbAsioOut.AutoSize = true;
            this.rbAsioOut.Location = new System.Drawing.Point(12, 174);
            this.rbAsioOut.Name = "rbAsioOut";
            this.rbAsioOut.Size = new System.Drawing.Size(64, 16);
            this.rbAsioOut.TabIndex = 6;
            this.rbAsioOut.Text = "AsioOut";
            this.rbAsioOut.UseVisualStyleBackColor = true;
            this.rbAsioOut.CheckedChanged += new System.EventHandler(this.rbAsioOut_CheckedChanged);
            // 
            // rbWasapiOut
            // 
            this.rbWasapiOut.AutoSize = true;
            this.rbWasapiOut.Location = new System.Drawing.Point(12, 117);
            this.rbWasapiOut.Name = "rbWasapiOut";
            this.rbWasapiOut.Size = new System.Drawing.Size(77, 16);
            this.rbWasapiOut.TabIndex = 4;
            this.rbWasapiOut.Text = "WasapiOut";
            this.rbWasapiOut.UseVisualStyleBackColor = true;
            this.rbWasapiOut.CheckedChanged += new System.EventHandler(this.rbWasapiOut_CheckedChanged);
            // 
            // gbAsioOut
            // 
            this.gbAsioOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAsioOut.Controls.Add(this.btnASIOControlPanel);
            this.gbAsioOut.Controls.Add(this.cmbAsioDevice);
            this.gbAsioOut.Location = new System.Drawing.Point(6, 177);
            this.gbAsioOut.Name = "gbAsioOut";
            this.gbAsioOut.Size = new System.Drawing.Size(416, 50);
            this.gbAsioOut.TabIndex = 7;
            this.gbAsioOut.TabStop = false;
            // 
            // btnASIOControlPanel
            // 
            this.btnASIOControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnASIOControlPanel.Location = new System.Drawing.Point(330, 8);
            this.btnASIOControlPanel.Name = "btnASIOControlPanel";
            this.btnASIOControlPanel.Size = new System.Drawing.Size(81, 39);
            this.btnASIOControlPanel.TabIndex = 8;
            this.btnASIOControlPanel.Text = "ASIO Control Panel";
            this.btnASIOControlPanel.UseVisualStyleBackColor = true;
            this.btnASIOControlPanel.Click += new System.EventHandler(this.btnASIOControlPanel_Click);
            // 
            // cmbAsioDevice
            // 
            this.cmbAsioDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAsioDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAsioDevice.FormattingEnabled = true;
            this.cmbAsioDevice.Location = new System.Drawing.Point(6, 18);
            this.cmbAsioDevice.Name = "cmbAsioDevice";
            this.cmbAsioDevice.Size = new System.Drawing.Size(317, 20);
            this.cmbAsioDevice.TabIndex = 6;
            // 
            // rbDirectSoundOut
            // 
            this.rbDirectSoundOut.AutoSize = true;
            this.rbDirectSoundOut.Location = new System.Drawing.Point(12, 62);
            this.rbDirectSoundOut.Name = "rbDirectSoundOut";
            this.rbDirectSoundOut.Size = new System.Drawing.Size(85, 16);
            this.rbDirectSoundOut.TabIndex = 2;
            this.rbDirectSoundOut.Text = "DirectSound";
            this.rbDirectSoundOut.UseVisualStyleBackColor = true;
            this.rbDirectSoundOut.CheckedChanged += new System.EventHandler(this.rbDirectSoundOut_CheckedChanged);
            // 
            // gbWasapiOut
            // 
            this.gbWasapiOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWasapiOut.Controls.Add(this.rbExclusive);
            this.gbWasapiOut.Controls.Add(this.rbShare);
            this.gbWasapiOut.Controls.Add(this.cmbWasapiDevice);
            this.gbWasapiOut.Location = new System.Drawing.Point(6, 121);
            this.gbWasapiOut.Name = "gbWasapiOut";
            this.gbWasapiOut.Size = new System.Drawing.Size(416, 50);
            this.gbWasapiOut.TabIndex = 5;
            this.gbWasapiOut.TabStop = false;
            // 
            // rbExclusive
            // 
            this.rbExclusive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbExclusive.AutoSize = true;
            this.rbExclusive.Location = new System.Drawing.Point(330, 31);
            this.rbExclusive.Name = "rbExclusive";
            this.rbExclusive.Size = new System.Drawing.Size(47, 16);
            this.rbExclusive.TabIndex = 7;
            this.rbExclusive.TabStop = true;
            this.rbExclusive.Text = "排他";
            this.rbExclusive.UseVisualStyleBackColor = true;
            // 
            // rbShare
            // 
            this.rbShare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbShare.AutoSize = true;
            this.rbShare.Location = new System.Drawing.Point(330, 9);
            this.rbShare.Name = "rbShare";
            this.rbShare.Size = new System.Drawing.Size(47, 16);
            this.rbShare.TabIndex = 6;
            this.rbShare.TabStop = true;
            this.rbShare.Text = "共有";
            this.rbShare.UseVisualStyleBackColor = true;
            // 
            // cmbWasapiDevice
            // 
            this.cmbWasapiDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWasapiDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWasapiDevice.FormattingEnabled = true;
            this.cmbWasapiDevice.Location = new System.Drawing.Point(6, 18);
            this.cmbWasapiDevice.Name = "cmbWasapiDevice";
            this.cmbWasapiDevice.Size = new System.Drawing.Size(317, 20);
            this.cmbWasapiDevice.TabIndex = 4;
            // 
            // gbDirectSound
            // 
            this.gbDirectSound.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDirectSound.Controls.Add(this.cmbDirectSoundDevice);
            this.gbDirectSound.Location = new System.Drawing.Point(6, 66);
            this.gbDirectSound.Name = "gbDirectSound";
            this.gbDirectSound.Size = new System.Drawing.Size(416, 48);
            this.gbDirectSound.TabIndex = 3;
            this.gbDirectSound.TabStop = false;
            // 
            // cmbDirectSoundDevice
            // 
            this.cmbDirectSoundDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDirectSoundDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirectSoundDevice.FormattingEnabled = true;
            this.cmbDirectSoundDevice.Location = new System.Drawing.Point(6, 18);
            this.cmbDirectSoundDevice.Name = "cmbDirectSoundDevice";
            this.cmbDirectSoundDevice.Size = new System.Drawing.Size(405, 20);
            this.cmbDirectSoundDevice.TabIndex = 2;
            // 
            // tcSetting
            // 
            this.tcSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcSetting.Controls.Add(this.tpOutput);
            this.tcSetting.Controls.Add(this.tpNuked);
            this.tcSetting.Controls.Add(this.tpNSF);
            this.tcSetting.Controls.Add(this.tpPMDDotNET);
            this.tcSetting.Controls.Add(this.tpMIDIExp);
            this.tcSetting.Controls.Add(this.tpMIDIKBD);
            this.tcSetting.Controls.Add(this.tpKeyBoard);
            this.tcSetting.Controls.Add(this.tpBalance);
            this.tcSetting.Controls.Add(this.tpMMLParameter);
            this.tcSetting.Controls.Add(this.tpOther);
            this.tcSetting.Controls.Add(this.tpOmake);
            this.tcSetting.Controls.Add(this.tpAbout);
            this.tcSetting.HotTrack = true;
            this.tcSetting.Location = new System.Drawing.Point(1, 3);
            this.tcSetting.Name = "tcSetting";
            this.tcSetting.SelectedIndex = 0;
            this.tcSetting.Size = new System.Drawing.Size(451, 426);
            this.tcSetting.TabIndex = 2;
            // 
            // tpOutput
            // 
            this.tpOutput.Controls.Add(this.cbUseRealChip);
            this.tpOutput.Controls.Add(this.tabControl1);
            this.tpOutput.Location = new System.Drawing.Point(4, 22);
            this.tpOutput.Name = "tpOutput";
            this.tpOutput.Padding = new System.Windows.Forms.Padding(3);
            this.tpOutput.Size = new System.Drawing.Size(443, 400);
            this.tpOutput.TabIndex = 0;
            this.tpOutput.Text = "出力";
            this.tpOutput.UseVisualStyleBackColor = true;
            // 
            // cbUseRealChip
            // 
            this.cbUseRealChip.AutoSize = true;
            this.cbUseRealChip.Location = new System.Drawing.Point(6, 6);
            this.cbUseRealChip.Name = "cbUseRealChip";
            this.cbUseRealChip.Size = new System.Drawing.Size(249, 16);
            this.cbUseRealChip.TabIndex = 8;
            this.cbUseRealChip.Text = "C86ctl/SCCIを使用しない(再起動が必要です)";
            this.cbUseRealChip.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage11);
            this.tabControl1.Controls.Add(this.tabPage12);
            this.tabControl1.Controls.Add(this.tabPage13);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(3, 30);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 367);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage11
            // 
            this.tabPage11.Controls.Add(this.rbWasapiOut);
            this.tabPage11.Controls.Add(this.rbSPPCM);
            this.tabPage11.Controls.Add(this.rbDirectSoundOut);
            this.tabPage11.Controls.Add(this.rbAsioOut);
            this.tabPage11.Controls.Add(this.rbWaveOut);
            this.tabPage11.Controls.Add(this.rbNullDevice);
            this.tabPage11.Controls.Add(this.groupBox3);
            this.tabPage11.Controls.Add(this.gbWasapiOut);
            this.tabPage11.Controls.Add(this.gbDirectSound);
            this.tabPage11.Controls.Add(this.lblWaitTime);
            this.tabPage11.Controls.Add(this.gbAsioOut);
            this.tabPage11.Controls.Add(this.lblLatencyUnit);
            this.tabPage11.Controls.Add(this.groupBox16);
            this.tabPage11.Controls.Add(this.label28);
            this.tabPage11.Controls.Add(this.lblLatency);
            this.tabPage11.Controls.Add(this.cmbWaitTime);
            this.tabPage11.Controls.Add(this.cmbLatency);
            this.tabPage11.Controls.Add(this.gbWaveOut);
            this.tabPage11.Location = new System.Drawing.Point(4, 22);
            this.tabPage11.Name = "tabPage11";
            this.tabPage11.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage11.Size = new System.Drawing.Size(429, 341);
            this.tabPage11.TabIndex = 0;
            this.tabPage11.Text = "Emulation";
            this.tabPage11.UseVisualStyleBackColor = true;
            // 
            // rbSPPCM
            // 
            this.rbSPPCM.AutoSize = true;
            this.rbSPPCM.Enabled = false;
            this.rbSPPCM.Location = new System.Drawing.Point(12, 230);
            this.rbSPPCM.Name = "rbSPPCM";
            this.rbSPPCM.Size = new System.Drawing.Size(61, 16);
            this.rbSPPCM.TabIndex = 2;
            this.rbSPPCM.Text = "SPPCM";
            this.rbSPPCM.UseVisualStyleBackColor = true;
            this.rbSPPCM.CheckedChanged += new System.EventHandler(this.rbDirectSoundOut_CheckedChanged);
            // 
            // rbNullDevice
            // 
            this.rbNullDevice.Location = new System.Drawing.Point(225, 243);
            this.rbNullDevice.Name = "rbNullDevice";
            this.rbNullDevice.Size = new System.Drawing.Size(158, 29);
            this.rbNullDevice.TabIndex = 2;
            this.rbNullDevice.Text = "NULL(サウンドデバイスを使用しない)";
            this.rbNullDevice.UseVisualStyleBackColor = true;
            this.rbNullDevice.CheckedChanged += new System.EventHandler(this.rbDirectSoundOut_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tbLatencyEmu);
            this.groupBox3.Controls.Add(this.tbLatencySCCI);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(258, 272);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 62);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "遅延演奏";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "EMU";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "Real";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(132, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 12);
            this.label11.TabIndex = 5;
            this.label11.Text = "ms";
            // 
            // tbLatencyEmu
            // 
            this.tbLatencyEmu.Location = new System.Drawing.Point(41, 15);
            this.tbLatencyEmu.Name = "tbLatencyEmu";
            this.tbLatencyEmu.Size = new System.Drawing.Size(85, 19);
            this.tbLatencyEmu.TabIndex = 1;
            // 
            // tbLatencySCCI
            // 
            this.tbLatencySCCI.Location = new System.Drawing.Point(41, 37);
            this.tbLatencySCCI.Name = "tbLatencySCCI";
            this.tbLatencySCCI.Size = new System.Drawing.Size(85, 19);
            this.tbLatencySCCI.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "ms";
            // 
            // lblWaitTime
            // 
            this.lblWaitTime.AutoSize = true;
            this.lblWaitTime.Location = new System.Drawing.Point(234, 316);
            this.lblWaitTime.Name = "lblWaitTime";
            this.lblWaitTime.Size = new System.Drawing.Size(20, 12);
            this.lblWaitTime.TabIndex = 9;
            this.lblWaitTime.Text = "ms";
            // 
            // lblLatencyUnit
            // 
            this.lblLatencyUnit.AutoSize = true;
            this.lblLatencyUnit.Location = new System.Drawing.Point(234, 290);
            this.lblLatencyUnit.Name = "lblLatencyUnit";
            this.lblLatencyUnit.Size = new System.Drawing.Size(20, 12);
            this.lblLatencyUnit.TabIndex = 9;
            this.lblLatencyUnit.Text = "ms";
            // 
            // groupBox16
            // 
            this.groupBox16.Controls.Add(this.cmbSPPCMDevice);
            this.groupBox16.Enabled = false;
            this.groupBox16.Location = new System.Drawing.Point(6, 233);
            this.groupBox16.Name = "groupBox16";
            this.groupBox16.Size = new System.Drawing.Size(213, 48);
            this.groupBox16.TabIndex = 3;
            this.groupBox16.TabStop = false;
            // 
            // cmbSPPCMDevice
            // 
            this.cmbSPPCMDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSPPCMDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSPPCMDevice.FormattingEnabled = true;
            this.cmbSPPCMDevice.Location = new System.Drawing.Point(6, 19);
            this.cmbSPPCMDevice.Name = "cmbSPPCMDevice";
            this.cmbSPPCMDevice.Size = new System.Drawing.Size(201, 20);
            this.cmbSPPCMDevice.TabIndex = 2;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(6, 316);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(98, 12);
            this.label28.TabIndex = 9;
            this.label28.Text = "演奏開始待ち時間";
            // 
            // lblLatency
            // 
            this.lblLatency.AutoSize = true;
            this.lblLatency.Location = new System.Drawing.Point(5, 283);
            this.lblLatency.Name = "lblLatency";
            this.lblLatency.Size = new System.Drawing.Size(97, 24);
            this.lblLatency.TabIndex = 9;
            this.lblLatency.Text = "遅延時間\r\n(レンダリングバッファ)";
            // 
            // cmbWaitTime
            // 
            this.cmbWaitTime.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWaitTime.FormattingEnabled = true;
            this.cmbWaitTime.Items.AddRange(new object[] {
            "0",
            "500",
            "1000",
            "1500",
            "2000",
            "2500",
            "3000",
            "3500",
            "4000",
            "4500",
            "5000"});
            this.cmbWaitTime.Location = new System.Drawing.Point(107, 313);
            this.cmbWaitTime.Name = "cmbWaitTime";
            this.cmbWaitTime.Size = new System.Drawing.Size(121, 20);
            this.cmbWaitTime.TabIndex = 8;
            // 
            // cmbLatency
            // 
            this.cmbLatency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLatency.FormattingEnabled = true;
            this.cmbLatency.Items.AddRange(new object[] {
            "25",
            "50",
            "100",
            "150",
            "200",
            "300",
            "400",
            "500"});
            this.cmbLatency.Location = new System.Drawing.Point(107, 287);
            this.cmbLatency.Name = "cmbLatency";
            this.cmbLatency.Size = new System.Drawing.Size(121, 20);
            this.cmbLatency.TabIndex = 8;
            // 
            // tabPage12
            // 
            this.tabPage12.Controls.Add(this.groupBox27);
            this.tabPage12.Location = new System.Drawing.Point(4, 22);
            this.tabPage12.Name = "tabPage12";
            this.tabPage12.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage12.Size = new System.Drawing.Size(429, 341);
            this.tabPage12.TabIndex = 1;
            this.tabPage12.Text = "音源割り当て";
            this.tabPage12.UseVisualStyleBackColor = true;
            // 
            // groupBox27
            // 
            this.groupBox27.Controls.Add(this.rbManualDetect);
            this.groupBox27.Controls.Add(this.rbAutoDetect);
            this.groupBox27.Controls.Add(this.groupBox28);
            this.groupBox27.Controls.Add(this.groupBox1);
            this.groupBox27.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox27.Location = new System.Drawing.Point(3, 3);
            this.groupBox27.Name = "groupBox27";
            this.groupBox27.Size = new System.Drawing.Size(423, 335);
            this.groupBox27.TabIndex = 9;
            this.groupBox27.TabStop = false;
            this.groupBox27.Text = "音源の割り当て";
            // 
            // rbManualDetect
            // 
            this.rbManualDetect.AutoSize = true;
            this.rbManualDetect.Location = new System.Drawing.Point(12, 71);
            this.rbManualDetect.Name = "rbManualDetect";
            this.rbManualDetect.Size = new System.Drawing.Size(47, 16);
            this.rbManualDetect.TabIndex = 10;
            this.rbManualDetect.Text = "手動";
            this.rbManualDetect.UseVisualStyleBackColor = true;
            // 
            // rbAutoDetect
            // 
            this.rbAutoDetect.AutoSize = true;
            this.rbAutoDetect.Checked = true;
            this.rbAutoDetect.Location = new System.Drawing.Point(12, 17);
            this.rbAutoDetect.Name = "rbAutoDetect";
            this.rbAutoDetect.Size = new System.Drawing.Size(47, 16);
            this.rbAutoDetect.TabIndex = 10;
            this.rbAutoDetect.TabStop = true;
            this.rbAutoDetect.Text = "自動";
            this.rbAutoDetect.UseVisualStyleBackColor = true;
            // 
            // groupBox28
            // 
            this.groupBox28.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox28.Controls.Add(this.rbSCCIDetect);
            this.groupBox28.Controls.Add(this.rbC86ctlDetect);
            this.groupBox28.Location = new System.Drawing.Point(6, 18);
            this.groupBox28.Name = "groupBox28";
            this.groupBox28.Size = new System.Drawing.Size(411, 46);
            this.groupBox28.TabIndex = 9;
            this.groupBox28.TabStop = false;
            // 
            // rbSCCIDetect
            // 
            this.rbSCCIDetect.AutoSize = true;
            this.rbSCCIDetect.Location = new System.Drawing.Point(212, 21);
            this.rbSCCIDetect.Name = "rbSCCIDetect";
            this.rbSCCIDetect.Size = new System.Drawing.Size(158, 16);
            this.rbSCCIDetect.TabIndex = 0;
            this.rbSCCIDetect.Text = "SCCIのモジュールを優先する";
            this.rbSCCIDetect.UseVisualStyleBackColor = true;
            // 
            // rbC86ctlDetect
            // 
            this.rbC86ctlDetect.AutoSize = true;
            this.rbC86ctlDetect.Checked = true;
            this.rbC86ctlDetect.Location = new System.Drawing.Point(21, 21);
            this.rbC86ctlDetect.Name = "rbC86ctlDetect";
            this.rbC86ctlDetect.Size = new System.Drawing.Size(165, 16);
            this.rbC86ctlDetect.TabIndex = 0;
            this.rbC86ctlDetect.TabStop = true;
            this.rbC86ctlDetect.Text = "C86ctlのモジュールを優先する";
            this.rbC86ctlDetect.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ucSI);
            this.groupBox1.Location = new System.Drawing.Point(6, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(411, 258);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // ucSI
            // 
            this.ucSI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucSI.AutoScroll = true;
            this.ucSI.Location = new System.Drawing.Point(3, 18);
            this.ucSI.Name = "ucSI";
            this.ucSI.Size = new System.Drawing.Size(405, 237);
            this.ucSI.TabIndex = 7;
            // 
            // tabPage13
            // 
            this.tabPage13.Controls.Add(this.splitContainer1);
            this.tabPage13.Location = new System.Drawing.Point(4, 22);
            this.tabPage13.Name = "tabPage13";
            this.tabPage13.Size = new System.Drawing.Size(429, 341);
            this.tabPage13.TabIndex = 2;
            this.tabPage13.Text = "MIDI";
            this.tabPage13.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.dgvMIDIoutPallet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbcMIDIoutList);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddVST);
            this.splitContainer1.Panel2.Controls.Add(this.label18);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddMIDIout);
            this.splitContainer1.Panel2.Controls.Add(this.btnSubMIDIout);
            this.splitContainer1.Size = new System.Drawing.Size(429, 341);
            this.splitContainer1.SplitterDistance = 136;
            this.splitContainer1.TabIndex = 6;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(3, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(126, 12);
            this.label16.TabIndex = 0;
            this.label16.Text = "MIDI Outデバイス パレット";
            // 
            // dgvMIDIoutPallet
            // 
            this.dgvMIDIoutPallet.AllowUserToAddRows = false;
            this.dgvMIDIoutPallet.AllowUserToDeleteRows = false;
            this.dgvMIDIoutPallet.AllowUserToResizeRows = false;
            this.dgvMIDIoutPallet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMIDIoutPallet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutPallet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmID,
            this.clmDeviceName,
            this.clmManufacturer,
            this.clmSpacer});
            this.dgvMIDIoutPallet.Location = new System.Drawing.Point(2, 15);
            this.dgvMIDIoutPallet.MultiSelect = false;
            this.dgvMIDIoutPallet.Name = "dgvMIDIoutPallet";
            this.dgvMIDIoutPallet.RowHeadersVisible = false;
            this.dgvMIDIoutPallet.RowTemplate.Height = 21;
            this.dgvMIDIoutPallet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutPallet.Size = new System.Drawing.Size(422, 118);
            this.dgvMIDIoutPallet.TabIndex = 1;
            // 
            // clmID
            // 
            this.clmID.Frozen = true;
            this.clmID.HeaderText = "ID";
            this.clmID.Name = "clmID";
            this.clmID.ReadOnly = true;
            this.clmID.Visible = false;
            this.clmID.Width = 40;
            // 
            // clmDeviceName
            // 
            this.clmDeviceName.Frozen = true;
            this.clmDeviceName.HeaderText = "Device Name";
            this.clmDeviceName.Name = "clmDeviceName";
            this.clmDeviceName.ReadOnly = true;
            this.clmDeviceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmDeviceName.Width = 200;
            // 
            // clmManufacturer
            // 
            this.clmManufacturer.Frozen = true;
            this.clmManufacturer.HeaderText = "Manufacturer";
            this.clmManufacturer.Name = "clmManufacturer";
            this.clmManufacturer.ReadOnly = true;
            this.clmManufacturer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // clmSpacer
            // 
            this.clmSpacer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmSpacer.HeaderText = "";
            this.clmSpacer.Name = "clmSpacer";
            this.clmSpacer.ReadOnly = true;
            this.clmSpacer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tbcMIDIoutList
            // 
            this.tbcMIDIoutList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcMIDIoutList.Controls.Add(this.tabPage1);
            this.tbcMIDIoutList.Controls.Add(this.tabPage2);
            this.tbcMIDIoutList.Controls.Add(this.tabPage3);
            this.tbcMIDIoutList.Controls.Add(this.tabPage4);
            this.tbcMIDIoutList.Location = new System.Drawing.Point(3, 31);
            this.tbcMIDIoutList.Name = "tbcMIDIoutList";
            this.tbcMIDIoutList.SelectedIndex = 0;
            this.tbcMIDIoutList.Size = new System.Drawing.Size(422, 167);
            this.tbcMIDIoutList.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvMIDIoutListA);
            this.tabPage1.Controls.Add(this.btnUP_A);
            this.tabPage1.Controls.Add(this.btnDOWN_A);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(414, 141);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "0";
            this.tabPage1.Text = "GM";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvMIDIoutListA
            // 
            this.dgvMIDIoutListA.AllowUserToAddRows = false;
            this.dgvMIDIoutListA.AllowUserToDeleteRows = false;
            this.dgvMIDIoutListA.AllowUserToResizeRows = false;
            this.dgvMIDIoutListA.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMIDIoutListA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutListA.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.clmIsVST,
            this.clmFileName,
            this.dataGridViewTextBoxColumn2,
            this.clmType,
            this.ClmBeforeSend,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dgvMIDIoutListA.Location = new System.Drawing.Point(0, 0);
            this.dgvMIDIoutListA.MultiSelect = false;
            this.dgvMIDIoutListA.Name = "dgvMIDIoutListA";
            this.dgvMIDIoutListA.RowHeadersVisible = false;
            this.dgvMIDIoutListA.RowTemplate.Height = 21;
            this.dgvMIDIoutListA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutListA.Size = new System.Drawing.Size(384, 136);
            this.dgvMIDIoutListA.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // clmIsVST
            // 
            this.clmIsVST.HeaderText = "IsVST";
            this.clmIsVST.Name = "clmIsVST";
            this.clmIsVST.Visible = false;
            // 
            // clmFileName
            // 
            this.clmFileName.HeaderText = "fileName";
            this.clmFileName.Name = "clmFileName";
            this.clmFileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmFileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmFileName.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Device Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 180;
            // 
            // clmType
            // 
            this.clmType.HeaderText = "Type";
            this.clmType.Items.AddRange(new object[] {
            "GM"});
            this.clmType.Name = "clmType";
            this.clmType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmType.Width = 70;
            // 
            // ClmBeforeSend
            // 
            this.ClmBeforeSend.HeaderText = "Before Send";
            this.ClmBeforeSend.Items.AddRange(new object[] {
            "None",
            "GM Reset",
            "XG Reset",
            "GS Reset",
            "Custom"});
            this.ClmBeforeSend.Name = "ClmBeforeSend";
            this.ClmBeforeSend.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ClmBeforeSend.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Manufacturer";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // btnUP_A
            // 
            this.btnUP_A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUP_A.Location = new System.Drawing.Point(390, 0);
            this.btnUP_A.Name = "btnUP_A";
            this.btnUP_A.Size = new System.Drawing.Size(22, 58);
            this.btnUP_A.TabIndex = 3;
            this.btnUP_A.Text = "↑";
            this.btnUP_A.UseVisualStyleBackColor = true;
            this.btnUP_A.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDOWN_A
            // 
            this.btnDOWN_A.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDOWN_A.Location = new System.Drawing.Point(390, 78);
            this.btnDOWN_A.Name = "btnDOWN_A";
            this.btnDOWN_A.Size = new System.Drawing.Size(22, 58);
            this.btnDOWN_A.TabIndex = 3;
            this.btnDOWN_A.Text = "↓";
            this.btnDOWN_A.UseVisualStyleBackColor = true;
            this.btnDOWN_A.Click += new System.EventHandler(this.btnDOWN_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvMIDIoutListB);
            this.tabPage2.Controls.Add(this.btnUP_B);
            this.tabPage2.Controls.Add(this.btnDOWN_B);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(414, 141);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "1";
            this.tabPage2.Text = "GS";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvMIDIoutListB
            // 
            this.dgvMIDIoutListB.AllowUserToAddRows = false;
            this.dgvMIDIoutListB.AllowUserToDeleteRows = false;
            this.dgvMIDIoutListB.AllowUserToResizeRows = false;
            this.dgvMIDIoutListB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMIDIoutListB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutListB.Location = new System.Drawing.Point(0, 0);
            this.dgvMIDIoutListB.MultiSelect = false;
            this.dgvMIDIoutListB.Name = "dgvMIDIoutListB";
            this.dgvMIDIoutListB.RowHeadersVisible = false;
            this.dgvMIDIoutListB.RowTemplate.Height = 21;
            this.dgvMIDIoutListB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutListB.Size = new System.Drawing.Size(384, 152);
            this.dgvMIDIoutListB.TabIndex = 7;
            // 
            // btnUP_B
            // 
            this.btnUP_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUP_B.Location = new System.Drawing.Point(390, 0);
            this.btnUP_B.Name = "btnUP_B";
            this.btnUP_B.Size = new System.Drawing.Size(22, 58);
            this.btnUP_B.TabIndex = 5;
            this.btnUP_B.Text = "↑";
            this.btnUP_B.UseVisualStyleBackColor = true;
            this.btnUP_B.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDOWN_B
            // 
            this.btnDOWN_B.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDOWN_B.Location = new System.Drawing.Point(390, 94);
            this.btnDOWN_B.Name = "btnDOWN_B";
            this.btnDOWN_B.Size = new System.Drawing.Size(22, 58);
            this.btnDOWN_B.TabIndex = 6;
            this.btnDOWN_B.Text = "↓";
            this.btnDOWN_B.UseVisualStyleBackColor = true;
            this.btnDOWN_B.Click += new System.EventHandler(this.btnDOWN_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgvMIDIoutListC);
            this.tabPage3.Controls.Add(this.btnUP_C);
            this.tabPage3.Controls.Add(this.btnDOWN_C);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(414, 141);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Tag = "2";
            this.tabPage3.Text = "XG";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvMIDIoutListC
            // 
            this.dgvMIDIoutListC.AllowUserToAddRows = false;
            this.dgvMIDIoutListC.AllowUserToDeleteRows = false;
            this.dgvMIDIoutListC.AllowUserToResizeRows = false;
            this.dgvMIDIoutListC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMIDIoutListC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutListC.Location = new System.Drawing.Point(0, 0);
            this.dgvMIDIoutListC.MultiSelect = false;
            this.dgvMIDIoutListC.Name = "dgvMIDIoutListC";
            this.dgvMIDIoutListC.RowHeadersVisible = false;
            this.dgvMIDIoutListC.RowTemplate.Height = 21;
            this.dgvMIDIoutListC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutListC.Size = new System.Drawing.Size(384, 152);
            this.dgvMIDIoutListC.TabIndex = 7;
            // 
            // btnUP_C
            // 
            this.btnUP_C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUP_C.Location = new System.Drawing.Point(390, 0);
            this.btnUP_C.Name = "btnUP_C";
            this.btnUP_C.Size = new System.Drawing.Size(22, 58);
            this.btnUP_C.TabIndex = 5;
            this.btnUP_C.Text = "↑";
            this.btnUP_C.UseVisualStyleBackColor = true;
            this.btnUP_C.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDOWN_C
            // 
            this.btnDOWN_C.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDOWN_C.Location = new System.Drawing.Point(390, 94);
            this.btnDOWN_C.Name = "btnDOWN_C";
            this.btnDOWN_C.Size = new System.Drawing.Size(22, 58);
            this.btnDOWN_C.TabIndex = 6;
            this.btnDOWN_C.Text = "↓";
            this.btnDOWN_C.UseVisualStyleBackColor = true;
            this.btnDOWN_C.Click += new System.EventHandler(this.btnDOWN_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgvMIDIoutListD);
            this.tabPage4.Controls.Add(this.btnUP_D);
            this.tabPage4.Controls.Add(this.btnDOWN_D);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(414, 141);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Tag = "3";
            this.tabPage4.Text = "VSTi";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvMIDIoutListD
            // 
            this.dgvMIDIoutListD.AllowUserToAddRows = false;
            this.dgvMIDIoutListD.AllowUserToDeleteRows = false;
            this.dgvMIDIoutListD.AllowUserToResizeRows = false;
            this.dgvMIDIoutListD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMIDIoutListD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMIDIoutListD.Location = new System.Drawing.Point(0, 0);
            this.dgvMIDIoutListD.MultiSelect = false;
            this.dgvMIDIoutListD.Name = "dgvMIDIoutListD";
            this.dgvMIDIoutListD.RowHeadersVisible = false;
            this.dgvMIDIoutListD.RowTemplate.Height = 21;
            this.dgvMIDIoutListD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMIDIoutListD.Size = new System.Drawing.Size(384, 152);
            this.dgvMIDIoutListD.TabIndex = 7;
            // 
            // btnUP_D
            // 
            this.btnUP_D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUP_D.Location = new System.Drawing.Point(390, 0);
            this.btnUP_D.Name = "btnUP_D";
            this.btnUP_D.Size = new System.Drawing.Size(22, 58);
            this.btnUP_D.TabIndex = 5;
            this.btnUP_D.Text = "↑";
            this.btnUP_D.UseVisualStyleBackColor = true;
            this.btnUP_D.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDOWN_D
            // 
            this.btnDOWN_D.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDOWN_D.Location = new System.Drawing.Point(390, 94);
            this.btnDOWN_D.Name = "btnDOWN_D";
            this.btnDOWN_D.Size = new System.Drawing.Size(22, 58);
            this.btnDOWN_D.TabIndex = 6;
            this.btnDOWN_D.Text = "↓";
            this.btnDOWN_D.UseVisualStyleBackColor = true;
            this.btnDOWN_D.Click += new System.EventHandler(this.btnDOWN_Click);
            // 
            // btnAddVST
            // 
            this.btnAddVST.Enabled = false;
            this.btnAddVST.Location = new System.Drawing.Point(263, 4);
            this.btnAddVST.Name = "btnAddVST";
            this.btnAddVST.Size = new System.Drawing.Size(75, 23);
            this.btnAddVST.TabIndex = 5;
            this.btnAddVST.Text = "Add VST";
            this.btnAddVST.UseVisualStyleBackColor = true;
            this.btnAddVST.Click += new System.EventHandler(this.btnAddVST_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(6, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(74, 12);
            this.label18.TabIndex = 2;
            this.label18.Text = "MIDI Outリスト";
            // 
            // btnAddMIDIout
            // 
            this.btnAddMIDIout.Location = new System.Drawing.Point(118, 4);
            this.btnAddMIDIout.Name = "btnAddMIDIout";
            this.btnAddMIDIout.Size = new System.Drawing.Size(66, 24);
            this.btnAddMIDIout.TabIndex = 3;
            this.btnAddMIDIout.Text = "↓ +";
            this.btnAddMIDIout.UseVisualStyleBackColor = true;
            this.btnAddMIDIout.Click += new System.EventHandler(this.btnAddMIDIout_Click);
            // 
            // btnSubMIDIout
            // 
            this.btnSubMIDIout.Location = new System.Drawing.Point(190, 4);
            this.btnSubMIDIout.Name = "btnSubMIDIout";
            this.btnSubMIDIout.Size = new System.Drawing.Size(66, 24);
            this.btnSubMIDIout.TabIndex = 3;
            this.btnSubMIDIout.Text = "-";
            this.btnSubMIDIout.UseVisualStyleBackColor = true;
            this.btnSubMIDIout.Click += new System.EventHandler(this.btnSubMIDIout_Click);
            // 
            // tpNuked
            // 
            this.tpNuked.Controls.Add(this.tabControl2);
            this.tpNuked.Location = new System.Drawing.Point(4, 22);
            this.tpNuked.Name = "tpNuked";
            this.tpNuked.Size = new System.Drawing.Size(443, 400);
            this.tpNuked.TabIndex = 14;
            this.tpNuked.Text = "チップ別";
            this.tpNuked.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage14);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.HotTrack = true;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(443, 400);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage14
            // 
            this.tabPage14.Controls.Add(this.groupBox26);
            this.tabPage14.Location = new System.Drawing.Point(4, 22);
            this.tabPage14.Name = "tabPage14";
            this.tabPage14.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage14.Size = new System.Drawing.Size(435, 374);
            this.tabPage14.TabIndex = 0;
            this.tabPage14.Text = "Nuked-OPN2";
            this.tabPage14.UseVisualStyleBackColor = true;
            // 
            // groupBox26
            // 
            this.groupBox26.Controls.Add(this.rbNukedOPN2OptionYM2612u);
            this.groupBox26.Controls.Add(this.rbNukedOPN2OptionYM2612);
            this.groupBox26.Controls.Add(this.rbNukedOPN2OptionDiscrete);
            this.groupBox26.Controls.Add(this.rbNukedOPN2OptionASIClp);
            this.groupBox26.Controls.Add(this.rbNukedOPN2OptionASIC);
            this.groupBox26.Location = new System.Drawing.Point(6, 6);
            this.groupBox26.Name = "groupBox26";
            this.groupBox26.Size = new System.Drawing.Size(318, 128);
            this.groupBox26.TabIndex = 0;
            this.groupBox26.TabStop = false;
            this.groupBox26.Text = "Emulation type";
            // 
            // rbNukedOPN2OptionYM2612u
            // 
            this.rbNukedOPN2OptionYM2612u.AutoSize = true;
            this.rbNukedOPN2OptionYM2612u.Location = new System.Drawing.Point(6, 84);
            this.rbNukedOPN2OptionYM2612u.Name = "rbNukedOPN2OptionYM2612u";
            this.rbNukedOPN2OptionYM2612u.Size = new System.Drawing.Size(189, 16);
            this.rbNukedOPN2OptionYM2612u.TabIndex = 0;
            this.rbNukedOPN2OptionYM2612u.TabStop = true;
            this.rbNukedOPN2OptionYM2612u.Text = "YM2612(without filter emulation)";
            this.rbNukedOPN2OptionYM2612u.UseVisualStyleBackColor = true;
            // 
            // rbNukedOPN2OptionYM2612
            // 
            this.rbNukedOPN2OptionYM2612.AutoSize = true;
            this.rbNukedOPN2OptionYM2612.Location = new System.Drawing.Point(6, 62);
            this.rbNukedOPN2OptionYM2612.Name = "rbNukedOPN2OptionYM2612";
            this.rbNukedOPN2OptionYM2612.Size = new System.Drawing.Size(188, 16);
            this.rbNukedOPN2OptionYM2612.TabIndex = 0;
            this.rbNukedOPN2OptionYM2612.TabStop = true;
            this.rbNukedOPN2OptionYM2612.Text = "YM2612(MD1,MD2 VA2)(default)";
            this.rbNukedOPN2OptionYM2612.UseVisualStyleBackColor = true;
            // 
            // rbNukedOPN2OptionDiscrete
            // 
            this.rbNukedOPN2OptionDiscrete.AutoSize = true;
            this.rbNukedOPN2OptionDiscrete.Location = new System.Drawing.Point(6, 18);
            this.rbNukedOPN2OptionDiscrete.Name = "rbNukedOPN2OptionDiscrete";
            this.rbNukedOPN2OptionDiscrete.Size = new System.Drawing.Size(122, 16);
            this.rbNukedOPN2OptionDiscrete.TabIndex = 0;
            this.rbNukedOPN2OptionDiscrete.TabStop = true;
            this.rbNukedOPN2OptionDiscrete.Text = "Discrete(Teradrive)";
            this.rbNukedOPN2OptionDiscrete.UseVisualStyleBackColor = true;
            // 
            // rbNukedOPN2OptionASIClp
            // 
            this.rbNukedOPN2OptionASIClp.AutoSize = true;
            this.rbNukedOPN2OptionASIClp.Location = new System.Drawing.Point(6, 106);
            this.rbNukedOPN2OptionASIClp.Name = "rbNukedOPN2OptionASIClp";
            this.rbNukedOPN2OptionASIClp.Size = new System.Drawing.Size(151, 16);
            this.rbNukedOPN2OptionASIClp.TabIndex = 0;
            this.rbNukedOPN2OptionASIClp.TabStop = true;
            this.rbNukedOPN2OptionASIClp.Text = "ASIC(with lowpass filter)";
            this.rbNukedOPN2OptionASIClp.UseVisualStyleBackColor = true;
            // 
            // rbNukedOPN2OptionASIC
            // 
            this.rbNukedOPN2OptionASIC.AutoSize = true;
            this.rbNukedOPN2OptionASIC.Location = new System.Drawing.Point(6, 40);
            this.rbNukedOPN2OptionASIC.Name = "rbNukedOPN2OptionASIC";
            this.rbNukedOPN2OptionASIC.Size = new System.Drawing.Size(174, 16);
            this.rbNukedOPN2OptionASIC.TabIndex = 0;
            this.rbNukedOPN2OptionASIC.TabStop = true;
            this.rbNukedOPN2OptionASIC.Text = "ASIC(MD1 VA7,MD2,MD3,etc)";
            this.rbNukedOPN2OptionASIC.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox34);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(435, 374);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Gens";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox34
            // 
            this.groupBox34.Controls.Add(this.cbGensSSGEG);
            this.groupBox34.Controls.Add(this.cbGensDACHPF);
            this.groupBox34.Location = new System.Drawing.Point(6, 6);
            this.groupBox34.Name = "groupBox34";
            this.groupBox34.Size = new System.Drawing.Size(318, 66);
            this.groupBox34.TabIndex = 1;
            this.groupBox34.TabStop = false;
            this.groupBox34.Text = "Gens Emulation option";
            // 
            // cbGensSSGEG
            // 
            this.cbGensSSGEG.AutoSize = true;
            this.cbGensSSGEG.Location = new System.Drawing.Point(6, 40);
            this.cbGensSSGEG.Name = "cbGensSSGEG";
            this.cbGensSSGEG.Size = new System.Drawing.Size(105, 16);
            this.cbGensSSGEG.TabIndex = 1;
            this.cbGensSSGEG.Text = "SSG-EG Enable";
            this.cbGensSSGEG.UseVisualStyleBackColor = true;
            // 
            // cbGensDACHPF
            // 
            this.cbGensDACHPF.AutoSize = true;
            this.cbGensDACHPF.Location = new System.Drawing.Point(6, 18);
            this.cbGensDACHPF.Name = "cbGensDACHPF";
            this.cbGensDACHPF.Size = new System.Drawing.Size(137, 16);
            this.cbGensDACHPF.TabIndex = 0;
            this.cbGensDACHPF.Text = "DAC Highpass Enable";
            this.cbGensDACHPF.UseVisualStyleBackColor = true;
            // 
            // tpNSF
            // 
            this.tpNSF.Controls.Add(this.tabControl3);
            this.tpNSF.Location = new System.Drawing.Point(4, 22);
            this.tpNSF.Name = "tpNSF";
            this.tpNSF.Size = new System.Drawing.Size(443, 400);
            this.tpNSF.TabIndex = 9;
            this.tpNSF.Text = "MIDI詳細";
            this.tpNSF.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage15);
            this.tabControl3.Controls.Add(this.tabPage16);
            this.tabControl3.Controls.Add(this.tabPage17);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.HotTrack = true;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Multiline = true;
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(443, 400);
            this.tabControl3.TabIndex = 9;
            // 
            // tabPage15
            // 
            this.tabPage15.Controls.Add(this.groupBox9);
            this.tabPage15.Controls.Add(this.groupBox10);
            this.tabPage15.Controls.Add(this.groupBox8);
            this.tabPage15.Controls.Add(this.groupBox12);
            this.tabPage15.Controls.Add(this.groupBox11);
            this.tabPage15.Location = new System.Drawing.Point(4, 22);
            this.tabPage15.Name = "tabPage15";
            this.tabPage15.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage15.Size = new System.Drawing.Size(435, 374);
            this.tabPage15.TabIndex = 0;
            this.tabPage15.Text = ".NSF";
            this.tabPage15.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.cbNFSNes_DutySwap);
            this.groupBox9.Controls.Add(this.cbNFSNes_PhaseRefresh);
            this.groupBox9.Controls.Add(this.cbNFSNes_NonLinearMixer);
            this.groupBox9.Controls.Add(this.cbNFSNes_UnmuteOnReset);
            this.groupBox9.Location = new System.Drawing.Point(3, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(210, 107);
            this.groupBox9.TabIndex = 8;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "NES";
            // 
            // cbNFSNes_DutySwap
            // 
            this.cbNFSNes_DutySwap.AutoSize = true;
            this.cbNFSNes_DutySwap.Location = new System.Drawing.Point(6, 84);
            this.cbNFSNes_DutySwap.Name = "cbNFSNes_DutySwap";
            this.cbNFSNes_DutySwap.Size = new System.Drawing.Size(78, 16);
            this.cbNFSNes_DutySwap.TabIndex = 7;
            this.cbNFSNes_DutySwap.Text = "Duty swap";
            this.cbNFSNes_DutySwap.UseVisualStyleBackColor = true;
            // 
            // cbNFSNes_PhaseRefresh
            // 
            this.cbNFSNes_PhaseRefresh.AutoSize = true;
            this.cbNFSNes_PhaseRefresh.Location = new System.Drawing.Point(6, 62);
            this.cbNFSNes_PhaseRefresh.Name = "cbNFSNes_PhaseRefresh";
            this.cbNFSNes_PhaseRefresh.Size = new System.Drawing.Size(95, 16);
            this.cbNFSNes_PhaseRefresh.TabIndex = 7;
            this.cbNFSNes_PhaseRefresh.Text = "Phase refresh";
            this.cbNFSNes_PhaseRefresh.UseVisualStyleBackColor = true;
            // 
            // cbNFSNes_NonLinearMixer
            // 
            this.cbNFSNes_NonLinearMixer.AutoSize = true;
            this.cbNFSNes_NonLinearMixer.Location = new System.Drawing.Point(6, 40);
            this.cbNFSNes_NonLinearMixer.Name = "cbNFSNes_NonLinearMixer";
            this.cbNFSNes_NonLinearMixer.Size = new System.Drawing.Size(110, 16);
            this.cbNFSNes_NonLinearMixer.TabIndex = 7;
            this.cbNFSNes_NonLinearMixer.Text = "Non-linear mixer";
            this.cbNFSNes_NonLinearMixer.UseVisualStyleBackColor = true;
            // 
            // cbNFSNes_UnmuteOnReset
            // 
            this.cbNFSNes_UnmuteOnReset.AutoSize = true;
            this.cbNFSNes_UnmuteOnReset.Location = new System.Drawing.Point(6, 18);
            this.cbNFSNes_UnmuteOnReset.Name = "cbNFSNes_UnmuteOnReset";
            this.cbNFSNes_UnmuteOnReset.Size = new System.Drawing.Size(109, 16);
            this.cbNFSNes_UnmuteOnReset.TabIndex = 7;
            this.cbNFSNes_UnmuteOnReset.Text = "Unmute on reset";
            this.cbNFSNes_UnmuteOnReset.UseVisualStyleBackColor = true;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.cbNSFDmc_TriNull);
            this.groupBox10.Controls.Add(this.cbNSFDmc_TriMute);
            this.groupBox10.Controls.Add(this.cbNSFDmc_RandomizeNoise);
            this.groupBox10.Controls.Add(this.cbNSFDmc_DPCMAntiClick);
            this.groupBox10.Controls.Add(this.cbNSFDmc_EnablePNoise);
            this.groupBox10.Controls.Add(this.cbNSFDmc_Enable4011);
            this.groupBox10.Controls.Add(this.cbNSFDmc_NonLinearMixer);
            this.groupBox10.Controls.Add(this.cbNSFDmc_UnmuteOnReset);
            this.groupBox10.Location = new System.Drawing.Point(220, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(210, 200);
            this.groupBox10.TabIndex = 8;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "DMC";
            // 
            // cbNSFDmc_TriNull
            // 
            this.cbNSFDmc_TriNull.AutoSize = true;
            this.cbNSFDmc_TriNull.Location = new System.Drawing.Point(6, 171);
            this.cbNSFDmc_TriNull.Name = "cbNSFDmc_TriNull";
            this.cbNSFDmc_TriNull.Size = new System.Drawing.Size(64, 16);
            this.cbNSFDmc_TriNull.TabIndex = 7;
            this.cbNSFDmc_TriNull.Text = "TRI null";
            this.cbNSFDmc_TriNull.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_TriMute
            // 
            this.cbNSFDmc_TriMute.AutoSize = true;
            this.cbNSFDmc_TriMute.Location = new System.Drawing.Point(6, 149);
            this.cbNSFDmc_TriMute.Name = "cbNSFDmc_TriMute";
            this.cbNSFDmc_TriMute.Size = new System.Drawing.Size(71, 16);
            this.cbNSFDmc_TriMute.TabIndex = 7;
            this.cbNSFDmc_TriMute.Text = "TRI mute";
            this.cbNSFDmc_TriMute.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_RandomizeNoise
            // 
            this.cbNSFDmc_RandomizeNoise.AutoSize = true;
            this.cbNSFDmc_RandomizeNoise.Location = new System.Drawing.Point(6, 128);
            this.cbNSFDmc_RandomizeNoise.Name = "cbNSFDmc_RandomizeNoise";
            this.cbNSFDmc_RandomizeNoise.Size = new System.Drawing.Size(110, 16);
            this.cbNSFDmc_RandomizeNoise.TabIndex = 7;
            this.cbNSFDmc_RandomizeNoise.Text = "Randomize noise";
            this.cbNSFDmc_RandomizeNoise.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_DPCMAntiClick
            // 
            this.cbNSFDmc_DPCMAntiClick.AutoSize = true;
            this.cbNSFDmc_DPCMAntiClick.Location = new System.Drawing.Point(6, 106);
            this.cbNSFDmc_DPCMAntiClick.Name = "cbNSFDmc_DPCMAntiClick";
            this.cbNSFDmc_DPCMAntiClick.Size = new System.Drawing.Size(107, 16);
            this.cbNSFDmc_DPCMAntiClick.TabIndex = 7;
            this.cbNSFDmc_DPCMAntiClick.Text = "DPCM anti click";
            this.cbNSFDmc_DPCMAntiClick.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_EnablePNoise
            // 
            this.cbNSFDmc_EnablePNoise.AutoSize = true;
            this.cbNSFDmc_EnablePNoise.Location = new System.Drawing.Point(6, 84);
            this.cbNSFDmc_EnablePNoise.Name = "cbNSFDmc_EnablePNoise";
            this.cbNSFDmc_EnablePNoise.Size = new System.Drawing.Size(96, 16);
            this.cbNSFDmc_EnablePNoise.TabIndex = 7;
            this.cbNSFDmc_EnablePNoise.Text = "Enable Pnoise";
            this.cbNSFDmc_EnablePNoise.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_Enable4011
            // 
            this.cbNSFDmc_Enable4011.AutoSize = true;
            this.cbNSFDmc_Enable4011.Location = new System.Drawing.Point(6, 62);
            this.cbNSFDmc_Enable4011.Name = "cbNSFDmc_Enable4011";
            this.cbNSFDmc_Enable4011.Size = new System.Drawing.Size(92, 16);
            this.cbNSFDmc_Enable4011.TabIndex = 7;
            this.cbNSFDmc_Enable4011.Text = "Enable $4011";
            this.cbNSFDmc_Enable4011.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_NonLinearMixer
            // 
            this.cbNSFDmc_NonLinearMixer.AutoSize = true;
            this.cbNSFDmc_NonLinearMixer.Location = new System.Drawing.Point(6, 40);
            this.cbNSFDmc_NonLinearMixer.Name = "cbNSFDmc_NonLinearMixer";
            this.cbNSFDmc_NonLinearMixer.Size = new System.Drawing.Size(110, 16);
            this.cbNSFDmc_NonLinearMixer.TabIndex = 7;
            this.cbNSFDmc_NonLinearMixer.Text = "Non-linear mixer";
            this.cbNSFDmc_NonLinearMixer.UseVisualStyleBackColor = true;
            // 
            // cbNSFDmc_UnmuteOnReset
            // 
            this.cbNSFDmc_UnmuteOnReset.AutoSize = true;
            this.cbNSFDmc_UnmuteOnReset.Location = new System.Drawing.Point(6, 18);
            this.cbNSFDmc_UnmuteOnReset.Name = "cbNSFDmc_UnmuteOnReset";
            this.cbNSFDmc_UnmuteOnReset.Size = new System.Drawing.Size(109, 16);
            this.cbNSFDmc_UnmuteOnReset.TabIndex = 7;
            this.cbNSFDmc_UnmuteOnReset.Text = "Unmute on reset";
            this.cbNSFDmc_UnmuteOnReset.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label21);
            this.groupBox8.Controls.Add(this.label20);
            this.groupBox8.Controls.Add(this.tbNSFFds_LPF);
            this.groupBox8.Controls.Add(this.cbNFSFds_4085Reset);
            this.groupBox8.Controls.Add(this.cbNSFFDSWriteDisable8000);
            this.groupBox8.Location = new System.Drawing.Point(3, 116);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(210, 87);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "FDS";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(143, 16);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(18, 12);
            this.label21.TabIndex = 10;
            this.label21.Text = "Hz";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 16);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(25, 12);
            this.label20.TabIndex = 10;
            this.label20.Text = "LPF";
            // 
            // tbNSFFds_LPF
            // 
            this.tbNSFFds_LPF.Location = new System.Drawing.Point(37, 13);
            this.tbNSFFds_LPF.Name = "tbNSFFds_LPF";
            this.tbNSFFds_LPF.Size = new System.Drawing.Size(100, 19);
            this.tbNSFFds_LPF.TabIndex = 9;
            // 
            // cbNFSFds_4085Reset
            // 
            this.cbNFSFds_4085Reset.AutoSize = true;
            this.cbNFSFds_4085Reset.Location = new System.Drawing.Point(6, 38);
            this.cbNFSFds_4085Reset.Name = "cbNFSFds_4085Reset";
            this.cbNFSFds_4085Reset.Size = new System.Drawing.Size(84, 16);
            this.cbNFSFds_4085Reset.TabIndex = 7;
            this.cbNFSFds_4085Reset.Text = "$4085 reset";
            this.cbNFSFds_4085Reset.UseVisualStyleBackColor = true;
            // 
            // cbNSFFDSWriteDisable8000
            // 
            this.cbNSFFDSWriteDisable8000.AutoSize = true;
            this.cbNSFFDSWriteDisable8000.Location = new System.Drawing.Point(6, 60);
            this.cbNSFFDSWriteDisable8000.Name = "cbNSFFDSWriteDisable8000";
            this.cbNSFFDSWriteDisable8000.Size = new System.Drawing.Size(177, 16);
            this.cbNSFFDSWriteDisable8000.TabIndex = 7;
            this.cbNSFFDSWriteDisable8000.Text = "Write disable($8000 - $DFFF)";
            this.cbNSFFDSWriteDisable8000.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.cbNSFN160_Serial);
            this.groupBox12.Location = new System.Drawing.Point(220, 209);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(210, 62);
            this.groupBox12.TabIndex = 8;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "N160";
            // 
            // cbNSFN160_Serial
            // 
            this.cbNSFN160_Serial.AutoSize = true;
            this.cbNSFN160_Serial.Location = new System.Drawing.Point(6, 18);
            this.cbNSFN160_Serial.Name = "cbNSFN160_Serial";
            this.cbNSFN160_Serial.Size = new System.Drawing.Size(53, 16);
            this.cbNSFN160_Serial.TabIndex = 7;
            this.cbNSFN160_Serial.Text = "Serial";
            this.cbNSFN160_Serial.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cbNSFMmc5_PhaseRefresh);
            this.groupBox11.Controls.Add(this.cbNSFMmc5_NonLinearMixer);
            this.groupBox11.Location = new System.Drawing.Point(3, 209);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(210, 62);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "MMC5";
            // 
            // cbNSFMmc5_PhaseRefresh
            // 
            this.cbNSFMmc5_PhaseRefresh.AutoSize = true;
            this.cbNSFMmc5_PhaseRefresh.Location = new System.Drawing.Point(6, 40);
            this.cbNSFMmc5_PhaseRefresh.Name = "cbNSFMmc5_PhaseRefresh";
            this.cbNSFMmc5_PhaseRefresh.Size = new System.Drawing.Size(95, 16);
            this.cbNSFMmc5_PhaseRefresh.TabIndex = 7;
            this.cbNSFMmc5_PhaseRefresh.Text = "Phase refresh";
            this.cbNSFMmc5_PhaseRefresh.UseVisualStyleBackColor = true;
            // 
            // cbNSFMmc5_NonLinearMixer
            // 
            this.cbNSFMmc5_NonLinearMixer.AutoSize = true;
            this.cbNSFMmc5_NonLinearMixer.Location = new System.Drawing.Point(6, 18);
            this.cbNSFMmc5_NonLinearMixer.Name = "cbNSFMmc5_NonLinearMixer";
            this.cbNSFMmc5_NonLinearMixer.Size = new System.Drawing.Size(110, 16);
            this.cbNSFMmc5_NonLinearMixer.TabIndex = 7;
            this.cbNSFMmc5_NonLinearMixer.Text = "Non-linear Mixer";
            this.cbNSFMmc5_NonLinearMixer.UseVisualStyleBackColor = true;
            // 
            // tabPage16
            // 
            this.tabPage16.Controls.Add(this.groupBox14);
            this.tabPage16.Controls.Add(this.groupBox13);
            this.tabPage16.Controls.Add(this.label49);
            this.tabPage16.Controls.Add(this.label51);
            this.tabPage16.Controls.Add(this.tbSIDOutputBufferSize);
            this.tabPage16.Location = new System.Drawing.Point(4, 22);
            this.tabPage16.Name = "tabPage16";
            this.tabPage16.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage16.Size = new System.Drawing.Size(435, 374);
            this.tabPage16.TabIndex = 1;
            this.tabPage16.Text = ".SID";
            this.tabPage16.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label27);
            this.groupBox14.Controls.Add(this.label26);
            this.groupBox14.Controls.Add(this.label25);
            this.groupBox14.Controls.Add(this.rdSIDQ1);
            this.groupBox14.Controls.Add(this.rdSIDQ3);
            this.groupBox14.Controls.Add(this.rdSIDQ2);
            this.groupBox14.Controls.Add(this.rdSIDQ4);
            this.groupBox14.Location = new System.Drawing.Point(3, 109);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(280, 111);
            this.groupBox14.TabIndex = 2;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Quality";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(162, 86);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(58, 12);
            this.label27.TabIndex = 2;
            this.label27.Text = "Low(Light)";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(162, 54);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(38, 12);
            this.label26.TabIndex = 2;
            this.label26.Text = "Middle";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(162, 20);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 12);
            this.label25.TabIndex = 2;
            this.label25.Text = "High(Heavy)";
            // 
            // rdSIDQ1
            // 
            this.rdSIDQ1.AutoSize = true;
            this.rdSIDQ1.Checked = true;
            this.rdSIDQ1.Location = new System.Drawing.Point(6, 84);
            this.rdSIDQ1.Name = "rdSIDQ1";
            this.rdSIDQ1.Size = new System.Drawing.Size(111, 16);
            this.rdSIDQ1.TabIndex = 1;
            this.rdSIDQ1.TabStop = true;
            this.rdSIDQ1.Text = "Interpolate - fast";
            this.rdSIDQ1.UseVisualStyleBackColor = true;
            // 
            // rdSIDQ3
            // 
            this.rdSIDQ3.AutoSize = true;
            this.rdSIDQ3.Location = new System.Drawing.Point(6, 40);
            this.rdSIDQ3.Name = "rdSIDQ3";
            this.rdSIDQ3.Size = new System.Drawing.Size(107, 16);
            this.rdSIDQ3.TabIndex = 1;
            this.rdSIDQ3.Text = "Resample - fast";
            this.rdSIDQ3.UseVisualStyleBackColor = true;
            // 
            // rdSIDQ2
            // 
            this.rdSIDQ2.AutoSize = true;
            this.rdSIDQ2.Location = new System.Drawing.Point(6, 62);
            this.rdSIDQ2.Name = "rdSIDQ2";
            this.rdSIDQ2.Size = new System.Drawing.Size(77, 16);
            this.rdSIDQ2.TabIndex = 1;
            this.rdSIDQ2.Text = "Interpolate";
            this.rdSIDQ2.UseVisualStyleBackColor = true;
            // 
            // rdSIDQ4
            // 
            this.rdSIDQ4.AutoSize = true;
            this.rdSIDQ4.Location = new System.Drawing.Point(6, 18);
            this.rdSIDQ4.Name = "rdSIDQ4";
            this.rdSIDQ4.Size = new System.Drawing.Size(73, 16);
            this.rdSIDQ4.TabIndex = 1;
            this.rdSIDQ4.Text = "Resample";
            this.rdSIDQ4.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.btnSIDBasic);
            this.groupBox13.Controls.Add(this.btnSIDCharacter);
            this.groupBox13.Controls.Add(this.btnSIDKernal);
            this.groupBox13.Controls.Add(this.tbSIDCharacter);
            this.groupBox13.Controls.Add(this.tbSIDBasic);
            this.groupBox13.Controls.Add(this.tbSIDKernal);
            this.groupBox13.Controls.Add(this.label24);
            this.groupBox13.Controls.Add(this.label23);
            this.groupBox13.Controls.Add(this.label22);
            this.groupBox13.Location = new System.Drawing.Point(3, 3);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(428, 100);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "ROM Image";
            // 
            // btnSIDBasic
            // 
            this.btnSIDBasic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSIDBasic.Location = new System.Drawing.Point(400, 44);
            this.btnSIDBasic.Name = "btnSIDBasic";
            this.btnSIDBasic.Size = new System.Drawing.Size(23, 23);
            this.btnSIDBasic.TabIndex = 2;
            this.btnSIDBasic.Text = "...";
            this.btnSIDBasic.UseVisualStyleBackColor = true;
            this.btnSIDBasic.Click += new System.EventHandler(this.btnSIDBasic_Click);
            // 
            // btnSIDCharacter
            // 
            this.btnSIDCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSIDCharacter.Location = new System.Drawing.Point(400, 69);
            this.btnSIDCharacter.Name = "btnSIDCharacter";
            this.btnSIDCharacter.Size = new System.Drawing.Size(23, 23);
            this.btnSIDCharacter.TabIndex = 2;
            this.btnSIDCharacter.Text = "...";
            this.btnSIDCharacter.UseVisualStyleBackColor = true;
            this.btnSIDCharacter.Click += new System.EventHandler(this.btnSIDCharacter_Click);
            // 
            // btnSIDKernal
            // 
            this.btnSIDKernal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSIDKernal.Location = new System.Drawing.Point(400, 19);
            this.btnSIDKernal.Name = "btnSIDKernal";
            this.btnSIDKernal.Size = new System.Drawing.Size(23, 23);
            this.btnSIDKernal.TabIndex = 2;
            this.btnSIDKernal.Text = "...";
            this.btnSIDKernal.UseVisualStyleBackColor = true;
            this.btnSIDKernal.Click += new System.EventHandler(this.btnSIDKernal_Click);
            // 
            // tbSIDCharacter
            // 
            this.tbSIDCharacter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSIDCharacter.Location = new System.Drawing.Point(67, 71);
            this.tbSIDCharacter.Name = "tbSIDCharacter";
            this.tbSIDCharacter.Size = new System.Drawing.Size(327, 19);
            this.tbSIDCharacter.TabIndex = 1;
            // 
            // tbSIDBasic
            // 
            this.tbSIDBasic.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSIDBasic.Location = new System.Drawing.Point(67, 46);
            this.tbSIDBasic.Name = "tbSIDBasic";
            this.tbSIDBasic.Size = new System.Drawing.Size(327, 19);
            this.tbSIDBasic.TabIndex = 1;
            // 
            // tbSIDKernal
            // 
            this.tbSIDKernal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSIDKernal.Location = new System.Drawing.Point(67, 21);
            this.tbSIDKernal.Name = "tbSIDKernal";
            this.tbSIDKernal.Size = new System.Drawing.Size(327, 19);
            this.tbSIDKernal.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 74);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(55, 12);
            this.label24.TabIndex = 0;
            this.label24.Text = "Character";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 49);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(34, 12);
            this.label23.TabIndex = 0;
            this.label23.Text = "Basic";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(6, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(37, 12);
            this.label22.TabIndex = 0;
            this.label22.Text = "Kernal";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(9, 229);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(95, 12);
            this.label49.TabIndex = 0;
            this.label49.Text = "OutputBuffer size";
            // 
            // label51
            // 
            this.label51.Location = new System.Drawing.Point(209, 224);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(223, 38);
            this.label51.TabIndex = 0;
            this.label51.Text = "テンポが速かったり、音が途切れる場合に調整すると改善することがあります。通常は5000。";
            // 
            // tbSIDOutputBufferSize
            // 
            this.tbSIDOutputBufferSize.Location = new System.Drawing.Point(110, 226);
            this.tbSIDOutputBufferSize.MaxLength = 10;
            this.tbSIDOutputBufferSize.Name = "tbSIDOutputBufferSize";
            this.tbSIDOutputBufferSize.Size = new System.Drawing.Size(93, 19);
            this.tbSIDOutputBufferSize.TabIndex = 1;
            // 
            // tabPage17
            // 
            this.tabPage17.Controls.Add(this.groupBox15);
            this.tabPage17.Location = new System.Drawing.Point(4, 22);
            this.tabPage17.Name = "tabPage17";
            this.tabPage17.Size = new System.Drawing.Size(435, 374);
            this.tabPage17.TabIndex = 2;
            this.tabPage17.Text = "Resetコマンド";
            this.tabPage17.UseVisualStyleBackColor = true;
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.btnBeforeSend_Default);
            this.groupBox15.Controls.Add(this.tbBeforeSend_Custom);
            this.groupBox15.Controls.Add(this.tbBeforeSend_XGReset);
            this.groupBox15.Controls.Add(this.label35);
            this.groupBox15.Controls.Add(this.label34);
            this.groupBox15.Controls.Add(this.label32);
            this.groupBox15.Controls.Add(this.tbBeforeSend_GSReset);
            this.groupBox15.Controls.Add(this.label33);
            this.groupBox15.Controls.Add(this.tbBeforeSend_GMReset);
            this.groupBox15.Controls.Add(this.label31);
            this.groupBox15.Location = new System.Drawing.Point(3, 3);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(428, 199);
            this.groupBox15.TabIndex = 0;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Before Send";
            // 
            // btnBeforeSend_Default
            // 
            this.btnBeforeSend_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBeforeSend_Default.Location = new System.Drawing.Point(348, 123);
            this.btnBeforeSend_Default.Name = "btnBeforeSend_Default";
            this.btnBeforeSend_Default.Size = new System.Drawing.Size(75, 23);
            this.btnBeforeSend_Default.TabIndex = 2;
            this.btnBeforeSend_Default.Text = "元に戻す";
            this.btnBeforeSend_Default.UseVisualStyleBackColor = true;
            this.btnBeforeSend_Default.Click += new System.EventHandler(this.btnBeforeSend_Default_Click);
            // 
            // tbBeforeSend_Custom
            // 
            this.tbBeforeSend_Custom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBeforeSend_Custom.Location = new System.Drawing.Point(90, 98);
            this.tbBeforeSend_Custom.Name = "tbBeforeSend_Custom";
            this.tbBeforeSend_Custom.Size = new System.Drawing.Size(333, 19);
            this.tbBeforeSend_Custom.TabIndex = 1;
            // 
            // tbBeforeSend_XGReset
            // 
            this.tbBeforeSend_XGReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBeforeSend_XGReset.Location = new System.Drawing.Point(90, 48);
            this.tbBeforeSend_XGReset.Name = "tbBeforeSend_XGReset";
            this.tbBeforeSend_XGReset.Size = new System.Drawing.Size(333, 19);
            this.tbBeforeSend_XGReset.TabIndex = 1;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(6, 128);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(329, 28);
            this.label35.TabIndex = 0;
            this.label35.Text = "Format:\r\n  (delayTime(dec)):(command data(hex)),...;...\r\n";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(6, 101);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 12);
            this.label34.TabIndex = 0;
            this.label34.Text = "Custom";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(6, 51);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(76, 12);
            this.label32.TabIndex = 0;
            this.label32.Text = "XG SystemOn";
            // 
            // tbBeforeSend_GSReset
            // 
            this.tbBeforeSend_GSReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBeforeSend_GSReset.Location = new System.Drawing.Point(90, 73);
            this.tbBeforeSend_GSReset.Name = "tbBeforeSend_GSReset";
            this.tbBeforeSend_GSReset.Size = new System.Drawing.Size(333, 19);
            this.tbBeforeSend_GSReset.TabIndex = 1;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(6, 76);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(54, 12);
            this.label33.TabIndex = 0;
            this.label33.Text = "GS Reset";
            // 
            // tbBeforeSend_GMReset
            // 
            this.tbBeforeSend_GMReset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBeforeSend_GMReset.Location = new System.Drawing.Point(90, 23);
            this.tbBeforeSend_GMReset.Name = "tbBeforeSend_GMReset";
            this.tbBeforeSend_GMReset.Size = new System.Drawing.Size(333, 19);
            this.tbBeforeSend_GMReset.TabIndex = 1;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(6, 26);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(78, 12);
            this.label31.TabIndex = 0;
            this.label31.Text = "GM SystemOn";
            // 
            // tpPMDDotNET
            // 
            this.tpPMDDotNET.Controls.Add(this.rbPMDManual);
            this.tpPMDDotNET.Controls.Add(this.rbPMDAuto);
            this.tpPMDDotNET.Controls.Add(this.btnPMDResetDriverArguments);
            this.tpPMDDotNET.Controls.Add(this.label47);
            this.tpPMDDotNET.Controls.Add(this.btnPMDResetCompilerArhguments);
            this.tpPMDDotNET.Controls.Add(this.tbPMDDriverArguments);
            this.tpPMDDotNET.Controls.Add(this.label37);
            this.tpPMDDotNET.Controls.Add(this.tbPMDCompilerArguments);
            this.tpPMDDotNET.Controls.Add(this.gbPMDManual);
            this.tpPMDDotNET.Location = new System.Drawing.Point(4, 22);
            this.tpPMDDotNET.Name = "tpPMDDotNET";
            this.tpPMDDotNET.Size = new System.Drawing.Size(443, 400);
            this.tpPMDDotNET.TabIndex = 15;
            this.tpPMDDotNET.Text = "PMDDotNET";
            this.tpPMDDotNET.UseVisualStyleBackColor = true;
            // 
            // rbPMDManual
            // 
            this.rbPMDManual.AutoSize = true;
            this.rbPMDManual.Location = new System.Drawing.Point(9, 58);
            this.rbPMDManual.Name = "rbPMDManual";
            this.rbPMDManual.Size = new System.Drawing.Size(59, 16);
            this.rbPMDManual.TabIndex = 3;
            this.rbPMDManual.TabStop = true;
            this.rbPMDManual.Text = "Manual";
            this.rbPMDManual.UseVisualStyleBackColor = true;
            this.rbPMDManual.CheckedChanged += new System.EventHandler(this.rbPMDManual_CheckedChanged);
            // 
            // rbPMDAuto
            // 
            this.rbPMDAuto.AutoSize = true;
            this.rbPMDAuto.Location = new System.Drawing.Point(9, 35);
            this.rbPMDAuto.Name = "rbPMDAuto";
            this.rbPMDAuto.Size = new System.Drawing.Size(47, 16);
            this.rbPMDAuto.TabIndex = 3;
            this.rbPMDAuto.TabStop = true;
            this.rbPMDAuto.Text = "Auto";
            this.rbPMDAuto.UseVisualStyleBackColor = true;
            // 
            // btnPMDResetDriverArguments
            // 
            this.btnPMDResetDriverArguments.Location = new System.Drawing.Point(376, 371);
            this.btnPMDResetDriverArguments.Name = "btnPMDResetDriverArguments";
            this.btnPMDResetDriverArguments.Size = new System.Drawing.Size(64, 23);
            this.btnPMDResetDriverArguments.TabIndex = 2;
            this.btnPMDResetDriverArguments.Text = "clear";
            this.btnPMDResetDriverArguments.UseVisualStyleBackColor = true;
            this.btnPMDResetDriverArguments.Click += new System.EventHandler(this.btnPMDResetDriverArguments_Click);
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(7, 376);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(93, 12);
            this.label47.TabIndex = 1;
            this.label47.Text = "Driver arguments";
            // 
            // btnPMDResetCompilerArhguments
            // 
            this.btnPMDResetCompilerArhguments.Location = new System.Drawing.Point(376, 8);
            this.btnPMDResetCompilerArhguments.Name = "btnPMDResetCompilerArhguments";
            this.btnPMDResetCompilerArhguments.Size = new System.Drawing.Size(64, 23);
            this.btnPMDResetCompilerArhguments.TabIndex = 2;
            this.btnPMDResetCompilerArhguments.Text = "reset";
            this.btnPMDResetCompilerArhguments.UseVisualStyleBackColor = true;
            this.btnPMDResetCompilerArhguments.Click += new System.EventHandler(this.btnPMDResetCompilerArhguments_Click);
            // 
            // tbPMDDriverArguments
            // 
            this.tbPMDDriverArguments.Location = new System.Drawing.Point(120, 373);
            this.tbPMDDriverArguments.Name = "tbPMDDriverArguments";
            this.tbPMDDriverArguments.Size = new System.Drawing.Size(250, 19);
            this.tbPMDDriverArguments.TabIndex = 0;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(7, 13);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(107, 12);
            this.label37.TabIndex = 1;
            this.label37.Text = "Compiler arguments";
            // 
            // tbPMDCompilerArguments
            // 
            this.tbPMDCompilerArguments.Location = new System.Drawing.Point(120, 10);
            this.tbPMDCompilerArguments.Name = "tbPMDCompilerArguments";
            this.tbPMDCompilerArguments.Size = new System.Drawing.Size(250, 19);
            this.tbPMDCompilerArguments.TabIndex = 0;
            // 
            // gbPMDManual
            // 
            this.gbPMDManual.Controls.Add(this.cbPMDSetManualVolume);
            this.gbPMDManual.Controls.Add(this.cbPMDUsePPZ8);
            this.gbPMDManual.Controls.Add(this.groupBox32);
            this.gbPMDManual.Controls.Add(this.cbPMDUsePPSDRV);
            this.gbPMDManual.Controls.Add(this.gbPPSDRV);
            this.gbPMDManual.Controls.Add(this.gbPMDSetManualVolume);
            this.gbPMDManual.Location = new System.Drawing.Point(16, 60);
            this.gbPMDManual.Name = "gbPMDManual";
            this.gbPMDManual.Size = new System.Drawing.Size(424, 303);
            this.gbPMDManual.TabIndex = 9;
            this.gbPMDManual.TabStop = false;
            // 
            // cbPMDSetManualVolume
            // 
            this.cbPMDSetManualVolume.AutoSize = true;
            this.cbPMDSetManualVolume.Location = new System.Drawing.Point(8, 55);
            this.cbPMDSetManualVolume.Name = "cbPMDSetManualVolume";
            this.cbPMDSetManualVolume.Size = new System.Drawing.Size(125, 16);
            this.cbPMDSetManualVolume.TabIndex = 10;
            this.cbPMDSetManualVolume.Text = "Set volume(manual)";
            this.cbPMDSetManualVolume.UseVisualStyleBackColor = true;
            this.cbPMDSetManualVolume.CheckedChanged += new System.EventHandler(this.cbPMDSetManualVolume_CheckedChanged);
            // 
            // cbPMDUsePPZ8
            // 
            this.cbPMDUsePPZ8.AutoSize = true;
            this.cbPMDUsePPZ8.Location = new System.Drawing.Point(6, 281);
            this.cbPMDUsePPZ8.Name = "cbPMDUsePPZ8";
            this.cbPMDUsePPZ8.Size = new System.Drawing.Size(75, 16);
            this.cbPMDUsePPZ8.TabIndex = 6;
            this.cbPMDUsePPZ8.Text = "Use PPZ8";
            this.cbPMDUsePPZ8.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            this.groupBox32.Controls.Add(this.rbPMD86B);
            this.groupBox32.Controls.Add(this.rbPMDSpbB);
            this.groupBox32.Controls.Add(this.rbPMDNrmB);
            this.groupBox32.Location = new System.Drawing.Point(6, 18);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(285, 36);
            this.groupBox32.TabIndex = 4;
            this.groupBox32.TabStop = false;
            this.groupBox32.Text = "Select board";
            // 
            // rbPMD86B
            // 
            this.rbPMD86B.AutoSize = true;
            this.rbPMD86B.Enabled = false;
            this.rbPMD86B.Location = new System.Drawing.Point(195, 14);
            this.rbPMD86B.Name = "rbPMD86B";
            this.rbPMD86B.Size = new System.Drawing.Size(67, 16);
            this.rbPMD86B.TabIndex = 0;
            this.rbPMD86B.TabStop = true;
            this.rbPMD86B.Text = "86 board";
            this.rbPMD86B.UseVisualStyleBackColor = true;
            // 
            // rbPMDSpbB
            // 
            this.rbPMDSpbB.AutoSize = true;
            this.rbPMDSpbB.Location = new System.Drawing.Point(103, 14);
            this.rbPMDSpbB.Name = "rbPMDSpbB";
            this.rbPMDSpbB.Size = new System.Drawing.Size(86, 16);
            this.rbPMDSpbB.TabIndex = 0;
            this.rbPMDSpbB.TabStop = true;
            this.rbPMDSpbB.Text = "Speak board";
            this.rbPMDSpbB.UseVisualStyleBackColor = true;
            // 
            // rbPMDNrmB
            // 
            this.rbPMDNrmB.AutoSize = true;
            this.rbPMDNrmB.Location = new System.Drawing.Point(6, 14);
            this.rbPMDNrmB.Name = "rbPMDNrmB";
            this.rbPMDNrmB.Size = new System.Drawing.Size(91, 16);
            this.rbPMDNrmB.TabIndex = 0;
            this.rbPMDNrmB.TabStop = true;
            this.rbPMDNrmB.Text = "Normal board";
            this.rbPMDNrmB.UseVisualStyleBackColor = true;
            // 
            // cbPMDUsePPSDRV
            // 
            this.cbPMDUsePPSDRV.AutoSize = true;
            this.cbPMDUsePPSDRV.Location = new System.Drawing.Point(6, 150);
            this.cbPMDUsePPSDRV.Name = "cbPMDUsePPSDRV";
            this.cbPMDUsePPSDRV.Size = new System.Drawing.Size(93, 16);
            this.cbPMDUsePPSDRV.TabIndex = 5;
            this.cbPMDUsePPSDRV.Text = "Use PPSDRV";
            this.cbPMDUsePPSDRV.UseVisualStyleBackColor = true;
            this.cbPMDUsePPSDRV.CheckedChanged += new System.EventHandler(this.cbPMDUsePPSDRV_CheckedChanged);
            // 
            // gbPPSDRV
            // 
            this.gbPPSDRV.Controls.Add(this.groupBox33);
            this.gbPPSDRV.Location = new System.Drawing.Point(12, 150);
            this.gbPPSDRV.Name = "gbPPSDRV";
            this.gbPPSDRV.Size = new System.Drawing.Size(406, 125);
            this.gbPPSDRV.TabIndex = 8;
            this.gbPPSDRV.TabStop = false;
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.rbPMDUsePPSDRVManualFreq);
            this.groupBox33.Controls.Add(this.label38);
            this.groupBox33.Controls.Add(this.rbPMDUsePPSDRVFreqDefault);
            this.groupBox33.Controls.Add(this.btnPMDPPSDRVManualWait);
            this.groupBox33.Controls.Add(this.label40);
            this.groupBox33.Controls.Add(this.tbPMDPPSDRVFreq);
            this.groupBox33.Controls.Add(this.label39);
            this.groupBox33.Controls.Add(this.tbPMDPPSDRVManualWait);
            this.groupBox33.Enabled = false;
            this.groupBox33.Location = new System.Drawing.Point(6, 18);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(394, 100);
            this.groupBox33.TabIndex = 12;
            this.groupBox33.TabStop = false;
            this.groupBox33.Text = "TBD";
            // 
            // rbPMDUsePPSDRVManualFreq
            // 
            this.rbPMDUsePPSDRVManualFreq.AutoSize = true;
            this.rbPMDUsePPSDRVManualFreq.Location = new System.Drawing.Point(221, 44);
            this.rbPMDUsePPSDRVManualFreq.Name = "rbPMDUsePPSDRVManualFreq";
            this.rbPMDUsePPSDRVManualFreq.Size = new System.Drawing.Size(14, 13);
            this.rbPMDUsePPSDRVManualFreq.TabIndex = 8;
            this.rbPMDUsePPSDRVManualFreq.TabStop = true;
            this.rbPMDUsePPSDRVManualFreq.UseVisualStyleBackColor = true;
            this.rbPMDUsePPSDRVManualFreq.CheckedChanged += new System.EventHandler(this.rbPMDUsePPSDRVManualFreq_CheckedChanged);
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(12, 19);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(175, 12);
            this.label38.TabIndex = 1;
            this.label38.Text = "(Real Chip) Rendering Frequency";
            // 
            // rbPMDUsePPSDRVFreqDefault
            // 
            this.rbPMDUsePPSDRVFreqDefault.AutoSize = true;
            this.rbPMDUsePPSDRVFreqDefault.Location = new System.Drawing.Point(221, 17);
            this.rbPMDUsePPSDRVFreqDefault.Name = "rbPMDUsePPSDRVFreqDefault";
            this.rbPMDUsePPSDRVFreqDefault.Size = new System.Drawing.Size(131, 16);
            this.rbPMDUsePPSDRVFreqDefault.TabIndex = 8;
            this.rbPMDUsePPSDRVFreqDefault.TabStop = true;
            this.rbPMDUsePPSDRVFreqDefault.Text = "Use interface default";
            this.rbPMDUsePPSDRVFreqDefault.UseVisualStyleBackColor = true;
            // 
            // btnPMDPPSDRVManualWait
            // 
            this.btnPMDPPSDRVManualWait.Location = new System.Drawing.Point(298, 71);
            this.btnPMDPPSDRVManualWait.Name = "btnPMDPPSDRVManualWait";
            this.btnPMDPPSDRVManualWait.Size = new System.Drawing.Size(64, 23);
            this.btnPMDPPSDRVManualWait.TabIndex = 2;
            this.btnPMDPPSDRVManualWait.Text = "reset";
            this.btnPMDPPSDRVManualWait.UseVisualStyleBackColor = true;
            this.btnPMDPPSDRVManualWait.Click += new System.EventHandler(this.btnPMDPPSDRVManualWait_Click);
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(347, 44);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(18, 12);
            this.label40.TabIndex = 1;
            this.label40.Text = "Hz";
            // 
            // tbPMDPPSDRVFreq
            // 
            this.tbPMDPPSDRVFreq.Location = new System.Drawing.Point(241, 41);
            this.tbPMDPPSDRVFreq.Name = "tbPMDPPSDRVFreq";
            this.tbPMDPPSDRVFreq.Size = new System.Drawing.Size(100, 19);
            this.tbPMDPPSDRVFreq.TabIndex = 7;
            this.tbPMDPPSDRVFreq.Click += new System.EventHandler(this.tbPMDPPSDRVFreq_Click);
            this.tbPMDPPSDRVFreq.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbPMDPPSDRVFreq_MouseClick);
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(12, 76);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(182, 12);
            this.label39.TabIndex = 1;
            this.label39.Text = "(SCCI) Send syncronize wait value";
            // 
            // tbPMDPPSDRVManualWait
            // 
            this.tbPMDPPSDRVManualWait.Location = new System.Drawing.Point(241, 73);
            this.tbPMDPPSDRVManualWait.Name = "tbPMDPPSDRVManualWait";
            this.tbPMDPPSDRVManualWait.Size = new System.Drawing.Size(51, 19);
            this.tbPMDPPSDRVManualWait.TabIndex = 7;
            // 
            // gbPMDSetManualVolume
            // 
            this.gbPMDSetManualVolume.Controls.Add(this.label41);
            this.gbPMDSetManualVolume.Controls.Add(this.label46);
            this.gbPMDSetManualVolume.Controls.Add(this.tbPMDVolumeAdpcm);
            this.gbPMDSetManualVolume.Controls.Add(this.label42);
            this.gbPMDSetManualVolume.Controls.Add(this.tbPMDVolumeRhythm);
            this.gbPMDSetManualVolume.Controls.Add(this.label43);
            this.gbPMDSetManualVolume.Controls.Add(this.tbPMDVolumeSSG);
            this.gbPMDSetManualVolume.Controls.Add(this.label44);
            this.gbPMDSetManualVolume.Controls.Add(this.tbPMDVolumeGIMICSSG);
            this.gbPMDSetManualVolume.Controls.Add(this.label45);
            this.gbPMDSetManualVolume.Controls.Add(this.tbPMDVolumeFM);
            this.gbPMDSetManualVolume.Location = new System.Drawing.Point(13, 55);
            this.gbPMDSetManualVolume.Name = "gbPMDSetManualVolume";
            this.gbPMDSetManualVolume.Size = new System.Drawing.Size(405, 93);
            this.gbPMDSetManualVolume.TabIndex = 11;
            this.gbPMDSetManualVolume.TabStop = false;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(5, 18);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(219, 12);
            this.label41.TabIndex = 1;
            this.label41.Text = "OPNA emulator volume(Min:-191  Max:20)";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(6, 64);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(189, 12);
            this.label46.TabIndex = 1;
            this.label46.Text = "(GIMIC) SSG volume(Min:0 Max:127)";
            // 
            // tbPMDVolumeAdpcm
            // 
            this.tbPMDVolumeAdpcm.Location = new System.Drawing.Point(342, 33);
            this.tbPMDVolumeAdpcm.Name = "tbPMDVolumeAdpcm";
            this.tbPMDVolumeAdpcm.Size = new System.Drawing.Size(51, 19);
            this.tbPMDVolumeAdpcm.TabIndex = 9;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(10, 36);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(21, 12);
            this.label42.TabIndex = 1;
            this.label42.Text = "FM";
            // 
            // tbPMDVolumeRhythm
            // 
            this.tbPMDVolumeRhythm.Location = new System.Drawing.Point(234, 33);
            this.tbPMDVolumeRhythm.Name = "tbPMDVolumeRhythm";
            this.tbPMDVolumeRhythm.Size = new System.Drawing.Size(51, 19);
            this.tbPMDVolumeRhythm.TabIndex = 9;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(94, 36);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(27, 12);
            this.label43.TabIndex = 1;
            this.label43.Text = "SSG";
            // 
            // tbPMDVolumeSSG
            // 
            this.tbPMDVolumeSSG.Location = new System.Drawing.Point(127, 33);
            this.tbPMDVolumeSSG.Name = "tbPMDVolumeSSG";
            this.tbPMDVolumeSSG.Size = new System.Drawing.Size(51, 19);
            this.tbPMDVolumeSSG.TabIndex = 9;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(184, 36);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(44, 12);
            this.label44.TabIndex = 1;
            this.label44.Text = "Rhythm";
            // 
            // tbPMDVolumeGIMICSSG
            // 
            this.tbPMDVolumeGIMICSSG.Location = new System.Drawing.Point(201, 61);
            this.tbPMDVolumeGIMICSSG.Name = "tbPMDVolumeGIMICSSG";
            this.tbPMDVolumeGIMICSSG.Size = new System.Drawing.Size(51, 19);
            this.tbPMDVolumeGIMICSSG.TabIndex = 9;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(291, 36);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(45, 12);
            this.label45.TabIndex = 1;
            this.label45.Text = "ADPCM";
            // 
            // tbPMDVolumeFM
            // 
            this.tbPMDVolumeFM.Location = new System.Drawing.Point(37, 33);
            this.tbPMDVolumeFM.Name = "tbPMDVolumeFM";
            this.tbPMDVolumeFM.Size = new System.Drawing.Size(51, 19);
            this.tbPMDVolumeFM.TabIndex = 9;
            // 
            // tpMIDIExp
            // 
            this.tpMIDIExp.Controls.Add(this.cbUseMIDIExport);
            this.tpMIDIExp.Controls.Add(this.gbMIDIExport);
            this.tpMIDIExp.Location = new System.Drawing.Point(4, 22);
            this.tpMIDIExp.Name = "tpMIDIExp";
            this.tpMIDIExp.Size = new System.Drawing.Size(443, 400);
            this.tpMIDIExp.TabIndex = 6;
            this.tpMIDIExp.Text = "MIDIExport";
            this.tpMIDIExp.UseVisualStyleBackColor = true;
            // 
            // cbUseMIDIExport
            // 
            this.cbUseMIDIExport.AutoSize = true;
            this.cbUseMIDIExport.Location = new System.Drawing.Point(15, 3);
            this.cbUseMIDIExport.Name = "cbUseMIDIExport";
            this.cbUseMIDIExport.Size = new System.Drawing.Size(177, 16);
            this.cbUseMIDIExport.TabIndex = 1;
            this.cbUseMIDIExport.Text = "演奏時MIDIファイルをexportする";
            this.cbUseMIDIExport.UseVisualStyleBackColor = true;
            this.cbUseMIDIExport.CheckedChanged += new System.EventHandler(this.cbUseMIDIExport_CheckedChanged);
            // 
            // gbMIDIExport
            // 
            this.gbMIDIExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMIDIExport.Controls.Add(this.cbMIDIKeyOnFnum);
            this.gbMIDIExport.Controls.Add(this.cbMIDIUseVOPM);
            this.gbMIDIExport.Controls.Add(this.groupBox6);
            this.gbMIDIExport.Controls.Add(this.cbMIDIPlayless);
            this.gbMIDIExport.Controls.Add(this.btnMIDIOutputPath);
            this.gbMIDIExport.Controls.Add(this.lblOutputPath);
            this.gbMIDIExport.Controls.Add(this.tbMIDIOutputPath);
            this.gbMIDIExport.Location = new System.Drawing.Point(7, 3);
            this.gbMIDIExport.Name = "gbMIDIExport";
            this.gbMIDIExport.Size = new System.Drawing.Size(433, 394);
            this.gbMIDIExport.TabIndex = 0;
            this.gbMIDIExport.TabStop = false;
            // 
            // cbMIDIKeyOnFnum
            // 
            this.cbMIDIKeyOnFnum.AutoSize = true;
            this.cbMIDIKeyOnFnum.Location = new System.Drawing.Point(21, 66);
            this.cbMIDIKeyOnFnum.Name = "cbMIDIKeyOnFnum";
            this.cbMIDIKeyOnFnum.Size = new System.Drawing.Size(169, 16);
            this.cbMIDIKeyOnFnum.TabIndex = 23;
            this.cbMIDIKeyOnFnum.Text = "KeyON時のみfnumを評価する";
            this.cbMIDIKeyOnFnum.UseVisualStyleBackColor = true;
            // 
            // cbMIDIUseVOPM
            // 
            this.cbMIDIUseVOPM.AutoSize = true;
            this.cbMIDIUseVOPM.Location = new System.Drawing.Point(21, 44);
            this.cbMIDIUseVOPM.Name = "cbMIDIUseVOPM";
            this.cbMIDIUseVOPM.Size = new System.Drawing.Size(196, 16);
            this.cbMIDIUseVOPM.TabIndex = 23;
            this.cbMIDIUseVOPM.Text = "VOPMex向けコントロールを出力する";
            this.cbMIDIUseVOPM.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbMIDIYM2612);
            this.groupBox6.Controls.Add(this.cbMIDISN76489Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2612Sec);
            this.groupBox6.Controls.Add(this.cbMIDISN76489);
            this.groupBox6.Controls.Add(this.cbMIDIYM2151);
            this.groupBox6.Controls.Add(this.cbMIDIYM2610BSec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2151Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2610B);
            this.groupBox6.Controls.Add(this.cbMIDIYM2203);
            this.groupBox6.Controls.Add(this.cbMIDIYM2608Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2203Sec);
            this.groupBox6.Controls.Add(this.cbMIDIYM2608);
            this.groupBox6.Location = new System.Drawing.Point(20, 113);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(188, 152);
            this.groupBox6.TabIndex = 22;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "出力対象音源";
            // 
            // cbMIDIYM2612
            // 
            this.cbMIDIYM2612.AutoSize = true;
            this.cbMIDIYM2612.Checked = true;
            this.cbMIDIYM2612.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbMIDIYM2612.Location = new System.Drawing.Point(6, 18);
            this.cbMIDIYM2612.Name = "cbMIDIYM2612";
            this.cbMIDIYM2612.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2612.TabIndex = 21;
            this.cbMIDIYM2612.Text = "YM2612";
            this.cbMIDIYM2612.UseVisualStyleBackColor = true;
            // 
            // cbMIDISN76489Sec
            // 
            this.cbMIDISN76489Sec.AutoSize = true;
            this.cbMIDISN76489Sec.Enabled = false;
            this.cbMIDISN76489Sec.Location = new System.Drawing.Point(84, 128);
            this.cbMIDISN76489Sec.Name = "cbMIDISN76489Sec";
            this.cbMIDISN76489Sec.Size = new System.Drawing.Size(96, 16);
            this.cbMIDISN76489Sec.TabIndex = 21;
            this.cbMIDISN76489Sec.Text = "SN76489(Sec)";
            this.cbMIDISN76489Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2612Sec
            // 
            this.cbMIDIYM2612Sec.AutoSize = true;
            this.cbMIDIYM2612Sec.Enabled = false;
            this.cbMIDIYM2612Sec.Location = new System.Drawing.Point(84, 18);
            this.cbMIDIYM2612Sec.Name = "cbMIDIYM2612Sec";
            this.cbMIDIYM2612Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2612Sec.TabIndex = 21;
            this.cbMIDIYM2612Sec.Text = "YM2612(Sec)";
            this.cbMIDIYM2612Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDISN76489
            // 
            this.cbMIDISN76489.AutoSize = true;
            this.cbMIDISN76489.Enabled = false;
            this.cbMIDISN76489.Location = new System.Drawing.Point(6, 128);
            this.cbMIDISN76489.Name = "cbMIDISN76489";
            this.cbMIDISN76489.Size = new System.Drawing.Size(69, 16);
            this.cbMIDISN76489.TabIndex = 21;
            this.cbMIDISN76489.Text = "SN76489";
            this.cbMIDISN76489.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2151
            // 
            this.cbMIDIYM2151.AutoSize = true;
            this.cbMIDIYM2151.Location = new System.Drawing.Point(6, 40);
            this.cbMIDIYM2151.Name = "cbMIDIYM2151";
            this.cbMIDIYM2151.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2151.TabIndex = 21;
            this.cbMIDIYM2151.Text = "YM2151";
            this.cbMIDIYM2151.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2610BSec
            // 
            this.cbMIDIYM2610BSec.AutoSize = true;
            this.cbMIDIYM2610BSec.Enabled = false;
            this.cbMIDIYM2610BSec.Location = new System.Drawing.Point(84, 106);
            this.cbMIDIYM2610BSec.Name = "cbMIDIYM2610BSec";
            this.cbMIDIYM2610BSec.Size = new System.Drawing.Size(99, 16);
            this.cbMIDIYM2610BSec.TabIndex = 21;
            this.cbMIDIYM2610BSec.Text = "YM2610B(Sec)";
            this.cbMIDIYM2610BSec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2151Sec
            // 
            this.cbMIDIYM2151Sec.AutoSize = true;
            this.cbMIDIYM2151Sec.Enabled = false;
            this.cbMIDIYM2151Sec.Location = new System.Drawing.Point(84, 40);
            this.cbMIDIYM2151Sec.Name = "cbMIDIYM2151Sec";
            this.cbMIDIYM2151Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2151Sec.TabIndex = 21;
            this.cbMIDIYM2151Sec.Text = "YM2151(Sec)";
            this.cbMIDIYM2151Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2610B
            // 
            this.cbMIDIYM2610B.AutoSize = true;
            this.cbMIDIYM2610B.Enabled = false;
            this.cbMIDIYM2610B.Location = new System.Drawing.Point(6, 106);
            this.cbMIDIYM2610B.Name = "cbMIDIYM2610B";
            this.cbMIDIYM2610B.Size = new System.Drawing.Size(72, 16);
            this.cbMIDIYM2610B.TabIndex = 21;
            this.cbMIDIYM2610B.Text = "YM2610B";
            this.cbMIDIYM2610B.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2203
            // 
            this.cbMIDIYM2203.AutoSize = true;
            this.cbMIDIYM2203.Enabled = false;
            this.cbMIDIYM2203.Location = new System.Drawing.Point(6, 62);
            this.cbMIDIYM2203.Name = "cbMIDIYM2203";
            this.cbMIDIYM2203.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2203.TabIndex = 21;
            this.cbMIDIYM2203.Text = "YM2203";
            this.cbMIDIYM2203.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2608Sec
            // 
            this.cbMIDIYM2608Sec.AutoSize = true;
            this.cbMIDIYM2608Sec.Enabled = false;
            this.cbMIDIYM2608Sec.Location = new System.Drawing.Point(84, 84);
            this.cbMIDIYM2608Sec.Name = "cbMIDIYM2608Sec";
            this.cbMIDIYM2608Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2608Sec.TabIndex = 21;
            this.cbMIDIYM2608Sec.Text = "YM2608(Sec)";
            this.cbMIDIYM2608Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2203Sec
            // 
            this.cbMIDIYM2203Sec.AutoSize = true;
            this.cbMIDIYM2203Sec.Enabled = false;
            this.cbMIDIYM2203Sec.Location = new System.Drawing.Point(84, 62);
            this.cbMIDIYM2203Sec.Name = "cbMIDIYM2203Sec";
            this.cbMIDIYM2203Sec.Size = new System.Drawing.Size(91, 16);
            this.cbMIDIYM2203Sec.TabIndex = 21;
            this.cbMIDIYM2203Sec.Text = "YM2203(Sec)";
            this.cbMIDIYM2203Sec.UseVisualStyleBackColor = true;
            // 
            // cbMIDIYM2608
            // 
            this.cbMIDIYM2608.AutoSize = true;
            this.cbMIDIYM2608.Enabled = false;
            this.cbMIDIYM2608.Location = new System.Drawing.Point(6, 84);
            this.cbMIDIYM2608.Name = "cbMIDIYM2608";
            this.cbMIDIYM2608.Size = new System.Drawing.Size(64, 16);
            this.cbMIDIYM2608.TabIndex = 21;
            this.cbMIDIYM2608.Text = "YM2608";
            this.cbMIDIYM2608.UseVisualStyleBackColor = true;
            // 
            // cbMIDIPlayless
            // 
            this.cbMIDIPlayless.AutoSize = true;
            this.cbMIDIPlayless.Enabled = false;
            this.cbMIDIPlayless.Location = new System.Drawing.Point(21, 22);
            this.cbMIDIPlayless.Name = "cbMIDIPlayless";
            this.cbMIDIPlayless.Size = new System.Drawing.Size(141, 16);
            this.cbMIDIPlayless.TabIndex = 20;
            this.cbMIDIPlayless.Text = "演奏を行わずに出力する";
            this.cbMIDIPlayless.UseVisualStyleBackColor = true;
            // 
            // btnMIDIOutputPath
            // 
            this.btnMIDIOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMIDIOutputPath.Location = new System.Drawing.Point(403, 86);
            this.btnMIDIOutputPath.Name = "btnMIDIOutputPath";
            this.btnMIDIOutputPath.Size = new System.Drawing.Size(23, 23);
            this.btnMIDIOutputPath.TabIndex = 19;
            this.btnMIDIOutputPath.Text = "...";
            this.btnMIDIOutputPath.UseVisualStyleBackColor = true;
            this.btnMIDIOutputPath.Click += new System.EventHandler(this.btnMIDIOutputPath_Click);
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(19, 91);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Size = new System.Drawing.Size(52, 12);
            this.lblOutputPath.TabIndex = 17;
            this.lblOutputPath.Text = "出力Path";
            // 
            // tbMIDIOutputPath
            // 
            this.tbMIDIOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMIDIOutputPath.Location = new System.Drawing.Point(77, 88);
            this.tbMIDIOutputPath.Name = "tbMIDIOutputPath";
            this.tbMIDIOutputPath.Size = new System.Drawing.Size(320, 19);
            this.tbMIDIOutputPath.TabIndex = 18;
            // 
            // tpMIDIKBD
            // 
            this.tpMIDIKBD.Controls.Add(this.cbMIDIKbdAlwaysTop);
            this.tpMIDIKBD.Controls.Add(this.cbUseMIDIKeyboard);
            this.tpMIDIKBD.Controls.Add(this.gbMIDIKeyboard);
            this.tpMIDIKBD.Location = new System.Drawing.Point(4, 22);
            this.tpMIDIKBD.Name = "tpMIDIKBD";
            this.tpMIDIKBD.Size = new System.Drawing.Size(443, 400);
            this.tpMIDIKBD.TabIndex = 5;
            this.tpMIDIKBD.Text = "MIDI鍵盤";
            this.tpMIDIKBD.UseVisualStyleBackColor = true;
            // 
            // cbMIDIKbdAlwaysTop
            // 
            this.cbMIDIKbdAlwaysTop.AutoSize = true;
            this.cbMIDIKbdAlwaysTop.Location = new System.Drawing.Point(12, 64);
            this.cbMIDIKbdAlwaysTop.Name = "cbMIDIKbdAlwaysTop";
            this.cbMIDIKbdAlwaysTop.Size = new System.Drawing.Size(154, 16);
            this.cbMIDIKbdAlwaysTop.TabIndex = 2;
            this.cbMIDIKbdAlwaysTop.Text = "鍵盤を常に手前に表示する";
            this.cbMIDIKbdAlwaysTop.UseVisualStyleBackColor = true;
            // 
            // cbUseMIDIKeyboard
            // 
            this.cbUseMIDIKeyboard.AutoSize = true;
            this.cbUseMIDIKeyboard.Location = new System.Drawing.Point(11, 4);
            this.cbUseMIDIKeyboard.Name = "cbUseMIDIKeyboard";
            this.cbUseMIDIKeyboard.Size = new System.Drawing.Size(124, 16);
            this.cbUseMIDIKeyboard.TabIndex = 1;
            this.cbUseMIDIKeyboard.Text = "MIDIキーボードを使う";
            this.cbUseMIDIKeyboard.UseVisualStyleBackColor = true;
            this.cbUseMIDIKeyboard.CheckedChanged += new System.EventHandler(this.cbUseMIDIKeyboard_CheckedChanged);
            // 
            // gbMIDIKeyboard
            // 
            this.gbMIDIKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox8);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox7);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox6);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox5);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox4);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox3);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox2);
            this.gbMIDIKeyboard.Controls.Add(this.pictureBox1);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCFadeout);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCPause);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCSlow);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCPrevious);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCNext);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCFast);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCStop);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCPlay);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCCopyLog);
            this.gbMIDIKeyboard.Controls.Add(this.label17);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCDelLog);
            this.gbMIDIKeyboard.Controls.Add(this.label15);
            this.gbMIDIKeyboard.Controls.Add(this.tbCCChCopy);
            this.gbMIDIKeyboard.Controls.Add(this.label8);
            this.gbMIDIKeyboard.Controls.Add(this.label9);
            this.gbMIDIKeyboard.Controls.Add(this.gbUseChannel);
            this.gbMIDIKeyboard.Controls.Add(this.cmbMIDIIN);
            this.gbMIDIKeyboard.Controls.Add(this.label5);
            this.gbMIDIKeyboard.Enabled = false;
            this.gbMIDIKeyboard.Location = new System.Drawing.Point(3, 6);
            this.gbMIDIKeyboard.Name = "gbMIDIKeyboard";
            this.gbMIDIKeyboard.Size = new System.Drawing.Size(437, 76);
            this.gbMIDIKeyboard.TabIndex = 0;
            this.gbMIDIKeyboard.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = global::mml2vgmIDE.Properties.Resources.ccNext;
            this.pictureBox8.Location = new System.Drawing.Point(371, 257);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(16, 16);
            this.pictureBox8.TabIndex = 4;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = global::mml2vgmIDE.Properties.Resources.ccFast;
            this.pictureBox7.Location = new System.Drawing.Point(261, 257);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(16, 16);
            this.pictureBox7.TabIndex = 4;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Visible = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = global::mml2vgmIDE.Properties.Resources.ccPlay;
            this.pictureBox6.Location = new System.Drawing.Point(152, 258);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(16, 16);
            this.pictureBox6.TabIndex = 4;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = global::mml2vgmIDE.Properties.Resources.ccSlow;
            this.pictureBox5.Location = new System.Drawing.Point(42, 258);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::mml2vgmIDE.Properties.Resources.ccStop;
            this.pictureBox4.Location = new System.Drawing.Point(42, 234);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::mml2vgmIDE.Properties.Resources.ccPause;
            this.pictureBox3.Location = new System.Drawing.Point(152, 234);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::mml2vgmIDE.Properties.Resources.ccPrevious;
            this.pictureBox2.Location = new System.Drawing.Point(371, 234);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::mml2vgmIDE.Properties.Resources.ccFadeout;
            this.pictureBox1.Location = new System.Drawing.Point(261, 234);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // tbCCFadeout
            // 
            this.tbCCFadeout.Location = new System.Drawing.Point(225, 232);
            this.tbCCFadeout.MaxLength = 3;
            this.tbCCFadeout.Name = "tbCCFadeout";
            this.tbCCFadeout.Size = new System.Drawing.Size(30, 19);
            this.tbCCFadeout.TabIndex = 12;
            this.tbCCFadeout.Visible = false;
            // 
            // tbCCPause
            // 
            this.tbCCPause.Location = new System.Drawing.Point(116, 232);
            this.tbCCPause.MaxLength = 3;
            this.tbCCPause.Name = "tbCCPause";
            this.tbCCPause.Size = new System.Drawing.Size(30, 19);
            this.tbCCPause.TabIndex = 11;
            this.tbCCPause.Visible = false;
            // 
            // tbCCSlow
            // 
            this.tbCCSlow.Location = new System.Drawing.Point(6, 257);
            this.tbCCSlow.MaxLength = 3;
            this.tbCCSlow.Name = "tbCCSlow";
            this.tbCCSlow.Size = new System.Drawing.Size(30, 19);
            this.tbCCSlow.TabIndex = 14;
            this.tbCCSlow.Visible = false;
            // 
            // tbCCPrevious
            // 
            this.tbCCPrevious.Location = new System.Drawing.Point(335, 232);
            this.tbCCPrevious.MaxLength = 3;
            this.tbCCPrevious.Name = "tbCCPrevious";
            this.tbCCPrevious.Size = new System.Drawing.Size(30, 19);
            this.tbCCPrevious.TabIndex = 13;
            this.tbCCPrevious.Visible = false;
            // 
            // tbCCNext
            // 
            this.tbCCNext.Location = new System.Drawing.Point(335, 257);
            this.tbCCNext.MaxLength = 3;
            this.tbCCNext.Name = "tbCCNext";
            this.tbCCNext.Size = new System.Drawing.Size(30, 19);
            this.tbCCNext.TabIndex = 17;
            this.tbCCNext.Visible = false;
            // 
            // tbCCFast
            // 
            this.tbCCFast.Location = new System.Drawing.Point(225, 257);
            this.tbCCFast.MaxLength = 3;
            this.tbCCFast.Name = "tbCCFast";
            this.tbCCFast.Size = new System.Drawing.Size(30, 19);
            this.tbCCFast.TabIndex = 16;
            this.tbCCFast.Visible = false;
            // 
            // tbCCStop
            // 
            this.tbCCStop.Location = new System.Drawing.Point(6, 232);
            this.tbCCStop.MaxLength = 3;
            this.tbCCStop.Name = "tbCCStop";
            this.tbCCStop.Size = new System.Drawing.Size(30, 19);
            this.tbCCStop.TabIndex = 10;
            this.tbCCStop.Visible = false;
            // 
            // tbCCPlay
            // 
            this.tbCCPlay.Location = new System.Drawing.Point(116, 257);
            this.tbCCPlay.MaxLength = 3;
            this.tbCCPlay.Name = "tbCCPlay";
            this.tbCCPlay.Size = new System.Drawing.Size(30, 19);
            this.tbCCPlay.TabIndex = 15;
            this.tbCCPlay.Visible = false;
            // 
            // tbCCCopyLog
            // 
            this.tbCCCopyLog.Location = new System.Drawing.Point(6, 207);
            this.tbCCCopyLog.MaxLength = 3;
            this.tbCCCopyLog.Name = "tbCCCopyLog";
            this.tbCCCopyLog.Size = new System.Drawing.Size(30, 19);
            this.tbCCCopyLog.TabIndex = 8;
            this.tbCCCopyLog.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(42, 210);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(230, 12);
            this.label17.TabIndex = 9;
            this.label17.Text = "MONOモード時、選択ログをクリップボードに設定";
            this.label17.Visible = false;
            // 
            // tbCCDelLog
            // 
            this.tbCCDelLog.Location = new System.Drawing.Point(6, 182);
            this.tbCCDelLog.MaxLength = 3;
            this.tbCCDelLog.Name = "tbCCDelLog";
            this.tbCCDelLog.Size = new System.Drawing.Size(30, 19);
            this.tbCCDelLog.TabIndex = 6;
            this.tbCCDelLog.Visible = false;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(42, 185);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 12);
            this.label15.TabIndex = 7;
            this.label15.Text = "直近のログをひとつ削除";
            this.label15.Visible = false;
            // 
            // tbCCChCopy
            // 
            this.tbCCChCopy.Location = new System.Drawing.Point(6, 157);
            this.tbCCChCopy.MaxLength = 3;
            this.tbCCChCopy.Name = "tbCCChCopy";
            this.tbCCChCopy.Size = new System.Drawing.Size(30, 19);
            this.tbCCChCopy.TabIndex = 4;
            this.tbCCChCopy.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 142);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 12);
            this.label8.TabIndex = 3;
            this.label8.Text = "CC(Control Change)による操作";
            this.label8.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(261, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "1Chの音色を全てのチャンネルにコピー(選択状況無視)";
            this.label9.Visible = false;
            // 
            // gbUseChannel
            // 
            this.gbUseChannel.Controls.Add(this.rbMONO);
            this.gbUseChannel.Controls.Add(this.rbPOLY);
            this.gbUseChannel.Controls.Add(this.groupBox7);
            this.gbUseChannel.Controls.Add(this.groupBox2);
            this.gbUseChannel.Location = new System.Drawing.Point(6, 44);
            this.gbUseChannel.Name = "gbUseChannel";
            this.gbUseChannel.Size = new System.Drawing.Size(425, 86);
            this.gbUseChannel.TabIndex = 2;
            this.gbUseChannel.TabStop = false;
            this.gbUseChannel.Text = "use channel";
            this.gbUseChannel.Visible = false;
            // 
            // rbMONO
            // 
            this.rbMONO.AutoSize = true;
            this.rbMONO.Checked = true;
            this.rbMONO.Location = new System.Drawing.Point(12, 17);
            this.rbMONO.Name = "rbMONO";
            this.rbMONO.Size = new System.Drawing.Size(56, 16);
            this.rbMONO.TabIndex = 1;
            this.rbMONO.TabStop = true;
            this.rbMONO.Text = "MONO";
            this.rbMONO.UseVisualStyleBackColor = true;
            // 
            // rbPOLY
            // 
            this.rbPOLY.AutoSize = true;
            this.rbPOLY.Location = new System.Drawing.Point(215, 17);
            this.rbPOLY.Name = "rbPOLY";
            this.rbPOLY.Size = new System.Drawing.Size(51, 16);
            this.rbPOLY.TabIndex = 3;
            this.rbPOLY.Text = "POLY";
            this.rbPOLY.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbFM6);
            this.groupBox7.Controls.Add(this.rbFM3);
            this.groupBox7.Controls.Add(this.rbFM5);
            this.groupBox7.Controls.Add(this.rbFM2);
            this.groupBox7.Controls.Add(this.rbFM4);
            this.groupBox7.Controls.Add(this.rbFM1);
            this.groupBox7.Location = new System.Drawing.Point(6, 18);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(197, 62);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            // 
            // rbFM6
            // 
            this.rbFM6.AutoSize = true;
            this.rbFM6.Location = new System.Drawing.Point(108, 40);
            this.rbFM6.Name = "rbFM6";
            this.rbFM6.Size = new System.Drawing.Size(45, 16);
            this.rbFM6.TabIndex = 5;
            this.rbFM6.Text = "FM6";
            this.rbFM6.UseVisualStyleBackColor = true;
            // 
            // rbFM3
            // 
            this.rbFM3.AutoSize = true;
            this.rbFM3.Location = new System.Drawing.Point(108, 18);
            this.rbFM3.Name = "rbFM3";
            this.rbFM3.Size = new System.Drawing.Size(45, 16);
            this.rbFM3.TabIndex = 2;
            this.rbFM3.Text = "FM3";
            this.rbFM3.UseVisualStyleBackColor = true;
            // 
            // rbFM5
            // 
            this.rbFM5.AutoSize = true;
            this.rbFM5.Location = new System.Drawing.Point(57, 40);
            this.rbFM5.Name = "rbFM5";
            this.rbFM5.Size = new System.Drawing.Size(45, 16);
            this.rbFM5.TabIndex = 4;
            this.rbFM5.Text = "FM5";
            this.rbFM5.UseVisualStyleBackColor = true;
            // 
            // rbFM2
            // 
            this.rbFM2.AutoSize = true;
            this.rbFM2.Location = new System.Drawing.Point(57, 18);
            this.rbFM2.Name = "rbFM2";
            this.rbFM2.Size = new System.Drawing.Size(45, 16);
            this.rbFM2.TabIndex = 1;
            this.rbFM2.Text = "FM2";
            this.rbFM2.UseVisualStyleBackColor = true;
            // 
            // rbFM4
            // 
            this.rbFM4.AutoSize = true;
            this.rbFM4.Location = new System.Drawing.Point(6, 40);
            this.rbFM4.Name = "rbFM4";
            this.rbFM4.Size = new System.Drawing.Size(45, 16);
            this.rbFM4.TabIndex = 3;
            this.rbFM4.Text = "FM4";
            this.rbFM4.UseVisualStyleBackColor = true;
            // 
            // rbFM1
            // 
            this.rbFM1.AutoSize = true;
            this.rbFM1.Checked = true;
            this.rbFM1.Location = new System.Drawing.Point(6, 18);
            this.rbFM1.Name = "rbFM1";
            this.rbFM1.Size = new System.Drawing.Size(45, 16);
            this.rbFM1.TabIndex = 0;
            this.rbFM1.TabStop = true;
            this.rbFM1.Text = "FM1";
            this.rbFM1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFM1);
            this.groupBox2.Controls.Add(this.cbFM6);
            this.groupBox2.Controls.Add(this.cbFM2);
            this.groupBox2.Controls.Add(this.cbFM5);
            this.groupBox2.Controls.Add(this.cbFM3);
            this.groupBox2.Controls.Add(this.cbFM4);
            this.groupBox2.Location = new System.Drawing.Point(209, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 62);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cbFM1
            // 
            this.cbFM1.AutoSize = true;
            this.cbFM1.Checked = true;
            this.cbFM1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM1.Location = new System.Drawing.Point(6, 18);
            this.cbFM1.Name = "cbFM1";
            this.cbFM1.Size = new System.Drawing.Size(46, 16);
            this.cbFM1.TabIndex = 0;
            this.cbFM1.Text = "FM1";
            this.cbFM1.UseVisualStyleBackColor = true;
            // 
            // cbFM6
            // 
            this.cbFM6.AutoSize = true;
            this.cbFM6.Checked = true;
            this.cbFM6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM6.Location = new System.Drawing.Point(110, 40);
            this.cbFM6.Name = "cbFM6";
            this.cbFM6.Size = new System.Drawing.Size(46, 16);
            this.cbFM6.TabIndex = 5;
            this.cbFM6.Text = "FM6";
            this.cbFM6.UseVisualStyleBackColor = true;
            // 
            // cbFM2
            // 
            this.cbFM2.AutoSize = true;
            this.cbFM2.Checked = true;
            this.cbFM2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM2.Location = new System.Drawing.Point(58, 18);
            this.cbFM2.Name = "cbFM2";
            this.cbFM2.Size = new System.Drawing.Size(46, 16);
            this.cbFM2.TabIndex = 1;
            this.cbFM2.Text = "FM2";
            this.cbFM2.UseVisualStyleBackColor = true;
            // 
            // cbFM5
            // 
            this.cbFM5.AutoSize = true;
            this.cbFM5.Checked = true;
            this.cbFM5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM5.Location = new System.Drawing.Point(58, 40);
            this.cbFM5.Name = "cbFM5";
            this.cbFM5.Size = new System.Drawing.Size(46, 16);
            this.cbFM5.TabIndex = 4;
            this.cbFM5.Text = "FM5";
            this.cbFM5.UseVisualStyleBackColor = true;
            // 
            // cbFM3
            // 
            this.cbFM3.AutoSize = true;
            this.cbFM3.Checked = true;
            this.cbFM3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM3.Location = new System.Drawing.Point(110, 18);
            this.cbFM3.Name = "cbFM3";
            this.cbFM3.Size = new System.Drawing.Size(46, 16);
            this.cbFM3.TabIndex = 2;
            this.cbFM3.Text = "FM3";
            this.cbFM3.UseVisualStyleBackColor = true;
            // 
            // cbFM4
            // 
            this.cbFM4.AutoSize = true;
            this.cbFM4.Checked = true;
            this.cbFM4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFM4.Location = new System.Drawing.Point(6, 40);
            this.cbFM4.Name = "cbFM4";
            this.cbFM4.Size = new System.Drawing.Size(46, 16);
            this.cbFM4.TabIndex = 3;
            this.cbFM4.Text = "FM4";
            this.cbFM4.UseVisualStyleBackColor = true;
            // 
            // cmbMIDIIN
            // 
            this.cmbMIDIIN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbMIDIIN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMIDIIN.FormattingEnabled = true;
            this.cmbMIDIIN.Location = new System.Drawing.Point(72, 18);
            this.cmbMIDIIN.Name = "cmbMIDIIN";
            this.cmbMIDIIN.Size = new System.Drawing.Size(359, 20);
            this.cmbMIDIIN.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "MIDI IN";
            // 
            // tpKeyBoard
            // 
            this.tpKeyBoard.Controls.Add(this.btnInitializeShortCutKey);
            this.tpKeyBoard.Controls.Add(this.lblSKKey);
            this.tpKeyBoard.Controls.Add(this.dgvShortCutKey);
            this.tpKeyBoard.Location = new System.Drawing.Point(4, 22);
            this.tpKeyBoard.Name = "tpKeyBoard";
            this.tpKeyBoard.Size = new System.Drawing.Size(443, 400);
            this.tpKeyBoard.TabIndex = 13;
            this.tpKeyBoard.Text = "ショートカットキー";
            this.tpKeyBoard.UseVisualStyleBackColor = true;
            // 
            // btnInitializeShortCutKey
            // 
            this.btnInitializeShortCutKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInitializeShortCutKey.Location = new System.Drawing.Point(336, 369);
            this.btnInitializeShortCutKey.Name = "btnInitializeShortCutKey";
            this.btnInitializeShortCutKey.Size = new System.Drawing.Size(104, 23);
            this.btnInitializeShortCutKey.TabIndex = 31;
            this.btnInitializeShortCutKey.Text = "初期状態に戻す";
            this.btnInitializeShortCutKey.UseVisualStyleBackColor = true;
            this.btnInitializeShortCutKey.Click += new System.EventHandler(this.btnInitializeShortCutKey_Click);
            // 
            // lblSKKey
            // 
            this.lblSKKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSKKey.AutoSize = true;
            this.lblSKKey.Location = new System.Drawing.Point(42, 374);
            this.lblSKKey.Name = "lblSKKey";
            this.lblSKKey.Size = new System.Drawing.Size(0, 12);
            this.lblSKKey.TabIndex = 30;
            // 
            // dgvShortCutKey
            // 
            this.dgvShortCutKey.AllowUserToAddRows = false;
            this.dgvShortCutKey.AllowUserToDeleteRows = false;
            this.dgvShortCutKey.AllowUserToOrderColumns = true;
            this.dgvShortCutKey.AllowUserToResizeRows = false;
            this.dgvShortCutKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShortCutKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShortCutKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmNumber,
            this.clmFunc,
            this.clmShift,
            this.clmCtrl,
            this.clmAlt,
            this.clmKey,
            this.clmSet,
            this.clmClr,
            this.clmKBDSpacer});
            this.dgvShortCutKey.Location = new System.Drawing.Point(3, 3);
            this.dgvShortCutKey.MultiSelect = false;
            this.dgvShortCutKey.Name = "dgvShortCutKey";
            this.dgvShortCutKey.RowHeadersVisible = false;
            this.dgvShortCutKey.RowTemplate.Height = 21;
            this.dgvShortCutKey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShortCutKey.Size = new System.Drawing.Size(437, 353);
            this.dgvShortCutKey.TabIndex = 29;
            this.dgvShortCutKey.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShortCutKey_CellContentClick);
            // 
            // clmNumber
            // 
            this.clmNumber.HeaderText = "Number";
            this.clmNumber.Name = "clmNumber";
            this.clmNumber.Visible = false;
            // 
            // clmFunc
            // 
            this.clmFunc.HeaderText = "機能";
            this.clmFunc.Name = "clmFunc";
            this.clmFunc.ReadOnly = true;
            this.clmFunc.Width = 150;
            // 
            // clmShift
            // 
            this.clmShift.HeaderText = "Shift";
            this.clmShift.Name = "clmShift";
            this.clmShift.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmShift.Width = 40;
            // 
            // clmCtrl
            // 
            this.clmCtrl.HeaderText = "Ctrl";
            this.clmCtrl.Name = "clmCtrl";
            this.clmCtrl.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmCtrl.Width = 40;
            // 
            // clmAlt
            // 
            this.clmAlt.HeaderText = "Alt";
            this.clmAlt.Name = "clmAlt";
            this.clmAlt.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmAlt.Width = 40;
            // 
            // clmKey
            // 
            this.clmKey.HeaderText = "Key";
            this.clmKey.Name = "clmKey";
            this.clmKey.ReadOnly = true;
            this.clmKey.Width = 50;
            // 
            // clmSet
            // 
            this.clmSet.HeaderText = "Set";
            this.clmSet.Name = "clmSet";
            this.clmSet.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmSet.Text = "Set";
            this.clmSet.Width = 40;
            // 
            // clmClr
            // 
            this.clmClr.HeaderText = "Clr";
            this.clmClr.Name = "clmClr";
            this.clmClr.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmClr.Text = "Clr";
            this.clmClr.Width = 40;
            // 
            // clmKBDSpacer
            // 
            this.clmKBDSpacer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmKBDSpacer.HeaderText = "";
            this.clmKBDSpacer.Name = "clmKBDSpacer";
            this.clmKBDSpacer.ReadOnly = true;
            this.clmKBDSpacer.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clmKBDSpacer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tpBalance
            // 
            this.tpBalance.Controls.Add(this.groupBox25);
            this.tpBalance.Controls.Add(this.cbAutoBalanceUseThis);
            this.tpBalance.Controls.Add(this.groupBox18);
            this.tpBalance.Location = new System.Drawing.Point(4, 22);
            this.tpBalance.Name = "tpBalance";
            this.tpBalance.Size = new System.Drawing.Size(443, 400);
            this.tpBalance.TabIndex = 12;
            this.tpBalance.Text = "ミキサーバランス";
            this.tpBalance.UseVisualStyleBackColor = true;
            // 
            // groupBox25
            // 
            this.groupBox25.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox25.Controls.Add(this.rbAutoBalanceNotSamePositionAsSongData);
            this.groupBox25.Controls.Add(this.rbAutoBalanceSamePositionAsSongData);
            this.groupBox25.Location = new System.Drawing.Point(7, 327);
            this.groupBox25.Name = "groupBox25";
            this.groupBox25.Size = new System.Drawing.Size(433, 41);
            this.groupBox25.TabIndex = 1;
            this.groupBox25.TabStop = false;
            this.groupBox25.Text = "ソングミキサーバランス参照フォルダー";
            // 
            // rbAutoBalanceNotSamePositionAsSongData
            // 
            this.rbAutoBalanceNotSamePositionAsSongData.AutoSize = true;
            this.rbAutoBalanceNotSamePositionAsSongData.Checked = true;
            this.rbAutoBalanceNotSamePositionAsSongData.Location = new System.Drawing.Point(6, 18);
            this.rbAutoBalanceNotSamePositionAsSongData.Name = "rbAutoBalanceNotSamePositionAsSongData";
            this.rbAutoBalanceNotSamePositionAsSongData.Size = new System.Drawing.Size(110, 16);
            this.rbAutoBalanceNotSamePositionAsSongData.TabIndex = 0;
            this.rbAutoBalanceNotSamePositionAsSongData.TabStop = true;
            this.rbAutoBalanceNotSamePositionAsSongData.Text = "設定ファイルと同じ";
            this.rbAutoBalanceNotSamePositionAsSongData.UseVisualStyleBackColor = true;
            // 
            // rbAutoBalanceSamePositionAsSongData
            // 
            this.rbAutoBalanceSamePositionAsSongData.AutoSize = true;
            this.rbAutoBalanceSamePositionAsSongData.Location = new System.Drawing.Point(122, 18);
            this.rbAutoBalanceSamePositionAsSongData.Name = "rbAutoBalanceSamePositionAsSongData";
            this.rbAutoBalanceSamePositionAsSongData.Size = new System.Drawing.Size(92, 16);
            this.rbAutoBalanceSamePositionAsSongData.TabIndex = 0;
            this.rbAutoBalanceSamePositionAsSongData.Text = "曲データと同じ";
            this.rbAutoBalanceSamePositionAsSongData.UseVisualStyleBackColor = true;
            // 
            // cbAutoBalanceUseThis
            // 
            this.cbAutoBalanceUseThis.AutoSize = true;
            this.cbAutoBalanceUseThis.Checked = true;
            this.cbAutoBalanceUseThis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAutoBalanceUseThis.Location = new System.Drawing.Point(13, 3);
            this.cbAutoBalanceUseThis.Name = "cbAutoBalanceUseThis";
            this.cbAutoBalanceUseThis.Size = new System.Drawing.Size(221, 16);
            this.cbAutoBalanceUseThis.TabIndex = 1;
            this.cbAutoBalanceUseThis.Text = "ミキサーバランス自動設定機能を使用する";
            this.cbAutoBalanceUseThis.UseVisualStyleBackColor = true;
            // 
            // groupBox18
            // 
            this.groupBox18.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox18.Controls.Add(this.groupBox24);
            this.groupBox18.Controls.Add(this.groupBox23);
            this.groupBox18.Location = new System.Drawing.Point(7, 3);
            this.groupBox18.Name = "groupBox18";
            this.groupBox18.Size = new System.Drawing.Size(433, 318);
            this.groupBox18.TabIndex = 0;
            this.groupBox18.TabStop = false;
            // 
            // groupBox24
            // 
            this.groupBox24.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox24.Controls.Add(this.groupBox21);
            this.groupBox24.Controls.Add(this.groupBox22);
            this.groupBox24.Location = new System.Drawing.Point(6, 185);
            this.groupBox24.Name = "groupBox24";
            this.groupBox24.Size = new System.Drawing.Size(421, 127);
            this.groupBox24.TabIndex = 1;
            this.groupBox24.TabStop = false;
            this.groupBox24.Text = "保存";
            // 
            // groupBox21
            // 
            this.groupBox21.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox21.Controls.Add(this.rbAutoBalanceNotSaveSongBalance);
            this.groupBox21.Controls.Add(this.rbAutoBalanceSaveSongBalance);
            this.groupBox21.Location = new System.Drawing.Point(6, 18);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Size = new System.Drawing.Size(409, 62);
            this.groupBox21.TabIndex = 0;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "ソングミキサーバランス(曲データ毎)";
            // 
            // rbAutoBalanceNotSaveSongBalance
            // 
            this.rbAutoBalanceNotSaveSongBalance.AutoSize = true;
            this.rbAutoBalanceNotSaveSongBalance.Checked = true;
            this.rbAutoBalanceNotSaveSongBalance.Location = new System.Drawing.Point(6, 40);
            this.rbAutoBalanceNotSaveSongBalance.Name = "rbAutoBalanceNotSaveSongBalance";
            this.rbAutoBalanceNotSaveSongBalance.Size = new System.Drawing.Size(153, 16);
            this.rbAutoBalanceNotSaveSongBalance.TabIndex = 0;
            this.rbAutoBalanceNotSaveSongBalance.TabStop = true;
            this.rbAutoBalanceNotSaveSongBalance.Text = "保存しない(手動保存のみ)";
            this.rbAutoBalanceNotSaveSongBalance.UseVisualStyleBackColor = true;
            // 
            // rbAutoBalanceSaveSongBalance
            // 
            this.rbAutoBalanceSaveSongBalance.AutoSize = true;
            this.rbAutoBalanceSaveSongBalance.Location = new System.Drawing.Point(6, 18);
            this.rbAutoBalanceSaveSongBalance.Name = "rbAutoBalanceSaveSongBalance";
            this.rbAutoBalanceSaveSongBalance.Size = new System.Drawing.Size(150, 16);
            this.rbAutoBalanceSaveSongBalance.TabIndex = 0;
            this.rbAutoBalanceSaveSongBalance.Text = "演奏停止時に自動で保存";
            this.rbAutoBalanceSaveSongBalance.UseVisualStyleBackColor = true;
            // 
            // groupBox22
            // 
            this.groupBox22.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox22.Controls.Add(this.label4);
            this.groupBox22.Location = new System.Drawing.Point(6, 86);
            this.groupBox22.Name = "groupBox22";
            this.groupBox22.Size = new System.Drawing.Size(409, 35);
            this.groupBox22.TabIndex = 0;
            this.groupBox22.TabStop = false;
            this.groupBox22.Text = "ドライバーミキサーバランス(ドライバ毎)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "手動保存のみ";
            // 
            // groupBox23
            // 
            this.groupBox23.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox23.Controls.Add(this.groupBox19);
            this.groupBox23.Controls.Add(this.groupBox20);
            this.groupBox23.Location = new System.Drawing.Point(6, 22);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(421, 157);
            this.groupBox23.TabIndex = 1;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "読み込み";
            // 
            // groupBox19
            // 
            this.groupBox19.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox19.Controls.Add(this.rbAutoBalanceNotLoadSongBalance);
            this.groupBox19.Controls.Add(this.rbAutoBalanceLoadSongBalance);
            this.groupBox19.Location = new System.Drawing.Point(6, 18);
            this.groupBox19.Name = "groupBox19";
            this.groupBox19.Size = new System.Drawing.Size(409, 63);
            this.groupBox19.TabIndex = 0;
            this.groupBox19.TabStop = false;
            this.groupBox19.Text = "ソングミキサーバランス(曲データ毎)";
            // 
            // rbAutoBalanceNotLoadSongBalance
            // 
            this.rbAutoBalanceNotLoadSongBalance.AutoSize = true;
            this.rbAutoBalanceNotLoadSongBalance.Checked = true;
            this.rbAutoBalanceNotLoadSongBalance.Location = new System.Drawing.Point(6, 40);
            this.rbAutoBalanceNotLoadSongBalance.Name = "rbAutoBalanceNotLoadSongBalance";
            this.rbAutoBalanceNotLoadSongBalance.Size = new System.Drawing.Size(102, 16);
            this.rbAutoBalanceNotLoadSongBalance.TabIndex = 0;
            this.rbAutoBalanceNotLoadSongBalance.TabStop = true;
            this.rbAutoBalanceNotLoadSongBalance.Text = "手動で読み込む";
            this.rbAutoBalanceNotLoadSongBalance.UseVisualStyleBackColor = true;
            // 
            // rbAutoBalanceLoadSongBalance
            // 
            this.rbAutoBalanceLoadSongBalance.AutoSize = true;
            this.rbAutoBalanceLoadSongBalance.Location = new System.Drawing.Point(6, 18);
            this.rbAutoBalanceLoadSongBalance.Name = "rbAutoBalanceLoadSongBalance";
            this.rbAutoBalanceLoadSongBalance.Size = new System.Drawing.Size(147, 16);
            this.rbAutoBalanceLoadSongBalance.TabIndex = 0;
            this.rbAutoBalanceLoadSongBalance.Text = "再生時に自動で読み込む";
            this.rbAutoBalanceLoadSongBalance.UseVisualStyleBackColor = true;
            // 
            // groupBox20
            // 
            this.groupBox20.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox20.Controls.Add(this.rbAutoBalanceNotLoadDriverBalance);
            this.groupBox20.Controls.Add(this.rbAutoBalanceLoadDriverBalance);
            this.groupBox20.Location = new System.Drawing.Point(6, 87);
            this.groupBox20.Name = "groupBox20";
            this.groupBox20.Size = new System.Drawing.Size(409, 63);
            this.groupBox20.TabIndex = 0;
            this.groupBox20.TabStop = false;
            this.groupBox20.Text = "ドライバーミキサーバランス(ドライバ毎)";
            // 
            // rbAutoBalanceNotLoadDriverBalance
            // 
            this.rbAutoBalanceNotLoadDriverBalance.AutoSize = true;
            this.rbAutoBalanceNotLoadDriverBalance.Location = new System.Drawing.Point(6, 40);
            this.rbAutoBalanceNotLoadDriverBalance.Name = "rbAutoBalanceNotLoadDriverBalance";
            this.rbAutoBalanceNotLoadDriverBalance.Size = new System.Drawing.Size(102, 16);
            this.rbAutoBalanceNotLoadDriverBalance.TabIndex = 0;
            this.rbAutoBalanceNotLoadDriverBalance.Text = "手動で読み込む";
            this.rbAutoBalanceNotLoadDriverBalance.UseVisualStyleBackColor = true;
            // 
            // rbAutoBalanceLoadDriverBalance
            // 
            this.rbAutoBalanceLoadDriverBalance.AutoSize = true;
            this.rbAutoBalanceLoadDriverBalance.Checked = true;
            this.rbAutoBalanceLoadDriverBalance.Location = new System.Drawing.Point(6, 18);
            this.rbAutoBalanceLoadDriverBalance.Name = "rbAutoBalanceLoadDriverBalance";
            this.rbAutoBalanceLoadDriverBalance.Size = new System.Drawing.Size(343, 16);
            this.rbAutoBalanceLoadDriverBalance.TabIndex = 0;
            this.rbAutoBalanceLoadDriverBalance.TabStop = true;
            this.rbAutoBalanceLoadDriverBalance.Text = "再生時に自動で読み込む(曲データ毎のバランスファイルが無い場合)";
            this.rbAutoBalanceLoadDriverBalance.UseVisualStyleBackColor = true;
            // 
            // tpOther
            // 
            this.tpOther.Controls.Add(this.cbWavSwitch);
            this.tpOther.Controls.Add(this.groupBox17);
            this.tpOther.Controls.Add(this.cbUseGetInst);
            this.tpOther.Controls.Add(this.groupBox4);
            this.tpOther.Controls.Add(this.cbDumpSwitch);
            this.tpOther.Controls.Add(this.gbWav);
            this.tpOther.Controls.Add(this.gbDump);
            this.tpOther.Controls.Add(this.label30);
            this.tpOther.Controls.Add(this.tbScreenFrameRate);
            this.tpOther.Controls.Add(this.label29);
            this.tpOther.Controls.Add(this.lblLoopTimes);
            this.tpOther.Controls.Add(this.btnDataPath);
            this.tpOther.Controls.Add(this.tbLoopTimes);
            this.tpOther.Controls.Add(this.tbDataPath);
            this.tpOther.Controls.Add(this.label19);
            this.tpOther.Controls.Add(this.btnResetPosition);
            this.tpOther.Controls.Add(this.btnOpenSettingFolder);
            this.tpOther.Controls.Add(this.cbEmptyPlayList);
            this.tpOther.Controls.Add(this.cbInitAlways);
            this.tpOther.Controls.Add(this.cbAutoOpen);
            this.tpOther.Controls.Add(this.cbUseLoopTimes);
            this.tpOther.Location = new System.Drawing.Point(4, 22);
            this.tpOther.Name = "tpOther";
            this.tpOther.Size = new System.Drawing.Size(443, 400);
            this.tpOther.TabIndex = 2;
            this.tpOther.Text = "Other";
            this.tpOther.UseVisualStyleBackColor = true;
            // 
            // cbWavSwitch
            // 
            this.cbWavSwitch.AutoSize = true;
            this.cbWavSwitch.Location = new System.Drawing.Point(14, 202);
            this.cbWavSwitch.Name = "cbWavSwitch";
            this.cbWavSwitch.Size = new System.Drawing.Size(177, 16);
            this.cbWavSwitch.TabIndex = 0;
            this.cbWavSwitch.Text = "演奏時に.wavファイルを出力する";
            this.cbWavSwitch.UseVisualStyleBackColor = true;
            this.cbWavSwitch.CheckedChanged += new System.EventHandler(this.cbWavSwitch_CheckedChanged);
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.tbImageExt);
            this.groupBox17.Controls.Add(this.tbMMLExt);
            this.groupBox17.Controls.Add(this.tbTextExt);
            this.groupBox17.Controls.Add(this.label1);
            this.groupBox17.Controls.Add(this.label3);
            this.groupBox17.Controls.Add(this.label2);
            this.groupBox17.Location = new System.Drawing.Point(7, 256);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Size = new System.Drawing.Size(227, 83);
            this.groupBox17.TabIndex = 1;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "File Extension";
            // 
            // tbImageExt
            // 
            this.tbImageExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbImageExt.Location = new System.Drawing.Point(52, 58);
            this.tbImageExt.Name = "tbImageExt";
            this.tbImageExt.Size = new System.Drawing.Size(164, 19);
            this.tbImageExt.TabIndex = 1;
            // 
            // tbMMLExt
            // 
            this.tbMMLExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbMMLExt.Location = new System.Drawing.Point(52, 35);
            this.tbMMLExt.Name = "tbMMLExt";
            this.tbMMLExt.Size = new System.Drawing.Size(164, 19);
            this.tbMMLExt.TabIndex = 1;
            // 
            // tbTextExt
            // 
            this.tbTextExt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTextExt.Location = new System.Drawing.Point(52, 12);
            this.tbTextExt.Name = "tbTextExt";
            this.tbTextExt.Size = new System.Drawing.Size(164, 19);
            this.tbTextExt.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "MML";
            // 
            // cbUseGetInst
            // 
            this.cbUseGetInst.AutoSize = true;
            this.cbUseGetInst.Location = new System.Drawing.Point(14, 31);
            this.cbUseGetInst.Name = "cbUseGetInst";
            this.cbUseGetInst.Size = new System.Drawing.Size(286, 16);
            this.cbUseGetInst.TabIndex = 12;
            this.cbUseGetInst.Text = "音色欄をクリック時、その音色をクリップボードにコピーする";
            this.cbUseGetInst.UseVisualStyleBackColor = true;
            this.cbUseGetInst.CheckedChanged += new System.EventHandler(this.cbUseGetInst_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cmbInstFormat);
            this.groupBox4.Controls.Add(this.lblInstFormat);
            this.groupBox4.Location = new System.Drawing.Point(7, 31);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(433, 45);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // cmbInstFormat
            // 
            this.cmbInstFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInstFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInstFormat.FormattingEnabled = true;
            this.cmbInstFormat.Items.AddRange(new object[] {
            "FMP7",
            "MDX",
            ".TFI(ファイル出力)",
            "MUSIC LALF #1",
            "MUSIC LALF #2",
            "MML2VGM",
            "NRTDRV",
            "HuSIC"});
            this.cmbInstFormat.Location = new System.Drawing.Point(298, 19);
            this.cmbInstFormat.Name = "cmbInstFormat";
            this.cmbInstFormat.Size = new System.Drawing.Size(129, 20);
            this.cmbInstFormat.TabIndex = 18;
            // 
            // lblInstFormat
            // 
            this.lblInstFormat.AutoSize = true;
            this.lblInstFormat.Location = new System.Drawing.Point(237, 22);
            this.lblInstFormat.Name = "lblInstFormat";
            this.lblInstFormat.Size = new System.Drawing.Size(55, 12);
            this.lblInstFormat.TabIndex = 17;
            this.lblInstFormat.Text = "フォーマット";
            // 
            // cbDumpSwitch
            // 
            this.cbDumpSwitch.AutoSize = true;
            this.cbDumpSwitch.Location = new System.Drawing.Point(14, 152);
            this.cbDumpSwitch.Name = "cbDumpSwitch";
            this.cbDumpSwitch.Size = new System.Drawing.Size(220, 16);
            this.cbDumpSwitch.TabIndex = 0;
            this.cbDumpSwitch.Text = "DataBlock処理時にその内容をダンプする";
            this.cbDumpSwitch.UseVisualStyleBackColor = true;
            this.cbDumpSwitch.CheckedChanged += new System.EventHandler(this.cbDumpSwitch_CheckedChanged);
            // 
            // gbWav
            // 
            this.gbWav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbWav.Controls.Add(this.btnWavPath);
            this.gbWav.Controls.Add(this.label7);
            this.gbWav.Controls.Add(this.tbWavPath);
            this.gbWav.Location = new System.Drawing.Point(7, 205);
            this.gbWav.Name = "gbWav";
            this.gbWav.Size = new System.Drawing.Size(433, 45);
            this.gbWav.TabIndex = 22;
            this.gbWav.TabStop = false;
            // 
            // btnWavPath
            // 
            this.btnWavPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWavPath.Location = new System.Drawing.Point(404, 16);
            this.btnWavPath.Name = "btnWavPath";
            this.btnWavPath.Size = new System.Drawing.Size(23, 23);
            this.btnWavPath.TabIndex = 16;
            this.btnWavPath.Text = "...";
            this.btnWavPath.UseVisualStyleBackColor = true;
            this.btnWavPath.Click += new System.EventHandler(this.btnWavPath_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "出力Path";
            // 
            // tbWavPath
            // 
            this.tbWavPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbWavPath.Location = new System.Drawing.Point(73, 18);
            this.tbWavPath.Name = "tbWavPath";
            this.tbWavPath.Size = new System.Drawing.Size(325, 19);
            this.tbWavPath.TabIndex = 15;
            // 
            // gbDump
            // 
            this.gbDump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDump.Controls.Add(this.btnDumpPath);
            this.gbDump.Controls.Add(this.label6);
            this.gbDump.Controls.Add(this.tbDumpPath);
            this.gbDump.Location = new System.Drawing.Point(7, 154);
            this.gbDump.Name = "gbDump";
            this.gbDump.Size = new System.Drawing.Size(433, 45);
            this.gbDump.TabIndex = 22;
            this.gbDump.TabStop = false;
            // 
            // btnDumpPath
            // 
            this.btnDumpPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDumpPath.Location = new System.Drawing.Point(404, 16);
            this.btnDumpPath.Name = "btnDumpPath";
            this.btnDumpPath.Size = new System.Drawing.Size(23, 23);
            this.btnDumpPath.TabIndex = 16;
            this.btnDumpPath.Text = "...";
            this.btnDumpPath.UseVisualStyleBackColor = true;
            this.btnDumpPath.Click += new System.EventHandler(this.btnDumpPath_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "出力Path";
            // 
            // tbDumpPath
            // 
            this.tbDumpPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDumpPath.Location = new System.Drawing.Point(73, 18);
            this.tbDumpPath.Name = "tbDumpPath";
            this.tbDumpPath.Size = new System.Drawing.Size(325, 19);
            this.tbDumpPath.TabIndex = 15;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(136, 132);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(30, 12);
            this.label30.TabIndex = 21;
            this.label30.Text = "Hz/s";
            // 
            // tbScreenFrameRate
            // 
            this.tbScreenFrameRate.Location = new System.Drawing.Point(80, 129);
            this.tbScreenFrameRate.Name = "tbScreenFrameRate";
            this.tbScreenFrameRate.Size = new System.Drawing.Size(50, 19);
            this.tbScreenFrameRate.TabIndex = 20;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 132);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(69, 12);
            this.label29.TabIndex = 19;
            this.label29.Text = "フレームレート";
            // 
            // lblLoopTimes
            // 
            this.lblLoopTimes.AutoSize = true;
            this.lblLoopTimes.Location = new System.Drawing.Point(340, 8);
            this.lblLoopTimes.Name = "lblLoopTimes";
            this.lblLoopTimes.Size = new System.Drawing.Size(17, 12);
            this.lblLoopTimes.TabIndex = 1;
            this.lblLoopTimes.Text = "回";
            // 
            // btnDataPath
            // 
            this.btnDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDataPath.Location = new System.Drawing.Point(411, 102);
            this.btnDataPath.Name = "btnDataPath";
            this.btnDataPath.Size = new System.Drawing.Size(23, 23);
            this.btnDataPath.TabIndex = 16;
            this.btnDataPath.Text = "...";
            this.btnDataPath.UseVisualStyleBackColor = true;
            this.btnDataPath.Click += new System.EventHandler(this.btnDataPath_Click);
            // 
            // tbLoopTimes
            // 
            this.tbLoopTimes.Location = new System.Drawing.Point(282, 5);
            this.tbLoopTimes.Name = "tbLoopTimes";
            this.tbLoopTimes.Size = new System.Drawing.Size(52, 19);
            this.tbLoopTimes.TabIndex = 0;
            // 
            // tbDataPath
            // 
            this.tbDataPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDataPath.Location = new System.Drawing.Point(80, 104);
            this.tbDataPath.Name = "tbDataPath";
            this.tbDataPath.Size = new System.Drawing.Size(325, 19);
            this.tbDataPath.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(5, 107);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 12);
            this.label19.TabIndex = 14;
            this.label19.Text = "データPath";
            // 
            // btnResetPosition
            // 
            this.btnResetPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetPosition.Location = new System.Drawing.Point(167, 345);
            this.btnResetPosition.Name = "btnResetPosition";
            this.btnResetPosition.Size = new System.Drawing.Size(142, 23);
            this.btnResetPosition.TabIndex = 13;
            this.btnResetPosition.Text = "ウィンドウ位置をリセット";
            this.btnResetPosition.UseVisualStyleBackColor = true;
            this.btnResetPosition.Click += new System.EventHandler(this.btnResetPosition_Click);
            // 
            // btnOpenSettingFolder
            // 
            this.btnOpenSettingFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpenSettingFolder.Location = new System.Drawing.Point(315, 345);
            this.btnOpenSettingFolder.Name = "btnOpenSettingFolder";
            this.btnOpenSettingFolder.Size = new System.Drawing.Size(125, 23);
            this.btnOpenSettingFolder.TabIndex = 13;
            this.btnOpenSettingFolder.Text = "設定フォルダーを開く";
            this.btnOpenSettingFolder.UseVisualStyleBackColor = true;
            this.btnOpenSettingFolder.Click += new System.EventHandler(this.btnOpenSettingFolder_Click);
            // 
            // cbEmptyPlayList
            // 
            this.cbEmptyPlayList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbEmptyPlayList.AutoSize = true;
            this.cbEmptyPlayList.Location = new System.Drawing.Point(240, 308);
            this.cbEmptyPlayList.Name = "cbEmptyPlayList";
            this.cbEmptyPlayList.Size = new System.Drawing.Size(177, 16);
            this.cbEmptyPlayList.TabIndex = 0;
            this.cbEmptyPlayList.Text = "起動時にプレイリストを空にする。";
            this.cbEmptyPlayList.UseVisualStyleBackColor = true;
            this.cbEmptyPlayList.CheckedChanged += new System.EventHandler(this.cbUseLoopTimes_CheckedChanged);
            // 
            // cbInitAlways
            // 
            this.cbInitAlways.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbInitAlways.Location = new System.Drawing.Point(240, 263);
            this.cbInitAlways.Name = "cbInitAlways";
            this.cbInitAlways.Size = new System.Drawing.Size(194, 39);
            this.cbInitAlways.TabIndex = 0;
            this.cbInitAlways.Text = "再生開始時に必ずデバイスを初期化する。";
            this.cbInitAlways.UseVisualStyleBackColor = true;
            this.cbInitAlways.CheckedChanged += new System.EventHandler(this.cbUseLoopTimes_CheckedChanged);
            // 
            // cbAutoOpen
            // 
            this.cbAutoOpen.AutoSize = true;
            this.cbAutoOpen.Location = new System.Drawing.Point(7, 82);
            this.cbAutoOpen.Name = "cbAutoOpen";
            this.cbAutoOpen.Size = new System.Drawing.Size(167, 16);
            this.cbAutoOpen.TabIndex = 0;
            this.cbAutoOpen.Text = "使用音源の画面を自動で開く";
            this.cbAutoOpen.UseVisualStyleBackColor = true;
            this.cbAutoOpen.CheckedChanged += new System.EventHandler(this.cbUseLoopTimes_CheckedChanged);
            // 
            // cbUseLoopTimes
            // 
            this.cbUseLoopTimes.AutoSize = true;
            this.cbUseLoopTimes.Location = new System.Drawing.Point(7, 7);
            this.cbUseLoopTimes.Name = "cbUseLoopTimes";
            this.cbUseLoopTimes.Size = new System.Drawing.Size(216, 16);
            this.cbUseLoopTimes.TabIndex = 0;
            this.cbUseLoopTimes.Text = "無限ループ時、指定の回数だけ繰り返す";
            this.cbUseLoopTimes.UseVisualStyleBackColor = true;
            this.cbUseLoopTimes.CheckedChanged += new System.EventHandler(this.cbUseLoopTimes_CheckedChanged);
            // 
            // tpOmake
            // 
            this.tpOmake.Controls.Add(this.cbClearHistory);
            this.tpOmake.Controls.Add(this.groupBox31);
            this.tpOmake.Controls.Add(this.groupBox30);
            this.tpOmake.Controls.Add(this.cbRequestCacheClear);
            this.tpOmake.Controls.Add(this.cbUseSIen);
            this.tpOmake.Controls.Add(this.cbInfiniteOfflineMode);
            this.tpOmake.Controls.Add(this.groupBox29);
            this.tpOmake.Controls.Add(this.tbOpacity);
            this.tpOmake.Controls.Add(this.label52);
            this.tpOmake.Controls.Add(this.label14);
            this.tpOmake.Controls.Add(this.btVST);
            this.tpOmake.Controls.Add(this.tbVST);
            this.tpOmake.Controls.Add(this.groupBox5);
            this.tpOmake.Location = new System.Drawing.Point(4, 22);
            this.tpOmake.Name = "tpOmake";
            this.tpOmake.Size = new System.Drawing.Size(443, 400);
            this.tpOmake.TabIndex = 7;
            this.tpOmake.Text = "おまけ";
            this.tpOmake.UseVisualStyleBackColor = true;
            // 
            // cbClearHistory
            // 
            this.cbClearHistory.Location = new System.Drawing.Point(228, 137);
            this.cbClearHistory.Name = "cbClearHistory";
            this.cbClearHistory.Size = new System.Drawing.Size(204, 34);
            this.cbClearHistory.TabIndex = 26;
            this.cbClearHistory.Text = "ファイル保存時、ヒストリ(アンドゥ)をクリアする";
            this.cbClearHistory.UseVisualStyleBackColor = true;
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.rbLoglevelINFO);
            this.groupBox31.Controls.Add(this.rbLoglevelDEBUG);
            this.groupBox31.Controls.Add(this.rbLoglevelTRACE);
            this.groupBox31.Location = new System.Drawing.Point(192, 3);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(243, 43);
            this.groupBox31.TabIndex = 25;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Log level";
            // 
            // rbLoglevelINFO
            // 
            this.rbLoglevelINFO.AutoSize = true;
            this.rbLoglevelINFO.Checked = true;
            this.rbLoglevelINFO.Location = new System.Drawing.Point(11, 16);
            this.rbLoglevelINFO.Name = "rbLoglevelINFO";
            this.rbLoglevelINFO.Size = new System.Drawing.Size(49, 16);
            this.rbLoglevelINFO.TabIndex = 3;
            this.rbLoglevelINFO.TabStop = true;
            this.rbLoglevelINFO.Text = "INFO";
            this.rbLoglevelINFO.UseVisualStyleBackColor = true;
            // 
            // rbLoglevelDEBUG
            // 
            this.rbLoglevelDEBUG.AutoSize = true;
            this.rbLoglevelDEBUG.Location = new System.Drawing.Point(66, 16);
            this.rbLoglevelDEBUG.Name = "rbLoglevelDEBUG";
            this.rbLoglevelDEBUG.Size = new System.Drawing.Size(62, 16);
            this.rbLoglevelDEBUG.TabIndex = 3;
            this.rbLoglevelDEBUG.Text = "DEBUG";
            this.rbLoglevelDEBUG.UseVisualStyleBackColor = true;
            // 
            // rbLoglevelTRACE
            // 
            this.rbLoglevelTRACE.AutoSize = true;
            this.rbLoglevelTRACE.Location = new System.Drawing.Point(134, 16);
            this.rbLoglevelTRACE.Name = "rbLoglevelTRACE";
            this.rbLoglevelTRACE.Size = new System.Drawing.Size(61, 16);
            this.rbLoglevelTRACE.TabIndex = 3;
            this.rbLoglevelTRACE.Text = "TRACE";
            this.rbLoglevelTRACE.UseVisualStyleBackColor = true;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.rbQueryPerformanceCounter);
            this.groupBox30.Controls.Add(this.rbDateTime);
            this.groupBox30.Controls.Add(this.rbStopWatch);
            this.groupBox30.Location = new System.Drawing.Point(7, 285);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(236, 85);
            this.groupBox30.TabIndex = 24;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Music Interrupt Timer";
            // 
            // rbQueryPerformanceCounter
            // 
            this.rbQueryPerformanceCounter.AutoSize = true;
            this.rbQueryPerformanceCounter.Location = new System.Drawing.Point(6, 62);
            this.rbQueryPerformanceCounter.Name = "rbQueryPerformanceCounter";
            this.rbQueryPerformanceCounter.Size = new System.Drawing.Size(213, 16);
            this.rbQueryPerformanceCounter.TabIndex = 2;
            this.rbQueryPerformanceCounter.Text = "QueryPerformanceCounter(Win32API)";
            this.rbQueryPerformanceCounter.UseVisualStyleBackColor = true;
            // 
            // rbDateTime
            // 
            this.rbDateTime.AutoSize = true;
            this.rbDateTime.Location = new System.Drawing.Point(6, 40);
            this.rbDateTime.Name = "rbDateTime";
            this.rbDateTime.Size = new System.Drawing.Size(94, 16);
            this.rbDateTime.TabIndex = 1;
            this.rbDateTime.Text = "DateTime(C#)";
            this.rbDateTime.UseVisualStyleBackColor = true;
            // 
            // rbStopWatch
            // 
            this.rbStopWatch.AutoSize = true;
            this.rbStopWatch.Checked = true;
            this.rbStopWatch.Location = new System.Drawing.Point(6, 18);
            this.rbStopWatch.Name = "rbStopWatch";
            this.rbStopWatch.Size = new System.Drawing.Size(137, 16);
            this.rbStopWatch.TabIndex = 0;
            this.rbStopWatch.TabStop = true;
            this.rbStopWatch.Text = "Stopwatch(C#) default";
            this.rbStopWatch.UseVisualStyleBackColor = true;
            // 
            // cbRequestCacheClear
            // 
            this.cbRequestCacheClear.AutoSize = true;
            this.cbRequestCacheClear.Location = new System.Drawing.Point(16, 245);
            this.cbRequestCacheClear.Name = "cbRequestCacheClear";
            this.cbRequestCacheClear.Size = new System.Drawing.Size(209, 16);
            this.cbRequestCacheClear.TabIndex = 23;
            this.cbRequestCacheClear.Text = "音色のキャッシュをクリアする(要再起動)";
            this.cbRequestCacheClear.UseVisualStyleBackColor = true;
            // 
            // cbUseSIen
            // 
            this.cbUseSIen.AutoSize = true;
            this.cbUseSIen.Location = new System.Drawing.Point(162, 223);
            this.cbUseSIen.Name = "cbUseSIen";
            this.cbUseSIen.Size = new System.Drawing.Size(148, 16);
            this.cbUseSIen.TabIndex = 23;
            this.cbUseSIen.Text = "入力支援機能を使用する";
            this.cbUseSIen.UseVisualStyleBackColor = true;
            // 
            // cbInfiniteOfflineMode
            // 
            this.cbInfiniteOfflineMode.AutoSize = true;
            this.cbInfiniteOfflineMode.Location = new System.Drawing.Point(16, 223);
            this.cbInfiniteOfflineMode.Name = "cbInfiniteOfflineMode";
            this.cbInfiniteOfflineMode.Size = new System.Drawing.Size(140, 16);
            this.cbInfiniteOfflineMode.TabIndex = 23;
            this.cbInfiniteOfflineMode.Text = "永続的にオフラインモード";
            this.cbInfiniteOfflineMode.UseVisualStyleBackColor = true;
            // 
            // groupBox29
            // 
            this.groupBox29.Controls.Add(this.label36);
            this.groupBox29.Controls.Add(this.btFont);
            this.groupBox29.Controls.Add(this.label54);
            this.groupBox29.Controls.Add(this.lblFontName);
            this.groupBox29.Controls.Add(this.label53);
            this.groupBox29.Controls.Add(this.lblFontSize);
            this.groupBox29.Controls.Add(this.lblFontStyle);
            this.groupBox29.Location = new System.Drawing.Point(9, 132);
            this.groupBox29.Name = "groupBox29";
            this.groupBox29.Size = new System.Drawing.Size(213, 85);
            this.groupBox29.TabIndex = 21;
            this.groupBox29.TabStop = false;
            this.groupBox29.Text = "フォント";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(5, 15);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(34, 12);
            this.label36.TabIndex = 19;
            this.label36.Text = "Name";
            // 
            // btFont
            // 
            this.btFont.Location = new System.Drawing.Point(183, 55);
            this.btFont.Name = "btFont";
            this.btFont.Size = new System.Drawing.Size(23, 23);
            this.btFont.TabIndex = 18;
            this.btFont.Text = "...";
            this.btFont.UseVisualStyleBackColor = true;
            this.btFont.Click += new System.EventHandler(this.BtFont_Click);
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(5, 60);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(31, 12);
            this.label54.TabIndex = 19;
            this.label54.Text = "Style";
            // 
            // lblFontName
            // 
            this.lblFontName.AutoSize = true;
            this.lblFontName.Location = new System.Drawing.Point(55, 15);
            this.lblFontName.Name = "lblFontName";
            this.lblFontName.Size = new System.Drawing.Size(52, 12);
            this.lblFontName.TabIndex = 19;
            this.lblFontName.Text = "Consolas";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(5, 38);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(26, 12);
            this.label53.TabIndex = 19;
            this.label53.Text = "Size";
            // 
            // lblFontSize
            // 
            this.lblFontSize.AutoSize = true;
            this.lblFontSize.Location = new System.Drawing.Point(55, 38);
            this.lblFontSize.Name = "lblFontSize";
            this.lblFontSize.Size = new System.Drawing.Size(17, 12);
            this.lblFontSize.TabIndex = 19;
            this.lblFontSize.Text = "12";
            // 
            // lblFontStyle
            // 
            this.lblFontStyle.AutoSize = true;
            this.lblFontStyle.Location = new System.Drawing.Point(55, 60);
            this.lblFontStyle.Name = "lblFontStyle";
            this.lblFontStyle.Size = new System.Drawing.Size(44, 12);
            this.lblFontStyle.TabIndex = 19;
            this.lblFontStyle.Text = "Regular";
            // 
            // tbOpacity
            // 
            this.tbOpacity.Location = new System.Drawing.Point(292, 52);
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Minimum = 1;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(143, 45);
            this.tbOpacity.TabIndex = 20;
            this.tbOpacity.TickFrequency = 10;
            this.tbOpacity.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.tbOpacity.Value = 1;
            this.tbOpacity.Scroll += new System.EventHandler(this.tbOpacity_Scroll);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(190, 67);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(96, 12);
            this.label52.TabIndex = 19;
            this.label52.Text = "ウィンドウ不透明度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 379);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 12);
            this.label14.TabIndex = 19;
            this.label14.Text = "VST effect";
            this.label14.Visible = false;
            // 
            // btVST
            // 
            this.btVST.Location = new System.Drawing.Point(417, 374);
            this.btVST.Name = "btVST";
            this.btVST.Size = new System.Drawing.Size(23, 23);
            this.btVST.TabIndex = 18;
            this.btVST.Text = "...";
            this.btVST.UseVisualStyleBackColor = true;
            this.btVST.Visible = false;
            this.btVST.Click += new System.EventHandler(this.btVST_Click);
            // 
            // tbVST
            // 
            this.tbVST.Location = new System.Drawing.Point(88, 376);
            this.tbVST.Name = "tbVST";
            this.tbVST.Size = new System.Drawing.Size(323, 19);
            this.tbVST.TabIndex = 17;
            this.tbVST.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbSinWave);
            this.groupBox5.Controls.Add(this.cbPlayDeviceCB);
            this.groupBox5.Controls.Add(this.cbLogWarning);
            this.groupBox5.Controls.Add(this.cbDispFrameCounter);
            this.groupBox5.Location = new System.Drawing.Point(7, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(178, 112);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Debug Mode";
            // 
            // cbSinWave
            // 
            this.cbSinWave.AutoSize = true;
            this.cbSinWave.Location = new System.Drawing.Point(7, 85);
            this.cbSinWave.Name = "cbSinWave";
            this.cbSinWave.Size = new System.Drawing.Size(91, 16);
            this.cbSinWave.TabIndex = 2;
            this.cbSinWave.Text = "440Hz正弦波";
            this.cbSinWave.UseVisualStyleBackColor = true;
            // 
            // cbPlayDeviceCB
            // 
            this.cbPlayDeviceCB.AutoSize = true;
            this.cbPlayDeviceCB.Location = new System.Drawing.Point(6, 63);
            this.cbPlayDeviceCB.Name = "cbPlayDeviceCB";
            this.cbPlayDeviceCB.Size = new System.Drawing.Size(159, 16);
            this.cbPlayDeviceCB.TabIndex = 2;
            this.cbPlayDeviceCB.Text = "デバイスのコールバックで演奏";
            this.cbPlayDeviceCB.UseVisualStyleBackColor = true;
            // 
            // cbLogWarning
            // 
            this.cbLogWarning.AutoSize = true;
            this.cbLogWarning.Location = new System.Drawing.Point(6, 39);
            this.cbLogWarning.Name = "cbLogWarning";
            this.cbLogWarning.Size = new System.Drawing.Size(143, 16);
            this.cbLogWarning.TabIndex = 2;
            this.cbLogWarning.Text = "ログにWarningを出力する";
            this.cbLogWarning.UseVisualStyleBackColor = true;
            // 
            // cbDispFrameCounter
            // 
            this.cbDispFrameCounter.AutoSize = true;
            this.cbDispFrameCounter.Location = new System.Drawing.Point(6, 17);
            this.cbDispFrameCounter.Name = "cbDispFrameCounter";
            this.cbDispFrameCounter.Size = new System.Drawing.Size(123, 16);
            this.cbDispFrameCounter.TabIndex = 2;
            this.cbDispFrameCounter.Text = "Debugウィンドウ表示";
            this.cbDispFrameCounter.UseVisualStyleBackColor = true;
            // 
            // tpAbout
            // 
            this.tpAbout.Controls.Add(this.tableLayoutPanel);
            this.tpAbout.Location = new System.Drawing.Point(4, 22);
            this.tpAbout.Name = "tpAbout";
            this.tpAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tpAbout.Size = new System.Drawing.Size(443, 400);
            this.tpAbout.TabIndex = 1;
            this.tpAbout.Text = "About";
            this.tpAbout.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel.Controls.Add(this.logoPictureBox, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.labelProductName, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.labelVersion, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.labelCopyright, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.labelCompanyName, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.textBoxDescription, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.llOpenGithub, 1, 5);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 6;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.070175F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.33333F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.421053F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(437, 394);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPictureBox.Image = global::mml2vgmIDE.Properties.Resources.ccPlay;
            this.logoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.logoPictureBox.Name = "logoPictureBox";
            this.tableLayoutPanel.SetRowSpan(this.logoPictureBox, 6);
            this.logoPictureBox.Size = new System.Drawing.Size(138, 388);
            this.logoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.logoPictureBox.TabIndex = 12;
            this.logoPictureBox.TabStop = false;
            // 
            // labelProductName
            // 
            this.labelProductName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelProductName.Location = new System.Drawing.Point(150, 0);
            this.labelProductName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelProductName.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelProductName.Name = "labelProductName";
            this.labelProductName.Size = new System.Drawing.Size(284, 16);
            this.labelProductName.TabIndex = 19;
            this.labelProductName.Text = "製品名";
            this.labelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelVersion.Location = new System.Drawing.Point(150, 39);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelVersion.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(284, 16);
            this.labelVersion.TabIndex = 0;
            this.labelVersion.Text = "バージョン";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCopyright.Location = new System.Drawing.Point(150, 78);
            this.labelCopyright.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCopyright.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(284, 16);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "著作権";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelCompanyName
            // 
            this.labelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCompanyName.Location = new System.Drawing.Point(150, 117);
            this.labelCompanyName.Margin = new System.Windows.Forms.Padding(6, 0, 3, 0);
            this.labelCompanyName.MaximumSize = new System.Drawing.Size(0, 16);
            this.labelCompanyName.Name = "labelCompanyName";
            this.labelCompanyName.Size = new System.Drawing.Size(284, 16);
            this.labelCompanyName.TabIndex = 22;
            this.labelCompanyName.Text = "会社名";
            this.labelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxDescription.Location = new System.Drawing.Point(150, 151);
            this.textBoxDescription.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = true;
            this.textBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDescription.Size = new System.Drawing.Size(284, 204);
            this.textBoxDescription.TabIndex = 23;
            this.textBoxDescription.TabStop = false;
            this.textBoxDescription.Text = "説明";
            // 
            // llOpenGithub
            // 
            this.llOpenGithub.AutoSize = true;
            this.llOpenGithub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.llOpenGithub.Location = new System.Drawing.Point(147, 358);
            this.llOpenGithub.Name = "llOpenGithub";
            this.llOpenGithub.Size = new System.Drawing.Size(287, 36);
            this.llOpenGithub.TabIndex = 24;
            this.llOpenGithub.TabStop = true;
            this.llOpenGithub.Text = "Open latest version page of Github.";
            this.llOpenGithub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.llOpenGithub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llOpenGithub_LinkClicked);
            // 
            // cbHiyorimiMode
            // 
            this.cbHiyorimiMode.AutoSize = true;
            this.cbHiyorimiMode.Location = new System.Drawing.Point(8, 435);
            this.cbHiyorimiMode.Name = "cbHiyorimiMode";
            this.cbHiyorimiMode.Size = new System.Drawing.Size(220, 28);
            this.cbHiyorimiMode.TabIndex = 6;
            this.cbHiyorimiMode.Text = "日和見モード(出力タブ：\r\n遅延時間100ms以下の時、使用を推奨)";
            this.cbHiyorimiMode.UseVisualStyleBackColor = true;
            this.cbHiyorimiMode.Visible = false;
            // 
            // tpMMLParameter
            // 
            this.tpMMLParameter.Controls.Add(this.cbDispInstrumentName);
            this.tpMMLParameter.Location = new System.Drawing.Point(4, 22);
            this.tpMMLParameter.Name = "tpMMLParameter";
            this.tpMMLParameter.Size = new System.Drawing.Size(443, 400);
            this.tpMMLParameter.TabIndex = 16;
            this.tpMMLParameter.Text = "MMLParameter";
            this.tpMMLParameter.UseVisualStyleBackColor = true;
            // 
            // cbDispInstrumentName
            // 
            this.cbDispInstrumentName.AutoSize = true;
            this.cbDispInstrumentName.Location = new System.Drawing.Point(23, 19);
            this.cbDispInstrumentName.Name = "cbDispInstrumentName";
            this.cbDispInstrumentName.Size = new System.Drawing.Size(134, 16);
            this.cbDispInstrumentName.TabIndex = 0;
            this.cbDispInstrumentName.Text = "disp Instrument name";
            this.cbDispInstrumentName.UseVisualStyleBackColor = true;
            // 
            // FrmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(464, 470);
            this.Controls.Add(this.cbHiyorimiMode);
            this.Controls.Add(this.tcSetting);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(480, 480);
            this.Name = "FrmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "オプション";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSetting_FormClosed);
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.gbWaveOut.ResumeLayout(false);
            this.gbAsioOut.ResumeLayout(false);
            this.gbWasapiOut.ResumeLayout(false);
            this.gbWasapiOut.PerformLayout();
            this.gbDirectSound.ResumeLayout(false);
            this.tcSetting.ResumeLayout(false);
            this.tpOutput.ResumeLayout(false);
            this.tpOutput.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage11.ResumeLayout(false);
            this.tabPage11.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox16.ResumeLayout(false);
            this.tabPage12.ResumeLayout(false);
            this.groupBox27.ResumeLayout(false);
            this.groupBox27.PerformLayout();
            this.groupBox28.ResumeLayout(false);
            this.groupBox28.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabPage13.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutPallet)).EndInit();
            this.tbcMIDIoutList.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListA)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListB)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListC)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMIDIoutListD)).EndInit();
            this.tpNuked.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage14.ResumeLayout(false);
            this.groupBox26.ResumeLayout(false);
            this.groupBox26.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox34.ResumeLayout(false);
            this.groupBox34.PerformLayout();
            this.tpNSF.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage15.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.tabPage16.ResumeLayout(false);
            this.tabPage16.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.tabPage17.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.tpPMDDotNET.ResumeLayout(false);
            this.tpPMDDotNET.PerformLayout();
            this.gbPMDManual.ResumeLayout(false);
            this.gbPMDManual.PerformLayout();
            this.groupBox32.ResumeLayout(false);
            this.groupBox32.PerformLayout();
            this.gbPPSDRV.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.groupBox33.PerformLayout();
            this.gbPMDSetManualVolume.ResumeLayout(false);
            this.gbPMDSetManualVolume.PerformLayout();
            this.tpMIDIExp.ResumeLayout(false);
            this.tpMIDIExp.PerformLayout();
            this.gbMIDIExport.ResumeLayout(false);
            this.gbMIDIExport.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tpMIDIKBD.ResumeLayout(false);
            this.tpMIDIKBD.PerformLayout();
            this.gbMIDIKeyboard.ResumeLayout(false);
            this.gbMIDIKeyboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbUseChannel.ResumeLayout(false);
            this.gbUseChannel.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tpKeyBoard.ResumeLayout(false);
            this.tpKeyBoard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShortCutKey)).EndInit();
            this.tpBalance.ResumeLayout(false);
            this.tpBalance.PerformLayout();
            this.groupBox25.ResumeLayout(false);
            this.groupBox25.PerformLayout();
            this.groupBox18.ResumeLayout(false);
            this.groupBox24.ResumeLayout(false);
            this.groupBox21.ResumeLayout(false);
            this.groupBox21.PerformLayout();
            this.groupBox22.ResumeLayout(false);
            this.groupBox22.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox19.ResumeLayout(false);
            this.groupBox19.PerformLayout();
            this.groupBox20.ResumeLayout(false);
            this.groupBox20.PerformLayout();
            this.tpOther.ResumeLayout(false);
            this.tpOther.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.gbWav.ResumeLayout(false);
            this.gbWav.PerformLayout();
            this.gbDump.ResumeLayout(false);
            this.gbDump.PerformLayout();
            this.tpOmake.ResumeLayout(false);
            this.tpOmake.PerformLayout();
            this.groupBox31.ResumeLayout(false);
            this.groupBox31.PerformLayout();
            this.groupBox30.ResumeLayout(false);
            this.groupBox30.PerformLayout();
            this.groupBox29.ResumeLayout(false);
            this.groupBox29.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tpAbout.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.tpMMLParameter.ResumeLayout(false);
            this.tpMMLParameter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox gbWaveOut;
        private System.Windows.Forms.RadioButton rbWaveOut;
        private System.Windows.Forms.RadioButton rbAsioOut;
        private System.Windows.Forms.RadioButton rbWasapiOut;
        private System.Windows.Forms.GroupBox gbAsioOut;
        private System.Windows.Forms.RadioButton rbDirectSoundOut;
        private System.Windows.Forms.GroupBox gbWasapiOut;
        private System.Windows.Forms.GroupBox gbDirectSound;
        private System.Windows.Forms.ComboBox cmbWaveOutDevice;
        private System.Windows.Forms.Button btnASIOControlPanel;
        private System.Windows.Forms.ComboBox cmbAsioDevice;
        private System.Windows.Forms.ComboBox cmbWasapiDevice;
        private System.Windows.Forms.ComboBox cmbDirectSoundDevice;
        private System.Windows.Forms.TabControl tcSetting;
        private System.Windows.Forms.TabPage tpOutput;
        private System.Windows.Forms.TabPage tpAbout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label labelProductName;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelCopyright;
        private System.Windows.Forms.Label labelCompanyName;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.TabPage tpOther;
        private System.Windows.Forms.GroupBox gbMIDIKeyboard;
        private System.Windows.Forms.GroupBox gbUseChannel;
        private System.Windows.Forms.CheckBox cbFM1;
        private System.Windows.Forms.CheckBox cbFM2;
        private System.Windows.Forms.CheckBox cbFM3;
        private System.Windows.Forms.CheckBox cbUseMIDIKeyboard;
        private System.Windows.Forms.CheckBox cbFM4;
        private System.Windows.Forms.CheckBox cbFM5;
        private System.Windows.Forms.CheckBox cbFM6;
        private System.Windows.Forms.ComboBox cmbMIDIIN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbExclusive;
        private System.Windows.Forms.RadioButton rbShare;
        private System.Windows.Forms.Label lblLatencyUnit;
        private System.Windows.Forms.Label lblLatency;
        private System.Windows.Forms.ComboBox cmbLatency;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbLatencyEmu;
        private System.Windows.Forms.TextBox tbLatencySCCI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox cbDispFrameCounter;
        private System.Windows.Forms.CheckBox cbHiyorimiMode;
        private System.Windows.Forms.CheckBox cbUseLoopTimes;
        private System.Windows.Forms.Label lblLoopTimes;
        private System.Windows.Forms.TextBox tbLoopTimes;
        private System.Windows.Forms.Button btnOpenSettingFolder;
        private System.Windows.Forms.CheckBox cbUseGetInst;
        private System.Windows.Forms.Button btnDataPath;
        private System.Windows.Forms.TextBox tbDataPath;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tpMIDIKBD;
        private System.Windows.Forms.ComboBox cmbInstFormat;
        private System.Windows.Forms.Label lblInstFormat;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox tbScreenFrameRate;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.CheckBox cbAutoOpen;
        private ucSettingInstruments ucSI;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cbDumpSwitch;
        private System.Windows.Forms.GroupBox gbDump;
        private System.Windows.Forms.Button btnDumpPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDumpPath;
        private System.Windows.Forms.Button btnResetPosition;
        private System.Windows.Forms.TabPage tpMIDIExp;
        private System.Windows.Forms.CheckBox cbUseMIDIExport;
        private System.Windows.Forms.GroupBox gbMIDIExport;
        private System.Windows.Forms.CheckBox cbMIDIUseVOPM;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckBox cbMIDIYM2612;
        private System.Windows.Forms.CheckBox cbMIDISN76489Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2612Sec;
        private System.Windows.Forms.CheckBox cbMIDISN76489;
        private System.Windows.Forms.CheckBox cbMIDIYM2151;
        private System.Windows.Forms.CheckBox cbMIDIYM2610BSec;
        private System.Windows.Forms.CheckBox cbMIDIYM2151Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2610B;
        private System.Windows.Forms.CheckBox cbMIDIYM2203;
        private System.Windows.Forms.CheckBox cbMIDIYM2608Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2203Sec;
        private System.Windows.Forms.CheckBox cbMIDIYM2608;
        private System.Windows.Forms.CheckBox cbMIDIPlayless;
        private System.Windows.Forms.Button btnMIDIOutputPath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TextBox tbMIDIOutputPath;
        private System.Windows.Forms.CheckBox cbWavSwitch;
        private System.Windows.Forms.GroupBox gbWav;
        private System.Windows.Forms.Button btnWavPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbWavPath;
        private System.Windows.Forms.RadioButton rbMONO;
        private System.Windows.Forms.RadioButton rbPOLY;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbFM6;
        private System.Windows.Forms.RadioButton rbFM3;
        private System.Windows.Forms.RadioButton rbFM5;
        private System.Windows.Forms.RadioButton rbFM2;
        private System.Windows.Forms.RadioButton rbFM4;
        private System.Windows.Forms.RadioButton rbFM1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tpOmake;
        private System.Windows.Forms.TextBox tbCCFadeout;
        private System.Windows.Forms.TextBox tbCCPause;
        private System.Windows.Forms.TextBox tbCCSlow;
        private System.Windows.Forms.TextBox tbCCPrevious;
        private System.Windows.Forms.TextBox tbCCNext;
        private System.Windows.Forms.TextBox tbCCFast;
        private System.Windows.Forms.TextBox tbCCStop;
        private System.Windows.Forms.TextBox tbCCPlay;
        private System.Windows.Forms.TextBox tbCCCopyLog;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbCCDelLog;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbCCChCopy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btVST;
        private System.Windows.Forms.TextBox tbVST;
        private System.Windows.Forms.Button btnUP_A;
        private System.Windows.Forms.Button btnSubMIDIout;
        private System.Windows.Forms.Button btnDOWN_A;
        private System.Windows.Forms.Button btnAddMIDIout;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DataGridView dgvMIDIoutListA;
        private System.Windows.Forms.DataGridView dgvMIDIoutPallet;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmDeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmSpacer;
        private System.Windows.Forms.TabControl tbcMIDIoutList;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnUP_B;
        private System.Windows.Forms.Button btnDOWN_B;
        private System.Windows.Forms.Button btnUP_C;
        private System.Windows.Forms.Button btnDOWN_C;
        private System.Windows.Forms.Button btnUP_D;
        private System.Windows.Forms.Button btnDOWN_D;
        private System.Windows.Forms.Button btnAddVST;
        private System.Windows.Forms.DataGridView dgvMIDIoutListB;
        private System.Windows.Forms.DataGridView dgvMIDIoutListC;
        private System.Windows.Forms.DataGridView dgvMIDIoutListD;
        private System.Windows.Forms.TabPage tpNSF;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.CheckBox cbNSFFDSWriteDisable8000;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.CheckBox cbNSFDmc_TriNull;
        private System.Windows.Forms.CheckBox cbNSFDmc_TriMute;
        private System.Windows.Forms.CheckBox cbNSFDmc_RandomizeNoise;
        private System.Windows.Forms.CheckBox cbNSFDmc_DPCMAntiClick;
        private System.Windows.Forms.CheckBox cbNSFDmc_EnablePNoise;
        private System.Windows.Forms.CheckBox cbNSFDmc_Enable4011;
        private System.Windows.Forms.CheckBox cbNSFDmc_NonLinearMixer;
        private System.Windows.Forms.CheckBox cbNSFDmc_UnmuteOnReset;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.CheckBox cbNSFN160_Serial;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox cbNSFMmc5_PhaseRefresh;
        private System.Windows.Forms.CheckBox cbNSFMmc5_NonLinearMixer;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox cbNFSNes_DutySwap;
        private System.Windows.Forms.CheckBox cbNFSNes_PhaseRefresh;
        private System.Windows.Forms.CheckBox cbNFSNes_NonLinearMixer;
        private System.Windows.Forms.CheckBox cbNFSNes_UnmuteOnReset;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox tbNSFFds_LPF;
        private System.Windows.Forms.CheckBox cbNFSFds_4085Reset;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Button btnSIDCharacter;
        private System.Windows.Forms.Button btnSIDBasic;
        private System.Windows.Forms.Button btnSIDKernal;
        private System.Windows.Forms.TextBox tbSIDCharacter;
        private System.Windows.Forms.TextBox tbSIDBasic;
        private System.Windows.Forms.TextBox tbSIDKernal;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.RadioButton rdSIDQ1;
        private System.Windows.Forms.RadioButton rdSIDQ3;
        private System.Windows.Forms.RadioButton rdSIDQ2;
        private System.Windows.Forms.RadioButton rdSIDQ4;
        private System.Windows.Forms.Label lblWaitTime;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cmbWaitTime;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnBeforeSend_Default;
        private System.Windows.Forms.TextBox tbBeforeSend_Custom;
        private System.Windows.Forms.TextBox tbBeforeSend_XGReset;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox tbBeforeSend_GSReset;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tbBeforeSend_GMReset;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.RadioButton rbSPPCM;
        private System.Windows.Forms.GroupBox groupBox16;
        private System.Windows.Forms.ComboBox cmbSPPCMDevice;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.TextBox tbImageExt;
        private System.Windows.Forms.TextBox tbMMLExt;
        private System.Windows.Forms.TextBox tbTextExt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbInitAlways;
        private System.Windows.Forms.TabPage tpBalance;
        private System.Windows.Forms.CheckBox cbAutoBalanceUseThis;
        private System.Windows.Forms.GroupBox groupBox18;
        private System.Windows.Forms.GroupBox groupBox24;
        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.RadioButton rbAutoBalanceNotSaveSongBalance;
        private System.Windows.Forms.RadioButton rbAutoBalanceSamePositionAsSongData;
        private System.Windows.Forms.RadioButton rbAutoBalanceSaveSongBalance;
        private System.Windows.Forms.GroupBox groupBox22;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.RadioButton rbAutoBalanceNotLoadSongBalance;
        private System.Windows.Forms.RadioButton rbAutoBalanceLoadSongBalance;
        private System.Windows.Forms.GroupBox groupBox20;
        private System.Windows.Forms.RadioButton rbAutoBalanceNotLoadDriverBalance;
        private System.Windows.Forms.RadioButton rbAutoBalanceLoadDriverBalance;
        private System.Windows.Forms.GroupBox groupBox25;
        private System.Windows.Forms.RadioButton rbAutoBalanceNotSamePositionAsSongData;
        private System.Windows.Forms.TabPage tpKeyBoard;
        private System.Windows.Forms.RadioButton rbNullDevice;
        private System.Windows.Forms.TextBox tbSIDOutputBufferSize;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TabPage tpNuked;
        private System.Windows.Forms.GroupBox groupBox26;
        private System.Windows.Forms.RadioButton rbNukedOPN2OptionYM2612u;
        private System.Windows.Forms.RadioButton rbNukedOPN2OptionYM2612;
        private System.Windows.Forms.RadioButton rbNukedOPN2OptionDiscrete;
        private System.Windows.Forms.RadioButton rbNukedOPN2OptionASIC;
        private System.Windows.Forms.RadioButton rbNukedOPN2OptionASIClp;
        private System.Windows.Forms.CheckBox cbEmptyPlayList;
        private System.Windows.Forms.CheckBox cbMIDIKeyOnFnum;
        private System.Windows.Forms.TrackBar tbOpacity;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox27;
        private System.Windows.Forms.RadioButton rbManualDetect;
        private System.Windows.Forms.RadioButton rbAutoDetect;
        private System.Windows.Forms.GroupBox groupBox28;
        private System.Windows.Forms.RadioButton rbSCCIDetect;
        private System.Windows.Forms.RadioButton rbC86ctlDetect;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage11;
        private System.Windows.Forms.TabPage tabPage12;
        private System.Windows.Forms.TabPage tabPage13;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage14;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage15;
        private System.Windows.Forms.TabPage tabPage16;
        private System.Windows.Forms.TabPage tabPage17;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button btFont;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label lblFontStyle;
        private System.Windows.Forms.Label lblFontSize;
        private System.Windows.Forms.Label lblFontName;
        private System.Windows.Forms.GroupBox groupBox29;
        private System.Windows.Forms.CheckBox cbInfiniteOfflineMode;
        private System.Windows.Forms.CheckBox cbMIDIKbdAlwaysTop;
        private System.Windows.Forms.CheckBox cbUseRealChip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmIsVST;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn clmType;
        private System.Windows.Forms.DataGridViewComboBoxColumn ClmBeforeSend;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox30;
        private System.Windows.Forms.RadioButton rbQueryPerformanceCounter;
        private System.Windows.Forms.RadioButton rbDateTime;
        private System.Windows.Forms.RadioButton rbStopWatch;
        private System.Windows.Forms.GroupBox groupBox31;
        private System.Windows.Forms.RadioButton rbLoglevelINFO;
        private System.Windows.Forms.RadioButton rbLoglevelDEBUG;
        private System.Windows.Forms.RadioButton rbLoglevelTRACE;
        private System.Windows.Forms.CheckBox cbLogWarning;
        private System.Windows.Forms.DataGridView dgvShortCutKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFunc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmShift;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmCtrl;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAlt;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKey;
        private System.Windows.Forms.DataGridViewButtonColumn clmSet;
        private System.Windows.Forms.DataGridViewButtonColumn clmClr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmKBDSpacer;
        private System.Windows.Forms.Label lblSKKey;
        private System.Windows.Forms.Button btnInitializeShortCutKey;
        private System.Windows.Forms.CheckBox cbUseSIen;
        private System.Windows.Forms.LinkLabel llOpenGithub;
        private System.Windows.Forms.CheckBox cbPlayDeviceCB;
        private System.Windows.Forms.TabPage tpPMDDotNET;
        private System.Windows.Forms.RadioButton rbPMDManual;
        private System.Windows.Forms.RadioButton rbPMDAuto;
        private System.Windows.Forms.Button btnPMDResetDriverArguments;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.Button btnPMDResetCompilerArhguments;
        private System.Windows.Forms.TextBox tbPMDDriverArguments;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox tbPMDCompilerArguments;
        private System.Windows.Forms.GroupBox gbPMDManual;
        private System.Windows.Forms.CheckBox cbPMDSetManualVolume;
        private System.Windows.Forms.CheckBox cbPMDUsePPZ8;
        private System.Windows.Forms.GroupBox groupBox32;
        private System.Windows.Forms.RadioButton rbPMD86B;
        private System.Windows.Forms.RadioButton rbPMDSpbB;
        private System.Windows.Forms.RadioButton rbPMDNrmB;
        private System.Windows.Forms.CheckBox cbPMDUsePPSDRV;
        private System.Windows.Forms.GroupBox gbPPSDRV;
        private System.Windows.Forms.RadioButton rbPMDUsePPSDRVManualFreq;
        private System.Windows.Forms.RadioButton rbPMDUsePPSDRVFreqDefault;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox tbPMDPPSDRVManualWait;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox tbPMDPPSDRVFreq;
        private System.Windows.Forms.Button btnPMDPPSDRVManualWait;
        private System.Windows.Forms.GroupBox gbPMDSetManualVolume;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox tbPMDVolumeAdpcm;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox tbPMDVolumeRhythm;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.TextBox tbPMDVolumeSSG;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TextBox tbPMDVolumeGIMICSSG;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox tbPMDVolumeFM;
        private System.Windows.Forms.GroupBox groupBox33;
        private System.Windows.Forms.CheckBox cbRequestCacheClear;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox34;
        private System.Windows.Forms.CheckBox cbGensSSGEG;
        private System.Windows.Forms.CheckBox cbGensDACHPF;
        private System.Windows.Forms.CheckBox cbSinWave;
        private System.Windows.Forms.CheckBox cbClearHistory;
        private System.Windows.Forms.TabPage tpMMLParameter;
        private System.Windows.Forms.CheckBox cbDispInstrumentName;
    }
}