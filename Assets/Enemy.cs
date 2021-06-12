using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    public float repulsionForce;
    public float velocityToKill = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<Rigidbody>().velocity.magnitude >= velocityToKill)
        {
            Destroy(this.gameObject);
        }
        else
        {
            other.gameObject.GetComponent<Rigidbody>().AddForce(other.contacts[0].normal.ToHorizontal()*repulsionForce,ForceMode.Impulse);
        }
        
    }
}
