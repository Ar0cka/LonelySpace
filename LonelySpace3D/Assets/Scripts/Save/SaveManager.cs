using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void SaveToFile(string fileName, CharacterData characterData) // ���������� ������ � ����
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName); // ����� ���� ����������

        try
        {
            string jsonDaTA = JsonUtility.ToJson(characterData); // ��������������� � Json ����
            File.WriteAllText(filePath, jsonDaTA); // ����������� ������ � ����
            Debug.Log("Save completed");
        }
        catch (Exception)
        {
            Debug.LogError("Error save");
        }
    }

    public CharacterData LoadToFile(string fileName) // �������� ������
    {
        string filePath = Path.Combine(Application.persistentDataPath, fileName);

        try
        {
            if (File.Exists(filePath)) // �������� �� ������������� �����
            {
                string jsonData = File.ReadAllText(filePath); // ������ ����� � Json �������
                CharacterData data = JsonUtility.FromJson<CharacterData>(jsonData); // �������� ������ �� Json � �����
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
    } // ���������� ��������������� �����

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
    } // �������� ������
}

public static class CurrentSlot // ������� ����
{
    public static int currentSlot = -1;  
}

public static class FileName // ��������� ����� � ����������� �� ������������ �����
{
    public static string[] slotName;

    public static string FileNameSlot()
    {
        if (CurrentSlot.currentSlot == 1)
            return slotName[0];
        if (CurrentSlot.currentSlot == 2)
            return slotName[1];
        if (CurrentSlot.currentSlot == 3)
            return slotName[2];

        return null;
    }
}
