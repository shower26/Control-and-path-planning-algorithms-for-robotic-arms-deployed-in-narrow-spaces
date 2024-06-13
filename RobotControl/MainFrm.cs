using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotControl.SHUTools;
using IndustrialCtrls;
using IndustrialCtrls.Leds;
using Models;
using HPSocket;
using cszmcaux;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using static RobotControl.SHUTools.Win32Api;
using System.Runtime.InteropServices;
using HPSocket.Base;
using System.Net.Sockets;
using System.Net;
using System.Runtime.CompilerServices;
using FinsCom;
using System.Timers;
using System.Net.Http.Headers;
using AOI_FragmentCheck;

namespace RobotControl
{
    public partial class MainFrm : Form
    {


        public int InitStatus = -1;   //总线初始化完成状态	0-失败 1-成功  -1-初始化未完成
        //static string base_path = System.AppDomain.CurrentDomain.BaseDirectory;
        static string base_path = System.IO.Directory.GetCurrentDirectory();
        //INIHelp ConfigINI = new INIHelp($"{base_path}\\Config.ini");

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <summary>
        /// 用于定时器定时更新UI界面的轴状态,软件启动加载时回临时使用该变量存入配置文件值，用于
        /// 填充界面的配置信息，后期主要用于定时器
        /// </summary>
        AxisParam[] AxisArr = new AxisParam[6] {new AxisParam (0),
                                                new AxisParam (1),
                                                new AxisParam (2),
                                                new AxisParam (3),
                                                new AxisParam (4),
                                                new AxisParam (5)
                                               };
        ZMControl zm = new ZMControl();
        bool IsCnctZM = false; //后面应该用zm.GetCnctSts()代替较为安全
        CameraSvr cameraSvr;
        CIP myCIP ;
        /// <summary>
        /// 用于视觉上位机给机械臂运动调度任务传递消息
        /// </summary>
        static Queue<Packet> msg_pkt = new Queue<Packet>();
        object sync_msg = new object();//线程同步
        AutoResetEvent evt_msg_arrive = new AutoResetEvent(false);

        HardwareCfg myHardwareCfg= new HardwareCfg();
        string xmlPath = $"{base_path}\\HardwareCfg.xml";
        //
        //Thread th_Task;
        AutoThread th_Motion;
        AutoThread XY_Motion;

        CancellationTokenSource cancelTokSrc = new CancellationTokenSource();

        public MainFrm()
        {
            Environment.SetEnvironmentVariable("PATH", base_path + "\\bin", EnvironmentVariableTarget.Process);
            InitializeComponent();
            Thread.CurrentThread.Name = "Main";
            logger.Info($"当前运行路径{base_path}");
            //logger.Info($"Config路径:{base_path}\\Config.ini");
            //上下的的split
            splitContUpDn.SplitterDistance = (int)(splitContUpDn.Height * (2.0 / (1.0 + 2.0)));
            //在上一个splint的上面panel中左右分
            splitContLfRt.SplitterDistance = (int)(splitContLfRt.Width * (1.0 / (1.0 + 2.0)));
            //在上一个splint的左边panel中上下分
            splitContLfUp.SplitterDistance = (int)(splitContLfUp.Height * (1.0 / (1.0 + 2.0)));
            //在第二个splint的右边panel中上下分
            splitContRtUp.SplitterDistance = (int)(splitContRtUp.Height * (1.0 / (1.0 + 2.0)));
            //在上面一个splint的下面panel中左右分
            splitContMidLfRt.SplitterDistance = splitContMidLfRt.Width / 2;
            //在上面一个右边panel中上下分
            splitContMidRtUpDn.SplitterDistance = (int)(splitContMidRtUpDn.Height * (2.0 / (1.0 + 2.0)));
            //吸盘吸尘器上下分
            splitContPlc.SplitterDistance = (int)(splitContPlc.Height * (2.0 / (1.0 + 2.0)));

            //左右分tablecontrol和右边动画
            splitContFightRobot.SplitterDistance = (int)(splitContFightRobot.Width * (3.0 / (1.0 + 3.0)));
            //右边动画上下分
            splitContDspUpDn.SplitterDistance = (int)(splitContDspUpDn.Height * (4.0 / (1.0 + 4.0)));

            this.StartPosition = FormStartPosition.CenterScreen;

            myHardwareCfg = HardwareCfg.Read(xmlPath);

            //read config 
            ReadConfig();


            //
            cameraSvr = new CameraSvr(cbbIP.Text.Trim(), Convert.ToUInt16(txtPort.Text));
            logger.Info("注册camera回调函数");
            cameraSvr.OnConnectCallback = OnCamConnectFcn;
            cameraSvr.OnReceiveCallback = OnCamReceiveFcn;
            cameraSvr.OnCloseCallback = OnCamCloseFcn;
            logger.Info("注册正运动回调函数");

            zm.CallBackFc = OnReceiveFromZM;
            cancelTokSrc.Token.Register(OnCancelTask);
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //fill winform
            //for (int i = 0; i < AxisArr.Length; i++)
            //{
            //    cbbAxis.Items.Add(i);
            //    cbbSpeed.Items.Add(AxisArr[i].Speed);
            //    cbbAccel.Items.Add(AxisArr[i].Accel);
            //    cbbDecel.Items.Add(AxisArr[i].Decel);
            //    cbbUnits.Items.Add(AxisArr[i].Units);
            //    cbbPosLimit.Items.Add(AxisArr[i].FsLimit);
            //    cbbNegLimit.Items.Add(AxisArr[i].RsLimit);
            //    cbbInit.Items.Add(AxisArr[i].Init);

            //}
            for (int i = 0; i < AxisArr.Length; i++)
            {
                cbbAxis.Items.Add(myHardwareCfg.AxisArr[i].Num);
                cbbSpeed.Items.Add(myHardwareCfg.AxisArr[i].Speed);
                cbbAccel.Items.Add(myHardwareCfg.AxisArr[i].Accel);
                cbbDecel.Items.Add(myHardwareCfg.AxisArr[i].Decel);
                cbbUnits.Items.Add(myHardwareCfg.AxisArr[i].Units);
                cbbPosLimit.Items.Add(myHardwareCfg.AxisArr[i].FsLimit);
                cbbNegLimit.Items.Add(myHardwareCfg.AxisArr[i].RsLimit);
                cbbInit.Items.Add(myHardwareCfg.AxisArr[i].Init);

                AxisArr[i].Num = myHardwareCfg.AxisArr[i].Num;
                AxisArr[i].Speed = myHardwareCfg.AxisArr[i].Speed;
                AxisArr[i].Accel = myHardwareCfg.AxisArr[i].Accel;
                AxisArr[i].Decel = myHardwareCfg.AxisArr[i].Decel;
                AxisArr[i].Units = myHardwareCfg.AxisArr[i].Units;
                AxisArr[i].FsLimit = myHardwareCfg.AxisArr[i].FsLimit;
                AxisArr[i].RsLimit = myHardwareCfg.AxisArr[i].RsLimit;
                AxisArr[i].Init = myHardwareCfg.AxisArr[i].Init;


            }
            cbbAxis.SelectedIndex = 0;
            cbbSpeed.SelectedIndex = 0;
            cbbAccel.SelectedIndex = 0;
            cbbDecel.SelectedIndex = 0;
            cbbUnits.SelectedIndex = 0;
            cbbPosLimit.SelectedIndex = 0;
            cbbNegLimit.SelectedIndex = 0;
            cbbInit.SelectedIndex = 0;

            cbbCnctType.Items.Add(CnctType.COM.ToString());

            cbbCnctType.Items.Add(CnctType.ETH.ToString());
            cbbCnctType.Items.Add(CnctType.PCI.ToString());
            cbbCnctType.Items.Add(CnctType.MotionRT.ToString());
            cbbCnctType.SelectedIndex = 3;

            cbbCnctStr.Items.Add(myHardwareCfg.TCP_IP);
            cbbCnctStr.Items.Add("192.168.0.11");
            cbbCnctStr.Items.Add("Com0");
            cbbCnctStr.SelectedIndex = 0;

            //Panel1初始化
            zm.PanelCreat(splitContDspUpDn.Panel1);

            ////机械臂运动线程
            //th_Task = new Thread(new ThreadStart(RobotMotion));
            //th_Task.IsBackground = true;
            //th_Task.Name = "Motion_Task";
            //logger.Info($"Start thread:{th_Task.Name}");
            //th_Task.Start();

            th_Motion = new AutoThread(RobotMotion, "Motion_Task");
            XY_Motion = new AutoThread(MoveXY, "XY_Task");
            logger.Info("Start thread:Motion_Task");

            tb_MovePositionLen.Text = MovePositionLen.ToString();
        }

