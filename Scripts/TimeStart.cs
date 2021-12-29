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

    private float TimeHours;
    private float TimeMinute;
    private float TimeFoolSecond;
    private bool CheckStart = false;
    private float TimeSecond;

    private TimeStartJsonResult dataElem;

    public Transform windowParent;
    public GameObject authPrefab;

    private int operators = -1;

    private string url = "https://it-scholar.000webhostapp.com/post/time_start_url.php";

    void Awake()
    {
        // URLController urlController = new URLController();
        // object[,] parameters =
        // {{}};
        // StartCoroutine(urlController.POST(objInit, url, parameters));
        objInit(
            "{\"code\":0,\"text\":\"Successful save\",\"data\":{\"time_start\":null,\"count_time\":\"30\",\"fool_second\":58}}");
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
            chechTime();

            CheckStart = true;
        }
    }


    void Update()
    {
        if (CheckStart)
        {
            Text hours = Hours.GetComponent<Text>();
            Text minute = Minute.GetComponent<Text>();
            Text second = Second.GetComponent<Text>();

            if (TimeFoolSecond <= 0)
            {
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
                    Debug.Log(59);

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
        // data_users = new DataUsers[10];
        return JsonUtility.FromJson<TimeStartJsonResult>(jsonString);
    }
}

[System.Serializable]
public class DataElem
{
    public string count_time;
    public string fool_second;
}