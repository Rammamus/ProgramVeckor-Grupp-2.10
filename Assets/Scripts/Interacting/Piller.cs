using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piller : MonoBehaviour
{
    public int pillAmount;

    //Minskar piller med ett när man äter ett -Filip
    void takePill()
    {
        pillAmount -= 1;
        FindObjectOfType<AudioManager>().PlaySFX(FindObjectOfType<AudioManager>().svaljaljud);
        FindObjectOfType<Sanity>().ChangeSanity(-250);
    }

    // Tar ett piller om man klickar på knappen och har piller kvar att ta -Filip
    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            if (Input.GetKeyDown(KeyBinds.useItem) && pillAmount > 0)
            {
                takePill();
            }
            else if (Input.GetKeyDown(KeyBinds.useItem) && pillAmount <= 0)
            {

            }
        }
    }
}