        ~MainFrm()
        {
            logger.Info("Logger Shutdown...");
            NLog.LogManager.Shutdown();
        }

        /// <summary>
        /// 更新界面显示Log，支持跨线程调用
        /// </summary>
        /// <param name="txt"></param>
        private void UpdateUILog(string str)
        {
            if (lstBoxTip.InvokeRequired)
            {

                this.BeginInvoke(new Action(() =>
                {
                    lstBoxTip.Items.Insert(0, $"[{DateTime.Now.ToString("HH:mm:ss:fff")}]{str}");
                }));
            }
            else
            {
                lstBoxTip.Items.Insert(0, $"[{DateTime.Now.ToString("HH:mm:ss:fff")}]{str}");
            }
        }



        private void btnCnct_Click(object sender, EventArgs e)
        {
            if (zm.GetCnctSts())
                return;

            CnctType cnctType = new CnctType();
            switch (cbbCnctType.Text)
            {
                case "COM":
                    cnctType = CnctType.COM;
                    break;
                case "ETH":
                    cnctType = CnctType.ETH;
                    break;
                case "PCI":
                    cnctType = CnctType.PCI;
                    break;
                case "MotionRT":
                    cnctType = CnctType.MotionRT;
                    break;
                default:
                    cnctType = CnctType.ETH;
                    break;
            }


            if (zm.Connect(cnctType, cbbCnctStr.Text))
            {
                ledZMSts.State = IndustrialCtrls.Leds.SWLed.LedState.On;
                btnCnct.Enabled = false;
                IsCnctZM = true;
                TiUpdSts.Enabled = true;
                logger.Info("成功连接控制器");
                UpdateUILog("连接控制器成功");
                
                //连接成功后读取轴状态
                GetAxisSts();

            }
            else
            {
                UpdateUILog("连接控制器失败");
                logger.Error("连接控制器失败");
            }
            logger.Info($"连接类型{cbbCnctType.Text}");
        }

        private void btnDisCnct_Click(object sender, EventArgs e)
        {

            if (!zm.GetCnctSts())
            {
                UpdateUILog("没有有效的连接!");
                logger.Info("没有有效的连接!");
                return;
            }

            if (zm.DisConnect())
            {
                ledZMSts.State = IndustrialCtrls.Leds.SWLed.LedState.Off;
                btnCnct.Enabled = true;
                UpdateUILog("断开连接控制器");
                logger.Info("断开连接控制器");
                IsCnctZM = false;
                TiUpdSts.Enabled = false;
            }
        }

        private void btnIPCnct_Click(object sender, EventArgs e)
        {
            if (zm.GetCnctSts())
                return;

            if (zm.ConnectSimulator())
            {
                ledZMSts.State = IndustrialCtrls.Leds.SWLed.LedState.On;
                IsCnctZM = true;
                TiUpdSts.Enabled = true;
                UpdateUILog("成功连接控制器仿真器");
                logger.Info("成功连接控制器仿真器");
            }
        }

        private void btnStartCleaner_Click(object sender, EventArgs e)
        {
            if (zm.SetCleaner())
            {
                logger.Info("Start Cleaner");
                UpdateUILog("开启吸尘器");
            }
            else
            {
                logger.Error("Failed to Start Cleaner");
                UpdateUILog("开启吸尘器失败");
            }
        }

        private void btnStopCleaner_Click(object sender, EventArgs e)
        {
            if (zm.StopCleaner())
            {
                logger.Info("Stop Cleaner");
                UpdateUILog("关闭吸尘器");
            }
            else
            {
                logger.Error("Failed to Srop Cleaner");
                UpdateUILog("关闭吸尘器失败");
            }
        }

        private void btnStartSucker_Click(object sender, EventArgs e)
        {
            if (zm.SetSucker())
            {
                logger.Info("Start Sucker");
                UpdateUILog("开启吸盘");
            }
            else
            {
                logger.Error("Failed to Start Sucker");
                UpdateUILog("关闭吸盘失败");
            }
        }

        private void btnStopSucker_Click(object sender, EventArgs e)
        {
            if (zm.StopSucker())
            {
                logger.Info("Stop Sucker");
                UpdateUILog("关闭吸盘");
            }
            else
            {
                logger.Error("Failed to Stop Sucker");
                UpdateUILog("关闭吸盘失败");
            }
        }

        private void btnRobotRun_Click(object sender, EventArgs e)
        {
            if (zm.SetRobotSts(Models.RobotSts.Running))
            {
                logger.Info("设置机器人忙碌状态");
                UpdateUILog("设置机器人忙碌状态");
            }
            else
            {
                logger.Error("设置机器人忙碌状态失败");
                UpdateUILog("设置机器人忙碌状态失败");
            }
        }

        private void btnRobotIdle_Click(object sender, EventArgs e)
        {
            if (zm.SetRobotSts(Models.RobotSts.Idle))
            {
                logger.Info("设置机器人空闲状态");
                UpdateUILog("设置机器人空闲状态");
            }
            else
            {
                logger.Error("失败设置机器人空闲状态");
                UpdateUILog("失败设置机器人空闲状态失败");
            }
        }
        /// <summary>
        /// 只用于软件初始化时加载
        /// </summary>
        private void ReadConfig()
        {

            

            txtPort.Text = myHardwareCfg.TCP_Port.ToString();


            cbbIP.Items.Add(myHardwareCfg.TCP_IP);

            cbbIP.SelectedIndex = 0;

            tb_SuctioncupDeflectionX.Text=myHardwareCfg.myEOAT.SuctioncupDeflection.X.ToString();
            tb_SuctioncupDeflectionZ.Text= myHardwareCfg.myEOAT.SuctioncupDeflection.Z.ToString();
            tb_BolwtorchDeflectionX.Text= myHardwareCfg.myEOAT.BolwtorchDeflection.X.ToString();
            tb_BolwtorchDeflectionZ.Text= myHardwareCfg.myEOAT.BolwtorchDeflection.Z.ToString();

            zm.SetDeflection(Convert.ToDouble(tb_SuctioncupDeflectionX.Text.Trim()), Convert.ToDouble(tb_SuctioncupDeflectionZ.Text.Trim()),
    Convert.ToDouble(tb_BolwtorchDeflectionX.Text.Trim()), Convert.ToDouble(tb_BolwtorchDeflectionZ.Text.Trim()));

            tb_mode1height.Text=myHardwareCfg.myEOAT.mode1_height.ToString();
            tb_mode2height.Text= myHardwareCfg.myEOAT.mode2_height.ToString();
            tb_axis5zeroheight.Text = myHardwareCfg.myEOAT.axis5zero.ToString();
            tb_ProductionlineHeight.Text = myHardwareCfg.myEOAT.Productionline_height.ToString();

            zm.SetHeight(Convert.ToDouble(tb_mode1height.Text.Trim()), Convert.ToDouble(tb_mode2height.Text.Trim()),Convert.ToDouble(tb_axis5zeroheight.Text.Trim()),Convert.ToDouble(tb_ProductionlineHeight.Text.Trim()));



            lbl_CurrentDeflectionX.Text= myHardwareCfg.myMotionControl.AbsDeflection.X.ToString();
            lbl_CurrentDeflectionY.Text = myHardwareCfg.myMotionControl.AbsDeflection.Y.ToString();
            zm.SetAbsDeflection(Convert.ToSingle(lbl_CurrentDeflectionX.Text.Trim()), Convert.ToSingle(lbl_CurrentDeflectionY.Text.Trim()));

            tb_BolwtorchIO.Text = myHardwareCfg.myIO.Bolwtorch.ToString();
            tb_emstopIO.Text = myHardwareCfg.myIO.emstop.ToString();
            tb_SuctioncupIO.Text = myHardwareCfg.myIO.Suctioncup.ToString();
            zm.SetIO(Convert.ToInt16(tb_SuctioncupIO.Text.Trim()), Convert.ToInt16(tb_BolwtorchIO.Text.Trim()), Convert.ToInt16(tb_emstopIO.Text.Trim()));

            tb_workspaceXMinus.Text = myHardwareCfg.myMotionControl.workspaceXMinus.ToString();
            tb_workspaceYMinus.Text = myHardwareCfg.myMotionControl.workspaceYMinus.ToString();
            tb_workspaceXPlus.Text = myHardwareCfg.myMotionControl.workspaceXPlus.ToString();
            tb_workspaceYPlus.Text = myHardwareCfg.myMotionControl.workspaceYPlus.ToString();

            zm.SetWorkspaceLimit(Convert.ToInt16(tb_workspaceXPlus.Text.Trim()), Convert.ToInt16(tb_workspaceXMinus.Text.Trim()), Convert.ToInt16(tb_workspaceYPlus.Text.Trim()), Convert.ToInt16(tb_workspaceYMinus.Text.Trim()));


        }

