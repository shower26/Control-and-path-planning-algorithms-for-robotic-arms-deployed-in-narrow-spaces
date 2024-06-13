namespace RobotControl
{
    partial class MainFrm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TiUpdSts = new System.Windows.Forms.Timer(this.components);
            this.splitContFightRobot = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpParam = new System.Windows.Forms.TabPage();
            this.splitContUpDn = new System.Windows.Forms.SplitContainer();
            this.splitContLfRt = new System.Windows.Forms.SplitContainer();
            this.grpBoxRobotCtrl = new System.Windows.Forms.GroupBox();
            this.splitContLfUp = new System.Windows.Forms.SplitContainer();
            this.cbbCnctStr = new System.Windows.Forms.ComboBox();
            this.lblCnctStr = new System.Windows.Forms.Label();
            this.cbbCnctType = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnIPCnct = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnDisCnct = new System.Windows.Forms.Button();
            this.btnCnct = new System.Windows.Forms.Button();
            this.ledZMSts = new IndustrialCtrls.Leds.SWLed();
            this.splitContPlc = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.RdBtn_mode0 = new System.Windows.Forms.RadioButton();
            this.RdBtn_Bolwtorch = new System.Windows.Forms.RadioButton();
            this.RdBtn_Suctioncup = new System.Windows.Forms.RadioButton();
            this.btnStopCleaner = new System.Windows.Forms.Button();
            this.btnStopSucker = new System.Windows.Forms.Button();
            this.btnStartSucker = new System.Windows.Forms.Button();
            this.btnStartCleaner = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnCIPConnect = new System.Windows.Forms.Button();
            this.tb_CIPPort = new System.Windows.Forms.TextBox();
            this.tb_CIPIP = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.plcLed = new IndustrialCtrls.Leds.SWLed();
            this.splitContRtUp = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cbbInit = new System.Windows.Forms.ComboBox();
            this.cbbPosLimit = new System.Windows.Forms.ComboBox();
            this.cbbAccel = new System.Windows.Forms.ComboBox();
            this.cbbUnits = new System.Windows.Forms.ComboBox();
            this.cbbNegLimit = new System.Windows.Forms.ComboBox();
            this.cbbDecel = new System.Windows.Forms.ComboBox();
            this.cbbSpeed = new System.Windows.Forms.ComboBox();
            this.axisname = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnConfirmParam = new System.Windows.Forms.Button();
            this.btnSaveParam = new System.Windows.Forms.Button();
            this.cbbAxis = new System.Windows.Forms.ComboBox();
            this.splitContMidLfRt = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstBoxTip = new System.Windows.Forms.ListBox();
            this.splitContMidRtUpDn = new System.Windows.Forms.SplitContainer();
            this.grpCamSvr = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnSnd2Svr = new System.Windows.Forms.Button();
            this.btnCnctCameraSvr = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cbbIP = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpBoxMode = new System.Windows.Forms.GroupBox();
            this.btn_InitStatus = new System.Windows.Forms.Button();
            this.txtTargetPosi = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnInitPosi = new System.Windows.Forms.Button();
            this.btnMoveIdle = new System.Windows.Forms.Button();
            this.btnSetIdlePosi = new System.Windows.Forms.Button();
            this.btnMoveInit = new System.Windows.Forms.Button();
            this.chbAutoMode = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnEmStop = new System.Windows.Forms.Button();
            this.button21 = new System.Windows.Forms.Button();
            this.Btn5Init = new System.Windows.Forms.Button();
            this.btn5Backward = new System.Windows.Forms.Button();
            this.btn4Backward = new System.Windows.Forms.Button();
            this.btn5Forward = new System.Windows.Forms.Button();
            this.btn3Backward = new System.Windows.Forms.Button();
            this.Btn2Init = new System.Windows.Forms.Button();
            this.btn4Forward = new System.Windows.Forms.Button();
            this.btn3Forward = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.Btn0Init = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.btn2Forward = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btn1Backward = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btn0Backward = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btn0Home = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.btn0Forward = new System.Windows.Forms.Button();
            this.lbl3Posi = new System.Windows.Forms.Label();
            this.lbl4Posi = new System.Windows.Forms.Label();
            this.lbl5Posi = new System.Windows.Forms.Label();
            this.lbl1FLimit = new System.Windows.Forms.Label();
            this.lbl1BLimit = new System.Windows.Forms.Label();
            this.lbl3Sts = new System.Windows.Forms.Label();
            this.btn1Forward = new System.Windows.Forms.Button();
            this.lbl3BLimit = new System.Windows.Forms.Label();
            this.lbl4Sts = new System.Windows.Forms.Label();
            this.lbl4BLimit = new System.Windows.Forms.Label();
            this.lbl5Sts = new System.Windows.Forms.Label();
            this.lbl5FLimit = new System.Windows.Forms.Label();
            this.lbl0Sts = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lbl1Posi = new System.Windows.Forms.Label();
            this.lbl1Sts = new System.Windows.Forms.Label();
            this.lbl5BLimit = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lbl0FLimit = new System.Windows.Forms.Label();
            this.lbl0Posi = new System.Windows.Forms.Label();
            this.lbl0BLimit = new System.Windows.Forms.Label();
            this.lbl2Posi = new System.Windows.Forms.Label();
            this.lbl2Sts = new System.Windows.Forms.Label();
            this.lbl2FLimit = new System.Windows.Forms.Label();
            this.btn1Home = new System.Windows.Forms.Button();
            this.Btn1Init = new System.Windows.Forms.Button();
            this.lbl3FLimit = new System.Windows.Forms.Label();
            this.lbl2BLimit = new System.Windows.Forms.Label();
            this.btn2Backward = new System.Windows.Forms.Button();
            this.Btn3Init = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.lbl4FLimit = new System.Windows.Forms.Label();
            this.Btn4Init = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.初始 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.运动模块 = new System.Windows.Forms.GroupBox();
            this.label87 = new System.Windows.Forms.Label();
            this.tb_MovePositionLen = new System.Windows.Forms.TextBox();
            this.Btn_ZMinus = new System.Windows.Forms.Button();
            this.Btn_ZPlus = new System.Windows.Forms.Button();
            this.Btn_YMinus = new System.Windows.Forms.Button();
            this.Btn_YPlus = new System.Windows.Forms.Button();
            this.Btn_XMinus = new System.Windows.Forms.Button();
            this.Btn_XPuls = new System.Windows.Forms.Button();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tb_workspaceYMinus = new System.Windows.Forms.TextBox();
            this.label72 = new System.Windows.Forms.Label();
            this.btn_SaveWorkspaceLimit = new System.Windows.Forms.Button();
            this.btn_ConfirmWorkspaceLimit = new System.Windows.Forms.Button();
            this.tb_workspaceYPlus = new System.Windows.Forms.TextBox();
            this.tb_workspaceXMinus = new System.Windows.Forms.TextBox();
            this.tb_workspaceXPlus = new System.Windows.Forms.TextBox();
            this.label67 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.运动空间限位 = new System.Windows.Forms.GroupBox();
            this.btn_ConfirmIO = new System.Windows.Forms.Button();
            this.btn_SaveIO = new System.Windows.Forms.Button();
            this.tb_emstopIO = new System.Windows.Forms.TextBox();
            this.tb_BolwtorchIO = new System.Windows.Forms.TextBox();
            this.tb_SuctioncupIO = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label68 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tb_ProductionlineHeight = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.tb_axis5zeroheight = new System.Windows.Forms.TextBox();
            this.label82 = new System.Windows.Forms.Label();
            this.tb_mode2height = new System.Windows.Forms.TextBox();
            this.tb_mode1height = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.btn_DeflectionSave = new System.Windows.Forms.Button();
            this.tb_BolwtorchDeflectionZ = new System.Windows.Forms.TextBox();
            this.btn_DeflectionConfirm = new System.Windows.Forms.Button();
            this.tb_SuctioncupDeflectionZ = new System.Windows.Forms.TextBox();
            this.tb_BolwtorchDeflectionX = new System.Windows.Forms.TextBox();
            this.tb_SuctioncupDeflectionX = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lbl_CurrentDeflectionY = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.lbl_CurrentDeflectionX = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.btn_SetAverageDeflection = new System.Windows.Forms.Button();
            this.btn_CalculateAverageDeflection = new System.Windows.Forms.Button();
            this.tb_AverageDeflectionY = new System.Windows.Forms.TextBox();
            this.tb_AverageDeflectionX = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.tb_DeflectionY6 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionX6 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionY5 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionX5 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionY4 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionX4 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionY3 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionX3 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionY2 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionX2 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionY1 = new System.Windows.Forms.TextBox();
            this.tb_DeflectionX1 = new System.Windows.Forms.TextBox();
            this.splitContDspUpDn = new System.Windows.Forms.SplitContainer();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label44 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.tb_P5 = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.tbP_Bolwtorch = new System.Windows.Forms.TextBox();
            this.label41 = new System.Windows.Forms.Label();
            this.tbP_Suctioncup = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.tbP_3 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label85 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.splitContFightRobot)).BeginInit();
            this.splitContFightRobot.Panel1.SuspendLayout();
            this.splitContFightRobot.Panel2.SuspendLayout();
            this.splitContFightRobot.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbpParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContUpDn)).BeginInit();
            this.splitContUpDn.Panel1.SuspendLayout();
            this.splitContUpDn.Panel2.SuspendLayout();
            this.splitContUpDn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContLfRt)).BeginInit();
            this.splitContLfRt.Panel1.SuspendLayout();
            this.splitContLfRt.Panel2.SuspendLayout();
            this.splitContLfRt.SuspendLayout();
            this.grpBoxRobotCtrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContLfUp)).BeginInit();
            this.splitContLfUp.Panel1.SuspendLayout();
            this.splitContLfUp.Panel2.SuspendLayout();
            this.splitContLfUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContPlc)).BeginInit();
            this.splitContPlc.Panel1.SuspendLayout();
            this.splitContPlc.Panel2.SuspendLayout();
            this.splitContPlc.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContRtUp)).BeginInit();
            this.splitContRtUp.Panel1.SuspendLayout();
            this.splitContRtUp.Panel2.SuspendLayout();
            this.splitContRtUp.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMidLfRt)).BeginInit();
            this.splitContMidLfRt.Panel1.SuspendLayout();
            this.splitContMidLfRt.Panel2.SuspendLayout();
            this.splitContMidLfRt.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContMidRtUpDn)).BeginInit();
            this.splitContMidRtUpDn.Panel1.SuspendLayout();
            this.splitContMidRtUpDn.Panel2.SuspendLayout();
            this.splitContMidRtUpDn.SuspendLayout();
            this.grpCamSvr.SuspendLayout();
            this.grpBoxMode.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.运动模块.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.运动空间限位.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContDspUpDn)).BeginInit();
            this.splitContDspUpDn.Panel1.SuspendLayout();
            this.splitContDspUpDn.Panel2.SuspendLayout();
            this.splitContDspUpDn.SuspendLayout();
            this.SuspendLayout();
            // 
            // TiUpdSts
            // 
            this.TiUpdSts.Tick += new System.EventHandler(this.TiUpdSts_Tick);
            // 
            // splitContFightRobot
            // 
            this.splitContFightRobot.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContFightRobot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContFightRobot.Location = new System.Drawing.Point(0, 0);
            this.splitContFightRobot.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContFightRobot.Name = "splitContFightRobot";
            // 
            // splitContFightRobot.Panel1
            // 
            this.splitContFightRobot.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContFightRobot.Panel2
            // 
            this.splitContFightRobot.Panel2.Controls.Add(this.splitContDspUpDn);
            this.splitContFightRobot.Size = new System.Drawing.Size(1399, 758);
            this.splitContFightRobot.SplitterDistance = 961;
            this.splitContFightRobot.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpParam);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(957, 754);
            this.tabControl1.TabIndex = 0;
            // 
            // tbpParam
            // 
            this.tbpParam.Controls.Add(this.splitContUpDn);
            this.tbpParam.Location = new System.Drawing.Point(4, 25);
            this.tbpParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpParam.Name = "tbpParam";
            this.tbpParam.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbpParam.Size = new System.Drawing.Size(949, 725);
            this.tbpParam.TabIndex = 0;
            this.tbpParam.Text = "手动模式参数";
            this.tbpParam.UseVisualStyleBackColor = true;
            // 
            // splitContUpDn
            // 
            this.splitContUpDn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContUpDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContUpDn.Location = new System.Drawing.Point(3, 2);
            this.splitContUpDn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContUpDn.Name = "splitContUpDn";
            this.splitContUpDn.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContUpDn.Panel1
            // 
            this.splitContUpDn.Panel1.Controls.Add(this.splitContLfRt);
            // 
            // splitContUpDn.Panel2
            // 
            this.splitContUpDn.Panel2.Controls.Add(this.groupBox4);
            this.splitContUpDn.Size = new System.Drawing.Size(943, 721);
            this.splitContUpDn.SplitterDistance = 417;
            this.splitContUpDn.TabIndex = 0;
            // 
            // splitContLfRt
            // 
            this.splitContLfRt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContLfRt.Location = new System.Drawing.Point(0, 0);
            this.splitContLfRt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContLfRt.Name = "splitContLfRt";
            // 
            // splitContLfRt.Panel1
            // 
            this.splitContLfRt.Panel1.Controls.Add(this.grpBoxRobotCtrl);
            // 
            // splitContLfRt.Panel2
            // 
            this.splitContLfRt.Panel2.Controls.Add(this.splitContRtUp);
            this.splitContLfRt.Panel2MinSize = 300;
            this.splitContLfRt.Size = new System.Drawing.Size(939, 413);
            this.splitContLfRt.SplitterDistance = 278;
            this.splitContLfRt.TabIndex = 0;
            // 
            // grpBoxRobotCtrl
            // 
            this.grpBoxRobotCtrl.Controls.Add(this.splitContLfUp);
            this.grpBoxRobotCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxRobotCtrl.Location = new System.Drawing.Point(0, 0);
            this.grpBoxRobotCtrl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoxRobotCtrl.Name = "grpBoxRobotCtrl";
            this.grpBoxRobotCtrl.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoxRobotCtrl.Size = new System.Drawing.Size(278, 413);
            this.grpBoxRobotCtrl.TabIndex = 0;
            this.grpBoxRobotCtrl.TabStop = false;
            this.grpBoxRobotCtrl.Text = "机械臂控制";
            // 
            // splitContLfUp
            // 
            this.splitContLfUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContLfUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContLfUp.Location = new System.Drawing.Point(3, 20);
            this.splitContLfUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContLfUp.Name = "splitContLfUp";
            this.splitContLfUp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContLfUp.Panel1
            // 
            this.splitContLfUp.Panel1.Controls.Add(this.cbbCnctStr);
            this.splitContLfUp.Panel1.Controls.Add(this.lblCnctStr);
            this.splitContLfUp.Panel1.Controls.Add(this.cbbCnctType);
            this.splitContLfUp.Panel1.Controls.Add(this.label28);
            this.splitContLfUp.Panel1.Controls.Add(this.button2);
            this.splitContLfUp.Panel1.Controls.Add(this.button1);
            this.splitContLfUp.Panel1.Controls.Add(this.btnIPCnct);
            this.splitContLfUp.Panel1.Controls.Add(this.btnInit);
            this.splitContLfUp.Panel1.Controls.Add(this.btnDisCnct);
            this.splitContLfUp.Panel1.Controls.Add(this.btnCnct);
            this.splitContLfUp.Panel1.Controls.Add(this.ledZMSts);
            // 
            // splitContLfUp.Panel2
            // 
            this.splitContLfUp.Panel2.Controls.Add(this.splitContPlc);
            this.splitContLfUp.Size = new System.Drawing.Size(272, 391);
            this.splitContLfUp.SplitterDistance = 140;
            this.splitContLfUp.TabIndex = 0;
            // 
            // cbbCnctStr
            // 
            this.cbbCnctStr.FormattingEnabled = true;
            this.cbbCnctStr.Location = new System.Drawing.Point(165, 41);
            this.cbbCnctStr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbCnctStr.Name = "cbbCnctStr";
            this.cbbCnctStr.Size = new System.Drawing.Size(141, 23);
            this.cbbCnctStr.TabIndex = 8;
            // 
            // lblCnctStr
            // 
            this.lblCnctStr.AutoSize = true;
            this.lblCnctStr.Location = new System.Drawing.Point(75, 46);
            this.lblCnctStr.Name = "lblCnctStr";
            this.lblCnctStr.Size = new System.Drawing.Size(90, 15);
            this.lblCnctStr.TabIndex = 7;
            this.lblCnctStr.Text = "连接字符串:";
            // 
            // cbbCnctType
            // 
            this.cbbCnctType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCnctType.FormattingEnabled = true;
            this.cbbCnctType.Location = new System.Drawing.Point(165, 9);
            this.cbbCnctType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbCnctType.Name = "cbbCnctType";
            this.cbbCnctType.Size = new System.Drawing.Size(141, 23);
            this.cbbCnctType.TabIndex = 6;
            this.cbbCnctType.SelectedIndexChanged += new System.EventHandler(this.cbbCnctType_SelectedIndexChanged);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(75, 14);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(75, 15);
            this.label28.TabIndex = 5;
            this.label28.Text = "连接方式:";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(128, 120);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "断开使能";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 86);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "初始化总线";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnIPCnct
            // 
            this.btnIPCnct.Location = new System.Drawing.Point(128, 85);
            this.btnIPCnct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIPCnct.Name = "btnIPCnct";
            this.btnIPCnct.Size = new System.Drawing.Size(101, 30);
            this.btnIPCnct.TabIndex = 2;
            this.btnIPCnct.Text = "连接仿真器";
            this.btnIPCnct.UseVisualStyleBackColor = true;
            this.btnIPCnct.Click += new System.EventHandler(this.btnIPCnct_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(19, 121);
            this.btnInit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(100, 30);
            this.btnInit.TabIndex = 1;
            this.btnInit.Text = "初始化轴";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnDisCnct
            // 
            this.btnDisCnct.Location = new System.Drawing.Point(235, 120);
            this.btnDisCnct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDisCnct.Name = "btnDisCnct";
            this.btnDisCnct.Size = new System.Drawing.Size(83, 30);
            this.btnDisCnct.TabIndex = 1;
            this.btnDisCnct.Text = "断开连接";
            this.btnDisCnct.UseVisualStyleBackColor = true;
            this.btnDisCnct.Click += new System.EventHandler(this.btnDisCnct_Click);
            // 
            // btnCnct
            // 
            this.btnCnct.Location = new System.Drawing.Point(235, 86);
            this.btnCnct.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCnct.Name = "btnCnct";
            this.btnCnct.Size = new System.Drawing.Size(83, 30);
            this.btnCnct.TabIndex = 1;
            this.btnCnct.Text = "连接";
            this.btnCnct.UseVisualStyleBackColor = true;
            this.btnCnct.Click += new System.EventHandler(this.btnCnct_Click);
            // 
            // ledZMSts
            // 
            this.ledZMSts.BackColor = System.Drawing.Color.Transparent;
            this.ledZMSts.BlinkInterval = 500;
            this.ledZMSts.Label = "状态";
            this.ledZMSts.LabelPosition = IndustrialCtrls.Leds.SWLed.LedLabelPosition.Top;
            this.ledZMSts.LedColor = System.Drawing.Color.Lime;
            this.ledZMSts.LedSize = new System.Drawing.SizeF(30F, 30F);
            this.ledZMSts.Location = new System.Drawing.Point(3, 2);
            this.ledZMSts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ledZMSts.Name = "ledZMSts";
            this.ledZMSts.Renderer = null;
            this.ledZMSts.Size = new System.Drawing.Size(65, 59);
            this.ledZMSts.State = IndustrialCtrls.Leds.SWLed.LedState.Off;
            this.ledZMSts.Style = IndustrialCtrls.Leds.SWLed.LedStyle.Circular;
            this.ledZMSts.TabIndex = 0;
            // 
            // splitContPlc
            // 
            this.splitContPlc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContPlc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContPlc.Location = new System.Drawing.Point(0, 0);
            this.splitContPlc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContPlc.Name = "splitContPlc";
            this.splitContPlc.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContPlc.Panel1
            // 
            this.splitContPlc.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContPlc.Panel2
            // 
            this.splitContPlc.Panel2.Controls.Add(this.groupBox5);
            this.splitContPlc.Size = new System.Drawing.Size(272, 247);
            this.splitContPlc.SplitterDistance = 139;
            this.splitContPlc.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.RdBtn_mode0);
            this.groupBox3.Controls.Add(this.RdBtn_Bolwtorch);
            this.groupBox3.Controls.Add(this.RdBtn_Suctioncup);
            this.groupBox3.Controls.Add(this.btnStopCleaner);
            this.groupBox3.Controls.Add(this.btnStopSucker);
            this.groupBox3.Controls.Add(this.btnStartSucker);
            this.groupBox3.Controls.Add(this.btnStartCleaner);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(268, 135);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "机械臂末端操作";
            // 
            // RdBtn_mode0
            // 
            this.RdBtn_mode0.AutoSize = true;
            this.RdBtn_mode0.Checked = true;
            this.RdBtn_mode0.ForeColor = System.Drawing.Color.Black;
            this.RdBtn_mode0.Location = new System.Drawing.Point(121, 100);
            this.RdBtn_mode0.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdBtn_mode0.Name = "RdBtn_mode0";
            this.RdBtn_mode0.Size = new System.Drawing.Size(103, 19);
            this.RdBtn_mode0.TabIndex = 7;
            this.RdBtn_mode0.TabStop = true;
            this.RdBtn_mode0.Text = "不使用末端";
            this.RdBtn_mode0.UseVisualStyleBackColor = true;
            this.RdBtn_mode0.CheckedChanged += new System.EventHandler(this.RdBtn_mode0_CheckedChanged);
            // 
            // RdBtn_Bolwtorch
            // 
            this.RdBtn_Bolwtorch.AutoSize = true;
            this.RdBtn_Bolwtorch.ForeColor = System.Drawing.Color.Black;
            this.RdBtn_Bolwtorch.Location = new System.Drawing.Point(70, 100);
            this.RdBtn_Bolwtorch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdBtn_Bolwtorch.Name = "RdBtn_Bolwtorch";
            this.RdBtn_Bolwtorch.Size = new System.Drawing.Size(58, 19);
            this.RdBtn_Bolwtorch.TabIndex = 6;
            this.RdBtn_Bolwtorch.Text = "吹嘴";
            this.RdBtn_Bolwtorch.UseVisualStyleBackColor = true;
            this.RdBtn_Bolwtorch.CheckedChanged += new System.EventHandler(this.RdBtn_Bolwtorch_CheckedChanged);
            // 
            // RdBtn_Suctioncup
            // 
            this.RdBtn_Suctioncup.AutoSize = true;
            this.RdBtn_Suctioncup.ForeColor = System.Drawing.Color.Black;
            this.RdBtn_Suctioncup.Location = new System.Drawing.Point(12, 100);
            this.RdBtn_Suctioncup.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RdBtn_Suctioncup.Name = "RdBtn_Suctioncup";
            this.RdBtn_Suctioncup.Size = new System.Drawing.Size(58, 19);
            this.RdBtn_Suctioncup.TabIndex = 5;
            this.RdBtn_Suctioncup.Text = "吸盘";
            this.RdBtn_Suctioncup.UseVisualStyleBackColor = true;
            this.RdBtn_Suctioncup.CheckedChanged += new System.EventHandler(this.RdBtn_Suctioncup_CheckedChanged);
            // 
            // btnStopCleaner
            // 
            this.btnStopCleaner.Location = new System.Drawing.Point(121, 20);
            this.btnStopCleaner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStopCleaner.Name = "btnStopCleaner";
            this.btnStopCleaner.Size = new System.Drawing.Size(100, 30);
            this.btnStopCleaner.TabIndex = 3;
            this.btnStopCleaner.Text = "关闭吹嘴";
            this.btnStopCleaner.UseVisualStyleBackColor = true;
            this.btnStopCleaner.Click += new System.EventHandler(this.btnStopCleaner_Click);
            // 
            // btnStopSucker
            // 
            this.btnStopSucker.Location = new System.Drawing.Point(121, 56);
            this.btnStopSucker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStopSucker.Name = "btnStopSucker";
            this.btnStopSucker.Size = new System.Drawing.Size(100, 30);
            this.btnStopSucker.TabIndex = 4;
            this.btnStopSucker.Text = "关闭吸盘";
            this.btnStopSucker.UseVisualStyleBackColor = true;
            this.btnStopSucker.Click += new System.EventHandler(this.btnStopSucker_Click);
            // 
            // btnStartSucker
            // 
            this.btnStartSucker.Location = new System.Drawing.Point(8, 55);
            this.btnStartSucker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartSucker.Name = "btnStartSucker";
            this.btnStartSucker.Size = new System.Drawing.Size(100, 30);
            this.btnStartSucker.TabIndex = 2;
            this.btnStartSucker.Text = "开启吸盘";
            this.btnStartSucker.UseVisualStyleBackColor = true;
            this.btnStartSucker.Click += new System.EventHandler(this.btnStartSucker_Click);
            // 
            // btnStartCleaner
            // 
            this.btnStartCleaner.Location = new System.Drawing.Point(8, 20);
            this.btnStartCleaner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStartCleaner.Name = "btnStartCleaner";
            this.btnStartCleaner.Size = new System.Drawing.Size(100, 30);
            this.btnStartCleaner.TabIndex = 2;
            this.btnStartCleaner.Text = "开启吹嘴";
            this.btnStartCleaner.UseVisualStyleBackColor = true;
            this.btnStartCleaner.Click += new System.EventHandler(this.btnStartCleaner_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button4);
            this.groupBox5.Controls.Add(this.btnCIPConnect);
            this.groupBox5.Controls.Add(this.tb_CIPPort);
            this.groupBox5.Controls.Add(this.tb_CIPIP);
            this.groupBox5.Controls.Add(this.label30);
            this.groupBox5.Controls.Add(this.label29);
            this.groupBox5.Controls.Add(this.plcLed);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox5.Size = new System.Drawing.Size(268, 100);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "PLC状态";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(128, 71);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(64, 24);
            this.button4.TabIndex = 7;
            this.button4.Text = "5轴0";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnCIPConnect
            // 
            this.btnCIPConnect.Location = new System.Drawing.Point(235, 74);
            this.btnCIPConnect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCIPConnect.Name = "btnCIPConnect";
            this.btnCIPConnect.Size = new System.Drawing.Size(100, 24);
            this.btnCIPConnect.TabIndex = 6;
            this.btnCIPConnect.Text = "连接";
            this.btnCIPConnect.UseVisualStyleBackColor = true;
            this.btnCIPConnect.Click += new System.EventHandler(this.btnCIPConnect_Click);
            // 
            // tb_CIPPort
            // 
            this.tb_CIPPort.Location = new System.Drawing.Point(185, 42);
            this.tb_CIPPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_CIPPort.Name = "tb_CIPPort";
            this.tb_CIPPort.Size = new System.Drawing.Size(100, 25);
            this.tb_CIPPort.TabIndex = 5;
            // 
            // tb_CIPIP
            // 
            this.tb_CIPIP.Location = new System.Drawing.Point(185, 18);
            this.tb_CIPIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_CIPIP.Name = "tb_CIPIP";
            this.tb_CIPIP.Size = new System.Drawing.Size(100, 25);
            this.tb_CIPIP.TabIndex = 4;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(125, 52);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(54, 15);
            this.label30.TabIndex = 3;
            this.label30.Text = "Port：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(125, 28);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(38, 15);
            this.label29.TabIndex = 2;
            this.label29.Text = "IP：";
            // 
            // plcLed
            // 
            this.plcLed.BackColor = System.Drawing.Color.Transparent;
            this.plcLed.BlinkInterval = 500;
            this.plcLed.Label = "运行状态";
            this.plcLed.LabelPosition = IndustrialCtrls.Leds.SWLed.LedLabelPosition.Top;
            this.plcLed.LedColor = System.Drawing.Color.Lime;
            this.plcLed.LedSize = new System.Drawing.SizeF(30F, 30F);
            this.plcLed.Location = new System.Drawing.Point(24, 4);
            this.plcLed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.plcLed.Name = "plcLed";
            this.plcLed.Renderer = null;
            this.plcLed.Size = new System.Drawing.Size(75, 75);
            this.plcLed.State = IndustrialCtrls.Leds.SWLed.LedState.Off;
            this.plcLed.Style = IndustrialCtrls.Leds.SWLed.LedStyle.Circular;
            this.plcLed.TabIndex = 0;
            // 
            // splitContRtUp
            // 
            this.splitContRtUp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContRtUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContRtUp.Location = new System.Drawing.Point(0, 0);
            this.splitContRtUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContRtUp.Name = "splitContRtUp";
            this.splitContRtUp.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContRtUp.Panel1
            // 
            this.splitContRtUp.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContRtUp.Panel2
            // 
            this.splitContRtUp.Panel2.Controls.Add(this.splitContMidLfRt);
            this.splitContRtUp.Size = new System.Drawing.Size(657, 413);
            this.splitContRtUp.SplitterDistance = 160;
            this.splitContRtUp.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(653, 156);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "轴参数设置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 9;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.12285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.34644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.12285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.34644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.12285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.34644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.12285F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.34644F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.12285F));
            this.tableLayoutPanel1.Controls.Add(this.cbbInit, 7, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbPosLimit, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbAccel, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbUnits, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbNegLimit, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbDecel, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cbbSpeed, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.axisname, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 6, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnConfirmParam, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveParam, 8, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbbAxis, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(647, 134);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // cbbInit
            // 
            this.cbbInit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbInit.FormattingEnabled = true;
            this.cbbInit.Location = new System.Drawing.Point(500, 89);
            this.cbbInit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbInit.Name = "cbbInit";
            this.cbbInit.Size = new System.Drawing.Size(72, 23);
            this.cbbInit.TabIndex = 17;
            // 
            // cbbPosLimit
            // 
            this.cbbPosLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbPosLimit.FormattingEnabled = true;
            this.cbbPosLimit.Location = new System.Drawing.Point(356, 89);
            this.cbbPosLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbPosLimit.Name = "cbbPosLimit";
            this.cbbPosLimit.Size = new System.Drawing.Size(72, 23);
            this.cbbPosLimit.TabIndex = 16;
            // 
            // cbbAccel
            // 
            this.cbbAccel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbAccel.FormattingEnabled = true;
            this.cbbAccel.Location = new System.Drawing.Point(212, 89);
            this.cbbAccel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbAccel.Name = "cbbAccel";
            this.cbbAccel.Size = new System.Drawing.Size(72, 23);
            this.cbbAccel.TabIndex = 15;
            // 
            // cbbUnits
            // 
            this.cbbUnits.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbUnits.FormatString = "N0";
            this.cbbUnits.FormattingEnabled = true;
            this.cbbUnits.Location = new System.Drawing.Point(68, 89);
            this.cbbUnits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbUnits.Name = "cbbUnits";
            this.cbbUnits.Size = new System.Drawing.Size(72, 23);
            this.cbbUnits.TabIndex = 14;
            // 
            // cbbNegLimit
            // 
            this.cbbNegLimit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbNegLimit.FormattingEnabled = true;
            this.cbbNegLimit.Location = new System.Drawing.Point(500, 22);
            this.cbbNegLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbNegLimit.Name = "cbbNegLimit";
            this.cbbNegLimit.Size = new System.Drawing.Size(72, 23);
            this.cbbNegLimit.TabIndex = 13;
            // 
            // cbbDecel
            // 
            this.cbbDecel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbDecel.FormattingEnabled = true;
            this.cbbDecel.Location = new System.Drawing.Point(356, 22);
            this.cbbDecel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbDecel.Name = "cbbDecel";
            this.cbbDecel.Size = new System.Drawing.Size(72, 23);
            this.cbbDecel.TabIndex = 12;
            // 
            // cbbSpeed
            // 
            this.cbbSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbSpeed.FormattingEnabled = true;
            this.cbbSpeed.Location = new System.Drawing.Point(212, 22);
            this.cbbSpeed.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbSpeed.Name = "cbbSpeed";
            this.cbbSpeed.Size = new System.Drawing.Size(72, 23);
            this.cbbSpeed.TabIndex = 11;
            // 
            // axisname
            // 
            this.axisname.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.axisname.AutoSize = true;
            this.axisname.Location = new System.Drawing.Point(10, 26);
            this.axisname.Name = "axisname";
            this.axisname.Size = new System.Drawing.Size(52, 15);
            this.axisname.TabIndex = 0;
            this.axisname.Text = "选定轴";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "脉冲当量";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(169, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "速度";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "加速度";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "减速度";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(313, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "正限";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(457, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "负限";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(457, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "初始";
            // 
            // btnConfirmParam
            // 
            this.btnConfirmParam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnConfirmParam.Location = new System.Drawing.Point(584, 21);
            this.btnConfirmParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmParam.Name = "btnConfirmParam";
            this.btnConfirmParam.Size = new System.Drawing.Size(60, 25);
            this.btnConfirmParam.TabIndex = 8;
            this.btnConfirmParam.Text = "确定";
            this.btnConfirmParam.UseVisualStyleBackColor = true;
            this.btnConfirmParam.Click += new System.EventHandler(this.btnConfirmParam_Click);
            // 
            // btnSaveParam
            // 
            this.btnSaveParam.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSaveParam.Location = new System.Drawing.Point(584, 88);
            this.btnSaveParam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveParam.Name = "btnSaveParam";
            this.btnSaveParam.Size = new System.Drawing.Size(60, 25);
            this.btnSaveParam.TabIndex = 9;
            this.btnSaveParam.Text = "保存";
            this.btnSaveParam.UseVisualStyleBackColor = true;
            this.btnSaveParam.Click += new System.EventHandler(this.btnSaveParam_Click);
            // 
            // cbbAxis
            // 
            this.cbbAxis.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbbAxis.FormattingEnabled = true;
            this.cbbAxis.Location = new System.Drawing.Point(68, 22);
            this.cbbAxis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbAxis.Name = "cbbAxis";
            this.cbbAxis.Size = new System.Drawing.Size(72, 23);
            this.cbbAxis.TabIndex = 10;
            this.cbbAxis.SelectedIndexChanged += new System.EventHandler(this.cbbAxis_SelectedIndexChanged);
            // 
            // splitContMidLfRt
            // 
            this.splitContMidLfRt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContMidLfRt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMidLfRt.Location = new System.Drawing.Point(0, 0);
            this.splitContMidLfRt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContMidLfRt.Name = "splitContMidLfRt";
            // 
            // splitContMidLfRt.Panel1
            // 
            this.splitContMidLfRt.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContMidLfRt.Panel2
            // 
            this.splitContMidLfRt.Panel2.Controls.Add(this.splitContMidRtUpDn);
            this.splitContMidLfRt.Size = new System.Drawing.Size(657, 249);
            this.splitContMidLfRt.SplitterDistance = 307;
            this.splitContMidLfRt.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstBoxTip);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(303, 245);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "提示信息";
            // 
            // lstBoxTip
            // 
            this.lstBoxTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBoxTip.FormattingEnabled = true;
            this.lstBoxTip.ItemHeight = 15;
            this.lstBoxTip.Location = new System.Drawing.Point(3, 20);
            this.lstBoxTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstBoxTip.Name = "lstBoxTip";
            this.lstBoxTip.Size = new System.Drawing.Size(297, 223);
            this.lstBoxTip.TabIndex = 0;
            // 
            // splitContMidRtUpDn
            // 
            this.splitContMidRtUpDn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContMidRtUpDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContMidRtUpDn.Location = new System.Drawing.Point(0, 0);
            this.splitContMidRtUpDn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContMidRtUpDn.Name = "splitContMidRtUpDn";
            this.splitContMidRtUpDn.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContMidRtUpDn.Panel1
            // 
            this.splitContMidRtUpDn.Panel1.Controls.Add(this.grpCamSvr);
            // 
            // splitContMidRtUpDn.Panel2
            // 
            this.splitContMidRtUpDn.Panel2.Controls.Add(this.grpBoxMode);
            this.splitContMidRtUpDn.Size = new System.Drawing.Size(346, 249);
            this.splitContMidRtUpDn.SplitterDistance = 142;
            this.splitContMidRtUpDn.TabIndex = 0;
            // 
            // grpCamSvr
            // 
            this.grpCamSvr.Controls.Add(this.label10);
            this.grpCamSvr.Controls.Add(this.txtMsg);
            this.grpCamSvr.Controls.Add(this.btnSnd2Svr);
            this.grpCamSvr.Controls.Add(this.btnCnctCameraSvr);
            this.grpCamSvr.Controls.Add(this.txtPort);
            this.grpCamSvr.Controls.Add(this.cbbIP);
            this.grpCamSvr.Controls.Add(this.label9);
            this.grpCamSvr.Controls.Add(this.label8);
            this.grpCamSvr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCamSvr.Location = new System.Drawing.Point(0, 0);
            this.grpCamSvr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpCamSvr.Name = "grpCamSvr";
            this.grpCamSvr.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpCamSvr.Size = new System.Drawing.Size(342, 138);
            this.grpCamSvr.TabIndex = 0;
            this.grpCamSvr.TabStop = false;
            this.grpCamSvr.Text = "视觉上位机";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 122);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "消息:";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(63, 120);
            this.txtMsg.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.Size = new System.Drawing.Size(169, 25);
            this.txtMsg.TabIndex = 4;
            this.txtMsg.Text = "Everything is OK";
            // 
            // btnSnd2Svr
            // 
            this.btnSnd2Svr.Location = new System.Drawing.Point(245, 111);
            this.btnSnd2Svr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSnd2Svr.Name = "btnSnd2Svr";
            this.btnSnd2Svr.Size = new System.Drawing.Size(107, 38);
            this.btnSnd2Svr.TabIndex = 3;
            this.btnSnd2Svr.Text = "发送";
            this.btnSnd2Svr.UseVisualStyleBackColor = true;
            this.btnSnd2Svr.Click += new System.EventHandler(this.btnSnd2Svr_Click);
            // 
            // btnCnctCameraSvr
            // 
            this.btnCnctCameraSvr.Location = new System.Drawing.Point(245, 30);
            this.btnCnctCameraSvr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCnctCameraSvr.Name = "btnCnctCameraSvr";
            this.btnCnctCameraSvr.Size = new System.Drawing.Size(107, 78);
            this.btnCnctCameraSvr.TabIndex = 3;
            this.btnCnctCameraSvr.Text = "连接";
            this.btnCnctCameraSvr.UseVisualStyleBackColor = true;
            this.btnCnctCameraSvr.Click += new System.EventHandler(this.btnCnctCameraSvr_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(67, 70);
            this.txtPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(89, 25);
            this.txtPort.TabIndex = 2;
            // 
            // cbbIP
            // 
            this.cbbIP.FormattingEnabled = true;
            this.cbbIP.Location = new System.Drawing.Point(63, 30);
            this.cbbIP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbbIP.Name = "cbbIP";
            this.cbbIP.Size = new System.Drawing.Size(169, 23);
            this.cbbIP.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "端口:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "IP地址:";
            // 
            // grpBoxMode
            // 
            this.grpBoxMode.Controls.Add(this.btn_InitStatus);
            this.grpBoxMode.Controls.Add(this.txtTargetPosi);
            this.grpBoxMode.Controls.Add(this.btnMove);
            this.grpBoxMode.Controls.Add(this.btnInitPosi);
            this.grpBoxMode.Controls.Add(this.btnMoveIdle);
            this.grpBoxMode.Controls.Add(this.btnSetIdlePosi);
            this.grpBoxMode.Controls.Add(this.btnMoveInit);
            this.grpBoxMode.Controls.Add(this.chbAutoMode);
            this.grpBoxMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBoxMode.Location = new System.Drawing.Point(0, 0);
            this.grpBoxMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoxMode.Name = "grpBoxMode";
            this.grpBoxMode.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpBoxMode.Size = new System.Drawing.Size(342, 99);
            this.grpBoxMode.TabIndex = 0;
            this.grpBoxMode.TabStop = false;
            this.grpBoxMode.Text = "操作模式";
            // 
            // btn_InitStatus
            // 
            this.btn_InitStatus.Location = new System.Drawing.Point(257, 50);
            this.btn_InitStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_InitStatus.Name = "btn_InitStatus";
            this.btn_InitStatus.Size = new System.Drawing.Size(82, 45);
            this.btn_InitStatus.TabIndex = 9;
            this.btn_InitStatus.Text = "初始状态";
            this.btn_InitStatus.UseVisualStyleBackColor = true;
            this.btn_InitStatus.Click += new System.EventHandler(this.btn_InitStatus_Click);
            // 
            // txtTargetPosi
            // 
            this.txtTargetPosi.Location = new System.Drawing.Point(131, 19);
            this.txtTargetPosi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTargetPosi.Name = "txtTargetPosi";
            this.txtTargetPosi.Size = new System.Drawing.Size(119, 25);
            this.txtTargetPosi.TabIndex = 5;
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(256, 19);
            this.btnMove.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(120, 25);
            this.btnMove.TabIndex = 6;
            this.btnMove.Text = "运动到坐标";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnInitPosi
            // 
            this.btnInitPosi.Location = new System.Drawing.Point(131, 78);
            this.btnInitPosi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInitPosi.Name = "btnInitPosi";
            this.btnInitPosi.Size = new System.Drawing.Size(119, 28);
            this.btnInitPosi.TabIndex = 8;
            this.btnInitPosi.Text = "保存初始位置";
            this.btnInitPosi.UseVisualStyleBackColor = true;
            this.btnInitPosi.Click += new System.EventHandler(this.btnInitPosi_Click);
            // 
            // btnMoveIdle
            // 
            this.btnMoveIdle.Location = new System.Drawing.Point(0, 76);
            this.btnMoveIdle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveIdle.Name = "btnMoveIdle";
            this.btnMoveIdle.Size = new System.Drawing.Size(123, 26);
            this.btnMoveIdle.TabIndex = 2;
            this.btnMoveIdle.Text = "运动到待机位置";
            this.btnMoveIdle.UseVisualStyleBackColor = true;
            this.btnMoveIdle.Click += new System.EventHandler(this.btnMoveIdle_Click);
            // 
            // btnSetIdlePosi
            // 
            this.btnSetIdlePosi.Location = new System.Drawing.Point(131, 48);
            this.btnSetIdlePosi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSetIdlePosi.Name = "btnSetIdlePosi";
            this.btnSetIdlePosi.Size = new System.Drawing.Size(119, 28);
            this.btnSetIdlePosi.TabIndex = 7;
            this.btnSetIdlePosi.Text = " 保存垃圾桶位置";
            this.btnSetIdlePosi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetIdlePosi.UseVisualStyleBackColor = true;
            this.btnSetIdlePosi.Click += new System.EventHandler(this.btnSetIdlePosi_Click);
            // 
            // btnMoveInit
            // 
            this.btnMoveInit.Location = new System.Drawing.Point(1, 48);
            this.btnMoveInit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveInit.Name = "btnMoveInit";
            this.btnMoveInit.Size = new System.Drawing.Size(121, 28);
            this.btnMoveInit.TabIndex = 1;
            this.btnMoveInit.Text = "运动到垃圾桶位置";
            this.btnMoveInit.UseVisualStyleBackColor = true;
            this.btnMoveInit.Click += new System.EventHandler(this.btnMoveInit_Click);
            // 
            // chbAutoMode
            // 
            this.chbAutoMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAutoMode.AutoSize = true;
            this.chbAutoMode.Location = new System.Drawing.Point(9, 22);
            this.chbAutoMode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chbAutoMode.Name = "chbAutoMode";
            this.chbAutoMode.Size = new System.Drawing.Size(89, 19);
            this.chbAutoMode.TabIndex = 0;
            this.chbAutoMode.Text = "自动模式";
            this.chbAutoMode.UseVisualStyleBackColor = true;
            this.chbAutoMode.CheckStateChanged += new System.EventHandler(this.chbAutoMode_CheckStateChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox4.Size = new System.Drawing.Size(939, 296);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "轴位置与状态";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 13;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.688633F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.688633F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.692975F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.btnEmStop, 1, 7);
            this.tableLayoutPanel2.Controls.Add(this.button21, 11, 6);
            this.tableLayoutPanel2.Controls.Add(this.Btn5Init, 12, 6);
            this.tableLayoutPanel2.Controls.Add(this.btn5Backward, 10, 6);
            this.tableLayoutPanel2.Controls.Add(this.btn4Backward, 10, 5);
            this.tableLayoutPanel2.Controls.Add(this.btn5Forward, 9, 6);
            this.tableLayoutPanel2.Controls.Add(this.btn3Backward, 10, 4);
            this.tableLayoutPanel2.Controls.Add(this.Btn2Init, 12, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn4Forward, 9, 5);
            this.tableLayoutPanel2.Controls.Add(this.btn3Forward, 9, 4);
            this.tableLayoutPanel2.Controls.Add(this.button9, 11, 3);
            this.tableLayoutPanel2.Controls.Add(this.Btn0Init, 12, 1);
            this.tableLayoutPanel2.Controls.Add(this.button13, 11, 4);
            this.tableLayoutPanel2.Controls.Add(this.btn2Forward, 9, 3);
            this.tableLayoutPanel2.Controls.Add(this.label15, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btn1Backward, 10, 2);
            this.tableLayoutPanel2.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.btn0Backward, 10, 1);
            this.tableLayoutPanel2.Controls.Add(this.label16, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.label14, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.btn0Home, 11, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn0Forward, 9, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl3Posi, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbl4Posi, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl5Posi, 1, 6);
            this.tableLayoutPanel2.Controls.Add(this.lbl1FLimit, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl1BLimit, 7, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl3Sts, 3, 4);
            this.tableLayoutPanel2.Controls.Add(this.btn1Forward, 9, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl3BLimit, 7, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbl4Sts, 3, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl4BLimit, 7, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl5Sts, 3, 6);
            this.tableLayoutPanel2.Controls.Add(this.lbl5FLimit, 5, 6);
            this.tableLayoutPanel2.Controls.Add(this.lbl0Sts, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label22, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl1Posi, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl1Sts, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl5BLimit, 7, 6);
            this.tableLayoutPanel2.Controls.Add(this.label18, 0, 7);
            this.tableLayoutPanel2.Controls.Add(this.label20, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label19, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label21, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lbl0FLimit, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl0Posi, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl0BLimit, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.lbl2Posi, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl2Sts, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.lbl2FLimit, 5, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn1Home, 11, 2);
            this.tableLayoutPanel2.Controls.Add(this.Btn1Init, 12, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbl3FLimit, 5, 4);
            this.tableLayoutPanel2.Controls.Add(this.lbl2BLimit, 7, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn2Backward, 10, 3);
            this.tableLayoutPanel2.Controls.Add(this.Btn3Init, 12, 4);
            this.tableLayoutPanel2.Controls.Add(this.button17, 11, 5);
            this.tableLayoutPanel2.Controls.Add(this.lbl4FLimit, 5, 5);
            this.tableLayoutPanel2.Controls.Add(this.Btn4Init, 12, 5);
            this.tableLayoutPanel2.Controls.Add(this.label24, 9, 0);
            this.tableLayoutPanel2.Controls.Add(this.label26, 10, 0);
            this.tableLayoutPanel2.Controls.Add(this.label27, 11, 0);
            this.tableLayoutPanel2.Controls.Add(this.初始, 12, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 20);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 8;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.664289F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33859F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33859F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33859F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33859F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33859F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.33859F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.30419F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(933, 274);
            this.tableLayoutPanel2.TabIndex = 0;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // btnEmStop
            // 
            this.btnEmStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnEmStop.BackColor = System.Drawing.Color.Red;
            this.tableLayoutPanel2.SetColumnSpan(this.btnEmStop, 10);
            this.btnEmStop.Location = new System.Drawing.Point(75, 238);
            this.btnEmStop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEmStop.Name = "btnEmStop";
            this.btnEmStop.Size = new System.Drawing.Size(701, 31);
            this.btnEmStop.TabIndex = 38;
            this.btnEmStop.Text = "急停";
            this.btnEmStop.UseVisualStyleBackColor = false;
            this.btnEmStop.Click += new System.EventHandler(this.btnEmStop_Click);
            // 
            // button21
            // 
            this.button21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button21.Location = new System.Drawing.Point(789, 203);
            this.button21.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button21.Name = "button21";
            this.button21.Size = new System.Drawing.Size(55, 25);
            this.button21.TabIndex = 27;
            this.button21.Text = "预设位置";
            this.button21.UseVisualStyleBackColor = true;
            this.button21.Click += new System.EventHandler(this.button21_Click);
            // 
            // Btn5Init
            // 
            this.Btn5Init.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn5Init.Location = new System.Drawing.Point(865, 202);
            this.Btn5Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn5Init.Name = "Btn5Init";
            this.Btn5Init.Size = new System.Drawing.Size(55, 28);
            this.Btn5Init.TabIndex = 28;
            this.Btn5Init.Text = "初始";
            this.Btn5Init.UseVisualStyleBackColor = true;
            this.Btn5Init.Click += new System.EventHandler(this.Btn5Init_Click);
            // 
            // btn5Backward
            // 
            this.btn5Backward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn5Backward.Location = new System.Drawing.Point(718, 202);
            this.btn5Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn5Backward.Name = "btn5Backward";
            this.btn5Backward.Size = new System.Drawing.Size(55, 28);
            this.btn5Backward.TabIndex = 30;
            this.btn5Backward.Text = "反向";
            this.btn5Backward.UseVisualStyleBackColor = true;
            this.btn5Backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn5Backward_MouseDown);
            this.btn5Backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn5Backward_MouseUp);
            // 
            // btn4Backward
            // 
            this.btn4Backward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn4Backward.Location = new System.Drawing.Point(718, 166);
            this.btn4Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn4Backward.Name = "btn4Backward";
            this.btn4Backward.Size = new System.Drawing.Size(55, 28);
            this.btn4Backward.TabIndex = 26;
            this.btn4Backward.Text = "反向";
            this.btn4Backward.UseVisualStyleBackColor = true;
            this.btn4Backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn4Backward_MouseDown);
            this.btn4Backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn4Backward_MouseUp);
            // 
            // btn5Forward
            // 
            this.btn5Forward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn5Forward.Location = new System.Drawing.Point(647, 202);
            this.btn5Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn5Forward.Name = "btn5Forward";
            this.btn5Forward.Size = new System.Drawing.Size(55, 28);
            this.btn5Forward.TabIndex = 29;
            this.btn5Forward.Text = "正向";
            this.btn5Forward.UseVisualStyleBackColor = true;
            this.btn5Forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn5Forward_MouseDown);
            this.btn5Forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn5Forward_MouseUp);
            // 
            // btn3Backward
            // 
            this.btn3Backward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn3Backward.Location = new System.Drawing.Point(718, 130);
            this.btn3Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn3Backward.Name = "btn3Backward";
            this.btn3Backward.Size = new System.Drawing.Size(55, 28);
            this.btn3Backward.TabIndex = 22;
            this.btn3Backward.Text = "反向";
            this.btn3Backward.UseVisualStyleBackColor = true;
            this.btn3Backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn3Backward_MouseDown);
            this.btn3Backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn3Backward_MouseUp);
            // 
            // Btn2Init
            // 
            this.Btn2Init.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn2Init.Location = new System.Drawing.Point(865, 94);
            this.Btn2Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn2Init.Name = "Btn2Init";
            this.Btn2Init.Size = new System.Drawing.Size(55, 28);
            this.Btn2Init.TabIndex = 16;
            this.Btn2Init.Text = "初始";
            this.Btn2Init.UseVisualStyleBackColor = true;
            this.Btn2Init.Click += new System.EventHandler(this.Btn2Init_Click);
            // 
            // btn4Forward
            // 
            this.btn4Forward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn4Forward.Location = new System.Drawing.Point(647, 166);
            this.btn4Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn4Forward.Name = "btn4Forward";
            this.btn4Forward.Size = new System.Drawing.Size(55, 28);
            this.btn4Forward.TabIndex = 25;
            this.btn4Forward.Text = "正向";
            this.btn4Forward.UseVisualStyleBackColor = true;
            this.btn4Forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn4Forward_MouseDown);
            this.btn4Forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn4Forward_MouseUp);
            // 
            // btn3Forward
            // 
            this.btn3Forward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn3Forward.Location = new System.Drawing.Point(647, 130);
            this.btn3Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn3Forward.Name = "btn3Forward";
            this.btn3Forward.Size = new System.Drawing.Size(55, 28);
            this.btn3Forward.TabIndex = 21;
            this.btn3Forward.Text = "正向";
            this.btn3Forward.UseVisualStyleBackColor = true;
            this.btn3Forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn3Forward_MouseDown);
            this.btn3Forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn3Forward_MouseUp);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.Location = new System.Drawing.Point(789, 95);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(55, 25);
            this.button9.TabIndex = 15;
            this.button9.Text = "回零";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Btn0Init
            // 
            this.Btn0Init.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn0Init.Location = new System.Drawing.Point(865, 22);
            this.Btn0Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn0Init.Name = "Btn0Init";
            this.Btn0Init.Size = new System.Drawing.Size(55, 28);
            this.Btn0Init.TabIndex = 1;
            this.Btn0Init.Text = "初始";
            this.Btn0Init.UseVisualStyleBackColor = true;
            this.Btn0Init.Click += new System.EventHandler(this.Btn0Init_Click);
            // 
            // button13
            // 
            this.button13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button13.Location = new System.Drawing.Point(789, 131);
            this.button13.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(55, 25);
            this.button13.TabIndex = 19;
            this.button13.Text = "回零";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // btn2Forward
            // 
            this.btn2Forward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2Forward.Location = new System.Drawing.Point(647, 94);
            this.btn2Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn2Forward.Name = "btn2Forward";
            this.btn2Forward.Size = new System.Drawing.Size(55, 28);
            this.btn2Forward.TabIndex = 17;
            this.btn2Forward.Text = "正向";
            this.btn2Forward.UseVisualStyleBackColor = true;
            this.btn2Forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn2Forward_MouseDown);
            this.btn2Forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn2Forward_MouseUp);
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 136);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 15);
            this.label15.TabIndex = 8;
            this.label15.Text = "3轴";
            // 
            // btn1Backward
            // 
            this.btn1Backward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn1Backward.Location = new System.Drawing.Point(718, 58);
            this.btn1Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn1Backward.Name = "btn1Backward";
            this.btn1Backward.Size = new System.Drawing.Size(55, 28);
            this.btn1Backward.TabIndex = 14;
            this.btn1Backward.Text = "反向";
            this.btn1Backward.UseVisualStyleBackColor = true;
            this.btn1Backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn1Backward_MouseDown);
            this.btn1Backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn1Backward_MouseUp);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 15);
            this.label13.TabIndex = 6;
            this.label13.Text = "轴区域";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 208);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(30, 15);
            this.label17.TabIndex = 10;
            this.label17.Text = "5轴";
            // 
            // btn0Backward
            // 
            this.btn0Backward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn0Backward.Location = new System.Drawing.Point(718, 22);
            this.btn0Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn0Backward.Name = "btn0Backward";
            this.btn0Backward.Size = new System.Drawing.Size(55, 28);
            this.btn0Backward.TabIndex = 11;
            this.btn0Backward.Text = "反向";
            this.btn0Backward.UseVisualStyleBackColor = true;
            this.btn0Backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn0Backward_MouseDown);
            this.btn0Backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn0Backward_MouseUp);
            // 
            // label16
            // 
            this.label16.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 172);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 15);
            this.label16.TabIndex = 9;
            this.label16.Text = "4轴";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 100);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(30, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "2轴";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 64);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 15);
            this.label12.TabIndex = 5;
            this.label12.Text = "1轴";
            // 
            // btn0Home
            // 
            this.btn0Home.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn0Home.Location = new System.Drawing.Point(789, 22);
            this.btn0Home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn0Home.Name = "btn0Home";
            this.btn0Home.Size = new System.Drawing.Size(55, 28);
            this.btn0Home.TabIndex = 0;
            this.btn0Home.Text = "回零";
            this.btn0Home.UseVisualStyleBackColor = true;
            this.btn0Home.Click += new System.EventHandler(this.btn0Home_Click);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 28);
            this.label11.Margin = new System.Windows.Forms.Padding(0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "0轴";
            // 
            // btn0Forward
            // 
            this.btn0Forward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn0Forward.Location = new System.Drawing.Point(647, 22);
            this.btn0Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn0Forward.Name = "btn0Forward";
            this.btn0Forward.Size = new System.Drawing.Size(55, 28);
            this.btn0Forward.TabIndex = 3;
            this.btn0Forward.Text = "正向";
            this.btn0Forward.UseVisualStyleBackColor = true;
            this.btn0Forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn0Forward_MouseDown);
            this.btn0Forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn0Forward_MouseUp);
            // 
            // lbl3Posi
            // 
            this.lbl3Posi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl3Posi.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl3Posi, 2);
            this.lbl3Posi.Location = new System.Drawing.Point(134, 136);
            this.lbl3Posi.Name = "lbl3Posi";
            this.lbl3Posi.Size = new System.Drawing.Size(15, 15);
            this.lbl3Posi.TabIndex = 42;
            this.lbl3Posi.Text = "0";
            // 
            // lbl4Posi
            // 
            this.lbl4Posi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl4Posi.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl4Posi, 2);
            this.lbl4Posi.Location = new System.Drawing.Point(134, 172);
            this.lbl4Posi.Name = "lbl4Posi";
            this.lbl4Posi.Size = new System.Drawing.Size(15, 15);
            this.lbl4Posi.TabIndex = 43;
            this.lbl4Posi.Text = "0";
            // 
            // lbl5Posi
            // 
            this.lbl5Posi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl5Posi.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl5Posi, 2);
            this.lbl5Posi.Location = new System.Drawing.Point(134, 208);
            this.lbl5Posi.Name = "lbl5Posi";
            this.lbl5Posi.Size = new System.Drawing.Size(15, 15);
            this.lbl5Posi.TabIndex = 44;
            this.lbl5Posi.Text = "0";
            // 
            // lbl1FLimit
            // 
            this.lbl1FLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl1FLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl1FLimit, 2);
            this.lbl1FLimit.Location = new System.Drawing.Point(418, 64);
            this.lbl1FLimit.Name = "lbl1FLimit";
            this.lbl1FLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl1FLimit.TabIndex = 49;
            this.lbl1FLimit.Text = "0";
            // 
            // lbl1BLimit
            // 
            this.lbl1BLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl1BLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl1BLimit, 2);
            this.lbl1BLimit.Location = new System.Drawing.Point(560, 64);
            this.lbl1BLimit.Name = "lbl1BLimit";
            this.lbl1BLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl1BLimit.TabIndex = 50;
            this.lbl1BLimit.Text = "0";
            // 
            // lbl3Sts
            // 
            this.lbl3Sts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl3Sts.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl3Sts, 2);
            this.lbl3Sts.Location = new System.Drawing.Point(276, 136);
            this.lbl3Sts.Name = "lbl3Sts";
            this.lbl3Sts.Size = new System.Drawing.Size(15, 15);
            this.lbl3Sts.TabIndex = 54;
            this.lbl3Sts.Text = "0";
            // 
            // btn1Forward
            // 
            this.btn1Forward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn1Forward.Location = new System.Drawing.Point(647, 58);
            this.btn1Forward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn1Forward.Name = "btn1Forward";
            this.btn1Forward.Size = new System.Drawing.Size(55, 28);
            this.btn1Forward.TabIndex = 13;
            this.btn1Forward.Text = "正向";
            this.btn1Forward.UseVisualStyleBackColor = true;
            this.btn1Forward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn1Forward_MouseDown);
            this.btn1Forward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn1Forward_MouseUp);
            // 
            // lbl3BLimit
            // 
            this.lbl3BLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl3BLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl3BLimit, 2);
            this.lbl3BLimit.Location = new System.Drawing.Point(560, 136);
            this.lbl3BLimit.Name = "lbl3BLimit";
            this.lbl3BLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl3BLimit.TabIndex = 56;
            this.lbl3BLimit.Text = "0";
            // 
            // lbl4Sts
            // 
            this.lbl4Sts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl4Sts.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl4Sts, 2);
            this.lbl4Sts.Location = new System.Drawing.Point(276, 172);
            this.lbl4Sts.Name = "lbl4Sts";
            this.lbl4Sts.Size = new System.Drawing.Size(15, 15);
            this.lbl4Sts.TabIndex = 57;
            this.lbl4Sts.Text = "0";
            // 
            // lbl4BLimit
            // 
            this.lbl4BLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl4BLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl4BLimit, 2);
            this.lbl4BLimit.Location = new System.Drawing.Point(560, 172);
            this.lbl4BLimit.Name = "lbl4BLimit";
            this.lbl4BLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl4BLimit.TabIndex = 59;
            this.lbl4BLimit.Text = "0";
            // 
            // lbl5Sts
            // 
            this.lbl5Sts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl5Sts.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl5Sts, 2);
            this.lbl5Sts.Location = new System.Drawing.Point(276, 208);
            this.lbl5Sts.Name = "lbl5Sts";
            this.lbl5Sts.Size = new System.Drawing.Size(15, 15);
            this.lbl5Sts.TabIndex = 60;
            this.lbl5Sts.Text = "0";
            // 
            // lbl5FLimit
            // 
            this.lbl5FLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl5FLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl5FLimit, 2);
            this.lbl5FLimit.Location = new System.Drawing.Point(418, 208);
            this.lbl5FLimit.Name = "lbl5FLimit";
            this.lbl5FLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl5FLimit.TabIndex = 61;
            this.lbl5FLimit.Text = "0";
            // 
            // lbl0Sts
            // 
            this.lbl0Sts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0Sts.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl0Sts, 2);
            this.lbl0Sts.Location = new System.Drawing.Point(276, 28);
            this.lbl0Sts.Name = "lbl0Sts";
            this.lbl0Sts.Size = new System.Drawing.Size(15, 15);
            this.lbl0Sts.TabIndex = 45;
            this.lbl0Sts.Text = "0";
            // 
            // label22
            // 
            this.label22.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label22.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label22, 2);
            this.label22.Location = new System.Drawing.Point(542, 1);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(52, 15);
            this.label22.TabIndex = 37;
            this.label22.Text = "负限位";
            // 
            // lbl1Posi
            // 
            this.lbl1Posi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl1Posi.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl1Posi, 2);
            this.lbl1Posi.Location = new System.Drawing.Point(134, 64);
            this.lbl1Posi.Name = "lbl1Posi";
            this.lbl1Posi.Size = new System.Drawing.Size(15, 15);
            this.lbl1Posi.TabIndex = 41;
            this.lbl1Posi.Text = "0";
            // 
            // lbl1Sts
            // 
            this.lbl1Sts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl1Sts.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl1Sts, 2);
            this.lbl1Sts.Location = new System.Drawing.Point(276, 64);
            this.lbl1Sts.Name = "lbl1Sts";
            this.lbl1Sts.Size = new System.Drawing.Size(15, 15);
            this.lbl1Sts.TabIndex = 48;
            this.lbl1Sts.Text = "0";
            // 
            // lbl5BLimit
            // 
            this.lbl5BLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl5BLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl5BLimit, 2);
            this.lbl5BLimit.Location = new System.Drawing.Point(560, 208);
            this.lbl5BLimit.Name = "lbl5BLimit";
            this.lbl5BLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl5BLimit.TabIndex = 62;
            this.lbl5BLimit.Text = "0";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 246);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(52, 15);
            this.label18.TabIndex = 33;
            this.label18.Text = "所有轴";
            // 
            // label20
            // 
            this.label20.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label20.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label20, 2);
            this.label20.Location = new System.Drawing.Point(258, 1);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(52, 15);
            this.label20.TabIndex = 35;
            this.label20.Text = "轴状态";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label19, 2);
            this.label19.Location = new System.Drawing.Point(116, 1);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 15);
            this.label19.TabIndex = 34;
            this.label19.Text = "轴坐标";
            // 
            // label21
            // 
            this.label21.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label21.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.label21, 2);
            this.label21.Location = new System.Drawing.Point(400, 1);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 15);
            this.label21.TabIndex = 36;
            this.label21.Text = "正限位";
            // 
            // lbl0FLimit
            // 
            this.lbl0FLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0FLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl0FLimit, 2);
            this.lbl0FLimit.Location = new System.Drawing.Point(418, 28);
            this.lbl0FLimit.Name = "lbl0FLimit";
            this.lbl0FLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl0FLimit.TabIndex = 46;
            this.lbl0FLimit.Text = "0";
            // 
            // lbl0Posi
            // 
            this.lbl0Posi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0Posi.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl0Posi, 2);
            this.lbl0Posi.Location = new System.Drawing.Point(134, 28);
            this.lbl0Posi.Name = "lbl0Posi";
            this.lbl0Posi.Size = new System.Drawing.Size(15, 15);
            this.lbl0Posi.TabIndex = 39;
            this.lbl0Posi.Text = "0";
            // 
            // lbl0BLimit
            // 
            this.lbl0BLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl0BLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl0BLimit, 2);
            this.lbl0BLimit.Location = new System.Drawing.Point(560, 28);
            this.lbl0BLimit.Name = "lbl0BLimit";
            this.lbl0BLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl0BLimit.TabIndex = 47;
            this.lbl0BLimit.Text = "0";
            // 
            // lbl2Posi
            // 
            this.lbl2Posi.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl2Posi.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl2Posi, 2);
            this.lbl2Posi.Location = new System.Drawing.Point(134, 100);
            this.lbl2Posi.Name = "lbl2Posi";
            this.lbl2Posi.Size = new System.Drawing.Size(15, 15);
            this.lbl2Posi.TabIndex = 40;
            this.lbl2Posi.Text = "0";
            // 
            // lbl2Sts
            // 
            this.lbl2Sts.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl2Sts, 2);
            this.lbl2Sts.Location = new System.Drawing.Point(276, 100);
            this.lbl2Sts.Name = "lbl2Sts";
            this.lbl2Sts.Size = new System.Drawing.Size(15, 15);
            this.lbl2Sts.TabIndex = 51;
            this.lbl2Sts.Text = "0";
            // 
            // lbl2FLimit
            // 
            this.lbl2FLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl2FLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl2FLimit, 2);
            this.lbl2FLimit.Location = new System.Drawing.Point(418, 100);
            this.lbl2FLimit.Name = "lbl2FLimit";
            this.lbl2FLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl2FLimit.TabIndex = 52;
            this.lbl2FLimit.Text = "0";
            // 
            // btn1Home
            // 
            this.btn1Home.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn1Home.Location = new System.Drawing.Point(789, 58);
            this.btn1Home.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn1Home.Name = "btn1Home";
            this.btn1Home.Size = new System.Drawing.Size(55, 28);
            this.btn1Home.TabIndex = 2;
            this.btn1Home.Text = "回零";
            this.btn1Home.UseVisualStyleBackColor = true;
            this.btn1Home.Click += new System.EventHandler(this.btn1Home_Click);
            // 
            // Btn1Init
            // 
            this.Btn1Init.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn1Init.Location = new System.Drawing.Point(865, 58);
            this.Btn1Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn1Init.Name = "Btn1Init";
            this.Btn1Init.Size = new System.Drawing.Size(55, 28);
            this.Btn1Init.TabIndex = 12;
            this.Btn1Init.Text = "初始";
            this.Btn1Init.UseVisualStyleBackColor = true;
            this.Btn1Init.Click += new System.EventHandler(this.Btn1Init_Click);
            // 
            // lbl3FLimit
            // 
            this.lbl3FLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl3FLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl3FLimit, 2);
            this.lbl3FLimit.Location = new System.Drawing.Point(418, 136);
            this.lbl3FLimit.Name = "lbl3FLimit";
            this.lbl3FLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl3FLimit.TabIndex = 55;
            this.lbl3FLimit.Text = "0";
            // 
            // lbl2BLimit
            // 
            this.lbl2BLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl2BLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl2BLimit, 2);
            this.lbl2BLimit.Location = new System.Drawing.Point(560, 100);
            this.lbl2BLimit.Name = "lbl2BLimit";
            this.lbl2BLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl2BLimit.TabIndex = 53;
            this.lbl2BLimit.Text = "0";
            // 
            // btn2Backward
            // 
            this.btn2Backward.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn2Backward.Location = new System.Drawing.Point(718, 94);
            this.btn2Backward.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn2Backward.Name = "btn2Backward";
            this.btn2Backward.Size = new System.Drawing.Size(55, 28);
            this.btn2Backward.TabIndex = 18;
            this.btn2Backward.Text = "反向";
            this.btn2Backward.UseVisualStyleBackColor = true;
            this.btn2Backward.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn2Backward_MouseDown);
            this.btn2Backward.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn2Backward_MouseUp);
            // 
            // Btn3Init
            // 
            this.Btn3Init.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn3Init.Location = new System.Drawing.Point(865, 130);
            this.Btn3Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn3Init.Name = "Btn3Init";
            this.Btn3Init.Size = new System.Drawing.Size(55, 28);
            this.Btn3Init.TabIndex = 20;
            this.Btn3Init.Text = "初始";
            this.Btn3Init.UseVisualStyleBackColor = true;
            this.Btn3Init.Click += new System.EventHandler(this.Btn3Init_Click);
            // 
            // button17
            // 
            this.button17.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button17.Location = new System.Drawing.Point(789, 167);
            this.button17.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(55, 25);
            this.button17.TabIndex = 23;
            this.button17.Text = "回零";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // lbl4FLimit
            // 
            this.lbl4FLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl4FLimit.AutoSize = true;
            this.tableLayoutPanel2.SetColumnSpan(this.lbl4FLimit, 2);
            this.lbl4FLimit.Location = new System.Drawing.Point(418, 172);
            this.lbl4FLimit.Name = "lbl4FLimit";
            this.lbl4FLimit.Size = new System.Drawing.Size(15, 15);
            this.lbl4FLimit.TabIndex = 58;
            this.lbl4FLimit.Text = "0";
            // 
            // Btn4Init
            // 
            this.Btn4Init.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Btn4Init.Location = new System.Drawing.Point(865, 166);
            this.Btn4Init.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn4Init.Name = "Btn4Init";
            this.Btn4Init.Size = new System.Drawing.Size(55, 28);
            this.Btn4Init.TabIndex = 24;
            this.Btn4Init.Text = "初始";
            this.Btn4Init.UseVisualStyleBackColor = true;
            this.Btn4Init.Click += new System.EventHandler(this.Btn4Init_Click);
            // 
            // label24
            // 
            this.label24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(656, 1);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 15);
            this.label24.TabIndex = 63;
            this.label24.Text = "正向";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(727, 1);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(37, 15);
            this.label26.TabIndex = 64;
            this.label26.Text = "反向";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(798, 1);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(37, 15);
            this.label27.TabIndex = 65;
            this.label27.Text = "回零";
            // 
            // 初始
            // 
            this.初始.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.初始.AutoSize = true;
            this.初始.Location = new System.Drawing.Point(874, 1);
            this.初始.Name = "初始";
            this.初始.Size = new System.Drawing.Size(37, 15);
            this.初始.TabIndex = 66;
            this.初始.Text = "初始";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPage1.Size = new System.Drawing.Size(949, 725);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "坐标系校正";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.运动模块);
            this.flowLayoutPanel1.Controls.Add(this.groupBox9);
            this.flowLayoutPanel1.Controls.Add(this.groupBox8);
            this.flowLayoutPanel1.Controls.Add(this.groupBox7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 2);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(943, 721);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // 运动模块
            // 
            this.运动模块.Controls.Add(this.label87);
            this.运动模块.Controls.Add(this.tb_MovePositionLen);
            this.运动模块.Controls.Add(this.Btn_ZMinus);
            this.运动模块.Controls.Add(this.Btn_ZPlus);
            this.运动模块.Controls.Add(this.Btn_YMinus);
            this.运动模块.Controls.Add(this.Btn_YPlus);
            this.运动模块.Controls.Add(this.Btn_XMinus);
            this.运动模块.Controls.Add(this.Btn_XPuls);
            this.运动模块.Location = new System.Drawing.Point(3, 2);
            this.运动模块.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.运动模块.Name = "运动模块";
            this.运动模块.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.运动模块.Size = new System.Drawing.Size(400, 222);
            this.运动模块.TabIndex = 0;
            this.运动模块.TabStop = false;
            this.运动模块.Text = "运动模块";
            // 
            // label87
            // 
            this.label87.AutoSize = true;
            this.label87.Location = new System.Drawing.Point(0, 36);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(82, 15);
            this.label87.TabIndex = 7;
            this.label87.Text = "移动距离：";
            // 
            // tb_MovePositionLen
            // 
            this.tb_MovePositionLen.Location = new System.Drawing.Point(92, 25);
            this.tb_MovePositionLen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_MovePositionLen.Name = "tb_MovePositionLen";
            this.tb_MovePositionLen.Size = new System.Drawing.Size(100, 25);
            this.tb_MovePositionLen.TabIndex = 6;
            this.tb_MovePositionLen.Leave += new System.EventHandler(this.tb_MovePositionLen_Leave);
            // 
            // Btn_ZMinus
            // 
            this.Btn_ZMinus.Location = new System.Drawing.Point(260, 160);
            this.Btn_ZMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_ZMinus.Name = "Btn_ZMinus";
            this.Btn_ZMinus.Size = new System.Drawing.Size(88, 46);
            this.Btn_ZMinus.TabIndex = 5;
            this.Btn_ZMinus.Text = "Z-";
            this.Btn_ZMinus.UseVisualStyleBackColor = true;
            this.Btn_ZMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_ZMinus_MouseDown);
            this.Btn_ZMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_ZMinus_MouseUp);
            // 
            // Btn_ZPlus
            // 
            this.Btn_ZPlus.Location = new System.Drawing.Point(260, 56);
            this.Btn_ZPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_ZPlus.Name = "Btn_ZPlus";
            this.Btn_ZPlus.Size = new System.Drawing.Size(88, 46);
            this.Btn_ZPlus.TabIndex = 4;
            this.Btn_ZPlus.Text = "Z+";
            this.Btn_ZPlus.UseVisualStyleBackColor = true;
            this.Btn_ZPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_ZPlus_MouseDown);
            this.Btn_ZPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_ZPlus_MouseUp);
            // 
            // Btn_YMinus
            // 
            this.Btn_YMinus.Location = new System.Drawing.Point(169, 108);
            this.Btn_YMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_YMinus.Name = "Btn_YMinus";
            this.Btn_YMinus.Size = new System.Drawing.Size(88, 46);
            this.Btn_YMinus.TabIndex = 3;
            this.Btn_YMinus.Text = "Y-";
            this.Btn_YMinus.UseVisualStyleBackColor = true;
            this.Btn_YMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_YMinus_MouseDown);
            this.Btn_YMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_YMinus_MouseUp);
            // 
            // Btn_YPlus
            // 
            this.Btn_YPlus.Location = new System.Drawing.Point(-4, 108);
            this.Btn_YPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_YPlus.Name = "Btn_YPlus";
            this.Btn_YPlus.Size = new System.Drawing.Size(88, 46);
            this.Btn_YPlus.TabIndex = 2;
            this.Btn_YPlus.Text = "Y+";
            this.Btn_YPlus.UseVisualStyleBackColor = true;
            this.Btn_YPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_YPlus_MouseDown);
            this.Btn_YPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_YPlus_MouseUp);
            // 
            // Btn_XMinus
            // 
            this.Btn_XMinus.Location = new System.Drawing.Point(84, 166);
            this.Btn_XMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_XMinus.Name = "Btn_XMinus";
            this.Btn_XMinus.Size = new System.Drawing.Size(88, 46);
            this.Btn_XMinus.TabIndex = 1;
            this.Btn_XMinus.Text = "X-";
            this.Btn_XMinus.UseVisualStyleBackColor = true;
            this.Btn_XMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_XMinus_MouseDown);
            this.Btn_XMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_XMinus_MouseUp);
            // 
            // Btn_XPuls
            // 
            this.Btn_XPuls.Location = new System.Drawing.Point(81, 56);
            this.Btn_XPuls.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Btn_XPuls.Name = "Btn_XPuls";
            this.Btn_XPuls.Size = new System.Drawing.Size(88, 46);
            this.Btn_XPuls.TabIndex = 0;
            this.Btn_XPuls.Text = "X+";
            this.Btn_XPuls.UseVisualStyleBackColor = true;
            this.Btn_XPuls.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Btn_XPuls_MouseDown);
            this.Btn_XPuls.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Btn_XPuls_MouseUp);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tb_workspaceYMinus);
            this.groupBox9.Controls.Add(this.label72);
            this.groupBox9.Controls.Add(this.btn_SaveWorkspaceLimit);
            this.groupBox9.Controls.Add(this.btn_ConfirmWorkspaceLimit);
            this.groupBox9.Controls.Add(this.tb_workspaceYPlus);
            this.groupBox9.Controls.Add(this.tb_workspaceXMinus);
            this.groupBox9.Controls.Add(this.tb_workspaceXPlus);
            this.groupBox9.Controls.Add(this.label67);
            this.groupBox9.Controls.Add(this.label70);
            this.groupBox9.Controls.Add(this.label71);
            this.groupBox9.Location = new System.Drawing.Point(409, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(528, 221);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "运动空间限位";
            // 
            // tb_workspaceYMinus
            // 
            this.tb_workspaceYMinus.Location = new System.Drawing.Point(109, 172);
            this.tb_workspaceYMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_workspaceYMinus.Name = "tb_workspaceYMinus";
            this.tb_workspaceYMinus.Size = new System.Drawing.Size(100, 25);
            this.tb_workspaceYMinus.TabIndex = 38;
            // 
            // label72
            // 
            this.label72.AutoSize = true;
            this.label72.Location = new System.Drawing.Point(26, 182);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(75, 15);
            this.label72.TabIndex = 37;
            this.label72.Text = "Y负限位：";
            // 
            // btn_SaveWorkspaceLimit
            // 
            this.btn_SaveWorkspaceLimit.Location = new System.Drawing.Point(258, 166);
            this.btn_SaveWorkspaceLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SaveWorkspaceLimit.Name = "btn_SaveWorkspaceLimit";
            this.btn_SaveWorkspaceLimit.Size = new System.Drawing.Size(84, 32);
            this.btn_SaveWorkspaceLimit.TabIndex = 36;
            this.btn_SaveWorkspaceLimit.Text = "保存";
            this.btn_SaveWorkspaceLimit.UseVisualStyleBackColor = true;
            this.btn_SaveWorkspaceLimit.Click += new System.EventHandler(this.btn_SaveWorkspaceLimit_Click);
            // 
            // btn_ConfirmWorkspaceLimit
            // 
            this.btn_ConfirmWorkspaceLimit.Location = new System.Drawing.Point(258, 78);
            this.btn_ConfirmWorkspaceLimit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ConfirmWorkspaceLimit.Name = "btn_ConfirmWorkspaceLimit";
            this.btn_ConfirmWorkspaceLimit.Size = new System.Drawing.Size(81, 38);
            this.btn_ConfirmWorkspaceLimit.TabIndex = 35;
            this.btn_ConfirmWorkspaceLimit.Text = "确认";
            this.btn_ConfirmWorkspaceLimit.UseVisualStyleBackColor = true;
            this.btn_ConfirmWorkspaceLimit.Click += new System.EventHandler(this.btn_ConfirmWorkspaceLimit_Click);
            // 
            // tb_workspaceYPlus
            // 
            this.tb_workspaceYPlus.Location = new System.Drawing.Point(109, 128);
            this.tb_workspaceYPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_workspaceYPlus.Name = "tb_workspaceYPlus";
            this.tb_workspaceYPlus.Size = new System.Drawing.Size(100, 25);
            this.tb_workspaceYPlus.TabIndex = 34;
            // 
            // tb_workspaceXMinus
            // 
            this.tb_workspaceXMinus.Location = new System.Drawing.Point(109, 87);
            this.tb_workspaceXMinus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_workspaceXMinus.Name = "tb_workspaceXMinus";
            this.tb_workspaceXMinus.Size = new System.Drawing.Size(100, 25);
            this.tb_workspaceXMinus.TabIndex = 33;
            // 
            // tb_workspaceXPlus
            // 
            this.tb_workspaceXPlus.Location = new System.Drawing.Point(109, 39);
            this.tb_workspaceXPlus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_workspaceXPlus.Name = "tb_workspaceXPlus";
            this.tb_workspaceXPlus.Size = new System.Drawing.Size(100, 25);
            this.tb_workspaceXPlus.TabIndex = 32;
            // 
            // label67
            // 
            this.label67.AutoSize = true;
            this.label67.Location = new System.Drawing.Point(26, 138);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(75, 15);
            this.label67.TabIndex = 31;
            this.label67.Text = "Y正限位：";
            // 
            // label70
            // 
            this.label70.AutoSize = true;
            this.label70.Location = new System.Drawing.Point(26, 49);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(75, 15);
            this.label70.TabIndex = 30;
            this.label70.Text = "X正限位：";
            // 
            // label71
            // 
            this.label71.AutoSize = true;
            this.label71.Location = new System.Drawing.Point(26, 95);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(75, 15);
            this.label71.TabIndex = 29;
            this.label71.Text = "X负限位：";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.运动空间限位);
            this.groupBox8.Controls.Add(this.label64);
            this.groupBox8.Controls.Add(this.groupBox6);
            this.groupBox8.Location = new System.Drawing.Point(3, 229);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox8.Size = new System.Drawing.Size(937, 245);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "运动控制参数";
            // 
            // 运动空间限位
            // 
            this.运动空间限位.Controls.Add(this.btn_ConfirmIO);
            this.运动空间限位.Controls.Add(this.btn_SaveIO);
            this.运动空间限位.Controls.Add(this.tb_emstopIO);
            this.运动空间限位.Controls.Add(this.tb_BolwtorchIO);
            this.运动空间限位.Controls.Add(this.tb_SuctioncupIO);
            this.运动空间限位.Controls.Add(this.label66);
            this.运动空间限位.Controls.Add(this.label68);
            this.运动空间限位.Controls.Add(this.label69);
            this.运动空间限位.Dock = System.Windows.Forms.DockStyle.Right;
            this.运动空间限位.Location = new System.Drawing.Point(655, 20);
            this.运动空间限位.Name = "运动空间限位";
            this.运动空间限位.Size = new System.Drawing.Size(279, 223);
            this.运动空间限位.TabIndex = 2;
            this.运动空间限位.TabStop = false;
            this.运动空间限位.Text = "IO口设置";
            // 
            // btn_ConfirmIO
            // 
            this.btn_ConfirmIO.Location = new System.Drawing.Point(195, 144);
            this.btn_ConfirmIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ConfirmIO.Name = "btn_ConfirmIO";
            this.btn_ConfirmIO.Size = new System.Drawing.Size(84, 32);
            this.btn_ConfirmIO.TabIndex = 28;
            this.btn_ConfirmIO.Text = "保存";
            this.btn_ConfirmIO.UseVisualStyleBackColor = true;
            this.btn_ConfirmIO.Click += new System.EventHandler(this.btn_ConfirmIO_Click);
            // 
            // btn_SaveIO
            // 
            this.btn_SaveIO.Location = new System.Drawing.Point(195, 51);
            this.btn_SaveIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SaveIO.Name = "btn_SaveIO";
            this.btn_SaveIO.Size = new System.Drawing.Size(81, 38);
            this.btn_SaveIO.TabIndex = 27;
            this.btn_SaveIO.Text = "确认";
            this.btn_SaveIO.UseVisualStyleBackColor = true;
            this.btn_SaveIO.Click += new System.EventHandler(this.btn_SaveIO_Click);
            // 
            // tb_emstopIO
            // 
            this.tb_emstopIO.Location = new System.Drawing.Point(89, 151);
            this.tb_emstopIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_emstopIO.Name = "tb_emstopIO";
            this.tb_emstopIO.Size = new System.Drawing.Size(100, 25);
            this.tb_emstopIO.TabIndex = 26;
            // 
            // tb_BolwtorchIO
            // 
            this.tb_BolwtorchIO.Location = new System.Drawing.Point(89, 99);
            this.tb_BolwtorchIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_BolwtorchIO.Name = "tb_BolwtorchIO";
            this.tb_BolwtorchIO.Size = new System.Drawing.Size(100, 25);
            this.tb_BolwtorchIO.TabIndex = 25;
            // 
            // tb_SuctioncupIO
            // 
            this.tb_SuctioncupIO.Location = new System.Drawing.Point(89, 51);
            this.tb_SuctioncupIO.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_SuctioncupIO.Name = "tb_SuctioncupIO";
            this.tb_SuctioncupIO.Size = new System.Drawing.Size(100, 25);
            this.tb_SuctioncupIO.TabIndex = 24;
            // 
            // label66
            // 
            this.label66.AutoSize = true;
            this.label66.Location = new System.Drawing.Point(6, 161);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(68, 15);
            this.label66.TabIndex = 23;
            this.label66.Text = "急停IO：";
            // 
            // label68
            // 
            this.label68.AutoSize = true;
            this.label68.Location = new System.Drawing.Point(6, 61);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(68, 15);
            this.label68.TabIndex = 22;
            this.label68.Text = "吸盘IO：";
            // 
            // label69
            // 
            this.label69.AutoSize = true;
            this.label69.Location = new System.Drawing.Point(6, 107);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(68, 15);
            this.label69.TabIndex = 21;
            this.label69.Text = "吹嘴IO：";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Location = new System.Drawing.Point(9, 41);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(0, 15);
            this.label64.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox6.Controls.Add(this.tb_ProductionlineHeight);
            this.groupBox6.Controls.Add(this.label65);
            this.groupBox6.Controls.Add(this.tb_axis5zeroheight);
            this.groupBox6.Controls.Add(this.label82);
            this.groupBox6.Controls.Add(this.tb_mode2height);
            this.groupBox6.Controls.Add(this.tb_mode1height);
            this.groupBox6.Controls.Add(this.label79);
            this.groupBox6.Controls.Add(this.label81);
            this.groupBox6.Controls.Add(this.btn_DeflectionSave);
            this.groupBox6.Controls.Add(this.tb_BolwtorchDeflectionZ);
            this.groupBox6.Controls.Add(this.btn_DeflectionConfirm);
            this.groupBox6.Controls.Add(this.tb_SuctioncupDeflectionZ);
            this.groupBox6.Controls.Add(this.tb_BolwtorchDeflectionX);
            this.groupBox6.Controls.Add(this.tb_SuctioncupDeflectionX);
            this.groupBox6.Controls.Add(this.label50);
            this.groupBox6.Controls.Add(this.label49);
            this.groupBox6.Controls.Add(this.label48);
            this.groupBox6.Controls.Add(this.label47);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(3, 20);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox6.Size = new System.Drawing.Size(652, 223);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "工具坐标系标定";
            // 
            // tb_ProductionlineHeight
            // 
            this.tb_ProductionlineHeight.Location = new System.Drawing.Point(541, 72);
            this.tb_ProductionlineHeight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_ProductionlineHeight.Name = "tb_ProductionlineHeight";
            this.tb_ProductionlineHeight.Size = new System.Drawing.Size(75, 25);
            this.tb_ProductionlineHeight.TabIndex = 18;
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Location = new System.Drawing.Point(438, 81);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(97, 15);
            this.label65.TabIndex = 17;
            this.label65.Text = "产线的高度：";
            // 
            // tb_axis5zeroheight
            // 
            this.tb_axis5zeroheight.Location = new System.Drawing.Point(541, 32);
            this.tb_axis5zeroheight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_axis5zeroheight.Name = "tb_axis5zeroheight";
            this.tb_axis5zeroheight.Size = new System.Drawing.Size(75, 25);
            this.tb_axis5zeroheight.TabIndex = 16;
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.Location = new System.Drawing.Point(288, 41);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(247, 15);
            this.label82.TabIndex = 15;
            this.label82.Text = "升降零点时吸盘底面到产线的距离：";
            // 
            // tb_mode2height
            // 
            this.tb_mode2height.Location = new System.Drawing.Point(203, 78);
            this.tb_mode2height.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_mode2height.Name = "tb_mode2height";
            this.tb_mode2height.Size = new System.Drawing.Size(80, 25);
            this.tb_mode2height.TabIndex = 14;
            // 
            // tb_mode1height
            // 
            this.tb_mode1height.Location = new System.Drawing.Point(203, 32);
            this.tb_mode1height.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_mode1height.Name = "tb_mode1height";
            this.tb_mode1height.Size = new System.Drawing.Size(80, 25);
            this.tb_mode1height.TabIndex = 13;
            // 
            // label79
            // 
            this.label79.AutoSize = true;
            this.label79.Location = new System.Drawing.Point(5, 82);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(187, 15);
            this.label79.TabIndex = 12;
            this.label79.Text = "吹嘴底面到产线间的距离：";
            // 
            // label81
            // 
            this.label81.AutoSize = true;
            this.label81.Location = new System.Drawing.Point(5, 41);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(187, 15);
            this.label81.TabIndex = 11;
            this.label81.Text = "吸盘底面到产线间的距离：";
            // 
            // btn_DeflectionSave
            // 
            this.btn_DeflectionSave.Location = new System.Drawing.Point(425, 172);
            this.btn_DeflectionSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DeflectionSave.Name = "btn_DeflectionSave";
            this.btn_DeflectionSave.Size = new System.Drawing.Size(100, 32);
            this.btn_DeflectionSave.TabIndex = 10;
            this.btn_DeflectionSave.Text = "保存";
            this.btn_DeflectionSave.UseVisualStyleBackColor = true;
            this.btn_DeflectionSave.Click += new System.EventHandler(this.btn_DeflectionSave_Click);
            // 
            // tb_BolwtorchDeflectionZ
            // 
            this.tb_BolwtorchDeflectionZ.Location = new System.Drawing.Point(319, 170);
            this.tb_BolwtorchDeflectionZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_BolwtorchDeflectionZ.Name = "tb_BolwtorchDeflectionZ";
            this.tb_BolwtorchDeflectionZ.Size = new System.Drawing.Size(100, 25);
            this.tb_BolwtorchDeflectionZ.TabIndex = 9;
            // 
            // btn_DeflectionConfirm
            // 
            this.btn_DeflectionConfirm.Location = new System.Drawing.Point(425, 115);
            this.btn_DeflectionConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_DeflectionConfirm.Name = "btn_DeflectionConfirm";
            this.btn_DeflectionConfirm.Size = new System.Drawing.Size(100, 38);
            this.btn_DeflectionConfirm.TabIndex = 7;
            this.btn_DeflectionConfirm.Text = "确认";
            this.btn_DeflectionConfirm.UseVisualStyleBackColor = true;
            this.btn_DeflectionConfirm.Click += new System.EventHandler(this.btn_DeflectionConfirm_Click);
            // 
            // tb_SuctioncupDeflectionZ
            // 
            this.tb_SuctioncupDeflectionZ.Location = new System.Drawing.Point(319, 120);
            this.tb_SuctioncupDeflectionZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_SuctioncupDeflectionZ.Name = "tb_SuctioncupDeflectionZ";
            this.tb_SuctioncupDeflectionZ.Size = new System.Drawing.Size(100, 25);
            this.tb_SuctioncupDeflectionZ.TabIndex = 6;
            // 
            // tb_BolwtorchDeflectionX
            // 
            this.tb_BolwtorchDeflectionX.Location = new System.Drawing.Point(113, 172);
            this.tb_BolwtorchDeflectionX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_BolwtorchDeflectionX.Name = "tb_BolwtorchDeflectionX";
            this.tb_BolwtorchDeflectionX.Size = new System.Drawing.Size(100, 25);
            this.tb_BolwtorchDeflectionX.TabIndex = 5;
            // 
            // tb_SuctioncupDeflectionX
            // 
            this.tb_SuctioncupDeflectionX.Location = new System.Drawing.Point(113, 119);
            this.tb_SuctioncupDeflectionX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_SuctioncupDeflectionX.Name = "tb_SuctioncupDeflectionX";
            this.tb_SuctioncupDeflectionX.Size = new System.Drawing.Size(100, 25);
            this.tb_SuctioncupDeflectionX.TabIndex = 4;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(233, 130);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(90, 15);
            this.label50.TabIndex = 3;
            this.label50.Text = "吸盘偏移Z：";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(233, 180);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(90, 15);
            this.label49.TabIndex = 2;
            this.label49.Text = "吹嘴偏移Z：";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(21, 130);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(90, 15);
            this.label48.TabIndex = 1;
            this.label48.Text = "吸盘偏移X：";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(21, 180);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(90, 15);
            this.label47.TabIndex = 0;
            this.label47.Text = "吹嘴偏移X：";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lbl_CurrentDeflectionY);
            this.groupBox7.Controls.Add(this.label78);
            this.groupBox7.Controls.Add(this.lbl_CurrentDeflectionX);
            this.groupBox7.Controls.Add(this.label76);
            this.groupBox7.Controls.Add(this.btn_SetAverageDeflection);
            this.groupBox7.Controls.Add(this.btn_CalculateAverageDeflection);
            this.groupBox7.Controls.Add(this.tb_AverageDeflectionY);
            this.groupBox7.Controls.Add(this.tb_AverageDeflectionX);
            this.groupBox7.Controls.Add(this.label63);
            this.groupBox7.Controls.Add(this.label61);
            this.groupBox7.Controls.Add(this.label62);
            this.groupBox7.Controls.Add(this.label59);
            this.groupBox7.Controls.Add(this.label60);
            this.groupBox7.Controls.Add(this.label58);
            this.groupBox7.Controls.Add(this.label57);
            this.groupBox7.Controls.Add(this.label54);
            this.groupBox7.Controls.Add(this.label55);
            this.groupBox7.Controls.Add(this.label56);
            this.groupBox7.Controls.Add(this.label53);
            this.groupBox7.Controls.Add(this.label52);
            this.groupBox7.Controls.Add(this.label51);
            this.groupBox7.Controls.Add(this.tb_DeflectionY6);
            this.groupBox7.Controls.Add(this.tb_DeflectionX6);
            this.groupBox7.Controls.Add(this.tb_DeflectionY5);
            this.groupBox7.Controls.Add(this.tb_DeflectionX5);
            this.groupBox7.Controls.Add(this.tb_DeflectionY4);
            this.groupBox7.Controls.Add(this.tb_DeflectionX4);
            this.groupBox7.Controls.Add(this.tb_DeflectionY3);
            this.groupBox7.Controls.Add(this.tb_DeflectionX3);
            this.groupBox7.Controls.Add(this.tb_DeflectionY2);
            this.groupBox7.Controls.Add(this.tb_DeflectionX2);
            this.groupBox7.Controls.Add(this.tb_DeflectionY1);
            this.groupBox7.Controls.Add(this.tb_DeflectionX1);
            this.groupBox7.Location = new System.Drawing.Point(3, 478);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox7.Size = new System.Drawing.Size(1019, 222);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "绝对坐标系";
            // 
            // lbl_CurrentDeflectionY
            // 
            this.lbl_CurrentDeflectionY.AutoSize = true;
            this.lbl_CurrentDeflectionY.Location = new System.Drawing.Point(965, 110);
            this.lbl_CurrentDeflectionY.Name = "lbl_CurrentDeflectionY";
            this.lbl_CurrentDeflectionY.Size = new System.Drawing.Size(15, 15);
            this.lbl_CurrentDeflectionY.TabIndex = 32;
            this.lbl_CurrentDeflectionY.Text = "0";
            // 
            // label78
            // 
            this.label78.AutoSize = true;
            this.label78.Location = new System.Drawing.Point(881, 108);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(90, 15);
            this.label78.TabIndex = 31;
            this.label78.Text = "当前Y偏差：";
            // 
            // lbl_CurrentDeflectionX
            // 
            this.lbl_CurrentDeflectionX.AutoSize = true;
            this.lbl_CurrentDeflectionX.Location = new System.Drawing.Point(965, 52);
            this.lbl_CurrentDeflectionX.Name = "lbl_CurrentDeflectionX";
            this.lbl_CurrentDeflectionX.Size = new System.Drawing.Size(15, 15);
            this.lbl_CurrentDeflectionX.TabIndex = 30;
            this.lbl_CurrentDeflectionX.Text = "0";
            // 
            // label76
            // 
            this.label76.AutoSize = true;
            this.label76.Location = new System.Drawing.Point(881, 52);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(90, 15);
            this.label76.TabIndex = 29;
            this.label76.Text = "当前X偏差：";
            // 
            // btn_SetAverageDeflection
            // 
            this.btn_SetAverageDeflection.Location = new System.Drawing.Point(657, 152);
            this.btn_SetAverageDeflection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_SetAverageDeflection.Name = "btn_SetAverageDeflection";
            this.btn_SetAverageDeflection.Size = new System.Drawing.Size(219, 46);
            this.btn_SetAverageDeflection.TabIndex = 28;
            this.btn_SetAverageDeflection.Text = "修正误差";
            this.btn_SetAverageDeflection.UseVisualStyleBackColor = true;
            this.btn_SetAverageDeflection.Click += new System.EventHandler(this.btn_SetAverageDeflection_Click);
            // 
            // btn_CalculateAverageDeflection
            // 
            this.btn_CalculateAverageDeflection.Location = new System.Drawing.Point(655, 94);
            this.btn_CalculateAverageDeflection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_CalculateAverageDeflection.Name = "btn_CalculateAverageDeflection";
            this.btn_CalculateAverageDeflection.Size = new System.Drawing.Size(220, 46);
            this.btn_CalculateAverageDeflection.TabIndex = 27;
            this.btn_CalculateAverageDeflection.Text = "求平均误差";
            this.btn_CalculateAverageDeflection.UseVisualStyleBackColor = true;
            this.btn_CalculateAverageDeflection.Click += new System.EventHandler(this.btn_CalculateAverageDeflection_Click);
            // 
            // tb_AverageDeflectionY
            // 
            this.tb_AverageDeflectionY.Location = new System.Drawing.Point(775, 42);
            this.tb_AverageDeflectionY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_AverageDeflectionY.Name = "tb_AverageDeflectionY";
            this.tb_AverageDeflectionY.Size = new System.Drawing.Size(100, 25);
            this.tb_AverageDeflectionY.TabIndex = 26;
            // 
            // tb_AverageDeflectionX
            // 
            this.tb_AverageDeflectionX.Location = new System.Drawing.Point(655, 42);
            this.tb_AverageDeflectionX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_AverageDeflectionX.Name = "tb_AverageDeflectionX";
            this.tb_AverageDeflectionX.Size = new System.Drawing.Size(100, 25);
            this.tb_AverageDeflectionX.TabIndex = 25;
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Location = new System.Drawing.Point(603, 52);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(52, 15);
            this.label63.TabIndex = 24;
            this.label63.Text = "平均：";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Location = new System.Drawing.Point(772, 21);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(75, 15);
            this.label61.TabIndex = 23;
            this.label61.Text = "Y方向偏差";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(653, 21);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(75, 15);
            this.label62.TabIndex = 22;
            this.label62.Text = "X方向偏差";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(508, 21);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(75, 15);
            this.label59.TabIndex = 21;
            this.label59.Text = "Y方向偏差";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(389, 21);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(75, 15);
            this.label60.TabIndex = 20;
            this.label60.Text = "X方向偏差";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(207, 21);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(75, 15);
            this.label58.TabIndex = 19;
            this.label58.Text = "Y方向偏差";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(89, 21);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(75, 15);
            this.label57.TabIndex = 18;
            this.label57.Text = "X方向偏差";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(319, 162);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(52, 15);
            this.label54.TabIndex = 17;
            this.label54.Text = "第六组";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(319, 104);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(52, 15);
            this.label55.TabIndex = 16;
            this.label55.Text = "第五组";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(319, 52);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(52, 15);
            this.label56.TabIndex = 15;
            this.label56.Text = "第四组";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(20, 162);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(52, 15);
            this.label53.TabIndex = 14;
            this.label53.Text = "第三组";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(20, 104);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(52, 15);
            this.label52.TabIndex = 13;
            this.label52.Text = "第二组";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(20, 52);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(52, 15);
            this.label51.TabIndex = 12;
            this.label51.Text = "第一组";
            // 
            // tb_DeflectionY6
            // 
            this.tb_DeflectionY6.Location = new System.Drawing.Point(497, 152);
            this.tb_DeflectionY6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionY6.Name = "tb_DeflectionY6";
            this.tb_DeflectionY6.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionY6.TabIndex = 11;
            this.tb_DeflectionY6.Text = "0";
            // 
            // tb_DeflectionX6
            // 
            this.tb_DeflectionX6.Location = new System.Drawing.Point(377, 152);
            this.tb_DeflectionX6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionX6.Name = "tb_DeflectionX6";
            this.tb_DeflectionX6.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionX6.TabIndex = 10;
            this.tb_DeflectionX6.Text = "0";
            // 
            // tb_DeflectionY5
            // 
            this.tb_DeflectionY5.Location = new System.Drawing.Point(497, 94);
            this.tb_DeflectionY5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionY5.Name = "tb_DeflectionY5";
            this.tb_DeflectionY5.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionY5.TabIndex = 9;
            this.tb_DeflectionY5.Text = "0";
            // 
            // tb_DeflectionX5
            // 
            this.tb_DeflectionX5.Location = new System.Drawing.Point(377, 94);
            this.tb_DeflectionX5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionX5.Name = "tb_DeflectionX5";
            this.tb_DeflectionX5.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionX5.TabIndex = 8;
            this.tb_DeflectionX5.Text = "0";
            // 
            // tb_DeflectionY4
            // 
            this.tb_DeflectionY4.Location = new System.Drawing.Point(497, 42);
            this.tb_DeflectionY4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionY4.Name = "tb_DeflectionY4";
            this.tb_DeflectionY4.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionY4.TabIndex = 7;
            this.tb_DeflectionY4.Text = "0";
            // 
            // tb_DeflectionX4
            // 
            this.tb_DeflectionX4.Location = new System.Drawing.Point(377, 42);
            this.tb_DeflectionX4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionX4.Name = "tb_DeflectionX4";
            this.tb_DeflectionX4.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionX4.TabIndex = 6;
            this.tb_DeflectionX4.Text = "0";
            // 
            // tb_DeflectionY3
            // 
            this.tb_DeflectionY3.Location = new System.Drawing.Point(197, 152);
            this.tb_DeflectionY3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionY3.Name = "tb_DeflectionY3";
            this.tb_DeflectionY3.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionY3.TabIndex = 5;
            this.tb_DeflectionY3.Text = "0";
            // 
            // tb_DeflectionX3
            // 
            this.tb_DeflectionX3.Location = new System.Drawing.Point(77, 152);
            this.tb_DeflectionX3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionX3.Name = "tb_DeflectionX3";
            this.tb_DeflectionX3.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionX3.TabIndex = 4;
            this.tb_DeflectionX3.Text = "0";
            // 
            // tb_DeflectionY2
            // 
            this.tb_DeflectionY2.Location = new System.Drawing.Point(197, 94);
            this.tb_DeflectionY2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionY2.Name = "tb_DeflectionY2";
            this.tb_DeflectionY2.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionY2.TabIndex = 3;
            this.tb_DeflectionY2.Text = "0";
            // 
            // tb_DeflectionX2
            // 
            this.tb_DeflectionX2.Location = new System.Drawing.Point(77, 94);
            this.tb_DeflectionX2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionX2.Name = "tb_DeflectionX2";
            this.tb_DeflectionX2.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionX2.TabIndex = 2;
            this.tb_DeflectionX2.Text = "0";
            // 
            // tb_DeflectionY1
            // 
            this.tb_DeflectionY1.Location = new System.Drawing.Point(197, 42);
            this.tb_DeflectionY1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionY1.Name = "tb_DeflectionY1";
            this.tb_DeflectionY1.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionY1.TabIndex = 1;
            this.tb_DeflectionY1.Text = "0";
            // 
            // tb_DeflectionX1
            // 
            this.tb_DeflectionX1.Location = new System.Drawing.Point(77, 42);
            this.tb_DeflectionX1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_DeflectionX1.Name = "tb_DeflectionX1";
            this.tb_DeflectionX1.Size = new System.Drawing.Size(100, 25);
            this.tb_DeflectionX1.TabIndex = 0;
            this.tb_DeflectionX1.Text = "0";
            // 
            // splitContDspUpDn
            // 
            this.splitContDspUpDn.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContDspUpDn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContDspUpDn.Location = new System.Drawing.Point(0, 0);
            this.splitContDspUpDn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContDspUpDn.Name = "splitContDspUpDn";
            this.splitContDspUpDn.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContDspUpDn.Panel1
            // 
            this.splitContDspUpDn.Panel1.Controls.Add(this.label45);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label46);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label44);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label43);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label42);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label25);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label40);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label35);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label36);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label37);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label38);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label34);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label33);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label32);
            this.splitContDspUpDn.Panel1.Controls.Add(this.label31);
            this.splitContDspUpDn.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContDspUpDn_Panel1_Paint);
            // 
            // splitContDspUpDn.Panel2
            // 
            this.splitContDspUpDn.Panel2.Controls.Add(this.tb_P5);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label86);
            this.splitContDspUpDn.Panel2.Controls.Add(this.tbP_Bolwtorch);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label41);
            this.splitContDspUpDn.Panel2.Controls.Add(this.tbP_Suctioncup);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label39);
            this.splitContDspUpDn.Panel2.Controls.Add(this.tbP_3);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label23);
            this.splitContDspUpDn.Panel2.Controls.Add(this.textBox1);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label83);
            this.splitContDspUpDn.Panel2.Controls.Add(this.textBox2);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label84);
            this.splitContDspUpDn.Panel2.Controls.Add(this.textBox3);
            this.splitContDspUpDn.Panel2.Controls.Add(this.label85);
            this.splitContDspUpDn.Size = new System.Drawing.Size(434, 758);
            this.splitContDspUpDn.SplitterDistance = 616;
            this.splitContDspUpDn.TabIndex = 0;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(35, 615);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(23, 15);
            this.label45.TabIndex = 14;
            this.label45.Text = "X+";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(321, 615);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(23, 15);
            this.label46.TabIndex = 13;
            this.label46.Text = "X-";
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label44.Location = new System.Drawing.Point(260, 461);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(104, 20);
            this.label44.TabIndex = 12;
            this.label44.Text = "零点：3轴";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label43.Location = new System.Drawing.Point(260, 265);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(104, 20);
            this.label43.TabIndex = 11;
            this.label43.Text = "零点：3轴";
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label42.Location = new System.Drawing.Point(260, 8);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(114, 20);
            this.label42.TabIndex = 10;
            this.label42.Text = "零点：基座";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(3, 464);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(148, 20);
            this.label25.TabIndex = 9;
            this.label25.Text = "后两轴XZ 1：1";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(219, 468);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(23, 15);
            this.label40.TabIndex = 8;
            this.label40.Text = "Z+";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label35.Location = new System.Drawing.Point(3, 265);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(148, 20);
            this.label35.TabIndex = 7;
            this.label35.Text = "后两轴XY 1：1";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(35, 420);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(23, 15);
            this.label36.TabIndex = 6;
            this.label36.Text = "X+";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(219, 265);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(23, 15);
            this.label37.TabIndex = 5;
            this.label37.Text = "Y+";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(321, 420);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(23, 15);
            this.label38.TabIndex = 4;
            this.label38.Text = "X-";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label34.Location = new System.Drawing.Point(3, 8);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(138, 20);
            this.label34.TabIndex = 3;
            this.label34.Text = "六轴XY 1：10";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(35, 235);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(23, 15);
            this.label33.TabIndex = 2;
            this.label33.Text = "X+";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(219, 8);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(23, 15);
            this.label32.TabIndex = 1;
            this.label32.Text = "Y+";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(321, 235);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 15);
            this.label31.TabIndex = 0;
            this.label31.Text = "X-";
            // 
            // tb_P5
            // 
            this.tb_P5.Location = new System.Drawing.Point(124, 92);
            this.tb_P5.Margin = new System.Windows.Forms.Padding(4);
            this.tb_P5.Name = "tb_P5";
            this.tb_P5.Size = new System.Drawing.Size(219, 25);
            this.tb_P5.TabIndex = 11;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(20, 101);
            this.label86.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(97, 15);
            this.label86.TabIndex = 10;
            this.label86.Text = "标定点坐标：";
            // 
            // tbP_Bolwtorch
            // 
            this.tbP_Bolwtorch.Location = new System.Drawing.Point(124, 62);
            this.tbP_Bolwtorch.Margin = new System.Windows.Forms.Padding(4);
            this.tbP_Bolwtorch.Name = "tbP_Bolwtorch";
            this.tbP_Bolwtorch.Size = new System.Drawing.Size(219, 25);
            this.tbP_Bolwtorch.TabIndex = 9;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(20, 71);
            this.label41.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(82, 15);
            this.label41.TabIndex = 8;
            this.label41.Text = "吹嘴坐标：";
            // 
            // tbP_Suctioncup
            // 
            this.tbP_Suctioncup.Location = new System.Drawing.Point(124, 34);
            this.tbP_Suctioncup.Margin = new System.Windows.Forms.Padding(4);
            this.tbP_Suctioncup.Name = "tbP_Suctioncup";
            this.tbP_Suctioncup.Size = new System.Drawing.Size(219, 25);
            this.tbP_Suctioncup.TabIndex = 7;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(20, 42);
            this.label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(82, 15);
            this.label39.TabIndex = 6;
            this.label39.Text = "吸盘坐标：";
            // 
            // tbP_3
            // 
            this.tbP_3.Location = new System.Drawing.Point(124, 4);
            this.tbP_3.Margin = new System.Windows.Forms.Padding(4);
            this.tbP_3.Name = "tbP_3";
            this.tbP_3.Size = new System.Drawing.Size(219, 25);
            this.tbP_3.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(20, 11);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(112, 15);
            this.label23.TabIndex = 0;
            this.label23.Text = "前三轴点坐标：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 62);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(219, 25);
            this.textBox1.TabIndex = 9;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(20, 71);
            this.label83.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(82, 15);
            this.label83.TabIndex = 8;
            this.label83.Text = "吹嘴坐标：";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(124, 34);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(219, 25);
            this.textBox2.TabIndex = 7;
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(20, 42);
            this.label84.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(82, 15);
            this.label84.TabIndex = 6;
            this.label84.Text = "吸盘坐标：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(124, 4);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(219, 25);
            this.textBox3.TabIndex = 1;
            // 
            // label85
            // 
            this.label85.AutoSize = true;
            this.label85.Location = new System.Drawing.Point(20, 11);
            this.label85.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(112, 15);
            this.label85.TabIndex = 0;
            this.label85.Text = "前三轴点坐标：";
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1399, 758);
            this.Controls.Add(this.splitContFightRobot);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainFrm";
            this.Text = "机械臂控制";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.splitContFightRobot.Panel1.ResumeLayout(false);
            this.splitContFightRobot.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContFightRobot)).EndInit();
            this.splitContFightRobot.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbpParam.ResumeLayout(false);
            this.splitContUpDn.Panel1.ResumeLayout(false);
            this.splitContUpDn.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContUpDn)).EndInit();
            this.splitContUpDn.ResumeLayout(false);
            this.splitContLfRt.Panel1.ResumeLayout(false);
            this.splitContLfRt.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContLfRt)).EndInit();
            this.splitContLfRt.ResumeLayout(false);
            this.grpBoxRobotCtrl.ResumeLayout(false);
            this.splitContLfUp.Panel1.ResumeLayout(false);
            this.splitContLfUp.Panel1.PerformLayout();
            this.splitContLfUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContLfUp)).EndInit();
            this.splitContLfUp.ResumeLayout(false);
            this.splitContPlc.Panel1.ResumeLayout(false);
            this.splitContPlc.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContPlc)).EndInit();
            this.splitContPlc.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.splitContRtUp.Panel1.ResumeLayout(false);
            this.splitContRtUp.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContRtUp)).EndInit();
            this.splitContRtUp.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContMidLfRt.Panel1.ResumeLayout(false);
            this.splitContMidLfRt.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMidLfRt)).EndInit();
            this.splitContMidLfRt.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContMidRtUpDn.Panel1.ResumeLayout(false);
            this.splitContMidRtUpDn.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContMidRtUpDn)).EndInit();
            this.splitContMidRtUpDn.ResumeLayout(false);
            this.grpCamSvr.ResumeLayout(false);
            this.grpCamSvr.PerformLayout();
            this.grpBoxMode.ResumeLayout(false);
            this.grpBoxMode.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.运动模块.ResumeLayout(false);
            this.运动模块.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.运动空间限位.ResumeLayout(false);
            this.运动空间限位.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.splitContDspUpDn.Panel1.ResumeLayout(false);
            this.splitContDspUpDn.Panel1.PerformLayout();
            this.splitContDspUpDn.Panel2.ResumeLayout(false);
            this.splitContDspUpDn.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContDspUpDn)).EndInit();
            this.splitContDspUpDn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TiUpdSts;
        private System.Windows.Forms.SplitContainer splitContFightRobot;
        private System.Windows.Forms.SplitContainer splitContDspUpDn;
        private System.Windows.Forms.TextBox tbP_3;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label34;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox tbP_Bolwtorch;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox tbP_Suctioncup;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpParam;
        private System.Windows.Forms.SplitContainer splitContUpDn;
        private System.Windows.Forms.SplitContainer splitContLfRt;
        private System.Windows.Forms.GroupBox grpBoxRobotCtrl;
        private System.Windows.Forms.SplitContainer splitContLfUp;
        private System.Windows.Forms.ComboBox cbbCnctStr;
        private System.Windows.Forms.Label lblCnctStr;
        private System.Windows.Forms.ComboBox cbbCnctType;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnIPCnct;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnDisCnct;
        private System.Windows.Forms.Button btnCnct;
        private IndustrialCtrls.Leds.SWLed ledZMSts;
        private System.Windows.Forms.SplitContainer splitContPlc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton RdBtn_mode0;
        private System.Windows.Forms.RadioButton RdBtn_Bolwtorch;
        private System.Windows.Forms.RadioButton RdBtn_Suctioncup;
        private System.Windows.Forms.Button btnStopCleaner;
        private System.Windows.Forms.Button btnStopSucker;
        private System.Windows.Forms.Button btnStartSucker;
        private System.Windows.Forms.Button btnStartCleaner;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnCIPConnect;
        private System.Windows.Forms.TextBox tb_CIPPort;
        private System.Windows.Forms.TextBox tb_CIPIP;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private IndustrialCtrls.Leds.SWLed plcLed;
        private System.Windows.Forms.SplitContainer splitContRtUp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox cbbInit;
        private System.Windows.Forms.ComboBox cbbPosLimit;
        private System.Windows.Forms.ComboBox cbbAccel;
        private System.Windows.Forms.ComboBox cbbUnits;
        private System.Windows.Forms.ComboBox cbbNegLimit;
        private System.Windows.Forms.ComboBox cbbDecel;
        private System.Windows.Forms.ComboBox cbbSpeed;
        private System.Windows.Forms.Label axisname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnConfirmParam;
        private System.Windows.Forms.Button btnSaveParam;
        private System.Windows.Forms.ComboBox cbbAxis;
        private System.Windows.Forms.SplitContainer splitContMidLfRt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstBoxTip;
        private System.Windows.Forms.SplitContainer splitContMidRtUpDn;
        private System.Windows.Forms.GroupBox grpCamSvr;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnSnd2Svr;
        private System.Windows.Forms.Button btnCnctCameraSvr;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.ComboBox cbbIP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpBoxMode;
        private System.Windows.Forms.TextBox txtTargetPosi;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnInitPosi;
        private System.Windows.Forms.Button btnMoveIdle;
        private System.Windows.Forms.Button btnSetIdlePosi;
        private System.Windows.Forms.Button btnMoveInit;
        private System.Windows.Forms.CheckBox chbAutoMode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnEmStop;
        private System.Windows.Forms.Button button21;
        private System.Windows.Forms.Button Btn5Init;
        private System.Windows.Forms.Button btn5Backward;
        private System.Windows.Forms.Button btn4Backward;
        private System.Windows.Forms.Button btn5Forward;
        private System.Windows.Forms.Button btn3Backward;
        private System.Windows.Forms.Button Btn2Init;
        private System.Windows.Forms.Button btn4Forward;
        private System.Windows.Forms.Button btn3Forward;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button Btn0Init;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button btn2Forward;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btn1Backward;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btn0Backward;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btn0Home;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn0Forward;
        private System.Windows.Forms.Label lbl3Posi;
        private System.Windows.Forms.Label lbl4Posi;
        private System.Windows.Forms.Label lbl5Posi;
        private System.Windows.Forms.Label lbl1FLimit;
        private System.Windows.Forms.Label lbl1BLimit;
        private System.Windows.Forms.Label lbl3Sts;
        private System.Windows.Forms.Button btn1Forward;
        private System.Windows.Forms.Label lbl3BLimit;
        private System.Windows.Forms.Label lbl4Sts;
        private System.Windows.Forms.Label lbl4BLimit;
        private System.Windows.Forms.Label lbl5Sts;
        private System.Windows.Forms.Label lbl5FLimit;
        private System.Windows.Forms.Label lbl0Sts;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lbl1Posi;
        private System.Windows.Forms.Label lbl1Sts;
        private System.Windows.Forms.Label lbl5BLimit;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lbl0FLimit;
        private System.Windows.Forms.Label lbl0Posi;
        private System.Windows.Forms.Label lbl0BLimit;
        private System.Windows.Forms.Label lbl2Posi;
        private System.Windows.Forms.Label lbl2Sts;
        private System.Windows.Forms.Label lbl2FLimit;
        private System.Windows.Forms.Button btn1Home;
        private System.Windows.Forms.Button Btn1Init;
        private System.Windows.Forms.Label lbl3FLimit;
        private System.Windows.Forms.Label lbl2BLimit;
        private System.Windows.Forms.Button btn2Backward;
        private System.Windows.Forms.Button Btn3Init;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Label lbl4FLimit;
        private System.Windows.Forms.Button Btn4Init;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label 初始;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox 运动模块;
        private System.Windows.Forms.Button Btn_ZMinus;
        private System.Windows.Forms.Button Btn_ZPlus;
        private System.Windows.Forms.Button Btn_YMinus;
        private System.Windows.Forms.Button Btn_YPlus;
        private System.Windows.Forms.Button Btn_XMinus;
        private System.Windows.Forms.Button Btn_XPuls;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox tb_SuctioncupDeflectionZ;
        private System.Windows.Forms.TextBox tb_BolwtorchDeflectionX;
        private System.Windows.Forms.TextBox tb_SuctioncupDeflectionX;
        private System.Windows.Forms.Button btn_DeflectionSave;
        private System.Windows.Forms.TextBox tb_BolwtorchDeflectionZ;
        private System.Windows.Forms.Button btn_DeflectionConfirm;
        private System.Windows.Forms.TextBox tb_DeflectionX1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox tb_DeflectionY6;
        private System.Windows.Forms.TextBox tb_DeflectionX6;
        private System.Windows.Forms.TextBox tb_DeflectionY5;
        private System.Windows.Forms.TextBox tb_DeflectionX5;
        private System.Windows.Forms.TextBox tb_DeflectionY4;
        private System.Windows.Forms.TextBox tb_DeflectionX4;
        private System.Windows.Forms.TextBox tb_DeflectionY3;
        private System.Windows.Forms.TextBox tb_DeflectionX3;
        private System.Windows.Forms.TextBox tb_DeflectionY2;
        private System.Windows.Forms.TextBox tb_DeflectionX2;
        private System.Windows.Forms.TextBox tb_DeflectionY1;
        private System.Windows.Forms.TextBox tb_AverageDeflectionY;
        private System.Windows.Forms.TextBox tb_AverageDeflectionX;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button btn_SetAverageDeflection;
        private System.Windows.Forms.Button btn_CalculateAverageDeflection;
        private System.Windows.Forms.Label lbl_CurrentDeflectionY;
        private System.Windows.Forms.Label label78;
        private System.Windows.Forms.Label lbl_CurrentDeflectionX;
        private System.Windows.Forms.Label label76;
        private System.Windows.Forms.TextBox tb_mode2height;
        private System.Windows.Forms.TextBox tb_mode1height;
        private System.Windows.Forms.Label label79;
        private System.Windows.Forms.Label label81;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox tb_axis5zeroheight;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.TextBox tb_P5;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label85;
        private System.Windows.Forms.Label label87;
        private System.Windows.Forms.TextBox tb_MovePositionLen;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Button btn_InitStatus;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.GroupBox 运动空间限位;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.TextBox tb_workspaceYMinus;
        private System.Windows.Forms.Label label72;
        private System.Windows.Forms.Button btn_SaveWorkspaceLimit;
        private System.Windows.Forms.Button btn_ConfirmWorkspaceLimit;
        private System.Windows.Forms.TextBox tb_workspaceYPlus;
        private System.Windows.Forms.TextBox tb_workspaceXMinus;
        private System.Windows.Forms.TextBox tb_workspaceXPlus;
        private System.Windows.Forms.Label label67;
        private System.Windows.Forms.Label label70;
        private System.Windows.Forms.Label label71;
        private System.Windows.Forms.Button btn_ConfirmIO;
        private System.Windows.Forms.Button btn_SaveIO;
        private System.Windows.Forms.TextBox tb_emstopIO;
        private System.Windows.Forms.TextBox tb_BolwtorchIO;
        private System.Windows.Forms.TextBox tb_SuctioncupIO;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Label label68;
        private System.Windows.Forms.Label label69;
        private System.Windows.Forms.TextBox tb_ProductionlineHeight;
        private System.Windows.Forms.Label label65;
    }
}

