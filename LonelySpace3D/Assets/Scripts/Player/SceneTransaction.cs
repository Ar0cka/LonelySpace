using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransaction : MonoBehaviour
{
    [SerializeField] string characterAttributesScene;
    [SerializeField] string inventoryScene;

    private void Update()
    {
        #region LoadCharacterAttributesScene
        if (Input.GetKeyDown(KeyCode.N))
            LoadCharacterAttributesPanel();
        #endregion
        #region LoadInventoryScene
        if (Input.GetKeyDown(KeyCode.I))
            LoadInventoryScene();
        #endregion
    }
    private void LoadCharacterAttributesPanel()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(characterAttributesScene);
    }
    private void LoadInventoryScene()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(inventoryScene);
    }
}
