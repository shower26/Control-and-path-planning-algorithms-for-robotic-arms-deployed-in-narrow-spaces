using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

//using RobotControl.SHUTools;
using cszmcaux;
using Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RobotControl
{
    /// <summary>
    /// 用于封装正运动的库函数
    /// </summary>
    public class ZMControl
    {


        IntPtr handle;
        int BolwtorchIO = 8; //吹器IO号
        int SuctioncupIO =9;  //吸盘IO 号
        int camera1 = 10; //吹器IO号
        int camera2 = 11;  //吸盘IO 号
        int robot_sts = 4;  // 机械臂忙碌IO
        int emstopIO = 8;   //紧急停止IO
        //大、中、小臂长度l1、l2、l3以及末端轴间距l4、l5
        double l1 = 600, l2 = 500, l3 = 710, l4 = 68, l5 = -8;
        //定义d1,d2,d3,d4,d5
        double d1 = 198, d2 = 84, d3 = 102.5, d4 = -52.03, d5 = -108.9;
        //定义偏移量(不必修改，请勿修改！！！)
        double DeflectionX = 0, DeflectionY = 0, DeflectionA;
        //定义吸盘和吹嘴两个末端执行器到末端俯仰自由度的偏移量
        double SuctioncupDeflectionX = 90, SuctioncupDeflectionZ = -168, BolwtorchDeflectionX = -90, BolwtorchDeflectionZ = -128;
        int ExtremityMode = 0;//不使用末端mode=0,吸盘mode=1，吹嘴mode=2
        double mode1_height = 8;//mode1_height指希望吸盘底面到产线间的距离；30指升降自由度位于零点时吸盘底面到产线的距离
        double mode2_height = 30;//mode2_height指希望吹嘴底面到产线间的距离；
        double axis5zero_height=30;//30指升降自由度位于零点时吸盘底面到产线的距离
        float AbsDeflectionX = 0, AbsDeflectionY = 0;//绝对位置修正
        //定义产线所在z平面的高度
        double Productionline_height = 15;

        double pi = Math.PI;

        Graphics g;//画
        Pen p1,p2,p3,p4,p5,p6,pxy,pyz;//画笔
        PointF P_p0 = new PointF();//panel1中的（0，0）位置
        PointF P_p1 = new PointF();//panel1中的（0，0）位置
        PointF P_p2 = new PointF();//panel1中的（0，0）位置

        string strFilePath= $"System.IO.Directory.GetCurrentDirectory()\\ECATInit.bas";//初始化文件位置
        PointXYZF[] PNow = new PointXYZF[4];//[0]第三轴的位置，[1]吸盘位置，[2]吹嘴位置
        double workspaceXPlus = 1000, workspaceXMinus = -1000, workspaceYPlus = 1800, workspaceYMimus = 0;
        /// <summary>
        /// 注册此事件后向外部传递数据
        /// </summary>
        public EventHandler<CycAxisSts[]> CallBackFc;

        Thread th_GetData;
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public ZMControl()
        {
            handle = IntPtr.Zero;
            
            th_GetData = new Thread(new ThreadStart(CycGetDataFromZM));
            th_GetData.IsBackground = true;
            th_GetData.Name = "GetDataFromZM_thread";
            th_GetData.Start();
            P_p0.X = 150.0F;
            P_p0.Y = 200.0F;
            P_p1.X = 150.0F;
            P_p1.Y = 350.0F;
            P_p2.X = 150.0F;
            P_p2.Y = 500.0F;
            for(int i=0;i<4;i++)
            {
                PNow[i] = new PointXYZF();
            }
        }
        ~ZMControl()
        {
            if (th_GetData != null)
                th_GetData.Abort();

            DisConnect();
            NLog.LogManager.Shutdown();
        }

        public void BusInit()
        {

            

            zmcaux.ZAux_BasDown(handle, strFilePath, 1);               //下载到ROM

            
            StringBuilder buffer = new StringBuilder(10240);
            zmcaux.ZAux_Execute(handle, "RUNTASK 1,Ecat_Init", buffer, 0);          //运行BAS中的初始化函数

            
        }

        /// <summary>
        /// 连接到控制器
        /// </summary>
        /// <param name="Type">1:COM, 2: ETH, 4: PCI, 5: MotionRT</param>
        /// <param name="CnctStr">
        /// type=1 COM 串口号
        /// type=2 IP 地址
        /// type=4 Pci+ 卡号
        /// type = 5 ：无要求
        /// </param>
        /// <returns></returns>
        public bool Connect(CnctType Type, string CnctStr)
        {
            int rtn = zmcaux.ZAux_FastOpen((int)Type, CnctStr, 1000, out handle);
            if(rtn == 0)
            {
                return true;
            }
            logger.Error($"ZAux_FastOpen return {rtn},Param:{Type}-{(int)Type},ConStr:{CnctStr}");
            return false;
        }
        /// <summary>
        /// 连接到仿真器
        /// </summary>
        /// <returns></returns>
        public bool ConnectSimulator()
        {
            if (0 == zmcaux.ZAux_OpenEth("127.0.0.1", out handle))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 断开控制器连接
        /// </summary>
        /// <returns></returns>
        public bool DisConnect()
        {
            bool rtn = false;
            if (handle != IntPtr.Zero)
            {
                if (0 == zmcaux.ZAux_Close(handle))
                {
                    handle = IntPtr.Zero;
                    rtn = true;
                }
            }
            return rtn;
        }

        public void SetAxisParam(AxisParam Axis)
        {
            //zmcaux.ZAux_Direct_SetAtype(handle, Axis.Num, 65);
            zmcaux.ZAux_Direct_SetUnits(handle, Axis.Num, Axis.Units);
            zmcaux.ZAux_Direct_SetSpeed(handle, Axis.Num, Axis.Speed);
            zmcaux.ZAux_Direct_SetAccel(handle, Axis.Num, Axis.Accel);
            zmcaux.ZAux_Direct_SetDecel(handle, Axis.Num, Axis.Decel);
            zmcaux.ZAux_Direct_SetFsLimit(handle, Axis.Num, Axis.FsLimit);
            zmcaux.ZAux_Direct_SetRsLimit(handle, Axis.Num, Axis.RsLimit);
            //zmcaux.ZAux_Direct_SetAtype(handle, Axis.Num, (int)Axis.Type);
            //zmcaux.ZAux_Direct_SetAtype(handle, Axis.Num, (int)Axis.Type);
        }

        /// <summary>
        /// 获取轴参数
        /// </summary>
        /// <param name="ap">轴对象并传出</param>
        public void GetAxisParam(ref AxisParam ap)
        {
            //AxisParam ap = new AxisParam();
            //ap.Num = n;
            zmcaux.ZAux_Direct_GetUnits(handle, ap.Num, ref ap.Units);
            zmcaux.ZAux_Direct_GetSpeed(handle, ap.Num, ref ap.Speed);
            zmcaux.ZAux_Direct_GetAccel(handle, ap.Num, ref ap.Accel);
            zmcaux.ZAux_Direct_GetDecel(handle, ap.Num, ref ap.Decel);
            zmcaux.ZAux_Direct_GetFsLimit(handle, ap.Num, ref ap.FsLimit);
            zmcaux.ZAux_Direct_GetRsLimit(handle, ap.Num, ref ap.RsLimit);
            //return ap;
        }

        /// <summary>
        /// 获取轴参数
        /// </summary>
        /// <param name="Num">轴号</param>
        /// <returns>轴对象</returns>
        public AxisParam GetAxisParam(int Num)
        {
            AxisParam ap = new AxisParam(Num);
            //ap.Num = Num;
            zmcaux.ZAux_Direct_GetUnits(handle, ap.Num, ref ap.Units);
            zmcaux.ZAux_Direct_GetSpeed(handle, ap.Num, ref ap.Speed);
            zmcaux.ZAux_Direct_GetAccel(handle, ap.Num, ref ap.Accel);
            zmcaux.ZAux_Direct_GetDecel(handle, ap.Num, ref ap.Decel);
            zmcaux.ZAux_Direct_GetFsLimit(handle, ap.Num, ref ap.FsLimit);
            zmcaux.ZAux_Direct_GetRsLimit(handle, ap.Num, ref ap.RsLimit);
            return ap;
        }

        /// <summary>
        /// 单轴点动
        /// </summary>
        /// <param name="n">轴号</param>
        /// <param name="md">Forward： 正向运动
        ///                  Backword：反向运动
        ///                  Cancel：  停止运动
        /// </param>
        public void SingleVMove(int n, MoveMode md)
        {
            if(md == MoveMode.Cancel)
            {
                zmcaux.ZAux_Direct_Single_Cancel(handle, n, 2);
                return;
            }

            zmcaux.ZAux_Direct_Single_Vmove(handle, n, (int)md);
        }

        /// <summary>
        /// 启动吸尘器
        /// </summary>
        /// <returns></returns>
        public bool SetCleaner()
        {
            zmcaux.ZAux_Direct_SetOp(handle, BolwtorchIO, 1);
            uint IO_sts = 0;
            int rtn = zmcaux.ZAux_Direct_GetOp(handle, BolwtorchIO, ref IO_sts);
            if (rtn == 0)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetOp return {rtn}");
            return false;
        }
        /// <summary>
        /// 吸盘模式mode=1
        /// </summary>
        public void SetSuctioncupMode()

        {
            ExtremityMode = 1;
        }
        /// <summary>
        /// 吹嘴模式mode=2
        /// </summary>
        public void SetBolwtorchMode()

        {
            ExtremityMode = 2;
        }
        /// <summary>
        /// 吹嘴模式mode=0
        /// </summary>
        public void Set0Mode()

        {
            ExtremityMode = 0;
        }
        /// <summary>
        /// 停止吸尘器
        /// </summary>
        /// <returns></returns>
        public bool StopCleaner()
        {
            zmcaux.ZAux_Direct_SetOp(handle, BolwtorchIO, 0);
            uint IO_sts = 1;
            int rtn = zmcaux.ZAux_Direct_GetOp(handle, BolwtorchIO, ref IO_sts);
            if (rtn == 0)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetOp return {rtn}");
            return false;
        }


        public void GetUserVar(string type, ref float status)
        {

            zmcaux.ZAux_Direct_GetUserVar(handle, type, ref status);               //读取BAS文件中的变量判断总线初始化完成状态
        }

        /// <summary>
        /// 启动吸盘
        /// </summary>
        /// <returns></returns>
        public bool SetSucker()
        {
            zmcaux.ZAux_Direct_SetOp(handle, SuctioncupIO, 1);
            uint IO_sts = 0;
            int rtn = zmcaux.ZAux_Direct_GetOp(handle, SuctioncupIO, ref IO_sts);
            if (rtn == 0)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetOp return {rtn}");
            return false;
        }
        /// <summary>
        /// 停止吸盘
        /// </summary>
        /// <returns></returns>
        public bool StopSucker()
        {
            zmcaux.ZAux_Direct_SetOp(handle, SuctioncupIO, 0);
            uint IO_sts = 1;
            int rtn = zmcaux.ZAux_Direct_GetOp(handle, SuctioncupIO, ref IO_sts);
            if (rtn == 0)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetOp return {rtn}");
            return false;
        }
        /// <summary>
        /// 设置机械臂的忙碌状态
        /// </summary>
        /// <param name="sts">Running:忙碌；Idle：空闲</param>
        /// <returns></returns>
        public bool SetRobotSts(RobotSts sts)
        {
            zmcaux.ZAux_Direct_SetOp(handle, robot_sts, (uint)sts);
            uint IO_sts = 1;
            int rtn = zmcaux.ZAux_Direct_GetOp(handle, robot_sts, ref IO_sts);
            if (rtn == 0)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetOp return {rtn}");
            return false;
        }


        
        /// <summary>
        /// 紧急停止指令
        /// </summary>
        /// <returns></returns>
        public bool EmergencyStop()
        {
            if (0 == zmcaux.ZAux_Direct_Rapidstop(handle, 2))
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// 获取控制器的连接状态
        /// </summary>
        /// <returns></returns>
        public bool GetCnctSts()
        {
            if (handle != IntPtr.Zero)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 设置轴的运动位置
        /// </summary>
        /// <param name="n">要设置的轴号</param>
        /// <param name="posi">要运动的位置</param>
        /// <returns></returns>
        public bool SetAxisPosi(int n, float posi)
        {
            int rtn = zmcaux.ZAux_Direct_SetDpos(handle, n, posi);
            if (0 == rtn )
            {
                return true;
            }
            logger.Error($"ZAux_Direct_SetDpos return {rtn}");
            return false;
        }

        /// <summary>
        /// 获取轴的位置
        /// </summary>
        /// <param name="n">轴号</param>
        /// <param name="posi">轴的实际位置</param>
        /// <returns></returns>
        public bool GetAxisPosi(int n, ref float posi)
        {
            int rtn = zmcaux.ZAux_Direct_GetDpos(handle, n, ref posi);
            if (0 == rtn)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetDpos return {rtn}");
            return false;
        }
        /// <summary>
        /// 获取轴的正限位
        /// </summary>
        /// <param name="n">轴号</param>
        /// <param name="posi">正限位</param>
        /// <returns></returns>
        public bool GetAxisFsLimit(int n, ref float posi)
        {
            int rtn = zmcaux.ZAux_Direct_GetFsLimit(handle, n, ref posi);
            if (0 == rtn)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetFsLimit return {rtn}");
            return false;
        }
        /// <summary>
        /// 获取轴的负限位
        /// </summary>
        /// <param name="n">轴号</param>
        /// <param name="posi">负限位</param>
        /// <returns></returns>
        public bool GetAxisRsLimit(int n, ref float posi)
        {
            int rtn = zmcaux.ZAux_Direct_GetRsLimit(handle, n, ref posi);
            if (0 == rtn)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_GetRsLimit return {rtn}");
            return false;
        }

        /// <summary>
        /// 设置轴的类型
        /// </summary>
        /// <param name="n">要设置的轴</param>
        /// <param name="mode">轴的模式设置
        ///                   0: 虚拟轴
        ///                   1: 脉冲方向方式的步进或伺服 
        ///                   2: 模拟信号控制方式的伺服 
        ///                   3: 正交编码器 
        ///                   4: 脉冲方向输出+正交编码器输入
        ///                   5: 脉冲方向输出+脉冲方向编码器输入 
        ///                   6: 脉冲方向方式的编码器，可用于手轮输入
        ///                   7: 脉冲方向方式步进或伺服+EZ信号输入。 
        ///                   8: ZCAN扩展脉冲方向方式步进或伺服  
        ///                   9: ZCAN扩展正交编码器。 
        ///                   10: ZCAN扩展脉冲方向方式的编码器。 
        ///                   20: 振镜类型，带振镜状态反馈；振镜连接不上AXISSTATUS 的 bit2 会置位 ENCODER 返回原始的发送位置，脉冲单位； ZMC408SCAN 支持
        ///                   21 :振镜轴类型，需要控制器支持；缺省系统周期250us，振镜刷新周期50us，与固件有关；可以使用普通轴的所有运动控制指令，支持振镜轴与
        /// </param>
        /// <returns></returns>
        public bool SetAxisType(int n, int mode)
        {
            int rtn = zmcaux.ZAux_Direct_SetAtype(handle, n, mode);
            if (0 == rtn)
            {
                return true;
            }
            logger.Error($"ZAux_Direct_SetAtype return {rtn}");
            return false;
        }
        /// <summary>
        /// 获取轴的状态
        /// </summary>
        /// <param name="n">要获取的轴号</param>
        /// <param name="info">报警类型</param>
        /// <returns></returns>
        public bool GetAxisStatus(int n, ref AxisSatus info)
        {
            int axisstate = 0;
            int rtn = zmcaux.ZAux_Direct_GetAxisStatus(handle, n, ref axisstate);
            if (0 == rtn)
            {
                if (axisstate == 0)
                {
                    info = AxisSatus.NoError;
                }
                else if (((axisstate >> 9) & 1) == 1)
                {
                    info = AxisSatus.FlimitError;
                }
                else if (((axisstate >> 10) & 1) == 1)
                {
                    info = AxisSatus.BlimitError;
                }
                else if (((axisstate >> 3) & 1) == 1)
                {
                    info = AxisSatus.ServoError;
                }

                return true;
            }
            logger.Error($"ZAux_Direct_GetAxisStatus return {rtn}");
            return false;
        }
        public uint GetIOStop()
        {
            uint a=2;
            zmcaux.ZAux_Direct_GetIn(handle, emstopIO, ref a);
            return a;
        }
        public void Set5Zero()
        {
            zmcaux.ZAux_Direct_SetDpos(handle, 5, 0);
        }
        public int GetDriveTorque(int i,ref int gValue)
        {
            //int  gValue=0;

            zmcaux.ZAux_BusCmd_GetDriveTorque(handle, (uint)i, ref gValue);
            return gValue;
        }


        public PointXYZ[] ForwardKinematics2(float[] dpos)
        {

            //a1_current,a2_current,a3_current,a4_current,a5_current定义为当前旋转角,h4_current为升降自由度升降高度
            double a1_current = dpos[0], a2_current = dpos[1], a3_current = dpos[2], h4_current = dpos[5], a5_current = dpos[3], a6_current = dpos[4];
            //0-5为六轴坐标，6为吸盘Suctioncup，7为吹嘴Bolwtorch
            //定义大、中、小臂当前末端位置(P_current[0].X,P_current[0].Y,P_current[0].Z) , ( P_current[1].X, P_current[1].Y, P_current[1].Z) , ( P_current[2].X, P_current[2].Y, P_current[2].Z),升降轴位置（ P_current[3].X, P_current[3].Y, P_current[3].Z）,旋转轴位置（ P_current[4].X, P_current[4].Y, P_current[4].Z）,俯仰轴位置（ P_current[5].X, P_current[5].Y, P_current[5].Z）
            //定义吸盘Suctioncup和吹嘴Bolwtorch坐标（ P_current[6].X,P_current[6].Y, P_current[6].Z）,( P_current[7].X, P_current[7].Y, P_current[7].Z)
            double myl1 = l1, myl2 = l2, myl3 = l3, myl4 = l4, myl5 = l5;
            double myDeflectiona = DeflectionA, myDeflectionY = DeflectionY, myDeflectionX = DeflectionX;


            PointXYZ[] P_current = new PointXYZ[8];
            for (int i = 0; i < P_current.Length; i++)
            {
                P_current[i] = new PointXYZ();
            }


            myl3 = myl3 + myDeflectionY;
            myl3 = Math.Sqrt(myl3 * myl3 + myDeflectionX * myDeflectionX);
            myDeflectiona = Math.Asin(myDeflectionX / myl3) / pi * 180;
            a3_current = a3_current + myDeflectiona;

            //将转角转换为计算用角度
            a1_current = a1_current / 180 * pi;
            a2_current = a2_current / 180 * pi;
            a3_current = a3_current / 180 * pi;
            a5_current = a5_current / 180 * pi;
            a6_current = a6_current / 180 * pi;



            P_current[0].X = myl1 * Math.Sin(a1_current);
            P_current[0].Y =  myl1 * Math.Cos(a1_current);
            P_current[0].Z = d1;


             P_current[1].X = P_current[0].X + myl2 * Math.Sin(a1_current + a2_current);
             P_current[1].Y = P_current[0].Y + myl2 * Math.Cos(a1_current + a2_current);
             P_current[1].Z = d1 + d2;


             P_current[2].X =  P_current[1].X + myl3 * Math.Sin(a1_current + a2_current + a3_current);
             P_current[2].Y =  P_current[1].Y + myl3 * Math.Cos(a1_current + a2_current + a3_current);
             P_current[2].Z = d1 + d2 + d3;


             P_current[3].X =  P_current[2].X;
             P_current[3].Y =  P_current[2].Y;
             P_current[3].Z =  P_current[2].Z + d4 + h4_current;


             P_current[4].X =  P_current[3].X + myl4 * Math.Sin(a1_current + a2_current + a3_current);
             P_current[4].Y =  P_current[3].Y + myl4 * Math.Cos(a1_current + a2_current + a3_current);
             P_current[4].Z =  P_current[3].Z + d5;


             P_current[5].X =  P_current[4].X + myl5 * Math.Sin(a1_current + a2_current + a3_current + a5_current);
             P_current[5].Y =  P_current[4].Y + myl5 * Math.Cos(a1_current + a2_current + a3_current + a5_current);
             P_current[5].Z =  P_current[4].Z;


            //double  P_current[6].X = 0,  P_current[6].Y = 0,  P_current[6].Z = 0,  P_current[7].X = 0,  P_current[7].Y = 0,  P_current[7].Z = 0;

             P_current[6].X =  P_current[5].X + Math.Cos(a6_current) * SuctioncupDeflectionX * Math.Sin(a1_current + a2_current + a3_current + a5_current + pi / 2) - Math.Sin(a6_current) * SuctioncupDeflectionZ * Math.Sin(a1_current + a2_current + a3_current + a5_current + pi / 2);
             P_current[6].Y =  P_current[5].Y + Math.Cos(a6_current) * SuctioncupDeflectionX * Math.Cos(a1_current + a2_current + a3_current + a5_current + pi / 2) - Math.Sin(a6_current) * SuctioncupDeflectionZ * Math.Cos(a1_current + a2_current + a3_current + a5_current + pi / 2);
             P_current[6].Z =  P_current[5].Z + Math.Sin(a6_current) * SuctioncupDeflectionX + Math.Cos(a6_current) * SuctioncupDeflectionZ;


             P_current[7].X =  P_current[5].X + Math.Cos(a6_current) * BolwtorchDeflectionX * Math.Sin(a1_current + a2_current + a3_current + a5_current + pi / 2) + Math.Sin(a6_current) * BolwtorchDeflectionZ * Math.Sin(a1_current + a2_current + a3_current + a5_current - pi / 2);
             P_current[7].Y =  P_current[5].Y + Math.Cos(a6_current) * BolwtorchDeflectionX * Math.Cos(a1_current + a2_current + a3_current + a5_current + pi / 2) + Math.Sin(a6_current) * BolwtorchDeflectionZ * Math.Cos(a1_current + a2_current + a3_current + a5_current - pi / 2);
             P_current[7].Z =  P_current[5].Z + Math.Sin(a6_current) * BolwtorchDeflectionX + Math.Cos(a6_current) * BolwtorchDeflectionZ;

            return P_current;
        }
        public void CalP(float[] dpos)
        {
            //机械臂的坐标
            PointXYZ[] myPNow = new PointXYZ[8];
            myPNow = ForwardKinematics2(dpos);
            PNow[0].ConvertXYZToXYZF(myPNow[2]);
            PNow[1].ConvertXYZToXYZF(myPNow[6]);
            PNow[2].ConvertXYZToXYZF(myPNow[7]);
            PNow[3].ConvertXYZToXYZF(myPNow[5]);
        }

        public void PanelPaint(float[] dpos)
        {
            PointXYZF[] PXY = new PointXYZF[8];
            PointXYZF[] P3XY = new PointXYZF[3];
            PointXYZF[] P3XZ = new PointXYZF[3];
            //机械臂的坐标
            PointXYZ[] myPNow = new PointXYZ[8];
            //机械臂的坐标
            g.Clear(Color.White);//刷新画板
            for (int i = 0; i < 8; i++)
            {
                myPNow[i] = new PointXYZ();
                PXY[i] = new PointXYZF();
                if(i<3)
                {
                    P3XY[i] = new PointXYZF();
                    P3XZ[i] = new PointXYZF();
                }
                    
            }
            myPNow = ForwardKinematics2(dpos);
            PNow[0].ConvertXYZToXYZF(myPNow[2]);
            PNow[1].ConvertXYZToXYZF(myPNow[6]);
            PNow[2].ConvertXYZToXYZF(myPNow[7]);
            //P0 = PNow[2];
            for (int i=0; i < 8;i++)
            {
                PXY[i].X =(float)( -myPNow[i].X )/10 + P_p0.X;
                PXY[i].Y = (float)(-myPNow[i].Y )/10 + P_p0.Y;

                if(i>5)
                {
                    P3XY[i-6].X= (float)(-myPNow[i].X+ myPNow[3].X)/2  + P_p1.X;
                    P3XY[i-6].Y = (float)(-myPNow[i].Y+ myPNow[3].Y)/2   + P_p1.Y;

                    P3XZ[i - 6].X = (float)(-myPNow[i].X + myPNow[3].X)/2 + P_p2.X;
                    P3XZ[i - 6].Z = (float)(-myPNow[i].Z )/2 + P_p2.Y;
                }
            }
            g.DrawLine(p1, P_p0.X, P_p0.Y, PXY[0].X, PXY[0].Y );//在画板上画直线
            g.DrawLine(p2, PXY[0].X , PXY[0].Y , PXY[1].X, PXY[1].Y);//在画板上画直线
            g.DrawLine(p3, PXY[1].X, PXY[1].Y, PXY[2].X, PXY[2].Y);//在画板上画直线
            g.DrawLine(p4, PXY[2].X , PXY[2].Y , PXY[3].X, PXY[3].Y);//在画板上画直线
            if (ExtremityMode != 0)
            {
                g.DrawLine(p3, PXY[3].X, PXY[3].Y, PXY[4].X, PXY[4].Y);//在画板上画直线
                g.DrawLine(p4, PXY[4].X, PXY[4].Y, PXY[5].X, PXY[5].Y);//在画板上画直线

                //g.DrawLine(p4, P_p1.X, P_p1.Y, P3XY[0].X, P3XY[0].Y);//在画板上画直线
                //g.DrawLine(p4, P3XY[0].X, P3XY[0].Y, P3XY[1].X, P3XY[1].Y);//在画板上画直线

            }
            if(ExtremityMode == 1)
            {
                g.DrawLine(p5, PXY[5].X, PXY[5].Y, PXY[6].X, PXY[6].Y);//在画板上画直线

                //g.DrawLine(p5, P_p1.X, P_p1.Y, P3XY[0].X, P3XY[0].Y);//在画板上画直线

            }
            else if(ExtremityMode == 2)
            {
                g.DrawLine(p6, PXY[5].X, PXY[5].Y, PXY[7].X, PXY[7].Y);//在画板上画直线
                //g.DrawLine(p6, P_p1.X, P_p1.Y, P3XY[1].X, P3XY[1].Y);//在画板上画直线

            }
            g.DrawLine(p6, P_p2.X, P_p2.Y, P3XZ[1].X, P3XZ[1].Z);//在画板上画直线
            g.DrawLine(p5, P3XZ[0].X, P3XZ[0].Z, P_p2.X, P_p2.Y);//在画板上画直线
            g.DrawLine(p4, P3XZ[0].X, P3XZ[0].Z, P3XZ[1].X, P3XZ[1].Z);//在画板上画直线

            g.DrawLine(p6, P_p1.X, P_p1.Y, P3XY[1].X, P3XY[1].Y);//在画板上画直线
            g.DrawLine(p5, P3XY[0].X, P3XY[0].Y, P_p1.X, P_p1.Y);//在画板上画直线
            g.DrawLine(p4, P3XY[0].X, P3XY[0].Y, P3XY[1].X, P3XY[1].Y);//在画板上画直线


            g.DrawLine(pxy,0, P_p0.Y, 300, P_p0.Y);
            g.DrawLine(pxy, 0, P_p1.Y, 300, P_p1.Y);
            g.DrawLine(pxy, 0, P_p2.Y, 300, P_p2.Y);
            g.DrawLine(pxy, P_p0.X, 0, P_p0.X, P_p2.Y);

            //g.DrawLine(pyz, P_p2.X, P_p2.Y+100, P_p2.X, P_p2.Y-100);
            //g.DrawLine(pyz, P_p2.X, P_p2.Y, P_p2.X+300, P_p2.Y);

          

        }
        /// <summary>
        ///设置吹嘴和吸盘高度
        /// </summary>
        /// <param name="mymode1height">希望吸盘底面到产线间的距离</param>
        /// <param name="mymode2height">希望吹嘴底面到产线间的距离</param>
        public void SetHeight(double mymode1height, double mymode2height,double axis5zeroheight,double productionlineheight)
        {
            mode1_height=mymode1height;
            mode2_height=mymode2height;
            axis5zero_height=axis5zeroheight;
            Productionline_height=productionlineheight;
        }
        /// <summary>
        /// 设置工作空间限位
        /// </summary>
        /// <param name="XPlus">X正限位</param>
        /// <param name="XMinus">X负限位</param>
        /// <param name="YPlus">Y正限位</param>
        /// <param name="YMinus">Y负限位</param>
        public void SetWorkspaceLimit(double XPlus,double XMinus,double YPlus,double YMinus)
        {
            workspaceXMinus=XMinus;
            workspaceXPlus=XPlus;
            workspaceYMimus=YMinus;
            workspaceYPlus=YPlus;
        }
        /// <summary>
        /// 设置吸盘和吹嘴偏移量
        /// </summary>
        /// <param name="mySuctioncupDeflectionX">吸盘X偏移</param>
        /// <param name="mySuctioncupDeflectionZ">吸盘Z偏移</param>
        /// <param name="myBolwtorchDeflectionX">吹嘴X偏移</param>
        /// <param name="myBolwtorchDeflectionZ">吹嘴Z偏移</param>
        public void SetDeflection(double mySuctioncupDeflectionX,double mySuctioncupDeflectionZ, double myBolwtorchDeflectionX, double myBolwtorchDeflectionZ)
        {
            BolwtorchDeflectionX = myBolwtorchDeflectionX;
            BolwtorchDeflectionZ = myBolwtorchDeflectionZ;
            SuctioncupDeflectionX = mySuctioncupDeflectionX;
            SuctioncupDeflectionZ= mySuctioncupDeflectionZ;
        }
        /// <summary>
        /// 绝对位置标定修正
        /// </summary>
        /// <param name="myAverageDeflectionX">X方向偏移</param>
        /// <param name="myAverageDeflectionY">Y方向偏移</param>
        public void SetAbsDeflection(float myAverageDeflectionX, float myAverageDeflectionY)
        {
            AbsDeflectionX = myAverageDeflectionX;
            AbsDeflectionY = myAverageDeflectionY;
        }
        public int MoveTargetPosition2(PointXYZF PointFtarget)
        {
            bool rightInitPosi = false;
            bool leftInitPosi = false;
            //x,y定义到达坐标的位置，（mode为1则采用吸盘，为2则采用吹嘴），a1_current,a2_current,a3_current,h4_current(高度),a5_current,a6_current定义当前旋转角，a1,a2,a3,h4(高度),a5,a6定义为最终旋转角
            double x = PointFtarget.X-AbsDeflectionX, y = PointFtarget.Y- AbsDeflectionY;
            float a1_current = 0, a2_current = 0, a3_current = 0, h4_current = 0, a5_current = 0, a6_current = 0;
            double a1 = 0, a2 = 0, a3 = 0, h4 = 0, a5 = 0, a6 = 0;
            float[] poslist = { 100, 100, 100, 100, 100, 100 };//位置列表，用于移动
            int[] axislist = { 0, 1, 2, 3, 4, 5 };

            //Console.WriteLine();
            zmcaux.ZAux_Direct_GetDpos(handle, 0, ref a1_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 1, ref a2_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 2, ref a3_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 3, ref a5_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 4, ref a6_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 5, ref h4_current);


            //大、中、小臂长度myl1、myl2、myl3以及末端轴间距myl4、myl5
            double myl1 = l1, myl2 = l2, myl3 = l3, myl4 = l4, myl5 = l5;

            //定义myd1,myd2,myd3,myd4,myd5
            double myd1 = d1, myd2 = d2, myd3 = d3, myd4 = d4, myd5 = d5;

            //定义吸盘和吹嘴两个末端执行器到末端俯仰自由度的偏移量
            double myxpmypyx = SuctioncupDeflectionX, myxppyz = SuctioncupDeflectionZ, myczmypyx = BolwtorchDeflectionX, myczpyz = BolwtorchDeflectionZ;



            //定义偏移量
            double mypyx = DeflectionX, mypyy = DeflectionY, mypya = DeflectionA;
            //定义吸盘和吹嘴两个末端执行器到末端俯仰自由度的偏移量

            //定义产线所在z平面的高度
            double mycxz = Productionline_height;

            //辅助变量(x1_current,y1_current为当前大臂末端位置，pattern为运动模式：0表示无法到达，1表示在一区内，2表示在二区内。)
            //(在pattern =1的情况下l_current为中臂旋转轴心到小臂末端的距离，a_current为该线段与中臂夹角；在pattern=2的情况下，l_current为大臂旋转轴心到小臂末端的距离，a_current为该线段与大臂夹角)
            double x1_current, y1_current, pattern , l_current, a_current;
            x1_current = Math.Sin(a1_current / 180 * pi) * myl1;
            y1_current = Math.Cos(a1_current / 180 * pi) * myl1;
            //Console.WriteLine("x1_current = " + x1_current);
            //Console.WriteLine("y1_current = " + y1_current);



            //判断采用吸盘还是吹嘴
            //采用吸盘
            if (ExtremityMode == 1)
            {
                h4 = mode1_height - axis5zero_height;//mode1_height指希望吸盘底面到产线间的距离；30指升降自由度位于零点时吸盘底面到产线的距离
                if (Math.Sqrt(x * x + y * y) <= (myl1 + myl2 + myl3))
                {
                    mypyx = myxpmypyx;
                    mypyy = myl4 + myl5;
                    a5 = 0;
                    a6 = 0;
                }
                else
                {
                    mypyx = -myl5;
                    mypyy = myl4 + myxpmypyx;
                    a5 = -90;
                    a6 = 0;
                }
            }
            //采用吹嘴
            else if (ExtremityMode == 2)
            {
                h4 = mycxz - myd1 - myd2 - myd3 - myd4 - myd5 - (myczmypyx + myczpyz) / Math.Sqrt(2) + mode2_height;
                mypyx = -myl5;
                mypyy = myl4 + (myczmypyx - myczpyz) / Math.Sqrt(2) + mode2_height;
                a5 = -90;
                a6 = 45;
                //Console.WriteLine(mypyy);
            }










            //得出真实myl3
            myl3 = myl3 + mypyy;
            //判断目标点需要用哪种运动方案，方案一为无需移动大臂的情况，方案二为需要移动大臂的情况，方案0为无法到达,方案三为接近基座处可能发生干涉区域
            if ((x - x1_current) * (x - x1_current) + (y - y1_current) * (y - y1_current) <= (myl2 + myl3) * (myl2 + myl3))//判断条件尚未补全，有碰撞风险，偏移可能考虑不全面
            {
                pattern = 1;
                //Console.Write("运动方案一");
            }
            else if (x * x + y * y <= (myl1 + myl2 + myl3) * (myl1 + myl2 + myl3))
            {
                pattern = 2;
                //Console.Write("运动方案二");
            }
            else
            {
                pattern = 0;
                //Console.Write("无法到达");

                return 0;
            }
            if (Math.Sqrt(x * x + y * y) <= myl1 - myl2 + Math.Sqrt(myl3 * myl3 + mypyx * mypyx))
            {
                pattern = 3;
                //Console.Write("改为运动方案三");
            }



            //方案一的解算
            if (pattern == 1)
            {
                a1 = a1_current;
                myl3 = Math.Sqrt(myl3 * myl3 + mypyx * mypyx);
                l_current = Math.Sqrt((x - x1_current) * (x - x1_current) + (y - y1_current) * (y - y1_current));
                a_current = Math.Acos((l_current * l_current + myl2 * myl2 - myl3 * myl3) / (2 * l_current * myl2)) / pi * 180;
                mypya = Math.Asin(mypyx / myl3) / pi * 180;
                a3 = 180 - Math.Acos((myl2 * myl2 + myl3 * myl3 - l_current * l_current) / (2 * myl2 * myl3)) / pi * 180;
                //判断采用左手模式还是右手模式
                //右手模式
                if (x >= x1_current)
                {
                    //lefthand = false;
                    //Console.Write("右手模式");
                    a2 = Math.Asin((y - y1_current) / l_current) * 180 / pi + a_current - (90 - a1);
                    a2 = -a2;
                    //添加小臂偏移量
                    a3 = a3 - mypya;
                }
                //左手模式
                else
                {
                    //lefthand = true;

                    //Console.Write("左手模式");
                    a2 = a_current - (90 + a1 - Math.Asin((y - y1_current) / l_current) * 180 / pi);
                    //添加小臂偏移量
                    a3 = a3 + mypya;
                    a3 = -a3;
                }


            }

            //方案二的解算
            else if (pattern == 2)
            {
                a3 = 0;
                //辅助变量l（用于计算偏移后虚拟中小臂总长）
                double l;
                l = Math.Sqrt((myl2 + myl3) * (myl2 + myl3) + mypyx * mypyx);

                l_current = Math.Sqrt(x * x + y * y);
                a_current = Math.Acos((l_current * l_current + myl1 * myl1 - l * l) / (2 * l_current * myl1)) / pi * 180;
                mypya = Math.Asin(mypyx / l) / pi * 180;
                a2 = 180 - Math.Acos((myl1 * myl1 + l * l - l_current * l_current) / (2 * myl1 * l)) / pi * 180;
                //判断采用左手模式还是右手模式
                //右手模式
                if (x >= 0)
                {
                    //lefthand = false;

                    //Console.Write("右手模式");
                    a1 = a_current - (90 - Math.Asin(y / l_current) * 180 / pi);
                    a1 = -a1;
                    //添加中臂偏移量
                    a2 = a2 - mypya;

                }
                //左手模式
                else
                {
                    //lefthand = true;

                    //Console.Write("左手模式");
                    a1 = a_current - (90 - Math.Asin(y / l_current) * 180 / pi);
                    //添加中臂偏移量
                    a2 = a2 + mypya;
                    a2 = -a2;
                }


            }

            //方案三的解算(其中x1_current,y1_current均改为了移动后大臂末端位置)
            else if (pattern == 3)
            {
                //目标点位于靠近基座中心区域
                if (Math.Abs(x) <= Math.Sqrt(myl3 * myl3 + mypyx * mypyx) - myl2 )
                {
                    a1 = 90;
                    //lefthand = true;
                    //Console.Write("左手模式");
                    //避免与基座发生碰撞
                    if(ExtremityMode==1)
                    {
                        mypyx = -myxpmypyx;
                        myl3 = myl3 - 2 * myl5;
                        a5 = 180;
                    }


                    myl3 = Math.Sqrt(myl3 * myl3 + mypyx * mypyx);
                    x1_current = Math.Sin(a1 / 180 * pi) * myl1;
                    y1_current = Math.Cos(a1 / 180 * pi) * myl1;
                    l_current = Math.Sqrt((x - x1_current) * (x - x1_current) + (y - y1_current) * (y - y1_current));
                    a_current = Math.Acos((l_current * l_current + myl2 * myl2 - myl3 * myl3) / (2 * l_current * myl2)) / pi * 180;
                    if (Double.IsNaN(a_current))
                    {
                        a1 = 45;
                        l3 = Math.Sqrt(l3 * l3 + mypyx * mypyx);
                        x1_current = Math.Sin(a1 / 180 * pi) * l1;
                        y1_current = Math.Cos(a1 / 180 * pi) * l1;
                        l_current = Math.Sqrt((x - x1_current) * (x - x1_current) + (y - y1_current) * (y - y1_current));
                        a_current = Math.Acos((l_current * l_current + l2 * l2 - l3 * l3) / (2 * l_current * l2)) / pi * 180;
                    }
                    mypya = Math.Asin(mypyx / myl3) / pi * 180;
                    a3 = 180 - Math.Acos((myl2 * myl2 + myl3 * myl3 - l_current * l_current) / (2 * myl2 * myl3)) / pi * 180;
                    a2 = a_current - (90 + a1 - Math.Asin((y - y1_current) / l_current) * 180 / pi);
                    //添加小臂偏移量
                    a3 = a3 + mypya;
                    a3 = -a3;
                    //不可达位置判断
                    if (Double.IsNaN(a_current))
                    {
                        return 0;
                    }
                }
                //目标点位于靠近基座左侧区域
                else if (x > 0)
                {
                    a1 = 0;
                    //lefthand = false;

                    // Console.Write("右手模式");
                    myl3 = Math.Sqrt(myl3 * myl3 + mypyx * mypyx);
                    x1_current = Math.Sin(a1 / 180 * pi) * myl1;
                    y1_current = Math.Cos(a1 / 180 * pi) * myl1;
                    l_current = Math.Sqrt((x - x1_current) * (x - x1_current) + (y - y1_current) * (y - y1_current));
                    a_current = Math.Acos((l_current * l_current + myl2 * myl2 - myl3 * myl3) / (2 * l_current * myl2)) / pi * 180;
                    mypya = Math.Asin(mypyx / myl3) / pi * 180;
                    a3 = 180 - Math.Acos((myl2 * myl2 + myl3 * myl3 - l_current * l_current) / (2 * myl2 * myl3)) / pi * 180;
                    a2 = Math.Asin((y - y1_current) / l_current) * 180 / pi + a_current - (90 - a1);
                    a2 = -a2;
                    //添加小臂偏移量
                    a3 = a3 - mypya;
                }
                //目标点位于靠近基座右侧区域
                else if (x < 0)
                {
                    a1 = 0;
                    //lefthand = true;

                    // Console.Write("左手模式");
                    myl3 = Math.Sqrt(myl3 * myl3 + mypyx * mypyx);
                    x1_current = Math.Sin(a1 / 180 * pi) * myl1;
                    y1_current = Math.Cos(a1 / 180 * pi) * myl1;
                    l_current = Math.Sqrt((x - x1_current) * (x - x1_current) + (y - y1_current) * (y - y1_current));
                    a_current = Math.Acos((l_current * l_current + myl2 * myl2 - myl3 * myl3) / (2 * l_current * myl2)) / pi * 180;
                    mypya = Math.Asin(mypyx / myl3) / pi * 180;
                    a3 = 180 - Math.Acos((myl2 * myl2 + myl3 * myl3 - l_current * l_current) / (2 * myl2 * myl3)) / pi * 180;
                    a2 = a_current - (90 + a1 - Math.Asin((y - y1_current) / l_current) * 180 / pi);
                    //添加小臂偏移量
                    a3 = a3 + mypya;
                    a3 = -a3;
                }

            }






            //Console.WriteLine();
            //Console.WriteLine("大臂所需旋转角度为：" + (a1 - a1_current));
            //Console.WriteLine("中臂所需旋转角度为：" + (a2 - a2_current));
            //Console.WriteLine("小臂所需旋转角度为：" + (a3 - a3_current));
            //Console.WriteLine("升降自由度所需升降高度为：" + (h4 - h4_current));
            //Console.WriteLine("旋转自由度旋转角度为：" + (a5 - a5_current));
            //Console.WriteLine("俯仰自由度所需旋转角度为：" + (a6 - a6_current));
            //Console.WriteLine("运动后大臂角度为：" + a1);
            //Console.WriteLine("运动后中臂角度为：" + a2);
            //Console.WriteLine("运动后小臂角度为：" + a3);
            //Console.WriteLine("运动后升降自由度高度为：" + h4);
            //Console.WriteLine("运动后旋转自由度角度为：" + a5);
            //Console.WriteLine("运动后俯仰自由度角度为：" + a6);


            //判断三轴中最大的旋转角度
            double max = 0;
            if (Math.Abs(a1 - a1_current) >= Math.Abs(a2 - a2_current) && Math.Abs(a1 - a1_current) >= Math.Abs(a3 - a3_current))
            {
                max = Math.Abs(a1 - a1_current);
            }
            else if (Math.Abs(a2 - a2_current) >= Math.Abs(a1 - a1_current) && Math.Abs(a2 - a2_current) >= Math.Abs(a3 - a3_current))
            {
                max = Math.Abs(a2 - a2_current);
            }
            else if (Math.Abs(a3 - a3_current) >= Math.Abs(a1 - a1_current) && Math.Abs(a3 - a3_current) >= Math.Abs(a2 - a2_current))
            {
                max = Math.Abs(a3 - a3_current);
            }

            int k = 0;
            k = (int)Math.Floor(max / 1) + 1;



            //得出各轴所需旋转角度序列表
            //Console.WriteLine();
            //Console.WriteLine("大臂转角序列为：");
            List<double> list1 = new List<double>();
            for (int i = 1; i <= k; i++)
            {
                list1.Add((a1_current + (a1 - a1_current) / k * i));
                //Console.Write((a1_current + (a1 - a1_current) / k * i));
                //Console.Write(" ");
            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("中臂转角序列为：");
            List<double> list2 = new List<double>();
            for (int i = 1; i <= k; i++)
            {
                list2.Add((a2_current + (a2 - a2_current) / k * i));
                //Console.Write((a2_current + (a2 - a2_current) / k * i));
                //Console.Write(" ");
            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("小臂转角序列为：");
            List<double> list3 = new List<double>();
            for (int i = 1; i <= k; i++)
            {
                list3.Add((a3_current + (a3 - a3_current) / k * i));
                //Console.Write((a3_current + (a3 - a3_current) / k * i));
                //Console.Write(" ");
            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("升降自由度高度序列为：");
            List<double> list4 = new List<double>();
            for (int i = 1; i <= k; i++)
            {
                list4.Add((h4_current + (h4 - h4_current) / k * i));
                //Console.Write((h4_current + (h4 - h4_current) / k * i));
                //Console.Write(" ");
            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("旋转自由度转角序列为：");
            List<double> list5 = new List<double>();
            for (int i = 1; i <= k; i++)
            {
                list5.Add((a5_current + (a5 - a5_current) / k * i));
                //Console.Write((a5_current + (a5 - a5_current) / k * i));
                //Console.Write(" ");
            }

            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("俯仰自由度转角序列为：");
            List<double> list6 = new List<double>();
            for (int i = 1; i <= k; i++)
            {
                list6.Add((a6_current + (a6 - a6_current) / k * i));
                //Console.Write((a6_current + (a6 - a6_current) / k * i));
                //Console.Write(" ");
            }


            for (int i = 0; i < k; i++)
            {

                poslist[0] = (float)list1[i];
                poslist[1] = (float)list2[i];
                poslist[2] = (float)list3[i];
                poslist[3] = (float)list5[i];
                poslist[4] = (float)list6[i];
                poslist[5] = (float)list4[i];
                if (Isinterference(poslist))
                {

                    leftInitPosi = true;

                }

            }
            int[] anis12 = { 0, 1, 2 };

            if (leftInitPosi)
            {
                list1.Clear();
                list2.Clear();
                list3.Clear();

                for (int i = 1; i <= k; i++)
                {
                    list1.Add((a1_current + (90 - a1_current) / k * i));
                    list2.Add((a2_current + (-180 - a2_current) / k * i));
                    list3.Add((a3_current + (180 - a3_current) / k * i));
                }


                for (int i = 0; i < k; i++)
                {
                    poslist[0] = (float)list1[i];
                    poslist[1] = (float)list2[i];
                    poslist[2] = (float)list3[i];

                    if (Isinterference(poslist))
                    {

                        rightInitPosi = true;

                    }


                }
                if (rightInitPosi)
                {
                    list1.Clear();
                    list2.Clear();
                    list3.Clear();
                    for (int i = 1; i <= k; i++)
                    {
                        list1.Add((a1_current + ((-90) - a1_current) / k * i));
                        list2.Add((a2_current + ((180) - a2_current) / k * i));
                        list3.Add((a3_current + ((-180) - a3_current) / k * i));
                    }
                    for (int i = 0; i < k; i++)
                    {
                        poslist[0] = (float)list1[i];
                        poslist[1] = (float)list2[i];
                        poslist[2] = (float)list3[i];

                        if (Isinterference(poslist))
                        {

                            return 0;
                        }


                    }

                        poslist[0] = (float)list1[k-1];
                        poslist[1] = (float)list2[k-1];
                        poslist[2] = (float)list3[k-1];
                        zmcaux.ZAux_Direct_MoveAbs(handle, 3, anis12, poslist);

                    

                    return 2;
                }


                    poslist[0] = (float)list1[k-1];
                    poslist[1] = (float)list2[k-1];
                    poslist[2] = (float)list3[k-1];
                    zmcaux.ZAux_Direct_MoveAbs(handle, 3, anis12, poslist);

                return 2;
            }




            poslist[0] = (float)list1[k - 1];
            poslist[1] = (float)list2[k - 1];
            poslist[2] = (float)list3[k - 1];
            poslist[3] = (float)list5[k - 1];
            zmcaux.ZAux_Direct_MoveAbs(handle, 4, axislist, poslist);
            return 1;





        }
        /// <summary>
        /// 判断是否会碰撞
        /// </summary>
        /// <param name="poslist"></param>
        /// <returns></returns>
        public bool Isinterference(float[] poslist)
        {
            if (ForwardKinematics2(poslist)[5].X > workspaceXPlus || ForwardKinematics2(poslist)[5].X < workspaceXMinus || (ForwardKinematics2(poslist)[5].Y <= workspaceYMimus) || (ForwardKinematics2(poslist)[5].Y >= workspaceYPlus))
            {

                return true;
            }
            return false;
        }

        public int MoveInitStstus()
        {
            float a1_current = 0, a2_current = 0, a3_current = 0,h4_current, a5_current = 0, a6_current = 0;
            double a1 = 90, a2 = -180, a3 = 180, h4 = 0, a5 = 0, a6 = 0;
            float[] poslist = { 100, 100, 100, 0, 0, 0 };//位置列表，用于移动
            int[] axislist = { 0, 1, 2, 3, 4, 5 };
            bool myrightInitPosi = false;

            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            List<double> list3 = new List<double>();
            List<double> list4 = new List<double>();

            zmcaux.ZAux_Direct_GetDpos(handle, 0, ref a1_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 1, ref a2_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 2, ref a3_current);
            zmcaux.ZAux_Direct_GetDpos(handle, 3, ref a5_current);
            //判断三轴中最大的旋转角度
            double max = 0;
            if (Math.Abs(a1 - a1_current) >= Math.Abs(a2 - a2_current) && Math.Abs(a1 - a1_current) >= Math.Abs(a3 - a3_current))
            {
                max = Math.Abs(a1 - a1_current);
            }
            else if (Math.Abs(a2 - a2_current) >= Math.Abs(a1 - a1_current) && Math.Abs(a2 - a2_current) >= Math.Abs(a3 - a3_current))
            {
                max = Math.Abs(a2 - a2_current);
            }
            else if (Math.Abs(a3 - a3_current) >= Math.Abs(a1 - a1_current) && Math.Abs(a3 - a3_current) >= Math.Abs(a2 - a2_current))
            {
                max = Math.Abs(a3 - a3_current);
            }
            int k = 0;
            k = (int)Math.Floor(max / 5) + 1;
            for (int i = 1; i <= k; i++)
            {
                list1.Add((a1_current + (90 - a1_current) / k * i));
                list2.Add((a2_current + (-180 - a2_current) / k * i));
                list3.Add((a3_current + (180 - a3_current) / k * i));
                list4.Add((a5_current + (0 - a5_current) / k * i));
            }


            for (int i = 0; i < k; i++)
            {
                poslist[0] = (float)list1[i];
                poslist[1] = (float)list2[i];
                poslist[2] = (float)list3[i];
                if (Isinterference(poslist))
                {

                    myrightInitPosi = true;
                }

            }


            if (myrightInitPosi)
            {
                list1.Clear();
                list2.Clear();
                list3.Clear();
                for (int i = 1; i <= k; i++)
                {
                    list1.Add((a1_current + ((-90) - a1_current) / k * i));
                    list2.Add((a2_current + ((180) - a2_current) / k * i));
                    list3.Add((a3_current + ((-180) - a3_current) / k * i));
                }
                for (int i = 0; i < k; i++)
                {
                    poslist[0] = (float)list1[i];
                    poslist[1] = (float)list2[i];
                    poslist[2] = (float)list3[i];

                    if (Isinterference(poslist))
                    {

                        return 0;
                    }


                }


            }

                poslist[0] = (float)list1[k-1];
                poslist[1] = (float)list2[k - 1];
                poslist[2] = (float)list3[k - 1];
                poslist[3] = (float)list4[k - 1];
                zmcaux.ZAux_Direct_MoveAbs(handle, 4, axislist, poslist);

            
            return 1;


        }


        /// <summary>
        /// 创建画板
        /// </summary>
        /// <param name="q">panel的name</param>
        public void PanelCreat(Panel q)
        {
            g = q.CreateGraphics(); //创建画板,这里的画板是由panel提供的.
            p1 = new Pen(Color.Black, 4);//大臂
            p2 = new Pen(Color.Red, 3);//中臂
            p3 = new Pen(Color.Green, 2);//小臂
            p4 = new Pen(Color.Black, 3);//大臂
            p5 = new Pen(Color.Red, 2);//中臂
            p6 = new Pen(Color.Green, 2);//小臂
            pxy =new Pen(Color.Blue, 1);//坐标轴
            pyz =new Pen(Color.DeepPink, 1);//yz轴
        }
        public void MergeChange()
        {
            for (int i = 0; i < 6; i++)
                zmcaux.ZAux_Direct_SetMerge(handle, i, 1);


        }

        /// <summary>
        ///移动到零点 
        /// </summary>
        /// <param name="n"></param>
        public void MoveZero(int n)
        {
            int[]naxis = new int[1];
            float[]Dpos = new float[1];
            naxis[0] = n;
            Dpos[0] = 0;
            zmcaux.ZAux_Direct_MoveAbs(handle, 1, naxis, Dpos);
        }
        /// <summary>
        /// 移动到初始位置
        /// </summary>
        /// <param name="n"></param>
        /// <param name="p"></param>
        public void MoveInit(int n,float p)
        {
            int[] naxis = new int[1];
            float[] Dpos = new float[1];
            naxis[0] = n;
            Dpos[0] = p;
            zmcaux.ZAux_Direct_MoveAbs(handle, 1, naxis, Dpos);
        }
        /// <summary>
        /// Z轴运动到希望位置mode1_height-axis5zero_height位置
        /// </summary>
        public void AnixZHeight()
        {
            int[] naxis = new int[1];
            float[] Dpos = new float[1];
            naxis[0] = 5;
            Dpos[0] =(float)( mode1_height-axis5zero_height);
            zmcaux.ZAux_Direct_MoveAbs(handle, 1, naxis, Dpos);
        }
        /// <summary>
        /// 所有轴移动到初始点
        /// </summary>
        /// <param name="Dpos"></param>
        public void MoveAllInit(float[] Dpos)
        {
            int[] naxis = new int[6] { 0, 1, 2, 3, 4, 5 };
            zmcaux.ZAux_Direct_MoveAbs(handle, 6, naxis, Dpos);
        }
        /// <summary>
        /// 所有轴移动到0点
        /// </summary>
        public void MoveAllZero()
        {
            int[] naxis = new int[6] { 0,1,2,3,4,5};
            float[] Dpos = new float[6] { 0,0,0,0,0,0};
            
            zmcaux.ZAux_Direct_MoveAbs(handle, 6, naxis, Dpos);
        }

        public void SetEnable()
        {
            for(int i = 0;i< 6; i++)
            {
                zmcaux.ZAux_Direct_SetAxisEnable(handle, i, 1);
            }
        }
        public void ResetEnable()
        {
            for (int i = 0; i < 6; i++)
            {
                zmcaux.ZAux_Direct_SetAxisEnable(handle, i, 0);
            }
        }
        /// <summary>
        /// 不使用末端mode=0,吸盘mode=1，吹嘴mode=2
        /// </summary>
        /// <returns></returns>
        public int GetExtremityMode()
        {
            return ExtremityMode;
        }

        /// <summary>
        /// 获取轴的mType
        /// </summary>
        /// <param name="n">轴号</param>
        /// <returns></returns>
        public bool GetMType(int n,ref AxisMType amt)
        {
            if (!GetCnctSts())
                return false;
            int mt = 0;
            if(0 ==zmcaux.ZAux_Direct_GetMtype(handle, n, ref mt))
            {
                amt= (AxisMType)mt;
                return true;
            }
            return false;
        }
        /// <summary>
        /// 设置IO口，吸盘，吹嘴，急停
        /// </summary>
        /// <param name="suctioncup"></param>
        /// <param name="bolwtorch"></param>
        /// <param name="emstop"></param>
        public void SetIO(int suctioncup,int bolwtorch,int emstop)
        {
            SuctioncupIO = suctioncup;
            BolwtorchIO=bolwtorch;
            emstopIO=emstop;
        }
        public PointXYZF GetP_3() { return PNow[0]; }
        public PointXYZF GetP_5() { return PNow[3]; }
        public PointXYZF GetP_Suctioncup() { return PNow[1]; }
        public PointXYZF GetP_Bolwtorch() { return PNow[2]; }
        public PointXYZF GetP_mode() 
        {
            switch(ExtremityMode)
            {
                case 0:
                    return GetP_3();
                case 1:
                    return GetP_Suctioncup();
                case 2:
                    return GetP_Bolwtorch();
            }
            return GetP_3();
        }

        private void CycGetDataFromZM()
        {
            CycAxisSts[] allAxisData = new CycAxisSts[6]{
                new CycAxisSts(),new CycAxisSts(),new CycAxisSts(),
                new CycAxisSts(),new CycAxisSts(),new CycAxisSts()};
            //连接
            while(true)
            {
                if (!GetCnctSts())
                    continue;

                //在连接状态下定时获取数据
                for (int i = 0; i < allAxisData.Length; i++)
                {
                    GetAxisPosi(i, ref allAxisData[i].posi);
                    GetAxisStatus(i, ref allAxisData[i].sts);
                    GetAxisFsLimit(i, ref allAxisData[i].fs_limit);
                    GetAxisRsLimit(i, ref allAxisData[i].rs_limit);
                    GetMType(i, ref allAxisData[i].mtype);
                }
                CallBackFc?.Invoke(this, allAxisData);
                //sleep;
                Thread.Sleep(100);
            }
        }

    }

    

    public enum AxisSatus : int
    {
        /// <summary>
        /// 轴的状态正常
        /// </summary>
        NoError = 0,
        /// <summary>
        /// 轴正限位报警
        /// </summary>
        FlimitError = 1,
        /// <summary>
        /// 轴负限位报警
        /// </summary>
        BlimitError = 2,
        /// <summary>
        /// 轴伺服报警
        /// </summary>
        ServoError = 3
    }

    public enum CnctType : int
    {
        /// <summary>
        /// COM连接
        /// </summary>
        COM = 1,
        /// <summary>
        /// Ethernet连接
        /// </summary>
        ETH = 2,
        /// <summary>
        /// PCI连接
        /// </summary>
        PCI = 4,
        /// <summary>
        /// RTMotion
        /// </summary>
        MotionRT = 5
    }
    public enum MoveMode : int
    {
        /// <summary>
        /// 正向运行
        /// </summary>
        Forward = 1,
        /// <summary>
        /// 反向运动
        /// </summary>
        Backword = -1,
        /// <summary>
        /// 停止或取消运动
        /// </summary>
        Cancel = 2
    }
    public enum AxisMType : int
    {
        Idle = 0,     //没有运动
        Move = 1,     //单轴直线或者插补直线运动
        MoveAbs = 2,  //绝对值单轴直线或者绝对插补直线运动
        MheliCal = 3, //圆心螺旋运动
        MoveCirc =4,  // 圆弧插补
        MoveModify = 5,// 修改运动位置
        MoveSp =6,      // SP速度的单轴直线或者SP速度的插补直线运动
        MoveAbsSp =7,   //SP速度的绝对值单轴直线/SP速度的绝对插补直线运动
        MoveCircSp =8,  //SP速度的圆弧插补
        MheliCalSp =9,  //SP速度的圆心螺旋运动
        ForwardVmove =10,//正向持续运动
        ReverseVmove =11, //负向持续运动
        DatuMing =12,    //回零运动中
        Cam =13,         //凸轮表运动
        FWD_Jog =14,     //映射正向JOG运动
        REV_Jog =15,     //映射负向JOG运动
        Cam_Box =20,     //跟随凸轮表运动
        Connect =21,     //同步运动
        MoveLink =22,     //自动凸轮运动
        ConnPath =23,      //同步运动2，矢量类型的
        MoveSLink =25,     //自动凸轮运动2
        MoveSpiRal =26,     //渐开线圆弧
        Meclpse =27,      //椭圆运动
        Move_Aout =28,    //缓冲IO/缓冲寄存器操作等
        Move_Delay =29, //  缓冲延时
        MspheriCal =31,  //空间圆弧
        Move_PT = 32,   //单位时间内运动距离
        ConnFRame =33,   // 机械手逆解运动
        ConnRefRame = 34,  //机械手正解运动
        EactCycle=65 //ECAT周期位置模式，需支持EtherCAT
    }
    public class AxisParam
    {
        public AxisParam(int n)
        {
            Num = n;
        }
        /// <summary>
        /// 轴号
        /// </summary>
        public int Num;
        /// <summary>
        /// 脉冲当量
        /// </summary>
        public float Units;
        /// <summary>
        /// 速度
        /// </summary>
        public float Speed;
        /// <summary>
        /// 正向加速度
        /// </summary>
        public float Accel;
        /// <summary>
        /// 反向加速度
        /// </summary>
        public float Decel;
        /// <summary>
        /// 正限位
        /// </summary>
        public float FsLimit;
        /// <summary>
        /// 负限位
        /// </summary>
        public float RsLimit;
        /// <summary>
        /// 初始化位置
        /// </summary>
        public float Init;
        /// <summary>
        /// 轴状态
        /// </summary>
        public int Type;

    }


    public class CycAxisSts: EventArgs
    {
        public CycAxisSts(float p, AxisSatus s, float f, float r, AxisMType mt)
        {
            posi = p;
            sts = s;
            fs_limit = f;
            rs_limit = r;
            mtype = mt;
        }
        public CycAxisSts()
        {

        }
        /// <summary>
        /// 轴的当前位置
        /// </summary>
        public float posi;
        /// <summary>
        /// 轴的状态
        /// </summary>
        public AxisSatus sts;
        /// <summary>
        /// 轴的正限位
        /// </summary>
        public float fs_limit;
        /// <summary>
        /// 轴的负限位
        /// </summary>
        public float rs_limit;
        /// <summary>
        /// 轴的mType
        /// </summary>
        public AxisMType mtype;
        /// <summary>
        /// 轴的力矩
        /// </summary>
        public int DriveTorque;
    }
    public class PointXYZ
    {
        public double X;
        public double Y;
        public double Z;
        public PointXYZ(double x,double y,double z)
        {
            X = x; Y=y; Z=z;
        }
        public PointXYZ()
        {
            X = 0; Y = 0; Z = 0;
        }

    }
    public class PointXYZF
    {
        public float X;
        public float Y;
        public float Z;
        public PointXYZF(float x, float y, float z)
        {
            X = x; Y = y; Z = z;
        }
        public PointXYZF()
        {
            X = 0; Y = 0; Z = 0;
        }
        public void  ConvertXYZToXYZF(PointXYZ point)
        {
            X = (float)point.X;
            Y = (float)point.Y;
            Z=(float)point.Z;
        }

    }
}
