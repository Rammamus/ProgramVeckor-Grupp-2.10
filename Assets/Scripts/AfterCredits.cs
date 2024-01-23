using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AfterCredits : MonoBehaviour
{
    float timer = 0;
    [SerializeField] GameObject text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        text.transform.position += new Vector3(0, 30, 0) * Time.deltaTime;
        if (timer > 50)
        {
            SceneManager.LoadScene(0);
        }
    }
}
