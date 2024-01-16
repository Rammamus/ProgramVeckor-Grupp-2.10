using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verktyg : Interactables
{

    private Rigidbody rb;
    private Collider coll;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.parent != null)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            coll.enabled = false;
            gameObject.transform.localPosition = new Vector3(0.2f,-0.1f,1);
            transform.localRotation = Quaternion.identity;
        }
        
        else
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            coll.enabled = true;
        }
        
    }
}
