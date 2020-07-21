using System.Threading;
using System.Timers;

namespace RabbitMQ.TopShelf
{
    public class MyService
    {
        #region prop
        readonly System.Timers.Timer _timer;
        Thread TestThread;
        bool TestEnabled;
        #endregion

        #region ctor
        public MyService()
        {
            var jobInterval = KeyConfig.WindowsServiceTimerIntervalMinutes;
            _timer = new System.Timers.Timer(1000 * 60 * jobInterval ) { AutoReset = true };
            _timer.Elapsed += new ElapsedEventHandler(this.ServiceTimer_Tick);

            TestEnabled = KeyConfig.TestEnabled;
        }
        #endregion

        #region Timer Event
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); } 
        #endregion

        #region Check and Start Thread
        public void ServiceTimer_Tick(object sender, ElapsedEventArgs e)
        {
            if (TestEnabled && (TestThread == null || !TestThread.IsAlive))
            {
                TestThread = new Thread(new ThreadStart(TestThreadMethod));
                TestThread.Start();
            }

        }
        #endregion

        #region Method to execute
        void TestThreadMethod()
        {
            //Your Code
            //Console.WriteLine("This is ${" + TestThread.IsAlive + "}");
        } 
        #endregion
    }
}
