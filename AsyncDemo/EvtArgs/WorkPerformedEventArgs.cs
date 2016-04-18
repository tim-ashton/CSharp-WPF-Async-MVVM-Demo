using System;

namespace AsyncDemo.EvtArgs
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public WorkPerformedEventArgs(string data)
        {
            Data = data;
        }

        public string Data { get; set; }  
    }
}
