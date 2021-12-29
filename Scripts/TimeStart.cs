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
    
    private string url = "https://it-scholar.000webhostapp.com/post/time_start_url.php";
    void Awake()
    {
        URLController urlController = new URLController();
        object[,] parameters =
        {{}};
        StartCoroutine(urlController.POST(objInit, url, parameters));
        // objInit("{\"code\":0,\"text\":\"Successful save\",\"data\":{\"time_start\":null,\"count_time\":\"30\",\"fool_second\":55431}}");
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
            TimeSecond = TimeFoolSecond;
            TimeHours = Mathf.Round(TimeSecond / 3600);
            TimeSecond -= TimeHours * 3600;
            TimeMinute = Mathf.Round(TimeSecond / 60);
            TimeSecond -= TimeMinute * 60;
        
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