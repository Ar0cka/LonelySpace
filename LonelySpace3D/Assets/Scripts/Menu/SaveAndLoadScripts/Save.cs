using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class Save : MonoBehaviour
{
    [Inject] ICharacterAttributes characterAttributes;
    [Inject] ISlotSaved slotSaved;

    private SaveManager saveManager;

    private MenuController menuController;


    #region panelSave
    [Header("Save buttons")]
    [SerializeField] Button[] _panelSaveButton = new Button[3];
    #endregion

    private void Awake()
    {
        menuController = GetComponent<MenuController>();
        saveManager = GetComponent<SaveManager>();
    }


    #region OnEnableAndDisable
    private void OnEnable()
    {
        for (int i = 0; i < 3; i++)
        {
            int index = i;
            _panelSaveButton[i].onClick.AddListener(() => SaveButtons(index));
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < 3; i++)
        {
            _panelSaveButton[i].onClick.RemoveAllListeners();
        }
    }
    #endregion
    #region SaveButton
    private void SaveButtons(int index)
    {
        characterAttributes.BeginAttributes();
        GameData data = new GameData();
        characterAttributes.SaveCharacterData(data);

        switch (index)
        {
            case 0:
                if (!slotSaved.slot1Saved)
                {
                    saveManager.SaveToFile(menuController.slotName[0], data);
                    slotSaved.CheckSlot(menuController.slotName[0]);
                    slotSaved.GetTrue(0);
                }
                break;
            case 1:
                if (!slotSaved.slot2Saved)
                {
                    saveManager.SaveToFile(menuController.slotName[1], data);
                    slotSaved.CheckSlot(menuController.slotName[1]);
                    slotSaved.GetTrue(1);
                }
                break;
            case 2:
                if (!slotSaved.slot3Saved)
                {
                    saveManager.SaveToFile(menuController.slotName[2], data);
                    slotSaved.CheckSlot(menuController.slotName[2]);
                    slotSaved.GetTrue(2);
                }
                break;
        }
        SlotSavedData slotSavedData = new SlotSavedData(slotSaved.slot1Saved, slotSaved.slot2Saved, slotSaved.slot3Saved);
        saveManager.SaveToFileSlotData("SlotData.txt", slotSavedData);
        SceneManager.LoadScene(menuController._mainScene);
    }
    #endregion
}
