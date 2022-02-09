using System;
using UnityEngine;
using Controller;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CardEvent : MonoBehaviour
{
    private string url_deleteChild = "https://it-scholar.000webhostapp.com/post/card_event_post.php";
    private string url_hideChild = "https://it-scholar.000webhostapp.com/post/card_event_post.php";
    private DefoultJsonResult dataElem;
    public Button id_element;
    public void eventChild(int type)
    {
        
        GameObject bvba = this.gameObject;
        string id = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;
        Debug.Log(id);
        URLController urlController = new URLController();
        object[,] parameters = {
            {"type", "1"},
            {"card_id", id}
        };
        StartCoroutine(urlController.POST(objInit, url_deleteChild, parameters));
    }
    void objInit(String info)
    {
        dataElem = DefoultJsonResult.CreateFromJSON(info);
        SceneManager.LoadScene(1);
    }
}

