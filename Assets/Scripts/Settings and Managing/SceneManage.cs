using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script manages the scene/day that you are in - Adrian
public class SceneManage : MonoBehaviour
{
    public int scene; //Gets saved so when you load the game later you join the scene you were in before you quit - Adrian

    [SerializeField] float dayLength;
    public GameObject[] skolpojkar;
    public GameObject[] soldater;
    private bool Bytaarray = false;
    public Sanity sanity;
    public bool fullyPassed;

    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SaveScene(this);
        StartCoroutine(Spawnobject());
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
    IEnumerator Spawnobject()
    {
        int i = 0;
        while (dayLength > 0 && i < 1000 )
        {
            GameObject[] Spawnobject = Bytaarray ? soldater : skolpojkar;
            foreach (GameObject obj in skolpojkar)
            {
                obj.SetActive(true);
                yield return new WaitForSeconds(20);
            }
            i++;
        }
        if (sanity.insanePercentage > 0.8)
        {
            Bytaarray = !Bytaarray;
        }
        if (sanity.insanePercentage < 0.8)
        {
            Bytaarray = true;
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
}
