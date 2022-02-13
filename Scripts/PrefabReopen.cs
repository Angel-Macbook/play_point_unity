using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabReopen : MonoBehaviour
{
    public GameObject FirstElement;
    public GameObject LastElement;

    public void Refresh(int coordination)
    {
        if (coordination == 0)
        {
            FirstElement.SetActive(false);
            LastElement.SetActive(true); 
        }
        else
        {
            FirstElement.SetActive( true);
            LastElement.SetActive(false); 
        }
        
    }
    
}
