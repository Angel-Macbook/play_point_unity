using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;

public class GetChildList : MonoBehaviour
{
    private string url = "https://it-scholar.000webhostapp.com/post/get_child_list.php";
    public GameObject rootObj;
    public Transform rootObjParent;
    public Transform[] TempArray;
    private Vector2 direction;
    void Start()
    {
        StartCoroutine(POST(funct_post));
    }

    void DoSomethingWhenDone(string tex)
    {
        
    }
    
    void funct_post(string dataJSON)
    {
        GameObject duplicate = Instantiate(rootObj, rootObjParent);
        GameObject duplicate1 = Instantiate(rootObj, rootObjParent);
        GameObject duplicate2 = Instantiate(rootObj, rootObjParent);
        
        // transform.position = new Vector3(transform.position.x + (1887) * Time.deltaTime, transform.position.y+2222, transform.position.z);;
        Vector3 movementMonster = new Vector2(0, 0);
        Vector3 movementMonster1 = new Vector2(0, -1);
        Vector3 movementMonster2 = new Vector2(0, -2);
        duplicate.transform.Translate(movementMonster);
        duplicate1.transform.Translate(movementMonster1);
        duplicate2.transform.Translate(movementMonster2);
        Debug.Log(transform);
        TempArray = duplicate.GetComponentsInChildren<Transform>();
        // Debug.Log(TempArray[1]);
    }
    public IEnumerator POST(Action<string> callback)
    {
        var Data = new WWWForm();
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
                callback?.Invoke(Query.text);
                // Debug.Log("3 Server responded : " + Query.text);
            }
        }
        Query.Dispose();
    }
    void Update()
    {
        
    }
}
