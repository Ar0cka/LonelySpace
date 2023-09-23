using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuController : MonoBehaviour
{
    #region initial
    [Inject] ICharacterAttributes characterAttributes;

    [Header("Save manager")]
    [SerializeField] private SaveManager saveManager;
    #endregion
    #region LoadAndSaveButton
    [Header ("Button menu")]
    [SerializeField] Button _loadGame;
    [SerializeField] Button _newGame;
    #endregion

    #region panelSaveAndLoad
    [Header("Panel save and load")]
    [SerializeField] GameObject _panelLoadAdnSave;
    [SerializeField] Button[] _panelSaveButton = new Button[3];
    #endregion


    private void Start()
    {
        _loadGame.interactable = false;
        _panelLoadAdnSave.SetActive(false);
    }
    #region OnEnabledOrOnDisableMenu
    private void OnEnable()
    {
        _loadGame.onClick.AddListener(ClickNewGameAndLoadGame);
        _newGame.onClick.AddListener(ClickNewGameAndLoadGame);

        for (int i = 0; i < 3; i++)
        {
            int index = i;
            _panelSaveButton[i].onClick.AddListener(() => SaveButtons(index));
        }
    }

    private void OnDisable()
    {
        _loadGame.onClick.RemoveAllListeners();
        _newGame.onClick.RemoveAllListeners();

        for (int i = 0; i < 3; i++)
        {
            _panelSaveButton[i].onClick.RemoveAllListeners();
        }
    }
    #endregion
    private void ClickNewGameAndLoadGame()
    {
        _panelLoadAdnSave.SetActive (true);
    }

    private void SaveButtons(int index)
    {
        characterAttributes.BeginAttributes();
        CharacterAttributesData data = new CharacterAttributesData();
        characterAttributes.SaveCharacterData(data);

        switch (index)
        {
            case 0: saveManager.SaveToFile("Slot1.txt", data); break;
            case 1: saveManager.SaveToFile("Slot2.txt", data); break;
            case 2: saveManager.SaveToFile("Slot3.txt", data); break;
        }
    }


}
