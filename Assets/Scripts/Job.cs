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

    [Header("Config")]
    [Tooltip("This thing you need to interact with to finisht the job")]
    public GameObject Objective;

    [Tooltip("The person who ejactulates the job description")]
    public GameObject Client;

    [Tooltip("Job text")]
    public string blurb = "My name is A'dumb!";

    [Tooltip("")]
    public ToolScorePair[] Tools;

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

[System.Serializable]
public class ToolScorePair
{
    [SerializeField]
    public enum Tools { Dick, Cock}
    public Tools Tool;
    public float Value;
}