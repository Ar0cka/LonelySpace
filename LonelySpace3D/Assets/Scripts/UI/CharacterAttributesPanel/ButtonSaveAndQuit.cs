using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonSaveAndQuit : MonoBehaviour
{
    [Header("Panel")]
    [SerializeField] private GameObject panel;

    [Header("Button")]
    [SerializeField] private Button showSavePanel;
    [SerializeField] private Button saveAttributes;
    [SerializeField] private Button closePanel;

    [Header("Scene")]
    [SerializeField] private string mainScene;

    [Header("CharacterAttributes")]
    [SerializeField] private AttributesController attributesController; 

    private void Start()
    {
        panel.SetActive(false);
    }

    private void OnEnable()
    {
        showSavePanel.onClick.AddListener(ShowPanel);
        saveAttributes.onClick.AddListener(SaveAttributes);
        closePanel.onClick.AddListener(ClosePanel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ShowPanel();   
        }
    }

    private void ShowPanel()
    {
        panel.SetActive(true);
    }

    private void SaveAttributes()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(mainScene);

    }

    private void ClosePanel()
    {
        panel.SetActive(false);
    }

    private void OnDisable()
    {
        showSavePanel.onClick.RemoveListener(ShowPanel);
        saveAttributes.onClick.RemoveListener(SaveAttributes);
        closePanel.onClick.RemoveListener(ClosePanel);
    }
}
