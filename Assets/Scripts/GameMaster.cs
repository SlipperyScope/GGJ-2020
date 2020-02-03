using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(JobDispatcher))]
public class GameMaster : MonoBehaviour
{
    [Header("Player")]
    public GameObject Player;

    public GameObject Van;
    public GameObject Driver;

    [Header("Other")]
    public GameObject HUD;
    public GameObject Map;
    public GameObject CurrentJob { get; private set; }
    public Job CurrentJobScript { get; private set; }

    public PlayerController Controller { get; private set; }
    public JobDispatcher Dispatcher { get; private set; }

    /// <summary>
    /// Awake
    /// </summary>
    private void Awake()
    {
        if (Player is null)
            throw new MissingReferenceException("You forgot to set the player");
        if (Van is null)
            throw new MissingReferenceException("You forgot to set the Van");
        if (Driver is null)
            throw new MissingReferenceException("You forgot to set the Driver");
        if (HUD is null)
            throw new MissingReferenceException("You forgot to set the HUD");
        if (Map is null)
            throw new MissingReferenceException("You forgot to set the Map");

        Controller = Player.GetComponent<PlayerController>();
        Dispatcher = GetComponent<JobDispatcher>();

        Dispatcher.JobDispatched += JobDispatched;
        
    }

    private void JobDispatched(object sender, JobDispatchedEventArgs e)
    {
        CurrentJob = e.Job;
        HUD.GetComponent<HUDController>().Destination = CurrentJob.GetComponent<Job>().Client;

        CurrentJobScript = CurrentJob.GetComponent<Job>();
        CurrentJobScript.JobsiteReached += JobSiteReached;
        CurrentJobScript.JobCompleted += JobComplete;

        HUD.GetComponent<HUDController>().StartTimer(Time.time);
    }

    private void JobComplete(object sender, EventArgs e)
    {
        Controller.SwitchToInCar();
    }

    private void JobSiteReached(object sender, EventArgs e)
    {
        Controller.SwitchToOnFoot();
        var controller = HUD.GetComponent<HUDController>();
        controller.StopTimer();
        controller.ShowToolbox();
        
    }

    
}
