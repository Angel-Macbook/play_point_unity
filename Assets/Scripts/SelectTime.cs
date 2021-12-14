using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;

public class SelectTime : MonoBehaviour
{
    private string url  = "https://it-scholar.000webhostapp.com/post/select_time_url.php";
    private Button Buttons1;
    // public Button Select_0;
    // public Button Select_1;
    // public Button Select_2;
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(this.name);
        
        Buttons1 = GameObject.Find(this.name).GetComponent <Button> ();
        Buttons1.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        StartCoroutine(POST());
    }
    public IEnumerator POST()
    {
        var Data = new WWWForm();
        
        Data.AddField("select_time", this.name);
        

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
