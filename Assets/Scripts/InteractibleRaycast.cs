using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleRaycast : MonoBehaviour
{
    public RaycastHit hit;

    Transform equippedItem;
    bool holdingSomething = false;
    [SerializeField] GameObject testInteract;
    [SerializeField] KeyCode interactkey = KeyCode.F;
    [SerializeField] float raycastRange;
    [SerializeField] GameObject interractText;
    [SerializeField] public Sanity sanity;
    
        

    // Start is called before the first frame update
    void Start()
    {
        interractText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Sätter Vektorn fwd till framåt från kameran -Filip
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //Känner efter om Raycasten träffar någonting raycastRange units framför objektet och överför informationen från det träffade objektet till raycastHit-variabeln hit - Filip
        if (Physics.Raycast(transform.position, fwd, out hit, raycastRange))
        {
            //Kollar om det träffade gameObjectet har taggen Interactable och aktiverar "Press F to interact" texten -Filip
            if (hit.transform.gameObject.CompareTag("Interactable") && holdingSomething == false)
             {
                interractText.SetActive(true);
                if (Input.GetKeyDown(interactkey))
                {
                    equippedItem = hit.transform;
                    hit.transform.parent = gameObject.transform;
                    holdingSomething = true;
                    
                }

            }
            //Kollar om det träffade gameObjectet har prat scriptet - Erwin
            if (hit.transform.GetComponent<Socialprat>())
            {
                interractText.SetActive(true);
                if (Input.GetKeyDown(interactkey))
                {
                    //Om spelarens sanity droppar under 25% så kommer man kunna ta bort objektet istället för att prata med det. - Erwin
                    if (hit.transform.gameObject.CompareTag("Prey") && sanity.insanePercentage >= 0.75)
                    {
                        hit.transform.GetComponent<Killcount>().killcount += 1;
                        Destroy(hit.transform.gameObject);
                    }
                    else
                    {
                        hit.transform.GetComponent<Socialprat>().Triggerdialogue();
                    }
                }
            }
            
            //Kollar om det träffade gameObjectet är en task - Adrian
            if (hit.transform.GetComponent<Tasks>())
            {
                hit.transform.GetComponent<Tasks>().interaction = true;

                interractText.SetActive(true);
            }
            
            if (holdingSomething == true)
            {
                interractText.SetActive(false);
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    foreach (Transform child in transform)
                    {
                        GameObject.Destroy(child.gameObject);
                    }
                    Instantiate(testInteract, new Vector3(0, 0, 0), Quaternion.identity);
                    holdingSomething = false;


                }
                
            }
            



        }
            else
            {
                
            }



        }
        
            
    }
    