        private void GetAxisSts()
        {
            for (int i = 0; i < AxisArr.Length; i++)
            {
                AxisSatus sts = new AxisSatus();
                if (!zm.GetAxisStatus(i, ref sts))
                {
                    UpdateUILog($"读取轴{i}状态失败");
                    logger.Error($"读取轴{i}状态失败");
                    return;
                }
                switch (sts)
                {
                    case AxisSatus.NoError:
                        UpdateUILog($"轴{i}状态正常");
                        logger.Info($"轴{i}状态正常");
                        break;
                    case AxisSatus.FlimitError:
                        UpdateUILog($"轴{i}正限位报警");
                        logger.Warn($"轴{i}正限位报警");
                        break;
                    case AxisSatus.BlimitError:
                        UpdateUILog($"轴{i}负限位报警");
                        logger.Warn($"轴{i}负限位报警");
                        break;
                    case AxisSatus.ServoError:
                        UpdateUILog($"轴{i}伺服报警");
                        logger.Warn($"轴{i}伺服报警");
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnCnctCameraSvr_Click(object sender, EventArgs e)
        {
            if (cameraSvr.ConnectSvr(cbbIP.Text, Convert.ToUInt16(txtPort.Text)))
            {
                myHardwareCfg.TCP_IP = cbbIP.Text;
                myHardwareCfg.TCP_Port = Convert.ToUInt16(txtPort.Text);
                HardwareCfg.Write(myHardwareCfg, xmlPath);
                //UpdateUILog("连接视觉上位机成功");
                //logger.Info("连接视觉上位机成功");

            }
            else
            {
                UpdateUILog("连接视觉上位机失败");
                logger.Error("连接视觉上位机失败");
            }
        }

        private void btnSnd2Svr_Click(object sender, EventArgs e)
        {
            Packet data = new Packet();
            data.Type = PacketType.Info;
            data.Info = txtMsg.Text;

            cameraSvr.Send(data);
        }

        private void btnConfirmParam_Click(object sender, EventArgs e)
        {
            if (!IsCnctZM)
            {
                UpdateUILog("未连接到控制器！请先连接控制器");
                MessageBox.Show("未连接到控制器！请先连接控制器");
            }
            //for (int i = 0; i < AxisArr.Length; i++)
            int n = Convert.ToInt32(cbbAxis.Text);
            {
                AxisParam ap = new AxisParam(n);

                ap.Speed = Convert.ToSingle(cbbSpeed.Text);
                ap.Decel = Convert.ToSingle(cbbDecel.Text);
                ap.Accel = Convert.ToSingle(cbbAccel.Text);
                ap.FsLimit = Convert.ToSingle(cbbPosLimit.Text);
                ap.RsLimit = Convert.ToSingle(cbbNegLimit.Text);
                ap.Units = Convert.ToSingle(cbbUnits.Text);
                AxisArr[n].Init = Convert.ToSingle(cbbInit.Text);

                zm.SetAxisParam(ap);
                logger.Info($"设置轴{n}参数:Unit[{ap.Units}]Init[{ap.Init}]Speed[{ap.Speed}]Accel[{ap.Accel}]Decel[{ap.Decel}]FsLimit[{ap.FsLimit}]RsLimit[{ap.RsLimit}]");
                UpdateUILog($"设置轴{n}参数");
            }

        }

        private void btnSaveParam_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(cbbAxis.Text);
            {
                AxisArr[n].FsLimit = Convert.ToInt32(cbbPosLimit.Text);
                AxisArr[n].RsLimit = Convert.ToInt32(cbbNegLimit.Text);
                AxisArr[n].Units = Convert.ToInt32(cbbUnits.Text);
                AxisArr[n].Speed = Convert.ToInt32(cbbSpeed.Text);
                AxisArr[n].Accel = Convert.ToInt32(cbbAccel.Text);
                AxisArr[n].Decel = Convert.ToInt32(cbbDecel.Text);
                AxisArr[n].Init = Convert.ToInt32(cbbInit.Text);

                myHardwareCfg.AxisArr[n].FsLimit = Convert.ToInt32(cbbPosLimit.Text);
                myHardwareCfg.AxisArr[n].RsLimit = Convert.ToInt32(cbbNegLimit.Text);
                myHardwareCfg.AxisArr[n].Units = Convert.ToInt32(cbbUnits.Text);
                myHardwareCfg.AxisArr[n].Speed = Convert.ToInt32(cbbSpeed.Text);
                myHardwareCfg.AxisArr[n].Accel = Convert.ToInt32(cbbAccel.Text);
                myHardwareCfg.AxisArr[n].Decel = Convert.ToInt32(cbbDecel.Text);
                myHardwareCfg.AxisArr[n].Init = Convert.ToInt32(cbbInit.Text);
                HardwareCfg.Write(myHardwareCfg, xmlPath);

                UpdateUILog($"保存轴{n}参数");
            }

        }

        private void btn0Forward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(0, MoveMode.Forward);
        }

        private void btn0Forward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(0, MoveMode.Cancel);
        }

        private void btn0Backward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(0, MoveMode.Backword);
        }

