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
        //få fram objektet som är npcn
    }

    // Update is called once per frame
    void Update()
    {
        if (test1.transform.position.x < limitx)
        {
            rb.AddForce(transform.right * 5);
        }
        //gör så att den går mot x
        if (limitx > 0 && test1.transform.position.x > limitx)
        {
            Destroy(this.gameObject);
        }
        //gör så att den gå sönder om det som står händer
        if (limitz > 0 && test1.transform.position.z > limitz)
        {
            Destroy(this.gameObject);
        }
        //gör så att den gå sönder om det som står händer
        if (test1.transform.position.z < limitz)
        {
            rb.AddForce(transform.forward * 5);
        }
        //gör så att den går mot z
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            dia.Triggerdialogue();
        }
    }
}
