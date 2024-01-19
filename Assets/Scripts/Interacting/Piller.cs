using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piller : MonoBehaviour
{
    public int pillAmount;

    //Minskar piller med ett n�r man �ter ett -Filip
    void takePill()
    {
        pillAmount -= 1;
        print(pillAmount + " Remaining Pills");
    }

    // Tar ett piller om man klickar p� knappen och har piller kvar att ta -Filip
    void Update()
    {
        if (gameObject.transform.parent != null)
        {
            if (Input.GetKeyDown(KeyBinds.useItem) && pillAmount > 0)
            {
                takePill();
                FindObjectOfType<Sanity>().ChangeSanity(-250);
            }
            else if (Input.GetKeyDown(KeyBinds.useItem) && pillAmount <= 0)
            {

            }
        }
    }
}
