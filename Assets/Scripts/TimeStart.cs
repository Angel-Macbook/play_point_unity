using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;

public class TimeStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Hours;
    public Text Minute;
    public Text Second;

    private float TimeHours;
    private float TimeMinute;
    private float TimeFoolSecond  = 3600;
    private float TimeSecond;
    void Start()
    {
        TimeSecond = TimeFoolSecond;
        TimeHours = Mathf.Round(TimeSecond / 3600);
        TimeSecond -= TimeHours * 3600;
        TimeMinute = Mathf.Round(TimeSecond / 60);
        TimeSecond -= TimeMinute * 60;
    }

    // Update is called once per frame
    void Update()
    {
        Text hours = Hours.GetComponent<Text>();
        Text minute = Minute.GetComponent<Text>();
        Text second = Second.GetComponent<Text>();
        TimeSecond -= Time.deltaTime;
        if (TimeSecond <= 0)
        {
            TimeSecond = 59;
            if (TimeMinute >= 1)
            {
                TimeMinute -= 1;
                minute.text = TimeMinute.ToString();
            }
            else
            {
                TimeMinute = 59;
                TimeHours -= 1;
                hours.text = TimeHours.ToString();
            }
        }
        second.text = Mathf.Round(TimeSecond).ToString();
        hours.text = TimeHours.ToString();
        minute.text = TimeMinute.ToString();

    }
}
