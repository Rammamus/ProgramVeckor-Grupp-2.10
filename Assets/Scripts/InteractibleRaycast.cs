using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleRaycast : MonoBehaviour
{
    public RaycastHit hit;

    GameObject equippedItem;
    bool holdingSomething = false;
    [SerializeField] KeyCode interactkey = KeyCode.F;
    [SerializeField] float raycastRange;
    [SerializeField] GameObject interractText;
    
        

    // Start is called before the first frame update
    void Start()
    {
        interractText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        print(holdingSomething);
        //S�tter Vektorn fwd till fram�t fr�n kameran -Filip
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //K�nner efter om Raycasten tr�ffar n�gonting raycastRange units framf�r objektet och �verf�r informationen fr�n det tr�ffade objektet till raycastHit-variabeln hit - Filip
        if (Physics.Raycast(transform.position, fwd, out hit, raycastRange))
        {

            print("Interact");
            //Kollar om det tr�ffade gameObjectet har taggen Interactable och aktiverar "Press F to interact" texten -Filip
            if (hit.transform.gameObject.CompareTag("Interactable") && holdingSomething == false)
             {
                interractText.SetActive(true);
                if (Input.GetKey(interactkey))
                {
                    hit.transform.parent = gameObject.transform;
                    holdingSomething = true;
                    
                }

            }

            //Kollar om det tr�ffade gameObjectet �r en task - Adrian
            if (hit.transform.GetComponent<Tasks>())
            {
                hit.transform.GetComponent<Tasks>().interaction = true;
                interractText.SetActive(true);
            }

            else if (holdingSomething == true)
            {
                interractText.SetActive(false);
                if (Input.GetKey(interactkey))
                {
                    
                    holdingSomething = false;


                }
                
            }



        }
            else
            {
                interractText.SetActive(false);
            }



        }
        
            
    }
    

