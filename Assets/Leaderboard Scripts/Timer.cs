using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TextMeshProUGUI text;
    private DateTime _time;
    private DateTime _end;
    private bool ended = false;
    public static TimeSpan lastTimeSpan;

    void Start()
    {
        this._time = DateTime.Now;
    }

    // Update is called once per frame
    void Update()
    {
        this.text.text = ((this.ended ? this._end : DateTime.Now) - this._time).ToString();
    }

    public void Stop()
    {
        this.ended = true;
        this._end = DateTime.Now;
        lastTimeSpan = this._end - this._time;
    }
}