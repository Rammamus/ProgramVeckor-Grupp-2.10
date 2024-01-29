using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InteractibleRaycast : MonoBehaviour
{
    public RaycastHit hit;

    Transform equippedItem;
    bool holdingSomething = false;
    [SerializeField] float raycastRange;
    [SerializeField] public GameObject interractText;
    TextMeshProUGUI uiText;
    [SerializeField] public Sanity sanity;
    [SerializeField] public DialogueManager dialogue;
    [SerializeField] public Killcount killcount;

    GameObject heldItem;
    float dropTimer;

    Tasks previousTask;

    // Start is called before the first frame update
    void Start()
    {
        interractText.SetActive(false);
        uiText = interractText.GetComponent<TextMeshProUGUI>();
        holdingSomething = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (dropTimer > 0)
        {
            dropTimer -= Time.deltaTime;
        }
        //S�tter Vektorn fwd till fram�t fr�n kameran -Filip
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //K�nner efter om Raycasten tr�ffar n�gonting raycastRange units framf�r objektet och �verf�r informationen fr�n det tr�ffade objektet till raycastHit-variabeln hit - Filip
        if (Physics.Raycast(transform.position, fwd, out hit, raycastRange))
        {
            //Kollar om det tr�ffade gameObjectet har taggen Interactable och aktiverar "Press F to interact" texten -Filip
            if (hit.transform.gameObject.CompareTag("Interactable") && !holdingSomething)
             {
                interractText.SetActive(true);
                UpdateInteractText(true, "to pick up");
                if (Input.GetKeyDown(KeyBinds.interact) && dropTimer <= 0)
                {
                    dropTimer = 0.5f;
                    heldItem = hit.transform.gameObject;
                    equippedItem = hit.transform;
                    hit.transform.parent = gameObject.transform;
                    holdingSomething = true;
                }
            }

            //Kollar om det tr�ffade gameObjectet har prat scriptet - Erwin
            if (hit.transform.GetComponent<Socialprat>() && dialogue.inconversation == false)
            {
                interractText.SetActive(true);
                UpdateInteractText(true, "to talk");
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

                    //If you talk to the principal while having completed all tasks you fully pass - Adrian
                    if (hit.transform.gameObject.CompareTag("Principal") && FindObjectOfType<TaskList>().passedTheLevel)
                    {
                        FindObjectOfType<SceneManage>().fullyPassed = true;
                    }
                }
            }
            
            //Kollar om det tr�ffade game objectet �r en task - Adrian
            if (hit.transform.GetComponent<Tasks>())
            {
                interractText.SetActive(true);
                if (holdingSomething && heldItem == hit.transform.GetComponent<Tasks>().tool)
                {
                    UpdateInteractText(false, "'" + KeyBinds.useItem +"' " + hit.transform.GetComponent<Tasks>().taskName);
                    hit.transform.GetComponent<Tasks>().interaction = true;
                }
                else
                {
                    UpdateInteractText(false, "I need my tools");
                }
               
                previousTask = hit.transform.GetComponent<Tasks>();
            }

            //Kollar om det tr�ffade game objectet �r en d�rr - Adrian
            if (hit.transform.GetComponent<DoorScript>())
            {
                interractText.SetActive(true);
                if (!hit.transform.GetComponent<DoorScript>().locked)
                {
                    UpdateInteractText(true, "to use door");
                    if (Input.GetKeyDown(KeyBinds.interact))
                    {
                        hit.transform.GetComponent<DoorScript>().DoorToggle();
                    }
                }
                else
                {
                    UpdateInteractText(false, "This door is locked");
                }
            }
        }
        else
        {
            interractText.SetActive(false);
            if (previousTask != null)
            {
                previousTask.StopTask();
            }
        }

        //Sl�pper objektet man h�ller i handen om man trycker p� interact knappen
        if (holdingSomething == true)
        {
            //interractText.SetActive(false);
            if (Input.GetKeyDown(KeyBinds.interact) && dropTimer <= 0)
            {
                interractText.SetActive(false);
                //gameObject.transform.DetachChildren(); //TODO - Make this only detach the object that is being held - Adrian
                heldItem.GetComponent<Verktyg>().GetDropped();
                holdingSomething = false;
                dropTimer = 0.5f;
            }
        }
    }

    public void UpdateInteractText(bool canInteract, string s)
    {
        if (canInteract)
        {
            uiText.text = "'" + KeyBinds.interact.ToString() + "' " + s;
        }
        else
        {
            uiText.text = s;
        }
    }
}
    

