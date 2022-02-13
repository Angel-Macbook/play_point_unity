using System;
using UnityEngine;
using Controller;
using UnityEngine.UI;


public class CheckAuth : MonoBehaviour
{
    public GameObject authPrefab;
    private TimeStartJsonResult dataElem;
    public Transform windowParent;
    void Awake()
    {
        CheckTimePost();
    }
    void CheckTimePost()
    {
        string url = "https://it-scholar.000webhostapp.com/post/time_start_url.php";
        URLController urlController = new URLController();
        object[,] parameters =
            {{ }};
        StartCoroutine(urlController.POST(objInit, url, parameters));
    }

    void objInit(String info)
    {
        Debug.Log(info);
        dataElem = TimeStartJsonResult.CreateFromJSON(info);
        if (Int16.Parse(dataElem.code) == 503)
        {
            Instantiate(authPrefab, windowParent);
        }
    }
}