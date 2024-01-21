using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script for the cleaning task - Adrian
public class CleaningTask : Tasks
{
    float cleaningProgress;
    [SerializeField] float cleaningTime;
    [SerializeField] GameObject slider;

    public override void StopTask()
    {
        base.StopTask();
        cleaningProgress = 0;
        slider.SetActive(false);
    }
    public override void DoTask()
    {
        base.DoTask();
        if (Input.GetKey(KeyBinds.interact))
        {
            cleaningProgress += Time.deltaTime;
            slider.SetActive(true);
            slider.GetComponent<Slider>().value = cleaningProgress/cleaningTime;
        }
        if (cleaningProgress > cleaningTime)
        {
            taskDone = true;
            slider.SetActive(false);
        }
        if (Input.GetKeyUp(KeyBinds.interact))
        {
            StopTask();
        }
    }
}