using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using UnityEngine.UI;

public class MenuListButton : MonoBehaviour
{
    public Button logout;
    private Transform gameScena;
    public GameObject authPrefab;

    void Awake()
    {
        Button logoutButton = logout.GetComponent<Button>();
        logoutButton.onClick.AddListener(LogoutFunction);
    }

    private void LogoutFunction()
    {
        var urlLogout = "http://www.playpoint.com/post/logout_post.php";
        URLController urlController = new URLController();
        object[,] parameters = { };
        StartCoroutine(urlController.POST(objInit, urlLogout, parameters));
        
        gameScena = GameObject.Find("Game_Scena").GetComponent <Transform> ();
        Instantiate(authPrefab, gameScena);
    }

    void objInit(String info)
    {
        Debug.Log(info);
    }
}