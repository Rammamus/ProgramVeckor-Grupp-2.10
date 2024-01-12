using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float limitx; 
    public float limitz;
    [SerializeField] GameObject test1;
    [SerializeField] Rigidbody rb;
    public Socialprat dia;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //f� fram objektet som �r npcn
    }

    // Update is called once per frame
    void Update()
    {
        if (test1.transform.position.x < limitx)
        {
            rb.AddForce(transform.right * 5);
        }
        //g�r s� att den g�r mot x
        if (limitx > 0 && test1.transform.position.x > limitx)
        {
            Destroy(this.gameObject);
        }
        //g�r s� att den g� s�nder om det som st�r h�nder
        if (limitz > 0 && test1.transform.position.z > limitz)
        {
            Destroy(this.gameObject);
        }
        //g�r s� att den g� s�nder om det som st�r h�nder
        if (test1.transform.position.z < limitz)
        {
            rb.AddForce(transform.forward * 5);
        }
        //g�r s� att den g�r mot z
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dia.Triggerdialogue();
        }
    }
}
