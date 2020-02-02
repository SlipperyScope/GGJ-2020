﻿using System;
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

    [Tooltip("Scoring tools for the job and their score\nUnspecified tool will default to a score of 0")]
    public ToolScorePair[] Tools;

    #region Events

    public event EventHandler JobCompleted;
    private void OnJobCompleted(JobCompletedEventArgs e)
    {
        EventHandler Handler = JobCompleted;
        Handler?.Invoke(this, e);
    }

    public event EventHandler JobsiteReached;
    private void OnJobsiteReached(EventArgs e)
    {
        EventHandler Handler = JobsiteReached;
        Handler?.Invoke(this, e);
    }

    #endregion

    /// <summary>
    /// On Trigger Enter
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger: " + collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            OnJobsiteReached(new EventArgs());
        }
    }
}