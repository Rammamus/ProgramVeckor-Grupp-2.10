using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

//This script changes the keybinds for the player - Adrian
public class KeyBindSettings : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] buttons;
    int place;

    void Start()
    {
        //Goes through every button and changes their text to the corresponding keybind - Adrian
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].text = KeyBinds.keybinds[i].ToString();
        }
    }

    void Update()
    {
        if (buttons[place].text == "") //if a button has been pressed - Adrian
        {
            foreach (KeyCode keycode in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(keycode))
                {
                    buttons[place].text = keycode.ToString();
                    KeyBinds.UpdateBinds(place, keycode);
                }
            }
        }
    }

    //The function that is used when pressing a button for changing a key - Adrian
    public void ChangeKey(int i)
    {
        place = i;
        buttons[place].text = ""; //edits the corresponding button text to check if it has been pressed - Adrian
    }

    public void SaveAndBack()
    {
        KeyBinds.Save();
    }
}
