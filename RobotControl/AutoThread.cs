using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotControl
{
    public class AutoThread
    {
        Thread th_worker;
        Action _fcn;
        string _name;

        public AutoThread(Action fcn)
        {

            _fcn = fcn;

            th_worker = new Thread(new ThreadStart(_fcn));
            th_worker.IsBackground = true;
            th_worker.Start();
        }
        public AutoThread(Action fcn,string name)
        {

            _fcn = fcn;
            _name = name;
            th_worker = new Thread(new ThreadStart(_fcn));
            th_worker.Name = _name;
            th_worker.IsBackground = true;
            th_worker.Start();
        }
        public void CancelThread()
        {
            if (th_worker != null)
            {
                th_worker.Abort();
                th_worker = null;
            }
        }
        public void RestartThread()
        {

            CancelThread();

            th_worker = new Thread(new ThreadStart(_fcn));
            th_worker.Name = _name;
            th_worker.IsBackground = true;
            th_worker.Start();
        }

        public void StartThread()
        {
            if (th_worker != null)
                return;

            th_worker = new Thread(new ThreadStart(_fcn));
            th_worker.Name = _name;
            th_worker.IsBackground = true;
            th_worker.Start();
        }

        ~AutoThread()
        {
            CancelThread();
        }
    }
}
