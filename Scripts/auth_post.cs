using System;
using UnityEngine;
using Controller;
using UnityEngine.UI;

public class auth_post : MonoBehaviour
{
    private InputField login;
    private InputField password;
    private DefoultJsonResult dataElem;
    public GameObject modalForm;

    private string url = "https://it-scholar.000webhostapp.com/post/login_url.php";

    public Button yourButton;

    void Awake()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        login = GameObject.Find("login").GetComponent<InputField>();
        password = GameObject.Find("password").GetComponent<InputField>();
        URLController urlController = new URLController();
        // object[,] parameters =
        // {
        //     {"login", login.text},
        //     {"password", password.text}
        // };
        object[,] parameters =
        {
            {"login", "Jalarm"},
            {"password", "123456789"}
        };
        StartCoroutine(urlController.POST(objInit, url, parameters));
    }

    void objInit(String info)
    {
        dataElem = DefoultJsonResult.CreateFromJSON(info);
        Destroy(modalForm);
    }
}

[System.Serializable]
public class DefoultJsonResult
{
    public string code;
    public string text;

    public static DefoultJsonResult CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<DefoultJsonResult>(jsonString);
    }
}