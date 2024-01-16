using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds
{
    //Default keybinds used in the game - Adrian
    static public KeyCode moveLeft = KeyCode.A;
    static public KeyCode moveRight = KeyCode.D;
    static public KeyCode moveForward = KeyCode.W;
    static public KeyCode moveBackward = KeyCode.S;
    static public KeyCode interact = KeyCode.F;

    //The array of the keybinds that will later be used - Adrian
    static public KeyCode[] keybinds = {moveLeft, moveRight, moveForward, moveBackward, interact};

    //Function for saving the keybinds - Adrian
    static public void Save()
    {
        SaveSystem.SaveBinds(new KeyBinds());
    }

    //Function when loading the saved keybinds - Adrian
    static public void Load()
    {
        SaveData data = SaveSystem.LoadBinds();
        keybinds = new KeyCode[] { data.moveLeft, data.moveRight, data.moveForward, data.moveBackward, data.interact };
    }
}
