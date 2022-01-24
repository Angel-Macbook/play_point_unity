using System;
using UnityEngine;
using Controller;
using UnityEngine.UI;

public class AddChild : MonoBehaviour
{
    public InputField ChildName;
    private string url = "https://it-scholar.000webhostapp.com/post/addChild_url.php";
    public void AddChildFunc()
    {
  

        Debug.Log(ChildName.text);
        URLController urlController = new URLController();
        // object[,] parameters =
        // {
        //     {"login", login.text},
        //     {"password", password.text}
        // };
        object[,] parameters =
        {
            {"name", ChildName.text}
        };
        StartCoroutine(urlController.POST(objInit, url, parameters));
    }
    void objInit(String info)
    {

    }

}
