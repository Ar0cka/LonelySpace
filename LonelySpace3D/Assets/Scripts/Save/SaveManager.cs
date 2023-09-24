using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveToFile(string fileName, GameData characterData)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            string jsonDaTA = JsonUtility.ToJson(characterData);
            File.WriteAllText(filePath, jsonDaTA);
            Debug.Log("Save completed");
        }
        catch (Exception)
        {
            Debug.LogError("Error save");
        }
    }

    public GameData LoadToFile(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            

            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                GameData data = JsonUtility.FromJson<GameData>(jsonData);
                Debug.Log("Load completed");
                return data;
            }
            else
            {
                Debug.LogWarning("File does not exists");
                return null;
            }
        }
        catch (Exception)
        {
            Debug.LogError("Error load");
            return null;
        }
    }

    public void SaveToFileSlotData(string fileName, SlotSavedData slotSavedData)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            string jsonDaTA = JsonUtility.ToJson(slotSavedData);
            File.WriteAllText(filePath, jsonDaTA);
            Debug.Log("Save completed");
        }
        catch (Exception)
        {
            Debug.LogError("Error save");
        }
    }

    public SlotSavedData LoadToFileSlotData(string fileName)
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            if (File.Exists(filePath))
            {
                string jsonData = File.ReadAllText(filePath);
                SlotSavedData data = JsonUtility.FromJson<SlotSavedData>(jsonData);
                Debug.Log("Load completed");
                return data;
            }
            else
            {
                Debug.LogWarning("File does not exists");
                return null;
            }
        }
        catch (Exception)
        {
            Debug.LogError("Error load");
            return null;
        }
    }
}
