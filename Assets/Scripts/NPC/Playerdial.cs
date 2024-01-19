using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdial : MonoBehaviour
{
    public DialogueManager dia;
    public Camera mainCamera;
    public GameObject spelare;
    float cooldown;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && dia.inconversation)
        {
            dia.DisplayNextScentence();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        //om objectet collidar med spelaren s� startas dial�gen och kameran v�nds rakt mot obejektet. -Erwin
        if (other.gameObject.CompareTag("Prey") && cooldown <= Time.time)
        {
            //st�nger av spelar-kamera k�den
            spelare.GetComponent<PlayerCam>().enabled = false;
            mainCamera.transform.LookAt(other.transform.position);
            cooldown = Time.time + 10f;
        }
    }
}
