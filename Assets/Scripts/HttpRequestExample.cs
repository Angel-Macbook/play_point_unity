using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;
using UnityEngine.UI;
public class HttpRequestExample : MonoBehaviour
{
    private InputField first_name;
    private InputField last_name;
    private InputField login;
    private InputField password;
    private InputField re_password;
   
    [SerializeField] private string url;
    // Start is called before the first frame update
    
    public Button yourButton;
    void Start()
    {
        
        
        first_name = GameObject.Find("first_name").GetComponent <InputField> ();
        last_name = GameObject.Find("last_name").GetComponent <InputField> ();
        login = GameObject.Find("login").GetComponent <InputField> ();
        password = GameObject.Find("password").GetComponent <InputField> ();
        re_password = GameObject.Find("re_password").GetComponent <InputField> ();



        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
        // 

    }

    void TaskOnClick()
    {
        StartCoroutine(POST());
        
    }
    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
    }
    private IEnumerator SendRequest()
    {
        UnityWebRequest request = UnityWebRequest.Get(this.url);
        yield return request.SendWebRequest();

        Debug.Log(request.downloadHandler.text);
    }
    private IEnumerator SendPostRequest()
    {
        WWWForm formData = new WWWForm();
        
        PostStruct post = new PostStruct()
        { 
            userId = 115,
            title = "Created Post Title",
            body = "Created Post Body",
            password = "1234562w7",
        };
        formData.AddField("password", "1231wrasdf34");
        string json = JsonUtility.ToJson(post);
        
        UnityWebRequest request = UnityWebRequest.Post(this.url, formData);
        
        byte[] postBytes = Encoding.UTF8.GetBytes(json);

        UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);
        
        request.uploadHandler = uploadHandler;

        request.SetRequestHeader("Content-Type", "application/json; charset=UTF=8");
        yield return request.SendWebRequest();

//        PostStruct postFromServer = JsonUtility.FromJson<PostStruct>(request.downloadHandler.text);

        Debug.Log(request.downloadHandler.text);
        //Debug.Log(postFromServer.id);
    }
    public IEnumerator POST()
    {
        var Data = new WWWForm();
        Debug.Log(first_name.text);
        
        Data.AddField("first_name", first_name.text);
        Data.AddField("last_name", last_name.text);
        Data.AddField("login", login.text);
        Data.AddField("password", password.text);
        Data.AddField("re_password", re_password.text);
  

        var Query = new WWW(this.url, Data);
        yield return Query;
        if (Query.error != null)
        {
            Debug.Log("Server does not respond : " + Query.error);
        }
        else
        {
            if (Query.text == "response") // в основном HTML код которым ответил сервер
            {
                Debug.Log("Server responded correctly");
            }
            else
            {
                Debug.Log("Server responded : " + Query.text);
            }
        }
        Query.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
