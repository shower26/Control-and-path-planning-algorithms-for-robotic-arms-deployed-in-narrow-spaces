using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotControl
{
    /// <summary>
    /// 定义机械臂的状态机
    /// </summary>
    public class FiniteStateMachine
    {
        //public enum States { Init, Ready, Run, Finished };
        //public States State { get; set; }

        //public enum Events { Standby, StartRun, Compl, NextCyc };

        //private Action[,] fsm;

        //public FiniteStateMachine()
        //{
        //    this.fsm = new Action[3, 4] { 
        //        //PlugIn,       TurnOn,                 TurnOff,            RemovePower
        //        {this.PowerOn,  null,                   null,               null},              //start
        //        {null,          this.StandbyWhenOff,    null,               this.PowerOff},     //standby
        //        {null,          null,                   this.StandbyWhenOn, this.PowerOff} };   //on
        //}
        //public void ProcessEvent(Events theEvent)
        //{
        //    this.fsm[(int)this.State, (int)theEvent].Invoke();
        //}

        //private void PowerOn() { this.State = States.Standby; }
        //private void PowerOff() { this.State = States.Start; }
        //private void StandbyWhenOn() { this.State = States.Standby; }
        //private void StandbyWhenOff() { this.State = States.On; }
    }
}
