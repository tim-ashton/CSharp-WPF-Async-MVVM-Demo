using AsyncDemo.EvtArgs;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo.Data
{
    public class AsyncDemoHelper
    {
        /// <summary>
        /// Event handler to route arguments to any listeners 
        /// </summary>
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;

        /// <summary>
        /// The main helper async task that does things.
        /// </summary>
        /// <returns>The returned string from subtasks</returns>
        public async Task<string> DoStuffAsync()
        {
            // call into the slow task 
            // You can see this is the last thing to be shown in the output in the listbox
            string stringFromSlowTask = await SlowTask();

            // return the string from the slow task
            return stringFromSlowTask;
        }

        /// <summary>
        /// Loop and execute the OnWorkPerformed each time work is performed.
        /// </summary>
        /// <returns></returns>
        private async Task DoLongRunningTaskWithCallbacks()
        {
            Action loopForAWhile = delegate ()
            {
                for (int i = 0; i < 5; i++)
                {
                    OnWorkPerformed(string.Format("Hello #{0} from task loop!", i));

                    Thread.Sleep(500);
                }
            };
            await Task.Run(loopForAWhile);
        }


        /// <summary>
        /// Callback fired to send data back to the viewmodel
        /// </summary>
        /// <param name="data">The string being sent in the callback</param>
        private void OnWorkPerformed(string data)
        {
            if (WorkPerformed != null)
            {
                WorkPerformed(this, new WorkPerformedEventArgs(data));
            }
        }

        /// <summary>
        /// Slow task that has a subtask.
        /// </summary>
        /// <returns>Completed message</returns>
        private async Task<string> SlowTask()
        {
            // keep calling back with updates. This calls back to viewmodel and updates
            // the output each tome it loops
            await DoLongRunningTaskWithCallbacks();

            await Task.Delay(5000);

            // This string returns back to the user interface after completion
            return "Really slow task completed!";
        }
    }
}
