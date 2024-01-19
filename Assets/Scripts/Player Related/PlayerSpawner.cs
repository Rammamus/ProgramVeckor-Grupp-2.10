using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Literally just spawns the player because it makes my life easier when testing - Adrian
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
    }
}
