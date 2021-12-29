using System;
using UnityEngine;
using Controller;
using UnityEngine.UI;

public class TimeStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Hours;
    public Text Minute;
    public Text Second;
    private Text hours;
    private Text minute;
    private Text second;

    private float TimeHours;
    private float TimeMinute;
    private float TimeFoolSecond;
    private bool CheckStart = false;
    private float TimeSecond;

    private TimeStartJsonResult dataElem;

    public Transform windowParent;
    public GameObject authPrefab;

    private int operators = 1;

    public Button yourButton;

    private string url = "https://it-scholar.000webhostapp.com/post/time_start_url.php";

    void Awake()
    {
        hours = Hours.GetComponent<Text>();
        minute = Minute.GetComponent<Text>();
        second = Second.GetComponent<Text>();

        objInit(
            "{\"code\":0,\"text\":\"Successful save\",\"data\":{\"time_start\":null,\"count_time\":\"30\",\"fool_second\":3}}");
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(CheckTimePost);
    }

    void CheckTimePost()
    {
        URLController urlController = new URLController();
        object[,] parameters =
            {{ }};
        StartCoroutine(urlController.POST(objInit, url, parameters));
    }

    void objInit(String info)
    {
        dataElem = TimeStartJsonResult.CreateFromJSON(info);
        if (Int16.Parse(dataElem.code) == 503)
        {
            Instantiate(authPrefab, windowParent);
        }
        else
        {
            TimeFoolSecond = Convert.ToSingle(dataElem.data.fool_second);
            if (TimeFoolSecond <= 0)
            {
                operators = -1;
                ChangeColorStatus(1);
                TimeFoolSecond *= -1;
            }
            else
            {
                ChangeColorStatus(0);
                operators = 1;
            }

            chechTime();

            CheckStart = true;
        }
    }

    private void ChangeColorStatus(int status)
    {
        Color color;
        if (status == 1)
        {
            color = new Color(255, 30, 0);
        }
        else
        {
            color = new Color(255, 255, 255);
        }

        hours.color = color;
        minute.color = color;
        second.color = color;
    }

    void Update()
    {
        if (CheckStart)
        {
            if (TimeFoolSecond <= 0)
            {
                ChangeColorStatus(1);
                operators = -1;
            }

            if (operators == 1)
            {
                TimeFoolSecond -= Time.deltaTime;
                TimeSecond -= Time.deltaTime;
                if (TimeSecond <= 0)
                {
                    chechTime();
                }
            }
            else
            {
                TimeFoolSecond += Time.deltaTime;
                TimeSecond += Time.deltaTime;
                if (TimeSecond >= 58)
                {
                    chechTime();
                }
            }


            second.text = Mathf.Round(TimeSecond).ToString();
            hours.text = TimeHours.ToString();
            minute.text = TimeMinute.ToString();
        }
    }

    private void chechTime()
    {
        TimeSecond = TimeFoolSecond;
        TimeHours = Mathf.Floor(TimeSecond / 3600);
        TimeSecond -= TimeHours * 3600;
        TimeMinute = Mathf.Floor(TimeSecond / 60);
        TimeSecond -= TimeMinute * 60;
    }
}

public class TimeStartJsonResult
{
    public string code;
    public string text;
    public DataElem data;

    public static TimeStartJsonResult CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<TimeStartJsonResult>(jsonString);
    }
}

[System.Serializable]
public class DataElem
{
    public string count_time;
    public string fool_second;
}