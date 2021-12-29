using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    
    public Transform trans;
    private Vector3 target = new Vector3(0, 360, 360);
    void Start()
    {
        
    }

    void Update()
    {
        trans.Rotate(Vector3.back * 1);
    }
}
