using System.Collections;
using TMPro;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Timer : Singleton<Timer>
{
    [SerializeField] private TMP_Text timer_ui;
    [SerializeField] private string format = @"mm\:ss";
    [Multiline]
    [SerializeField] private string template = "Time: {1}s";
    private bool _isActive = false;
    private TimeSpan _timer = TimeSpan.Zero;
    private DateTime _since = new DateTime();

    private void Update()
    {
        if (_isActive)
        {
            _timer = DateTime.Now - _since;
        }
        Render();
    }

    public void Begin()
    {
        _since = DateTime.Now;
        _isActive = true;
        Debug.LogWarning(string.Format("Timer has started at {0}", _since));
    }

    public void Stop()
    {
        _isActive = false;
    }

    public void Resume()
    {
        _isActive = true;
    }

    public void Reset()
    {
        _timer = TimeSpan.Zero;
        _isActive = false;
    }

    public void Render()
    {
        string rendered = string.Format(template, _timer.Milliseconds, _timer.Seconds, _timer.Minutes, _timer.Hours, _timer.Days);
        if(timer_ui != null )
        {
            timer_ui.text = rendered;
        }
        Debug.Log(rendered);
    }
}
