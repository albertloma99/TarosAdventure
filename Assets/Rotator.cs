using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update

    public float angularSpeed;
    public bool isCombo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isCombo)
        {
            transform.Rotate(0, angularSpeed*Time.deltaTime, 0);
        }
        else
        {
            transform.Rotate(0, 0, angularSpeed*Time.deltaTime);
        }
    }
}
