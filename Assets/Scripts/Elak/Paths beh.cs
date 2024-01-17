using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathsbeh : MonoBehaviour
{
    public float limitx; 
    public float limitz;
    public float limitleft;
    public float limitback;
    [SerializeField] GameObject test1;
    [SerializeField] Rigidbody rb;
    public Socialprat dia;
    public GameObject prata;
    public Camera mainCamera;
    public GameObject spelare;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //f� fram rigidbodyn som �r npcn - Erwin
    }

    // Update is called once per frame
    void Update()
    {
        //Beh�vde brute-forca det, kunde inte komma p� en l�sning. - Erwin
        if (limitx != 0 && test1.transform.position.x < limitx)
        {
            rb.AddForce(transform.right * 2);
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
        }
        //g�r s� att den g�r mot +x kordinaten -Erwin
        if (limitx > 0 && test1.transform.position.x > limitx)
        {
            Destroy(this.gameObject);
            Debug.Log("As");
        }
        //g�r s� att den g� s�nder om det som st�r h�nder -Erwin
        if (limitz > 0 && test1.transform.position.z > limitz)
        {
            Destroy(this.gameObject);
        }
        //g�r s� att den g� s�nder om det som st�r h�nder -Erwin
        if (limitz != 0 && test1.transform.position.z < limitz)
        {
            rb.AddForce(transform.forward * 2);
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
        //g�r s� att den g�r mot +z kordinaten -Erwin
        if (limitleft != 0 && test1.transform.position.x > limitleft)
        {
            rb.AddForce(Vector3.left * 2);
            rb.constraints = RigidbodyConstraints.FreezeRotationX;
        }
        //g�r s� att den g�r mot -x kordinaten -Erwin
        if (limitleft < 0 && test1.transform.position.x < limitleft)
        {
            Destroy(this.gameObject);
            Debug.Log("As");
        }
        //g�r s� att den g� s�nder om det som st�r h�nder -Erwin
        if (limitback < 0 && test1.transform.position.z < limitback)
        {
            Destroy(this.gameObject);
        }
        //g�r s� att den g� s�nder om det som st�r h�nder -Erwin
        if (limitback != 0 && test1.transform.position.z > limitback)
        {
            rb.AddForce(Vector3.back * 2);
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }
        //g�r s� att den g�r mot -z kordinaten -Erwin
    }
    private void OnCollisionEnter(Collision collision)
    {
        //om objectet collidar med spelaren s� startas dial�gen. -Erwin
        if (collision.gameObject.CompareTag("Player"))
        {
            dia.Triggerdialogue();
            Debug.Log("Lala");
        }
    }
}
