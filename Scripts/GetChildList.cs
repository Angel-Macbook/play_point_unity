using System;
using UnityEngine;
using Controller;
using TMPro;

public class GetChildList : MonoBehaviour
{
    private string url = "https://it-scholar.000webhostapp.com/post/get_child_list.php";
    public ChildCardController userPrefab;
    public Transform prefabContent;
    public Transform[] TempArray;
    private Vector2 direction;
    private PlayerInfo dataElem;
    
    
    
    public Transform windowParent;
    public GameObject authPrefab;
    private GameObject testPrefab;
    
    void Awake()
    {
        URLController urlController = new URLController();
        object[,] parameters = {{}};
        StartCoroutine(urlController.POST(objInit, url, parameters));
    }
    void objInit(String info)
    {
        dataElem = PlayerInfo.CreateFromJSON(info);
        if (Int16.Parse(dataElem.code) == 503)
        {
            Instantiate(authPrefab, windowParent);
        }
        else
        {
            foreach (var item in dataElem.data_users)
            {
                ChildCardController userCard = Instantiate(userPrefab, prefabContent);
                userCard.Init(item);
            }
        }
    }
}
[System.Serializable]
public class PlayerInfo
{
    public string code;
    public string text;
    public DataUsers[] data_users;
    
    public static PlayerInfo CreateFromJSON(string jsonString)
    {
        // data_users = new DataUsers[10];
        return JsonUtility.FromJson<PlayerInfo>(jsonString);
    }
}
[System.Serializable]
public class DataUsers
{
    public string id;
    public string parent_id;
    public string name;
    public string status;
    public string avatar;
}
