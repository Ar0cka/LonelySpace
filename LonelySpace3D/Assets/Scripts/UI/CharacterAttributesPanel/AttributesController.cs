using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AttributesController : MonoBehaviour
{
    [Inject] private ICharacterAttributes characterAttributes;
    #region Serialize
    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI[] textAttributes = new TextMeshProUGUI[6];
    [SerializeField] private TextMeshProUGUI pointQuality;
    [Header("Buttons")]
    [SerializeField] private Button[] buttonMines = new Button[6];
    [SerializeField] private Button[] buttonPlus = new Button[6];


    #endregion
    #region AddListener and CharacterAttributsInitialize 
    private void Awake()
    { 
        string jsonData = PlayerPrefs.GetString("CharacterAttributesData", "");
        if (!string.IsNullOrEmpty(jsonData))
        {
            CharacterAttributesData data = JsonUtility.FromJson<CharacterAttributesData>(jsonData);
            characterAttributes.LoadCharacterData(data);
        }
        Debug.Log("Сила " + characterAttributes.Strength + " Ловкость " + characterAttributes.Agility + " интеллект " + characterAttributes.Intelligence + " крафт " + characterAttributes.Craft + " скрытность " +
   characterAttributes.Stealth + " садоводство " + characterAttributes.Garden);

        UpdateUI();

        pointQuality.text = "Quality point: " + characterAttributes.point;
    }

    private void Start()
    {
        // Инициализация массивов текстовых полей и кнопок
        for (int i = 0; i < 6; i++)
        {
            // Подписываем методы увеличения и уменьшения атрибутов на кнопки
            int index = i; // Создаем локальную переменную, чтобы избежать замыкания
            buttonPlus[i].onClick.AddListener(() => IncreaseAttribute(index));
            buttonMines[i].onClick.AddListener(() => DecreaseAttribute(index));
        }  
    }
    #endregion
    #region UpdateUI
    private void UpdateUI()
    {
        // Обновление текстовых полей для отображения текущих значений атрибутов
        for (int i = 0; i < 6; i++)
        {
            textAttributes[i].text = $"{GetAttributeValue(i)}";
        }
        pointQuality.text = "Quality point: " + characterAttributes.point;
    }

    private int GetAttributeValue(int index)
    {
        // Метод для получения значения атрибута по индексу
        switch (index)
        {
            case 0: return characterAttributes.Strength;
            case 1: return characterAttributes.Agility;
            case 2: return characterAttributes.Intelligence;
            case 3: return characterAttributes.Craft;
            case 4: return characterAttributes.Stealth;
            case 5: return characterAttributes.Garden;
            default: return 0;
        }
    }
    #endregion
    #region Increase and decrease Attributes
    private void IncreaseAttribute(int index)
    {
            characterAttributes.IncreaseAttribute(index);
            UpdateUI();
    }

    private void DecreaseAttribute(int index)
    {
            characterAttributes.DecreaseAttribute(index);
            UpdateUI();
    }
    #endregion
    public void CharacterAttributesUpdate()
    {
        CharacterAttributesData data = new CharacterAttributesData();
        characterAttributes.SaveCharacterData(data);

        string JsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("CharacterAttributesData", JsonData);
        PlayerPrefs.Save();
    }
}
