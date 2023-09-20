using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonSaveAndQuit : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    [SerializeField] private Button showSavePanel;

    [SerializeField] private Button saveAttributes;
    [SerializeField] private Button closePanel;

    [SerializeField] private string mainScene;

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
            SaveAttributes();   
        }
    }

    private void ShowPanel()
    {
        panel.SetActive(true);
    }

    private void SaveAttributes()
    {
        SceneManager.LoadScene(mainScene);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
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
