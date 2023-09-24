using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Load : MonoBehaviour
{
    [Inject] ISlotSaved slotSaved;

    private SaveManager saveManager;
    private MenuController menuController;

    #region panelLoad
    [SerializeField] Button[] _loadSave = new Button[3];
    #endregion

    private void Awake()
    {
        menuController = GetComponent<MenuController>();
        saveManager = GetComponent<SaveManager>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < _loadSave.Length; i++)
        {
            int index = i;
            _loadSave[i].onClick.AddListener(() => LoadGame(index));
        }
    }

    private void Update()
    {
        if (slotSaved.slot1Saved) _loadSave[0].interactable = true;
        else _loadSave[0].interactable = false;

        if (slotSaved.slot2Saved) _loadSave[1].interactable = true;
        else _loadSave[0].interactable = false;

        if (slotSaved.slot3Saved) _loadSave[2].interactable = true;
        else _loadSave[0].interactable = false;
    }
    private void LoadGame(int index)
    {
        switch (index)
        {
            case 0: saveManager.LoadToFile("Slot1.txt"); break;
            case 1: saveManager.LoadToFile("Slot2.txt"); break;
            case 2: saveManager.LoadToFile("Slot3.txt"); break;
        }
        SceneManager.LoadScene(menuController._mainScene);
    }
}
