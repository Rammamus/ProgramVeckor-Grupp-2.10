using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script manages the scene/day that you are in - Adrian
public class SceneManage : MonoBehaviour
{
    public int scene; //Gets saved so when you load the game later you join the scene you were in before you quit - Adrian

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
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void LoadSceneData()
    {
        SaveData data = SaveSystem.LoadScene();
        scene = data.scene;
        SceneManager.LoadScene(scene);
    }
}
