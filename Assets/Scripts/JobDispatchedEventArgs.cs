using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class JobDispatchedEventArgs : EventArgs
{
    /// <summary>
    /// Mission that was dispatched
    /// </summary>
    public readonly GameObject Job;

    public JobDispatchedEventArgs(GameObject Job)
    {
       this.Job = Job;
    }
}
