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
        _loadSave[0].interactable = slotSaved.slot1Saved;
        _loadSave[1].interactable = slotSaved.slot2Saved;
        _loadSave[2].interactable = slotSaved.slot3Saved;
    }
    private void LoadGame(int index)
    {
        switch (index)
        {
            case 0: saveManager.LoadToFile("Slot1.txt"); CurrentSlot.currentSlot = 1; break; // загрузка файлов в зависимости от нажатой кнопки
            case 1: saveManager.LoadToFile("Slot2.txt"); CurrentSlot.currentSlot = 2; break;
            case 2: saveManager.LoadToFile("Slot3.txt"); CurrentSlot.currentSlot = 3; break;
        }
        SceneManager.LoadScene(menuController._mainScene);
    }
}
