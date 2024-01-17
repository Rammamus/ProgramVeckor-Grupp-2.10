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
    public KeyCode moveBackward;
    public KeyCode interact;
    public KeyCode converse;

    public SaveData(KeyBinds keybinds)
    {
        moveLeft = KeyBinds.moveLeft;
        moveRight = KeyBinds.moveRight;
        moveForward = KeyBinds.moveForward;
        moveBackward = KeyBinds.moveBackward;
        interact = KeyBinds.interact;
        converse = KeyBinds.converse;
    }

    public SaveData(SceneManage scenemanager)
    {
        scene = scenemanager.scene;
    }
}
