using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;

public class JoinGroup : MonoBehaviour
{
    private InputField group_select;
    
    [SerializeField] private string url;
    
    public Button yourButton;
    void Start()
    {
        group_select = GameObject.Find("group_select").GetComponent <InputField> ();

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
        
        Data.AddField("group_select", group_select.text);
  

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
