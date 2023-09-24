using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class MenuController : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] public string _mainScene;

    [Inject] ISlotSaved slotSaved;

    private SaveManager saveManager;

    [HideInInspector]
    public string[] slotName = new string[3];

    #region LoadAndSaveButton
    [Header ("Button menu")]
    [SerializeField] Button _loadGame;
    [SerializeField] Button _newGame;
    #endregion

    #region Panels
    [Header("Panel save")]
    [SerializeField] GameObject _panelSave;
    [Header("Panel load")]
    [SerializeField] GameObject _panelLoadGame;
    #endregion
    private void Awake()
    {
        saveManager = GetComponent<SaveManager>();
        saveManager.LoadToFileSlotData("SlotData.txt");
    }
    private void Start()
    {

        _loadGame.onClick.AddListener(OpenLoadPanel);
        _newGame.onClick.AddListener(ClickNewGame);

        _loadGame.interactable = false;
        _panelSave.SetActive(false);
        _panelLoadGame.SetActive(false);

        for (int i = 0; i < slotName.Length; i++)
        {
            slotName[i] = "Slot" + (i + 1);
        }   
    }

    private void Update()
    {
        if (slotSaved.slot1Saved || slotSaved.slot2Saved || slotSaved.slot3Saved) _loadGame.interactable = true;
    }

    #region panelSaveGame
    private void ClickNewGame()
    {
        _panelSave.SetActive (true);
    }
    #endregion

    #region LoadGamePanel


    private void OpenLoadPanel()
    {
        _panelLoadGame.SetActive(true);
    }
    #endregion
}