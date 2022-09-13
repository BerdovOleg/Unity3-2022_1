using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public int CurrentLevel;
    public int RecordBlock;
    bool isloda = false;

    private void Awake()
    {
        LoadGame();
        if (!isloda)
        {
            SaveGame(1, 0);
        }
    }

    public void SaveGame(int CurrentLevel, int RecordBlock)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.CurrentLevel = CurrentLevel;
        data.RecordBlock = RecordBlock;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
     + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            CurrentLevel = data.CurrentLevel;
            RecordBlock = data.RecordBlock;
            Debug.Log("Game data loaded!");
            isloda = true;
        }
        else
            Debug.LogError("There is no save data!");
    }


    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
    + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            SaveGame(1, 0);
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
}
