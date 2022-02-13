using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controller;
using System;
using UnityEngine.UI;


public class Auth : MonoBehaviour
{
    public InputField first_name;
    public InputField last_name;
    public InputField login;
    public InputField password;

    public void Registration()
    {
        Debug.Log(first_name.text);
        Debug.Log(last_name.text);
        Debug.Log(login.text);
        Debug.Log(password.text);
        string url = "https://it-scholar.000webhostapp.com/post/register_url.php";
        URLController urlController = new URLController();
        object[,] parameters =
        {
            {"first_name", first_name.text},
            {"last_name", last_name.text},
            {"login", login.text},
            {"password", password.text},
            {"re_password", "23"}
        };
        StartCoroutine(urlController.POST(RegisterInit, url, parameters));
    } 

    private void RegisterInit(String info)
    {
        Debug.Log(info);
    }
}