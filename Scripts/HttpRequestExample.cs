using System;
using UnityEngine;
using Controller;
using UnityEngine.UI;

public class HttpRequestExample : MonoBehaviour
{
    private InputField first_name;
    private InputField last_name;
    private InputField login;
    private InputField password;
    private InputField re_password;
   
    private DefoultJsonResult dataElem;
    
    private string url = "https://it-scholar.000webhostapp.com/post/register_url.php";
    
    public Button yourButton;
    void Awake()
    {
        first_name = GameObject.Find("first_name").GetComponent <InputField> ();
        last_name = GameObject.Find("last_name").GetComponent <InputField> ();
        login = GameObject.Find("login").GetComponent <InputField> ();
        password = GameObject.Find("password").GetComponent <InputField> ();
        re_password = GameObject.Find("re_password").GetComponent <InputField> ();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        URLController urlController = new URLController();
        
         object[,] parameters =
         {
             {"first_name", first_name.text},
             {"last_name", last_name.text},
             {"login", login.text},
             {"password", password.text},
           {"re_password", re_password.text},
         };
        /*object[,] parameters =
        {
            {"first_name", "Jalarm1"},
            {"last_name", "123456789"},
            {"login", "123456789"},
            {"password", "123456789"},
            {"re_password", "123456789"},
        };*/
        StartCoroutine(urlController.POST(objInit, url, parameters));
    }
    void objInit(String info)
    {
        dataElem = DefoultJsonResult.CreateFromJSON(info);
        // Debug.Log(dataElem.code);
    }
}
