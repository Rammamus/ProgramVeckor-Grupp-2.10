using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleRaycast : MonoBehaviour
{
    public RaycastHit hit;

    Transform equippedItem;
    bool holdingSomething = false;
    [SerializeField] float raycastRange;
    [SerializeField] GameObject interractText;
    [SerializeField] public Sanity sanity;
    [SerializeField] public DialogueManager dialogue;
    [SerializeField] public Killcount killcount;


    // Start is called before the first frame update
    void Start()
    {
        interractText.SetActive(false);
        holdingSomething = false;
    }

    // Update is called once per frame
    void Update()
    {
        //S�tter Vektorn fwd till fram�t fr�n kameran -Filip
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //K�nner efter om Raycasten tr�ffar n�gonting raycastRange units framf�r objektet och �verf�r informationen fr�n det tr�ffade objektet till raycastHit-variabeln hit - Filip
        if (Physics.Raycast(transform.position, fwd, out hit, raycastRange))
        {
            //Kollar om det tr�ffade gameObjectet har taggen Interactable och aktiverar "Press F to interact" texten -Filip
            if (hit.transform.gameObject.CompareTag("Interactable") && holdingSomething == false)
             {
                interractText.SetActive(true);
                if (Input.GetKeyUp(KeyBinds.interact))
                {
                    equippedItem = hit.transform;
                    hit.transform.parent = gameObject.transform;
                    holdingSomething = true;
                }
            }

            else
            {
                interractText.SetActive(false);

            }

            //Kollar om det tr�ffade gameObjectet har prat scriptet - Erwin
            if (hit.transform.GetComponent<Socialprat>() && dialogue.inconversation == false)
            {
                interractText.SetActive(true);
                if (Input.GetKeyDown(KeyBinds.interact))
                {
                    //Om spelarens sanity droppar under 25% s� kommer man kunna ta bort objektet ist�llet f�r att prata med det. - Erwin
                    if (hit.transform.gameObject.CompareTag("Prey") && sanity.insanePercentage >= 0.75)
                    {
                        killcount.killcount += 1;
                        Destroy(hit.transform.gameObject);
                    }
                    else
                    {
                        hit.transform.GetComponent<Socialprat>().Triggerdialogue();
                    }
                }
            }
            
            //Kollar om det tr�ffade game objectet �r en task - Adrian
            if (hit.transform.GetComponent<Tasks>())
            {
                hit.transform.GetComponent<Tasks>().interaction = true;

                interractText.SetActive(true);
            }

            //Kollar om det tr�ffade game objectet �r en d�rr - Adrian
            if (hit.transform.GetComponent<DoorScript>())
            {
                interractText.SetActive(true);
                if (Input.GetKeyDown(KeyBinds.interact))
                {
                    hit.transform.GetComponent<DoorScript>().DoorToggle();
                }
            }
        }
        else
        {
            interractText.SetActive(false);
        }

        //Sl�pper objektet man h�ller i handen om man trycker p� interact knappen
        if (holdingSomething == true)
        {

            interractText.SetActive(false);
            if (Input.GetKeyDown(KeyBinds.interact))
            {
                interractText.SetActive(false);
                gameObject.transform.DetachChildren();
                holdingSomething = false;
            }
        }
        }
    }
    
