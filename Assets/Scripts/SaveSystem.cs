using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//This script is for saving the game - Adrians
public static class SaveSystem
{
    //Function for saving the keybinds - Adrian
    public static void SaveBinds(KeyBinds keybinds)
    {
        //Creates the binaryformatter, the path where the data will be saved and the "stream" of data - Adrian
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/keybinds.boom";
        FileStream stream = new FileStream(path, FileMode.Create);
        SaveData data = new SaveData(keybinds);

        //Writes the data in the binary format and closes the stream - Adrian
        Debug.Log("Keybind data saved in " + path);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Function for saving the level you are in - Adrian
    public static void SaveScene(SceneManage sceneM)
    {
        //Creates the binaryformatter, the path where the data will be saved and the "stream" of data - Adrian
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/scene.boom";
        FileStream stream = new FileStream(path, FileMode.Create); 
        SaveData data = new SaveData(sceneM);

        //Writes the data in the binary format and closes the stream - Adrian
        Debug.Log("Scene data saved in " + path);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    //Loads the saved keybind data - Adrian
    public static SaveData LoadBinds()
    {
        //Gets the path the data *should be* saved in - Adrian
        string path = Application.persistentDataPath + "/keybinds.boom";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); //Opens the savefile/stream of data - Adrian

            SaveData data = formatter.Deserialize(stream) as SaveData; //"Unscrambles" the data from binary - Adrian
            stream.Close(); //Closes the savefile/stream of data - Adrian
            Debug.Log("Keybind data loaded from " + path);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    //Loads the saved scene data - Adrian
    public static SaveData LoadScene()
    {
        //Gets the path the data *should be* saved in - Adrian
        string path = Application.persistentDataPath + "/scene.boom";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); //Opens the savefile/stream of data - Adrian

            SaveData data = formatter.Deserialize(stream) as SaveData; //"Unscrambles" the data from binary - Adrian
            stream.Close();
            Debug.Log("Scene data loaded from " + path);
            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
