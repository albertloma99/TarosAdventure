using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update

    public float angularSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, angularSpeed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.SetParent(this.transform);
    }

    private void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.SetParent(null);
    }
}
