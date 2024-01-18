using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Guess what this script does - Adrian
public class KeyBinds
{
    //The array of the keybinds that will later be used - Adrian
    static public KeyCode[] keybinds = {KeyCode.A, KeyCode.D, KeyCode.W, KeyCode.S, KeyCode.F, KeyCode.Space, KeyCode.Escape, KeyCode.Mouse0};
    
    //Default keybinds used in the game - Adrian
    static public KeyCode moveLeft = keybinds[0];
    static public KeyCode moveRight = keybinds[1];
    static public KeyCode moveForward = keybinds[2];
    static public KeyCode moveBackward = keybinds[3];
    static public KeyCode interact = keybinds[4];
    static public KeyCode converse = keybinds[5];
    static public KeyCode pause = keybinds[6];
    static public KeyCode useItem = keybinds[7];

    static public void UpdateBinds(int i, KeyCode key)
    {
        keybinds[i] = key;
        moveLeft = keybinds[0];
        moveRight = keybinds[1];
        moveForward = keybinds[2];
        moveBackward = keybinds[3];
        interact = keybinds[4];
        converse = keybinds[5];
        pause = keybinds[6];
        useItem = keybinds[7];
    }

    //Function for saving the keybinds - Adrian
    static public void Save()
    {
        SaveSystem.SaveBinds(new KeyBinds());
    }

    //Function when loading the saved keybinds - Adrian
    static public void Load()
    {
        SaveData data = SaveSystem.LoadBinds();
        keybinds = new KeyCode[] { data.moveLeft, data.moveRight, data.moveForward, data.moveBackward, data.interact, data.converse, data.pause, data.useItem };
        for (int i = 0; i < keybinds.Length; i++)
        {
            UpdateBinds(i, keybinds[i]);
            Debug.Log(keybinds[i].ToString());
        }
    }
}
