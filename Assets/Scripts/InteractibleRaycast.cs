using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleRaycast : MonoBehaviour
{
    public RaycastHit hit;

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
    {   //S�tter Vektorn fwd till fram�t fr�n kameran -Filip
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        //K�nner efter om Raycasten tr�ffar n�gonting raycastRange units framf�r objektet och �verf�r informationen fr�n det tr�ffade objektet till raycastHit-variabeln hit - Filip
        if (Physics.Raycast(transform.position, fwd, out hit, raycastRange))
        {


            //Kollar om det tr�ffade gameObjectet har taggen Interactable och aktiverar "Press X to interact" texten -Filip
            if (hit.transform.gameObject.CompareTag("Interactable") && holdingSomething == false)
            {
                interractText.SetActive(true);
                if (Input.GetKey(interactkey))
                {
                    hit.transform.parent = gameObject.transform;
                    
                    
                }
            }
            else
            {
                interractText.SetActive(false);
            }



        }
        
            
    }
    
}
