using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Zenject;

public class DeleteButton : MonoBehaviour
{
    [HideInInspector]
    public string fileException = ".txt";

    [Inject] private ISlotSaved slotSaved;

    [SerializeField] private Button _deleteButton;

    private void Start()
    {
        _deleteButton.onClick.AddListener(DeleteAllSave);
    }

    private void DeleteAllSave()
    {
        string saveDirectory = Application.persistentDataPath;

        string[] filesToDelete = Directory.GetFiles(saveDirectory, "*" + fileException);

        foreach (var FileDelete in filesToDelete)
        {
            File.Delete(FileDelete);
            Debug.Log("Delete " + FileDelete);
        }
        ChangeBoolSaved();
    }

    private void ChangeBoolSaved()
    {
        slotSaved.GetFalse(0);
        slotSaved.GetFalse(1);
        slotSaved.GetFalse(2);
    }
}
