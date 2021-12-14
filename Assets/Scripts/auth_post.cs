using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;

public class auth_post : MonoBehaviour
{
    private InputField login;
    private InputField password;
    
    
    [SerializeField] private string url;
    
    public Button yourButton;
    void Start()
    {
        login = GameObject.Find("login").GetComponent <InputField> ();
        password = GameObject.Find("password").GetComponent <InputField> ();

        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick()
    {
        StartCoroutine(POST());
        
    }
    public IEnumerator POST()
    {
        var Data = new WWWForm();
        
        Data.AddField("login", login.text);
        Data.AddField("password", password.text);
  

        var Query = new WWW(this.url, Data);
        yield return Query;
        if (Query.error != null)
        {
            Debug.Log("1 Server does not respond : " + Query.error);
        }
        else
        {
            if (Query.text == "response")
            {
                Debug.Log("2 Server responded correctly");
            }
            else
            {
                Debug.Log("3 Server responded : " + Query.text);
            }
        }
        Query.Dispose();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
