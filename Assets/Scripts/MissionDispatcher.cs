using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionDispatcher : MonoBehaviour
{
    [Header("Config")]
    [Tooltip("Time until first mission is dispatched")]
    [Range(0f, 300f)]
    public float StartDelay = 10f;

    [Tooltip("Time until next mission is dispatched after mission complete")]
    [Range(0f, 300f)]
    public float DispatchDelay = 5f;

    private bool ReadyForDispatch = false;
    private Coroutine DelayCoroutineRef;

    public event EventHandler MissionDispatched;
    private void OnMissionDispatched(MissionDispatchedEventArgs e)
    {
        EventHandler handler = MissionDispatched;
        handler?.Invoke(this, e);
    }

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

        }
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
}
