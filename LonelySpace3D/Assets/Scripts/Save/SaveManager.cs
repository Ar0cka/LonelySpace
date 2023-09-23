using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveToFile(string fileName, CharacterAttributesData characterData)
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
}
