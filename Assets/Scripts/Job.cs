using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Job : MonoBehaviour
{
    /// <summary>
    /// Time the Job started
    /// </summary>
    public float StartTime { get; }

    /// <summary>
    /// Location of the Job
    /// </summary>
    public Vector2 Jobsite { get; }

    //TODO: make person object
    /// <summary>
    /// The thing you need to interact with the finish the job
    /// </summary>
    public object JobObjective { get; }

    /// <summary>
    /// Person who ejaculates the mission text when you come close
    /// </summary>
    public object Client { get; }

    /// <summary>
    /// Client's message text
    /// </summary>
    public string Blurb { get; } = "My name is A-dumb!";

    public object SolutionTool { get; }

    #region Events

    /// <summary>
    /// Called when a Job has been completed
    /// </summary>
    public event EventHandler JobCompleted;
    private void OnJobCompleted(JobCompletedEventArgs e)
    {
        EventHandler Handler = JobCompleted;
        Handler?.Invoke(this, e);
    }

    #endregion

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="Time"></param>
    public Job(float Time)
    {
        StartTime = Time;
    }
}
