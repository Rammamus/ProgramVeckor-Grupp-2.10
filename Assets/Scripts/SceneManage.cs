using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script manages the scene/day that you are in - Adrian
public class SceneManage : MonoBehaviour
{
    public int scene; //Variable that will be saved if you quit the game so that you come back to where you left off - Adrian

    //Variables for the day timer, minute and hour is simply for aesthetic purposes - Adrian
    [SerializeField] float dayLength;

    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SaveScene(this);
    }

    private void Update()
    {
        //Simple countdown for the day - Adrian
        dayLength -= Time.deltaTime;
        if (dayLength <= 0)
        {
            EndDay();
        }
    }

    public void EndDay()
    {
        if (FindObjectOfType<TaskList>().passedTheLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SaveSystem.SaveScene(this);
        }
        else
        {
            Debug.Log("L");
        }
    }
}
