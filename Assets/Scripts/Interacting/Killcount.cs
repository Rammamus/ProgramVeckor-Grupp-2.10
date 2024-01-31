using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killcount : MonoBehaviour
{
    public int killcount;
    public GameObject[] Soldater;
    public GameObject[] barn;
    public Sanity sanity;
    // Update is called once per frame
    void Update()
    {
        /* if (sanity.insanePercentage >= 0.75)
         {
             for (int i = 0; i < Soldater.Length; i++)
             {
                 Soldater[i].SetActive(true);
             }
             for (int i = 0; i < barn.Length; i++)
             {
                 barn[i].SetActive(false);
             }
         }
         if (sanity.insanePercentage < 0.75)
         {
             for (int i = 0; i < Soldater.Length; i++)
             {
                 Soldater[i].SetActive(false);
             }
             for (int i = 0; i < barn.Length; i++)
             {
                 barn[i].SetActive(true);
             }
         }*/
        if (killcount <= 2)
        {

        }
    }
}
