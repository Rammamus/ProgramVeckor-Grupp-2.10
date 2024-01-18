using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerdial : MonoBehaviour
{
    public DialogueManager dia;
    public Camera mainCamera;
    public GameObject spelare;
    bool activationtimer = true;
    float cooldown;
    void Update()
    {
        cooldown = Time.deltaTime;
        if (!activationtimer && cooldown == 5)
        {
            activationtimer = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && dia.inconversation)
        {
            dia.DisplayNextScentence();
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        //om objectet collidar med spelaren så startas dialågen och kameran vänds rakt mot obejektet. -Erwin
        if (collision.gameObject.CompareTag("Prey") && activationtimer)
        {
            spelare.GetComponent<PlayerCam>().enabled = false;
            mainCamera.transform.LookAt(collision.transform.position);
            cooldown = Time.deltaTime - Time.deltaTime;
        }
    }
}
