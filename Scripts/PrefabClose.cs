using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrefabClose : MonoBehaviour
{
    public GameObject ParentPopap = null;
    public void PrefabCloseFunc()
    {
        ParentPopap.SetActive(false);
    }
    public void PrefabOpenFunc()
    {
        ParentPopap.SetActive(true);
        
    }
    public void PrefabOpenFunc_v2(GameObject elem)
    {
        elem.SetActive(true);
    }
}
