using System;
using UnityEngine;
using Controller;
using UnityEngine.UI;

public class SelectTime : MonoBehaviour
{
    private string url = "https://it-scholar.000webhostapp.com/post/select_time_url.php";
    private Button Buttons1;
    private DefoultJsonResult dataElem;
    void Awake()
    {
        Buttons1 = GameObject.Find(this.name).GetComponent<Button>();
        Buttons1.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        URLController urlController = new URLController();
        object[,] parameters =
        {
            {"select_time", this.name},
        };
        StartCoroutine(urlController.POST(objInit, url, parameters));

    }
    void objInit(String info)
    {
        dataElem = DefoultJsonResult.CreateFromJSON(info);
    }
} 