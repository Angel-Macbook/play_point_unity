using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menuList;
    void Awake()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        if (menuList.activeSelf)
        {
            menuList.SetActive(false);
        }
        else
        {
            menuList.SetActive(true);
        }
    }

}
