using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//This script is for saving the game - Adrians
public static class SaveSystem
{
    //Function for saving the keybinds - Adrian
    public static void SaveBinds(KeyBinds keybinds)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/keybinds.boom"; //Creates the path where the file will be saved - Adrian
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(keybinds);

        formatter.Serialize(stream, data); //Writes the data - Adrian
        stream.Close();
    }

    public static void SaveScene(KeyBinds sceneM)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scene.boom"; //Creates the path where the file will be saved - Adrian
        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(sceneM);

        formatter.Serialize(stream, data); //Writes the data - Adrian
        stream.Close();
    }

    //Loads the saved keybinds - Adrian
    public static SaveData loadBinds()
    {
        string path = Application.persistentDataPath + "/keybinds.boom";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); //Opens the savefile - Adrian

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static SaveData loadScene()
    {
        string path = Application.persistentDataPath + "/scene.boom";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); //Opens the savefile - Adrian

            SaveData data = formatter.Deserialize(stream) as SaveData;
            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
