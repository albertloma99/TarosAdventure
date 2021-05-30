using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovablePlatform : MonoBehaviour
{
    private Vector3 origin;
    public GameObject targetObject;
    private Vector3 target;// the target position
    public float speed; // speed - units per second (gives you control of how fast the object will move in the inspector)
    public bool moveObj; // a public bool that allows you to toggle this script on and off in the inspector
    public float distanceToValidate;
    public Vector3 scale;
    public float FixeScaleX ;
    public float FixeScaleY; 
    public float FixeScaleZ;
    // Update is called once per frame
    private void Start()
    {
        origin = this.transform.position;
        target = targetObject.transform.position;
        scale = transform.localScale;
        FixeScaleX = scale.x;
        FixeScaleY = scale.y;
        FixeScaleZ = scale.z;
    }

    void Update ()
    {
        if (moveObj != true) return;
        var step = speed * Time.deltaTime; // step size = speed * frame time
        // moves position a step closer to the target position
        if (Vector3.Distance(this.transform.position, target) > distanceToValidate)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
        else
        {
            var tar = target;
            target = origin;
            origin = tar;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Inside Platform");
        other.gameObject.transform.SetParent(this.transform);
    }
    
    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Outside Platform");
        other.gameObject.transform.SetParent(null);
        other.gameObject.transform.localScale = new Vector3(1,1,1);
    }
}
