using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    public int scene;

    public void SceneChange()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        scene = SceneManager.GetActiveScene().buildIndex;
        SaveSystem.SaveScene(this);
    }
}
