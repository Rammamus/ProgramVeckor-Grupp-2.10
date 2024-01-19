using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piller : MonoBehaviour
{
    public int remainingPills;
    [SerializeField] KeyCode pillerSmaskarn;


    //Minskar piller med ett när man äter ett -Filip
    void takePill()
    {
        remainingPills -= 1;
        print(remainingPills + " Remaining Pills");
    }

   



    // Tar ett piller om man klickar på knappen och har piller kvar att ta -Filip
    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            if (Input.GetKeyDown(pillerSmaskarn) && remainingPills > 0)
            {
                takePill();
            }
            else if (Input.GetKeyDown(pillerSmaskarn) && remainingPills <= 0)
            {

            }
        }
       
    }
}