        private void btn0Backward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(0, MoveMode.Cancel);
        }

        private void btn1Forward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(1, MoveMode.Forward);
        }

        private void btn1Forward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(1, MoveMode.Cancel);
        }

        private void btn1Backward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(1, MoveMode.Backword);
        }

        private void btn1Backward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(1, MoveMode.Cancel);
        }

        private void btn2Forward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(2, MoveMode.Forward);
        }

        private void btn2Forward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(2, MoveMode.Cancel);
        }

        private void btn2Backward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(2, MoveMode.Backword);
        }

        private void btn2Backward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(2, MoveMode.Cancel);
        }

        private void btn3Forward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(3, MoveMode.Forward);
        }

        private void btn3Forward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(3, MoveMode.Cancel);
        }

        private void btn3Backward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(3, MoveMode.Backword);
        }

        private void btn3Backward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(3, MoveMode.Cancel);
        }

        private void btn4Forward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(4, MoveMode.Forward);
        }

        private void btn4Forward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(4, MoveMode.Cancel);
        }

        private void btn4Backward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(4, MoveMode.Backword);
        }

        private void btn4Backward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(4, MoveMode.Cancel);
        }

        private void btn5Forward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Forward);
        }

        private void btn5Forward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Cancel);
        }

        private void btn5Backward_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Backword);
        }

        private void btn5Backward_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Cancel);
        }

        private void btnEmStop_Click(object sender, EventArgs e)
        {
            zm.EmergencyStop();
            //th_Task.Abort();
            run = false;
            XY_Motion.CancelThread();

            evt_msg_arrive.Reset();
            th_Motion.CancelThread();
            //cancelTokSrc.Cancel();
            logger.Info("按下急停按钮!!!");

            zm.ResetEnable();
            //if (movementThread != null && movementThread.IsAlive)
            //{
            //    movementThread.Abort(); // 等待运动线程结束
            //}
        }


        private  void UpdAnix(CycAxisSts[] axis_sts)
        {
            Label[,] lbl = { {lbl0Posi,  lbl0Sts, lbl0FLimit, lbl0BLimit},
                              {lbl1Posi, lbl1Sts, lbl1FLimit, lbl1BLimit},
                              {lbl2Posi, lbl2Sts, lbl2FLimit, lbl2BLimit},
                              {lbl3Posi, lbl3Sts, lbl3FLimit, lbl3BLimit},
                              {lbl4Posi, lbl4Sts, lbl4FLimit, lbl4BLimit},
                              {lbl5Posi, lbl5Sts, lbl5FLimit, lbl5BLimit}
                             };
            for (int i = 0; i < AxisArr.Length; i++)
            {
                //获取参数
                //zm.GetAxisPosi(i, ref axis_sts[i].posi);
                //zm.GetAxisStatus(i, ref axis_sts[i].sts);
                //zm.GetAxisFsLimit(i, ref axis_sts[i].fs_limit);
                //zm.GetAxisRsLimit(i, ref axis_sts[i].rs_limit);
                //zm.GetMType(i, ref axis_sts[i].mtype);
                //UpdateUILog($"轴{i}的mType是{axis_sts[i].mtype}");
                //update UI
                this.SetText(lbl[i, 0], axis_sts[i].posi.ToString("f"));
                //this.SetText(lbl[i, 1], axis_sts[i].sts.ToString("f"));
                //this.SetText(lbl[i, 2], axis_sts[i].fs_limit.ToString("f"));
                //this.SetText(lbl[i, 3], axis_sts[i].rs_limit.ToString("f"));
            }
            ////画图
            //float[] posi = { axis_sts[0].posi, axis_sts[1].posi, axis_sts[2].posi };
            ////画图
            //P0 = zm.PanelPaint(posi);
            //this.SetText(tbP0, P0.X.ToString("f3") + "," + P0.Y.ToString("f3"));
            //this.SetText(lblP0, P0.X.ToString("f3") + "," + P0.Y.ToString("f3"));

        }

        private void SetText(Label lblname, string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { lblname, text });
            }
            else
            {
                lblname.Text = text;
            }
        }

        private void SetText(TextBox lblname, string text)
         {
                // InvokeRequired required compares the thread ID of the
                // calling thread to the thread ID of the creating thread.
                // If these threads are different, it returns true.
                if (this.InvokeRequired)
                {
                    SetTextBoxCallback d = new SetTextBoxCallback(SetText);
                    this.Invoke(d, new object[] { lblname, text });
                }
                else
                {
                    lblname.Text = text;
                }
         }
        
        delegate void SetTextCallback(Label lblname, string text);
        delegate void SetTextBoxCallback(TextBox lblname, string text);

        static float[] last_posi = new float[6] { 0, 0, 0, 0, 0, 0 };
        private bool posi_changed = false;
        private object lockposi = new object(); // 用于线程同步的锁对象

        //private bool posi_isProcessing=false;
        private void TiUpdSts_Tick(object sender, EventArgs e)
        {
            if (!IsCnctZM)
            {
                return;
            }
            CycAxisSts[] axis_sts = new CycAxisSts[6] {new CycAxisSts (0,AxisSatus.NoError,0,0,AxisMType.Idle),
                                                            new CycAxisSts (0,AxisSatus.NoError,0,0,AxisMType.Idle),
                                                            new CycAxisSts (0,AxisSatus.NoError,0,0,AxisMType.Idle),
                                                            new CycAxisSts (0,AxisSatus.NoError,0,0,AxisMType.Idle),
                                                            new CycAxisSts (0,AxisSatus.NoError,0,0,AxisMType.Idle),
                                                            new CycAxisSts (0,AxisSatus.NoError,0,0,AxisMType.Idle)
                                                      };
            //Label[,] lbl = { {lbl0Posi, lbl1Posi, lbl2Posi, lbl3Posi, lbl4Posi, lbl5Posi },
            //                  { lbl0Sts,  lbl1Sts,  lbl2Sts,  lbl3Sts, lbl4Sts,   lbl5Sts },
            //                  { lbl0FLimit,lbl1FLimit,lbl2FLimit,lbl3FLimit,lbl4FLimit,lbl4FLimit },
            //                  { lbl0BLimit,lbl1BLimit,lbl2BLimit,lbl3BLimit,lbl4BLimit,lbl5BLimit }
            //                 };
            Label[,] lbl = { {lbl0Posi,  lbl0Sts, lbl0FLimit, lbl0BLimit},
                              {lbl1Posi, lbl1Sts, lbl1FLimit, lbl1BLimit},
                              {lbl2Posi, lbl2Sts, lbl2FLimit, lbl2BLimit},
                              {lbl3Posi, lbl3Sts, lbl3FLimit, lbl3BLimit},
                              {lbl4Posi, lbl4Sts, lbl4FLimit, lbl4BLimit},
                              {lbl5Posi, lbl5Sts, lbl5FLimit, lbl5BLimit}
                             };
            for (int i = 0; i < AxisArr.Length; i++)
            {
                //获取参数
                zm.GetAxisPosi(i, ref axis_sts[i].posi);
                zm.GetAxisStatus(i, ref axis_sts[i].sts);
                zm.GetAxisFsLimit(i, ref axis_sts[i].fs_limit);
                zm.GetAxisRsLimit(i, ref axis_sts[i].rs_limit);
                zm.GetMType(i, ref axis_sts[i].mtype);
                zm.GetDriveTorque(i, ref axis_sts[i].DriveTorque);

                //UpdateUILog($"轴{i}的mType是{axis_sts[i].mtype}");
                //update UI
                lbl[i, 0].Text = axis_sts[i].posi.ToString("f");
                lbl[i, 1].Text = axis_sts[i].sts.ToString("f");
                lbl[i, 2].Text = axis_sts[i].fs_limit.ToString("f");
                lbl[i, 3].Text = axis_sts[i].rs_limit.ToString("f");


            }
            float[] posi = { axis_sts[0].posi, axis_sts[1].posi, axis_sts[2].posi, axis_sts[3].posi, axis_sts[4].posi, axis_sts[5].posi };
            for (int i = 0; i < 6; i++)
            {
                if (last_posi[i] != posi[i])
                {
                    last_posi[i] = posi[i];
                    posi_changed = true;
                }
            }
            if (posi_changed)
            {
                posi_changed = false;
                zm.CalP(posi);
                if (IsCnctZM)
                {
                    lock (lockposi)
                    {
                        //if (posi_isProcessing)
                        //return;
                        //posi_isProcessing = true;
                        Thread processingThread = new Thread(() =>
                        {
                            //画图
                            zm.PanelPaint(posi);
                            //posi_isProcessing = false; // 标记处理完成
                        });
                        processingThread.Start();
                    }
                }
            }


            tb_P5.Text = zm.GetP_5().X.ToString("f3") + "," + zm.GetP_5().Y.ToString("f3") + "," + zm.GetP_5().Z.ToString("f3");

            tbP_3.Text = zm.GetP_3().X.ToString("f3") + "," + zm.GetP_3().Y.ToString("f3") + "," + zm.GetP_3().Z.ToString("f3");
            tbP_Suctioncup.Text = zm.GetP_Suctioncup().X.ToString("f3") + "," + zm.GetP_Suctioncup().Y.ToString("f3") + "," + zm.GetP_Suctioncup().Z.ToString("f3");
            tbP_Bolwtorch.Text = zm.GetP_Bolwtorch().X.ToString("f3") + "," + zm.GetP_Bolwtorch().Y.ToString("f3") + "," + zm.GetP_Bolwtorch().Z.ToString("f3");
            if (InitStatus == -1)                //已经加载文件并且正在初始化 读取状态
            {
                float tempstatus = -1;
                int m_BusNodeNum = 0;
                float m_BusAxisNum = 0;

                zm.GetUserVar("Bus_InitStatus", ref tempstatus);//读取BAS文件中的变量判断总线初始化完成状态
                zm.GetUserVar("Bus_TotalAxisnum", ref m_BusAxisNum);//读取BAS文件中的变量判断扫描的总轴数
                InitStatus = (int)tempstatus;
                if (InitStatus == 0)     //初始化完成刷新状态	
                {
                    UpdateUILog("初始化失败");
                    logger.Info("初始化失败");

                }
                else if(InitStatus == 1)
                {
                     m_BusAxisNum.ToString();
                    UpdateUILog("初始化成功"+ m_BusNodeNum.ToString()+"轴完成初始化");
                    logger.Info("初始化成功" + m_BusNodeNum.ToString() + "轴完成初始化");
                }
            }

            uint IOStop = zm.GetIOStop();
            if (IOStop == 0)
            {
                zm.EmergencyStop();
                //th_Task.Abort();
                run = false;
                XY_Motion.CancelThread();
                th_Motion.CancelThread();
                //cancelTokSrc.Cancel();
                logger.Info("按下急停按钮!!!");
                evt_msg_arrive.Reset();

                zm.ResetEnable();
            }


        }


        private void cbbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsCnctZM)
            {
                UpdateUILog("未连接到控制器！请先尝试连接控制器");
                return;
            }

            //获取界面当前选中的轴号
            int n = Convert.ToInt32(cbbAxis.Text);
            AxisParam ap = new AxisParam(n);
            zm.GetAxisParam(ref ap);
            UpdateUILog($"读取轴{n}状态");
            cbbSpeed.Text = ap.Speed.ToString();
            cbbUnits.Text = ap.Units.ToString();
            cbbAccel.Text = ap.Accel.ToString();
            cbbDecel.Text = ap.Decel.ToString();
            cbbPosLimit.Text = ap.FsLimit.ToString();
            cbbNegLimit.Text = ap.RsLimit.ToString();
            cbbInit.Text = ap.Init.ToString();

        }

        /// <summary>
        /// 连接成功视觉上位机后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCamConnectFcn(object sender, EventArgs e)
        {
            //UpdateUILog("连接到视觉上位机");
            UpdateUILog("连接视觉上位机成功");
            logger.Info("连接视觉上位机成功");
        }

        //TODO: 完善视觉上位机的消息处理
        /// <summary>
        /// 收到视觉上位机TCP消息后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCamReceiveFcn(object sender, Packet e)
        {
            UpdateUILog(e.Type.ToString());  //only for testing
            UpdateUILog(e.Info);

            //检查是否是自动模式，如果不是直接return
            if (!chbAutoMode.Checked)
            {
                return;
            }
            //检查PLC状态 是否出入安全位置，如果不是不处理或上报error
            //PLC 处理的类还没有写


            //判断消息类型
            switch (e.Type)
            {
                case PacketType.Exec:

                    switch (e.Commd)
                    {
                        case RobotCommand.Stop:
                            UpdateUILog("收到Stop消息");
                            logger.Info("收到Stop消息");
                            break;
                        case RobotCommand.Pause:
                            UpdateUILog("收到Pause消息");
                            logger.Info("收到Pause消息");
                            break;
                        case RobotCommand.Take:
                            //放进消息队列,暂时屏蔽测试
                            UpdateUILog($"收到取物消息位置[{e.Posi.X},{e.Posi.Y}]");


                            lock (sync_msg)
                            {
                                msg_pkt.Enqueue(e);
                            }
                            logger.Info("收到取东西消息，发送事件");
                            evt_msg_arrive.Set();//发送事件消息通知task线程处理
                            break;
                        default:
                            UpdateUILog("未处理消息");

                            break;
                    }
                    break;
                case PacketType.Info:
                    UpdateUILog($"收到信息:{e.Info}");

                    break;
                default:
                    break;
            }


        }

        /// <summary>
        /// 与视觉上位机断开连接后触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCamCloseFcn(object sender, EventArgs e)
        {
            UpdateUILog("断开视觉上位机连接");
            logger.Info("断开视觉上位机连接");


            Thread thread = new Thread(() =>
            {
                do
                {
                    logger.Info("重连视觉上位机...");
                    cameraSvr.ConnectSvr();
                    Thread.Sleep(1000);//等待1s再去重连
                } while (!cameraSvr.IsConnect());
                
            });
            thread.IsBackground = true;//设置为后台线程，在程序退出时自己会自动释放
            thread.Start();//开始执行线程

        }

        /// <summary>
        /// 用于保存上个周期的轴mtype
        /// </summary>
        static AxisMType[] last_amt = new AxisMType[6] { AxisMType.Idle, AxisMType.Idle,
                                                  AxisMType.Idle,AxisMType.Idle,
                                                  AxisMType.Idle,AxisMType.Idle};

        object mt_lock = new object();
        List<Task> ts = new List<Task>();
        /// <summary>
        /// 循环获取正运动轴数据的回调函数,100ms触发一次
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnReceiveFromZM(object sender, CycAxisSts[] e)
        {
            Label[,] lbl = { {lbl0Posi,  lbl0Sts, lbl0FLimit, lbl0BLimit},
                              {lbl1Posi, lbl1Sts, lbl1FLimit, lbl1BLimit},
                              {lbl2Posi, lbl2Sts, lbl2FLimit, lbl2BLimit},
                              {lbl3Posi, lbl3Sts, lbl3FLimit, lbl3BLimit},
                              {lbl4Posi, lbl4Sts, lbl4FLimit, lbl4BLimit},
                              {lbl5Posi, lbl5Sts, lbl5FLimit, lbl5BLimit}
                             };

            lock (mt_lock)
            {
                uint IOStop = zm.GetIOStop();
                if (IOStop == 0)
                {
                    zm.EmergencyStop();
                    //th_Task.Abort();
                    evt_msg_arrive.Reset();
                    run = false;
                    XY_Motion.CancelThread();

                    th_Motion.CancelThread();
                    //cancelTokSrc.Cancel();
                    UpdateUILog("按下急停按钮!!!");
                    logger.Info("按下急停按钮!!!");

                    zm.ResetEnable();
                }

                for (int i = 0; i < e.Length; i++)
                {
                    if (last_amt[i] != e[i].mtype)
                    {
                        UpdateUILog($"轴{i}从{last_amt[i]}变为{e[i].mtype}");
                        logger.Info($"轴{i}从{last_amt[i]}变为{e[i].mtype}");

                    }
                    //if (last_posi[i] != e[i].posi)
                    //{

                    //    //ts.Add(Upd_Task = Task.Factory.StartNew(() => UpdAnix(e)));

                    //    //Action<CycAxisSts> a = new Action();
                    //    //lbl[i, 0].Text = e[i].posi.ToString("f");
                    //    //Action<CycAxisSts[]> b = (CycAxisSts[] ab) => Updpaint(ab);
                    //    //b.Invoke(e);
                    //    Action<CycAxisSts[]> a = (CycAxisSts[] ab) => UpdAnix(ab);
                    //    a.Invoke(e);
                    //}
                    //if (e[i].mtype != AxisMType.Idle)
                    //{
                    //    //UpdateUILog($"轴{i}当前mType:{e[i].mtype}");
                    //}
                    //保存当前周期的值供下个周期使用
                    last_amt[i] = e[i].mtype;
                    //last_posi[i] = e[i].posi;

                }
            }
        }

        private bool comparecurrentposition(PointXYZF a)
        {

            if((zm.GetP_mode().X<a.X+2)&& (zm.GetP_mode().X > a.X - 2)&& (zm.GetP_mode().Y < a.Y + 2)&&(zm.GetP_mode().Y> a.Y - 2))
                return true;
            else 
                return false;
        }

        /// <summary>
        /// 机械比运动函数 TODO： 
        /// </summary>
        private void RobotMotion()
        {
            while (!cancelTokSrc.IsCancellationRequested)
            {
                //th_ctrl_evt.WaitOne();

                evt_msg_arrive.WaitOne();
                while (msg_pkt.Count > 0)
                {
                    Packet pkt;
                    lock (sync_msg)
                    {
                        pkt = msg_pkt.Dequeue();
                    }
                    //根据指令打开吸盘或吹嘴
                    zm.SetSuctioncupMode();
                    //zm.SetBolwtorchMode();
                    //收回Z轴
                    zm.MoveInit(5, AxisArr[5].Init);
                    Thread.Sleep(1000);
                    while (!IsAllAxisIdle())
                    {
                        Thread.Sleep(100);
                    }

                    //执行机械臂操作,TODO:调用正逆解函数
                    logger.Info($"机械臂开始向位置[{pkt.Posi.X},{pkt.Posi.Y}]移动");
                    UpdateUILog($"机械臂开始向位置[{pkt.Posi.X},{pkt.Posi.Y}]移动");
                    //zm.MoveTargetPosition2(pkt.Posi);
                    MoveTargetPosi_limit(pkt.Posi);

                 

                    

                    Thread.Sleep(1000);
                    //等待机械臂达到目标位置
                    while (!IsAllAxisIdle())
                    {
                        Thread.Sleep(100);
                    }
                    if(!comparecurrentposition(pkt.Posi))          
                    {
                        while (!IsAllAxisIdle())
                        {
                            Thread.Sleep(100);
                        }
                    }
                    logger.Info($"机械臂到达位置[{pkt.Posi.X},{pkt.Posi.Y}]");
                    UpdateUILog($"机械臂到达位置[{pkt.Posi.X},{pkt.Posi.Y}]");
                    //Z轴放下
                    zm.AnixZHeight();
                    Thread.Sleep(1000);
                    while (!IsAllAxisIdle())
                    {
                        Thread.Sleep(100);
                    }
                    

                    logger.Info("吸尘器或吸盘操作");
                    UpdateUILog("吸尘器或吸盘操作");
                    if (zm.GetExtremityMode() == 1)
                    { //吸尘器或吸盘操作 TODO:吸尘器或吸盘


                        if (zm.SetSucker())
                        {
                            logger.Info("Start Sucker");
                            UpdateUILog("开启吸盘");
                        }
                        else
                        {
                            logger.Error("Failed to Start Sucker");
                            UpdateUILog("开启吸盘失败");
                        }
                    }
                    else if(zm.GetExtremityMode()==2)
                    {
                        if (zm.SetCleaner())
                        {
                            logger.Info("Start Blow");
                            UpdateUILog("开启吹嘴");
                        }
                        else
                        {
                            logger.Error("Failed to Start Blow");
                            UpdateUILog("开启吹嘴失败");
                        }
                    }
                    


                    //Z轴抬升
                    Thread.Sleep(1000);
                    //zm.MoveZero(3);
                    zm.MoveInit(5, AxisArr[5].Init);
                    Thread.Sleep(1000);
                    while (!IsAllAxisIdle())
                    {
                        Thread.Sleep(100);
                    }

                    if (zm.GetExtremityMode() == 1)
                    {
                        //执行机械臂操作到达垃圾桶  TODO:调用机械臂操作函数
                        logger.Info("机械臂开始向垃圾桶移动");
                        UpdateUILog("机械臂开始向垃圾桶移动");

                        MoveTargetPosi_limit(myHardwareCfg.PIdle);
                        Thread.Sleep(1000);

                        //等待机械臂达到目标位置
                        while (!IsAllAxisIdle())
                        {
                            Thread.Sleep(100);


                        }
                        if (!comparecurrentposition(myHardwareCfg.PIdle))
                        {
                            while (!IsAllAxisIdle())
                            {
                                Thread.Sleep(100);
                            }
                        }
                        logger.Info("机械臂到达垃圾桶");
                        UpdateUILog("机械臂到达垃圾桶");
                    }

                    //吸盘或吸尘器扔东西
                    logger.Info("吸盘或吸尘器扔东西");
                    UpdateUILog("吸盘或吸尘器扔东西");


                    if (zm.GetExtremityMode() == 1)
                    { //吸尘器或吸盘操作 TODO:吸尘器或吸盘


                        if (zm.StopSucker())
                        {
                            logger.Info("Start Sucker");
                            UpdateUILog("关闭吸盘");
                        }
                        else
                        {
                            logger.Error("Failed to Start Sucker");
                            UpdateUILog("关闭吸盘失败");
                        }
                    }
                    else if (zm.GetExtremityMode() == 2)
                    {
                        if (zm.StopCleaner())
                        {
                            logger.Info("Start Blow");
                            UpdateUILog("关闭吹嘴");
                        }
                        else
                        {
                            logger.Error("Failed to Start Blow");
                            UpdateUILog("关闭吹嘴失败");
                        }
                    }
                    Thread.Sleep(1000);

                    if (msg_pkt.Count == 0)
                    {
                        //机械臂回零
                        logger.Info("机械臂准备回归初始位置");
                        UpdateUILog("机械臂准备回归初始位置");
                        //zm.MoveTargetPosition2(PIdle);
                        //MoveTargetPosi_limit(PIdle);
                        zm.MoveInitStstus();
                        Thread.Sleep(1000);
                        //等待机械臂回零
                        while (!IsAllAxisIdle())
                        {
                            Thread.Sleep(100);
                        }
                        logger.Info("机械臂准备到达初始位置");
                        UpdateUILog("机械臂准备到达初始位置");
                        ////上报状态
                        //Packet data = new Packet();
                        //data.Status = RobotSts.Idle;
                        //cameraSvr.Send(data);
                    }

                }//packet arrive

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 通过判断轴的mtype来判断轴是否完成运动处于Idle状态
        /// </summary>
        /// <returns></returns>
        private bool IsAllAxisIdle()
        {
            lock (mt_lock)
            {
                for (int i = 0; i < last_amt.Length; i++)
                {
                    if (last_amt[i] != AxisMType.Idle)
                        return false;
                }
            }

            return true;
        }


        /// <summary>
        /// 设置PLC led灯开启或关闭,支持跨线程操作
        /// </summary>
        /// <param name="sts"></param>
        public void SetPLCLed(SWLed.LedState sts)
        {

            this.BeginInvoke(new Action(() =>
            {
                plcLed.State = sts;
            }));
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void OnCipReceiveFcn(CIPRecvInfoArgs recvMsg)
        {
            UpdateUILog(recvMsg.TrigFlag.ToString());
           
        }
        private void btnMove_Click(object sender, EventArgs e)
        {
            //AxisMType amt = zm.GetMType(0);  //only for testing
            //UpdateUILog($"0轴mType:{amt}");
            if (txtTargetPosi.Text == string.Empty ||
                !Regex.IsMatch(txtTargetPosi.Text, @"^-?\d+\.?\d*,-?\d+\.?\d*$"))
            {
                MessageBox.Show("请输入要移动的目标位置坐标，X，Y以逗号隔开!例如：600.0,600.0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PointXYZF point = new PointXYZF();
            List<string> list = new List<string>(txtTargetPosi.Text.Split(','));
            point.X = Convert.ToSingle(list[0]);
            point.Y = Convert.ToSingle(list[1]);



            Thread processingThread = new Thread(() =>
            {
                //画图
                MoveTargetPosi_limit(point);

            });
            processingThread.Start();

        }
        int flag_loop = 0;
        private bool MoveTargetPosi_limit(PointXYZF point)
        {
            int flag= zm.MoveTargetPosition2(point);
            if (flag == 1)
            {

                UpdateUILog($"运动到指定位置[{point.X},{point.Y}]");
                logger.Info($"运动到指定位置[{point.X},{point.Y}]");
                flag_loop = 0;
                return true;
            }
            else if (flag == 0)
            {
                UpdateUILog($"运动到指定位置[{point.X},{point.Y}]失败");
                logger.Error($"运动到指定位置[{point.X},{point.Y}]失败");
                flag_loop = 0;
                return true;


            }
            else if (flag == 2)
            {

                flag_loop++;

                if (flag_loop > 1)
                {
                    UpdateUILog($"运动到指定位置[{point.X},{point.Y}]失败");
                    logger.Error($"运动到指定位置[{point.X},{point.Y}]失败");
                    flag_loop = 0;
                    return true;
                }
                else
                {
                    Thread.Sleep(1000);
                    while (!IsAllAxisIdle()) ;
                    MoveTargetPosi_limit(point);
                    return false;

                }

            }
            else
                return true;

        }

        private void btn0Home_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveZero(0);

            });
            processingThread.Start();



        }

        private void btn1Home_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveZero(1);

            });
            processingThread.Start();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveZero(2);

            });
            processingThread.Start();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveZero(3);

            });
            processingThread.Start();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveZero(4);

            });
            processingThread.Start();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.AnixZHeight();
            });
            processingThread.Start();
        }



        private void Btn0Init_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveInit(0, AxisArr[0].Init);

            });
            processingThread.Start();
        }

        private void Btn1Init_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveInit(1, AxisArr[1].Init);

            });
            processingThread.Start();
        }

        private void Btn2Init_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveInit(2, AxisArr[2].Init);

            });
            processingThread.Start();

        }

        private void Btn3Init_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveInit(3, AxisArr[3].Init);

            });
            processingThread.Start();
        }

        private void Btn4Init_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveInit(4, AxisArr[4].Init);

            });
            processingThread.Start();
        }

        private void Btn5Init_Click(object sender, EventArgs e)
        {
            Thread processingThread = new Thread(() =>
            {
                while (!IsAllAxisIdle()) ;
                zm.MoveInit(5, AxisArr[5].Init);

            });
            processingThread.Start();
        }



        private void btnInit_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 6; i++)
            {
                if (btnCnct.Enabled == false)
                    zm.SetAxisType(i, 65);
                else
                    zm.SetAxisType(i, 0);
                zm.SetAxisParam(AxisArr[i]);

            }
            //打开连续插补
            logger.Info("OpenMergeChange");
            UpdateUILog("打开连续插补");
            zm.MergeChange();
            //使能轴
            logger.Info("EnableAxis");
            UpdateUILog("使能所有轴");
            zm.SetEnable();
            //机械臂运动线程
            //th_Task = new Thread(new ThreadStart(RobotMotion));
            //th_Task.IsBackground = true;
            //th_Task.Name = "Motion_Task";
            //logger.Info($"Start thread:{th_Task.Name}");
            //th_Task.Start();
            //evt_msg_arrive.Reset();

            th_Motion.StartThread();
            XY_Motion.StartThread();
        }

 

  
        private void chbAutoMode_CheckStateChanged(object sender, EventArgs e)
        {
            //DialogResult dr = MessageBox.Show("确定要求切换到自动模式吗？如果PLC处于工作状态可能会危险!!", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            //if (dr == DialogResult.OK)
            //{
            //    chbAutoMode.Checked = true;
            //}
            //else
            //{
            //    chbAutoMode.Checked = false;
            //}
        }





        private void btnSetIdlePosi_Click(object sender, EventArgs e)
        {
            if (txtTargetPosi.Text == string.Empty ||
    !Regex.IsMatch(txtTargetPosi.Text, @"^-?\d+\.?\d*,-?\d+\.?\d*$"))
            {
                MessageBox.Show("请输入要保存的待机位置坐标，X，Y以逗号隔开!例如：600.0,600.0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> list = new List<string>(txtTargetPosi.Text.Split(','));

            myHardwareCfg.PIdle.X = Convert.ToSingle(list[0]);
            myHardwareCfg.PIdle.Y = Convert.ToSingle(list[1]);
            HardwareCfg.Write(myHardwareCfg,xmlPath);
        }

        private void btnInitPosi_Click(object sender, EventArgs e)
        {
            if (txtTargetPosi.Text == string.Empty ||
    !Regex.IsMatch(txtTargetPosi.Text, @"^-?\d+\.?\d*,-?\d+\.?\d*$"))
            {
                MessageBox.Show("请输入要保存的初始位置坐标，X，Y以逗号隔开!例如：600.0,600.0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            List<string> list = new List<string>(txtTargetPosi.Text.Split(','));
            myHardwareCfg.PInit.X = Convert.ToSingle(list[0]);
            myHardwareCfg.PInit.Y = Convert.ToSingle(list[1]);
            HardwareCfg.Write(myHardwareCfg, xmlPath);
        }

        private void btnMoveInit_Click(object sender, EventArgs e)
        {
            MoveTargetPosi_limit(myHardwareCfg.PIdle);

        }

        private void btnMoveIdle_Click(object sender, EventArgs e)
        {
            MoveTargetPosi_limit(myHardwareCfg.PInit);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //初始化总线

            logger.Info("BusInit");
            UpdateUILog("初始化总线");
            zm.BusInit();
            InitStatus = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //取消使能轴
            logger.Info("DisableAxis");
            UpdateUILog("取消使能所有轴");
            zm.ResetEnable();
        }

        private void cbbCnctType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbCnctType.SelectedItem.ToString() == "MotionRT")
            {
                cbbCnctStr.Enabled = false;
            }
            else
            {
                cbbCnctStr.Enabled = true;
            }
        }
        private void OnCancelTask()
        {
            logger.Info("Motion Task was canceled!");
        }




        private void btnCIPConnect_Click(object sender, EventArgs e)
        {
            if(myCIP.Connect(tb_CIPIP.Text.Trim(),Convert.ToInt16( tb_CIPPort.Text.Trim()),true))
            {



                myHardwareCfg.PLCAddress = tb_CIPIP.Text;
                myHardwareCfg.PLCPort = Convert.ToInt16(tb_CIPPort.Text);
                HardwareCfg.Write(myHardwareCfg, xmlPath);
                UpdateUILog("连接PLC成功");
                logger.Info("连接PLC成功");
                plcLed.State = IndustrialCtrls.Leds.SWLed.LedState.On;

            }
            else
            {
                UpdateUILog("连接PLC失败");
                logger.Error("连接PLC失败");
                plcLed.State = IndustrialCtrls.Leds.SWLed.LedState.Off;

            }

        }

        private void RdBtn_Suctioncup_CheckedChanged(object sender, EventArgs e)
        {
            
            if(RdBtn_Suctioncup.Checked)
            {
                zm.SetSuctioncupMode();
            }
            posi_changed = true;

        }

        private void RdBtn_Bolwtorch_CheckedChanged(object sender, EventArgs e)
        {
            if (RdBtn_Bolwtorch.Checked)
                zm.SetBolwtorchMode(); 
            posi_changed = true;

        }

        private void RdBtn_mode0_CheckedChanged(object sender, EventArgs e)
        {
            if(RdBtn_mode0.Checked)
                zm.Set0Mode();
            posi_changed = true;
        }

        private void splitContDspUpDn_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        float MovePositionLen = 4;


        private void Btn_ZPlus_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Forward);

        }

        private void Btn_ZPlus_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Cancel);

        }

        private void Btn_ZMinus_MouseDown(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Backword);

        }

        private void Btn_ZMinus_MouseUp(object sender, MouseEventArgs e)
        {
            zm.SingleVMove(5, MoveMode.Cancel);
        }

        private void btn_DeflectionConfirm_Click(object sender, EventArgs e)
        {
            zm.SetDeflection(Convert.ToDouble(tb_SuctioncupDeflectionX.Text.Trim()), Convert.ToDouble(tb_SuctioncupDeflectionZ.Text.Trim()),
                Convert.ToDouble(tb_BolwtorchDeflectionX.Text.Trim()), Convert.ToDouble(tb_BolwtorchDeflectionZ.Text.Trim()));
            zm.SetHeight(Convert.ToDouble(tb_mode1height.Text.Trim()), Convert.ToDouble(tb_mode2height.Text.Trim()), Convert.ToDouble(tb_axis5zeroheight.Text.Trim()),Convert.ToDouble(tb_ProductionlineHeight.Text.Trim()));
        }

        private void btn_DeflectionSave_Click(object sender, EventArgs e)
        {

            myHardwareCfg.myEOAT.BolwtorchDeflection.X=Convert.ToSingle(tb_BolwtorchDeflectionX.Text.Trim());
            myHardwareCfg.myEOAT.BolwtorchDeflection.Z= Convert.ToSingle(tb_BolwtorchDeflectionZ.Text.Trim());
            myHardwareCfg.myEOAT.SuctioncupDeflection.X = Convert.ToSingle(tb_SuctioncupDeflectionX.Text.Trim());
            myHardwareCfg.myEOAT.SuctioncupDeflection.Z = Convert.ToSingle(tb_SuctioncupDeflectionZ.Text.Trim());
            myHardwareCfg.myEOAT.mode1_height= Convert.ToSingle(tb_mode1height.Text.Trim());
            myHardwareCfg.myEOAT.mode2_height = Convert.ToSingle(tb_mode2height.Text.Trim());
            myHardwareCfg.myEOAT.axis5zero = Convert.ToSingle(tb_axis5zeroheight.Text.Trim());
            myHardwareCfg.myEOAT.Productionline_height = Convert.ToSingle(tb_ProductionlineHeight.Text.Trim());

            HardwareCfg.Write(myHardwareCfg, xmlPath);


        }

        private void btn_SetAverageDeflection_Click(object sender, EventArgs e)
        {
            if (tb_AverageDeflectionX.Text == string.Empty || tb_AverageDeflectionY.Text == string.Empty)
            {
                MessageBox.Show("请先求XY方向平均偏差", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            zm.SetAbsDeflection(Convert.ToSingle(tb_AverageDeflectionX.Text.Trim()), Convert.ToSingle(tb_AverageDeflectionY.Text.Trim()));
            myHardwareCfg.myMotionControl.AbsDeflection.X = Convert.ToSingle(tb_AverageDeflectionX.Text.Trim());
            myHardwareCfg.myMotionControl.AbsDeflection.Y = Convert.ToSingle(tb_AverageDeflectionY.Text.Trim());
            HardwareCfg.Write(myHardwareCfg, xmlPath);
            lbl_CurrentDeflectionX.Text = tb_AverageDeflectionX.Text.Trim();
            lbl_CurrentDeflectionY.Text = tb_AverageDeflectionY.Text.Trim();

        }

        private void btn_CalculateAverageDeflection_Click(object sender, EventArgs e)
        {
            tb_AverageDeflectionX.Text = ((Convert.ToSingle(tb_DeflectionX1.Text.Trim())+ Convert.ToSingle(tb_DeflectionX2.Text.Trim())+ Convert.ToSingle(tb_DeflectionX3.Text.Trim())+ 
                Convert.ToSingle(tb_DeflectionX4.Text.Trim())+ Convert.ToSingle(tb_DeflectionX5.Text.Trim())+ Convert.ToSingle(tb_DeflectionX6.Text.Trim())) / 6).ToString();
            tb_AverageDeflectionY.Text = ((Convert.ToSingle(tb_DeflectionY1.Text.Trim()) + Convert.ToSingle(tb_DeflectionY2.Text.Trim()) + Convert.ToSingle(tb_DeflectionY3.Text.Trim()) +
     Convert.ToSingle(tb_DeflectionY4.Text.Trim()) + Convert.ToSingle(tb_DeflectionY5.Text.Trim()) + Convert.ToSingle(tb_DeflectionY6.Text.Trim())) / 6).ToString();
        }




        private void button4_Click(object sender, EventArgs e)
        {
            zm.Set5Zero();
        }



        private void btn_InitStatus_Click(object sender, EventArgs e)
        {

            int flag = zm.MoveInitStstus();
            if (flag == 1)
            {

                UpdateUILog($"运动到初始位置");
                logger.Info($"运动到初始位置");
            }
            else if (flag == 0)
            {
                UpdateUILog($"运动到初始位置失败");
                logger.Error($"运动到初始位置失败");

            }


        }

  

        private void btn_ConfirmWorkspaceLimit_Click(object sender, EventArgs e)
        {
            zm.SetWorkspaceLimit(Convert.ToInt16(tb_workspaceXPlus.Text.Trim()), Convert.ToInt16(tb_workspaceXMinus.Text.Trim()), Convert.ToInt16(tb_workspaceYPlus.Text.Trim()), Convert.ToInt16(tb_workspaceYMinus.Text.Trim()));
        }

        private void btn_SaveWorkspaceLimit_Click(object sender, EventArgs e)
        {
            myHardwareCfg.myMotionControl.workspaceXPlus = Convert.ToInt16(tb_workspaceXPlus.Text.Trim());
            myHardwareCfg.myMotionControl.workspaceYPlus = Convert.ToInt16(tb_workspaceYPlus.Text.Trim());
            myHardwareCfg.myMotionControl.workspaceYMinus = Convert.ToInt16(tb_workspaceYMinus.Text.Trim());
            myHardwareCfg.myMotionControl.workspaceXMinus = Convert.ToInt16(tb_workspaceXMinus.Text.Trim());

            HardwareCfg.Write(myHardwareCfg, xmlPath);
        }

        private void btn_SaveIO_Click(object sender, EventArgs e)
        {
            myHardwareCfg.myIO.Suctioncup = Convert.ToInt16(tb_SuctioncupIO.Text.Trim());
            myHardwareCfg.myIO.Bolwtorch = Convert.ToInt16(tb_BolwtorchIO.Text.Trim());
            myHardwareCfg.myIO.emstop = Convert.ToInt16(tb_emstopIO.Text.Trim());
            HardwareCfg.Write(myHardwareCfg, xmlPath);
        }

        private void btn_ConfirmIO_Click(object sender, EventArgs e)
        {
            zm.SetIO(Convert.ToInt16(tb_SuctioncupIO.Text.Trim()), Convert.ToInt16(tb_BolwtorchIO.Text.Trim()), Convert.ToInt16(tb_emstopIO.Text.Trim()));


        }

        volatile bool run = false;
        volatile bool IsX = false;
        volatile bool IsPlus = false;
        PointXYZF a = new PointXYZF();

        PointXYZF b = new PointXYZF();
        volatile bool ismoving = false;
        private void MoveXY()
        {

            while (!cancelTokSrc.IsCancellationRequested)
            {


                while (run)
                {
                    ismoving = true;



                    if (IsX)
                    {
                        if (IsPlus)
                        {
                            if (a.X + MovePositionLen < myHardwareCfg.myMotionControl.workspaceXPlus)
                            {
                                a.X += MovePositionLen;

                            }
                            else
                            {
                                UpdateUILog($"超出边界");
                                logger.Error($"超出边界");
                                run = false;
                                continue;

                            }
                        }
                        else
                        {
                            if (a.X - MovePositionLen > myHardwareCfg.myMotionControl.workspaceXMinus)
                            {
                                a.X -= MovePositionLen;

                            }
                            else
                            {
                                UpdateUILog($"超出边界");
                                logger.Error($"超出边界");
                                run = false;

                                continue;
                            }
                        }
                    }
                    else
                    {
                        if (IsPlus)
                        {
                            if (a.Y + MovePositionLen < myHardwareCfg.myMotionControl.workspaceYPlus)
                            {
                                a.Y += MovePositionLen;

                            }
                            else
                            {
                                UpdateUILog($"超出边界");
                                logger.Error($"超出边界");
                                run = false;

                                continue;
                            }
                        }
                        else
                        {
                            if (a.Y - MovePositionLen > myHardwareCfg.myMotionControl.workspaceYMinus)
                            {
                                a.Y -= MovePositionLen;

                            }
                            else
                            {
                                UpdateUILog($"超出边界");
                                logger.Error($"超出边界");
                                run = false;

                                continue;
                            }
                        }
                    }

                    b.X = a.X;
                    b.Y = a.Y;
                    MoveTargetPosi_limit(b);

                    Thread.Sleep(100);
                    while (!IsAllAxisIdle()) ;
                    // 休眠100ms
                    ismoving = false;
                }
            }


        }
        private async void Btn_XPuls_MouseDown(object sender, MouseEventArgs e)
        {
            if(!ismoving)
                a=zm.GetP_mode();
            IsPlus = true;
            IsX = true;
            run = true;


        }

        private void Btn_XPuls_MouseUp(object sender, MouseEventArgs e)
        {
            run = false;

        }

        private void Btn_XMinus_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ismoving)
                a = zm.GetP_mode();
            IsPlus = false;
            IsX = true;
            run = true;


        }

        private void Btn_XMinus_MouseUp(object sender, MouseEventArgs e)
        {
            //movementThreadXMinus?.Cancel();
            run = false;
        }

        private async void Btn_YPlus_MouseDown(object sender, MouseEventArgs e)
        {
            if (!ismoving)
                a = zm.GetP_mode();
            IsPlus = true;
            IsX = false;
            run = true;
            //}
        }

        private void Btn_YPlus_MouseUp(object sender, MouseEventArgs e)
        {
            run = false;

        }

        private async void Btn_YMinus_MouseDown(object sender, MouseEventArgs e)
        {
            //if (!isMoving)
            //{
            if (!ismoving)
                a = zm.GetP_mode();
            IsPlus = false;
            IsX = false;
            run = true;
            //}
        }

        private void Btn_YMinus_MouseUp(object sender, MouseEventArgs e)
        {
            run = false;

        }

        private void tb_MovePositionLen_Leave(object sender, EventArgs e)
        {
            MovePositionLen = Convert.ToSingle(tb_MovePositionLen.Text.Trim());

        }
    }//end of class
}
