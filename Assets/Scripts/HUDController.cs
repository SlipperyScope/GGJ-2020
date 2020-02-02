using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Color IdleColor;
    public Color RunningColor;

    private float refTime = 0;
    private bool timerIsRunning = false;
    private Text timerText;
    void Start()
    {
        this.timerText = GameObject.Find("Timer").GetComponent<Text>();
        this.timerText.text = "0:00";
        this.timerText.color = IdleColor;
        StartCoroutine(TestTheTimers());
    }

    // Update is called once per frame
    void Update()
    {
        if (this.timerIsRunning) {
            this.timerText.text = this.FormattedTime();
        }
    }

    IEnumerator TestTheTimers() {
        yield return new WaitForSeconds(2);
        this.StartTimer(Time.time);
        yield return new WaitForSeconds(6.3f);
        this.StopTimer();
    }

    public void StartTimer(float time)
    {
        this.refTime = time;
        this.timerIsRunning = true;
        this.timerText.color = RunningColor;
    }

    public float StopTimer() {
        this.timerIsRunning = false;
        float duration = Time.time - this.refTime;
        StartCoroutine(StopAnimation());
        return duration;
    }

    IEnumerator StopAnimation()
    {
        var originalColor = this.timerText.color;
        for (int i = 0; i < 4; i++)
        {
            var flashTime = 0.3f;
            this.timerText.color = Color.clear;
            yield return new WaitForSeconds(flashTime);
            this.timerText.color = originalColor;
            yield return new WaitForSeconds(flashTime);
        }
        this.refTime = 0;
        this.timerText.text = "0:00"; 
        this.timerText.color = IdleColor;
    }

    string FormattedTime()
    {
        float duration = Time.time - this.refTime;
        var span = new TimeSpan(0, 0, 0, (int)duration);

        if (span.Hours > 0) {
            return $"{span.Hours}:{pad(span.Minutes)}:{pad(span.Seconds)}";
        }
        return $"{span.Minutes}:{pad(span.Seconds)}.{pad((int)((duration % 1)*100))}";
    }

    string pad(int number) {
        return number < 10 ? $"0{number}" : number.ToString();
    }
}
