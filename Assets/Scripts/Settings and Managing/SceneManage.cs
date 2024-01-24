using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//This script manages the scene/day that you are in - Adrian
public class SceneManage : MonoBehaviour
{
    public int scene; //Gets saved so when you load the game later you join the scene you were in before you quit - Adrian

    public bool isSchoolScene;

    [SerializeField] float dayLength;
    public GameObject[] skolpojkar;
    public GameObject[] soldater;
    public bool bytaArray = false;
    public Sanity sanity;
    public bool fullyPassed;
    public TextMeshProUGUI clock;

    int minutes;
    public int hours;
    float seconds;
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SaveScene(this);
        StartCoroutine(Spawnobject());
        UpdateClock();
    }

    private void Update()
    {
        //Simple countdown for the day if it's a school scene - Adrian
        if (isSchoolScene)
        {
            seconds += Time.deltaTime;
            if (seconds > 2)
            {
                minutes++;
                seconds = 0;
                UpdateClock();
            }
            if (minutes >= 60)
            {
                hours++;
                minutes = 0;
                UpdateClock();
            }
            if (hours >= 23)
            {
                EndDay();
            }
        }
    }
    IEnumerator Spawnobject()
    {
        int i = 0;
        while (hours < 23 && i < 1000 )
        {
            GameObject[] Spawnobject = bytaArray ? soldater : skolpojkar;
            foreach (GameObject obj in skolpojkar)
            {
                obj.SetActive(true);
                yield return new();
            }
            i++;
        }
        if (sanity.insanePercentage > 0.8)
        {
            bytaArray = !bytaArray;
        }
        if (sanity.insanePercentage < 0.8)
        {
            bytaArray = true;
        }
    }

    //Ends the day, if you passed the level you go to next scene, if you don't you go back one - Adrian
    public void EndDay()
    {
        if (fullyPassed)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            SaveSystem.SaveScene(this);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void GoToWork()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Loads the scene which was last saved - Adrian
    public void LoadSceneData()
    {
        SaveData data = SaveSystem.LoadScene();
        scene = data.scene;
        SceneManager.LoadScene(scene);
    }

    public void UpdateClock()
    {
        if (minutes < 10)
        {
            clock.text = hours + ":0" + minutes;
        }
        else
        {
            clock.text = hours + ":" + minutes;
        }
    }
}
