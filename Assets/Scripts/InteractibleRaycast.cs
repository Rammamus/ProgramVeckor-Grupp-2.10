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
        //Sätter Vektorn fwd till framåt från kameran -Filip
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Känner efter om Raycasten träffar någonting raycastRange units framför objektet och överför informationen från det träffade objektet till raycastHit-variabeln hit - Filip
        if (Physics.Raycast(transform.position, fwd, out hit, raycastRange))
        {

            print("Interact");
            //Kollar om det träffade gameObjectet har taggen Interactable och aktiverar "Press F to interact" texten -Filip
            if (hit.transform.gameObject.CompareTag("Interactable") && holdingSomething == false)
             {
                interractText.SetActive(true);
                if (Input.GetKey(interactkey))
                {
                    hit.transform.parent = gameObject.transform;
                    holdingSomething = true;
                    
                }

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
    

