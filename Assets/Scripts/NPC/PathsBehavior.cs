using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsBehavior : MonoBehaviour
{
    /*public float limitx; 
    public float limitz;
    public float limitleft;
    public float limitback;*/
    [SerializeField] GameObject test1;
    [SerializeField] Rigidbody rb;
    public Socialprat dia;
    //public GameObject prata;
    public Camera mainCamera;
    public GameObject spelare;
    public Quaternion origRotation;
    public float cooldown = 0f;
    public Transform targetPoint;  
    public float movementSpeed = 5f;
    public float stoppingDistance = 0.1f; 
    public Transform originPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //få fram rigidbodyn som är npcn - Erwin
        origRotation = transform.rotation;
        Vector3 initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()

    {
        if (Vector3.Distance(transform.position, targetPoint.position) > stoppingDistance)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            MoveTowardsTarget();
        }
        else
        {
            Disappear();
        }
        /* //Behövde brute-forca det, kunde inte komma på en lösning. - Erwin
         if (limitx != 0 && test1.transform.position.x < limitx)
         {
             rb.AddForce(transform.right * 2);
             rb.constraints = RigidbodyConstraints.FreezeRotationX;
         }
         //gör så att den går mot +x kordinaten -Erwin
         if (limitx > 0 && test1.transform.position.x > limitx)
         {
             Destroy(this.gameObject);

         }
         //gör så att den gå sönder om det som står händer -Erwin
         if (limitz > 0 && test1.transform.position.z > limitz)
         {
             Destroy(this.gameObject);
         }
         //gör så att den gå sönder om det som står händer -Erwin
         if (limitz != 0 && test1.transform.position.z < limitz)
         {
             rb.AddForce(transform.forward * 2);
             rb.constraints = RigidbodyConstraints.FreezeRotationZ;
         }
         //gör så att den går mot +z kordinaten -Erwin
         if (limitleft != 0 && test1.transform.position.x > limitleft)
         {
             rb.AddForce(Vector3.left * 2);
             rb.constraints = RigidbodyConstraints.FreezeRotationX;
         }
         //gör så att den går mot -x kordinaten -Erwin
         if (limitleft < 0 && test1.transform.position.x < limitleft)
         {
             Destroy(this.gameObject);
         }
         //gör så att den gå sönder om det som står händer -Erwin
         if (limitback < 0 && test1.transform.position.z < limitback)
         {
             Destroy(this.gameObject);
         }
         //gör så att den gå sönder om det som står händer -Erwin
         if (limitback != 0 && test1.transform.position.z > limitback)
         {
             rb.AddForce(Vector3.back * 2);
             rb.constraints = RigidbodyConstraints.FreezeRotationZ;
         }
         //gör så att den går mot -z kordinaten -Erwin*/

    }
    void MoveTowardsTarget()
    {
        
        Vector3 direction = (targetPoint.position - transform.position).normalized;

        
        transform.Translate(direction * movementSpeed * Time.deltaTime, Space.World);
    }
    void Disappear()
    {
        //Destroy(gameObject);
        transform.position = originPoint.position;
        //this.gameObject.SetActive(false);
    }
 
    private void OnTriggerEnter(Collider other)
    {
        //om objectet collidar med spelaren så startas dialågen. -Erwin
        if (other.gameObject.CompareTag("Player") && cooldown <= Time.time)
        {
            Quaternion origRotation = transform.rotation;
            transform.LookAt(other.transform.position);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            dia.Triggerdialogue();
            cooldown = Time.time + 10f;

        }
    }
}
