using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabClose : MonoBehaviour
{
    public GameObject ParentPopap;
    public void PrefabCloseFunc()
    {
        ParentPopap.SetActive(false);
    }
    public void PrefabOpenFunc()
    {
        ParentPopap.SetActive(true);
    }
}
