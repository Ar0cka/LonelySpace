using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MenuController : MonoBehaviour
{
    [SerializeField] string _mainScene;
    #region initial
    [Inject] ICharacterAttributes characterAttributes;
    private SaveManager saveManager;
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
        saveManager = GetComponent<SaveManager>();

        _loadGame.onClick.AddListener(ClickNewGameAndLoadGame);
        _newGame.onClick.AddListener(ClickNewGameAndLoadGame);

        _loadGame.interactable = false;
        _panelLoadAdnSave.SetActive(false);
    }
    #region OnEnabledOrOnDisableMenu
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

        SceneManager.LoadScene(_mainScene);
    }
}
