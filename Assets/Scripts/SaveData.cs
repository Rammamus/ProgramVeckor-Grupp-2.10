using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//A script for all the data that will be saved - Adrian
[System.Serializable]
public class SaveData
{
    public int scene;

    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode moveForward;
    public KeyCode moveBack;
    public KeyCode interact;

    public SaveData(KeyBinds keybinds)
    {
        moveLeft = KeyBinds.moveLeft;
        moveRight = KeyBinds.moveRight;
        moveForward = KeyBinds.moveForward;
        moveBack = KeyBinds.moveBack;
        interact = KeyBinds.interact;
    }

    public SaveData(SceneManager scenemanager)
    {
        scene = scenemanager.scene;
    }
}
