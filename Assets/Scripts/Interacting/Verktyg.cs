using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verktyg : Interactables
{

    private Rigidbody rb;
    private Collider coll;
    [SerializeField] Transform hand;
    [SerializeField] float customRotationX, customRotationY, customRotationZ;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        //Gör att verktyg alltid pekar framåt och är i samma position utifrån spelarens position  -Filip  
        if(transform.parent != null)
        {
            rb.useGravity = false;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            coll.enabled = false;
            gameObject.transform.position = hand.transform.position;
            transform.rotation = hand.transform.rotation * Quaternion.Euler(customRotationX, customRotationY, customRotationZ);
        }
        /*
        else
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;
            coll.enabled = true;
        }
        */
    }

    public void GetDropped()
    {
        rb.useGravity = true;
        rb.constraints = RigidbodyConstraints.None;
        coll.enabled = true;
        transform.parent = null;
    }
}
