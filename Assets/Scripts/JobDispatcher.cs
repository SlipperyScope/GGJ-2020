using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public enum Location { Downtown, Beaverton, Lents, Ladd}

public class JobDispatcher : MonoBehaviour
{
    [Header("Config")]
    [Tooltip("Time until first mission is dispatched")]
    [Range(0f, 60f)]
    public float StartDelay = 10f;

    [Tooltip("Time until next mission is dispatched after mission complete")]
    [Range(0f, 60f)]
    public float DispatchDelay = 5f;

    public GameObject[] Steves;
    

    public GameObject CurrentJob { get; private set; }

    private bool ReadyForDispatch = false;
    private Coroutine DelayCoroutineRef;

    #region Events

    public event EventHandler<JobDispatchedEventArgs> JobDispatched;
    private void OnJobDispatched(JobDispatchedEventArgs e)
    {
        EventHandler<JobDispatchedEventArgs> handler = JobDispatched;
        handler?.Invoke(this, e);
    } 

    #endregion

    /// <summary>
    /// Start
    /// </summary>
    private void Start()
    {
        DelayCoroutineRef = StartCoroutine(DelayDispatch(StartDelay));
    }

    /// <summary>
    /// Update
    /// </summary>
    private void Update()
    {
        if (ReadyForDispatch == true)
        {
            DispatchJob();
        }
    }

    /// <summary>
    /// Dispatch Mission
    /// </summary>
    private void DispatchJob()
    {
        ReadyForDispatch = false;

        var NewJob = Instantiate(GetRandomJob());
        CurrentJob = NewJob;
        CurrentJob.GetComponent<Job>().JobCompleted += KillCompletedJob;
        OnJobDispatched(new JobDispatchedEventArgs(NewJob));
    }

    private void KillCompletedJob(object sender, EventArgs e)
    {
        Destroy(CurrentJob);
        StartCoroutine(WaitThenNextLevel());
    }

    private IEnumerator WaitThenNextLevel()
    {
        yield return new WaitForSeconds(DispatchDelay);
        DispatchJob();
    }

    /// <summary>
    /// Delay Dispatch
    /// </summary>
    /// <param name="Seconds"></param>
    /// <returns></returns>
    private IEnumerator DelayDispatch(float Seconds)
    {
        yield return new WaitForSeconds(Seconds);
        ReadyForDispatch = true;
    }

    private GameObject GetRandomJob()
    {
        int index = UnityEngine.Random.Range(0, Steves.Length);
        return Steves[index];
    }
}
