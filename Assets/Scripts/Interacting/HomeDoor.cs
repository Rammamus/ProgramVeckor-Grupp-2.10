using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeDoor : MonoBehaviour
{
    [SerializeField] GameObject door;
    // Update is called once per frame
    void Update()
    {
        //I have been awake for more than 24 hours and this is all the logic my brain can produce - Adrian
        if (FindObjectOfType<InteractibleRaycast>().hit.transform == door)
        {
            Debug.Log("gets hit");
            if (Input.GetKeyDown(KeyBinds.interact))
            {
                FindObjectOfType<SceneManage>().GoToWork();
                Debug.Log("GoToWork");
            }
        }
    }
}
