using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class JobDispatchedEventArgs : EventArgs
{
    /// <summary>
    /// Mission that was dispatched
    /// </summary>
    public readonly Job Job;

    public JobDispatchedEventArgs(Job Job)
    {
        this.Job = Job;
    }
}
