using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AttributesController : MonoBehaviour
{
    [Inject] private ICharacterAttributes characterAttributes; // inject интерфейс
    #region Serialize
    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI[] textAttributes = new TextMeshProUGUI[6]; //массив цифр, которые указывают на количество определенного атрибута
    [SerializeField] private TextMeshProUGUI pointQuality; // количество поинтов
    [Header("Buttons")]
    [SerializeField] private Button[] buttonMines = new Button[6]; // массив кнопок отвечающих за вычитание атрибута
    [SerializeField] private Button[] buttonPlus = new Button[6]; // массив кнопок отвечающий за прибавление атрибутов

    [HideInInspector]
    private SaveManager saveManager; // класс в котором реализованы методы сохранени€ данных в файле в формате Json
    [HideInInspector]
    public CharacterData characterAttributesData; // класс который хранит в себе данные дл€ выгрузки и загрузки данных.

    private void Awake()
    {
        saveManager = GetComponent<SaveManager>();

        if (CurrentSlot.currentSlot == 1) // проверка на то, какой слот был включен
            LoadAttributesFromFile("Slot1.txt");

        else if (CurrentSlot.currentSlot == 2)
            LoadAttributesFromFile("Slot2.txt");

        else if (CurrentSlot.currentSlot == 3)
            LoadAttributesFromFile("Slot3.txt");

        else LoadAttributesFromFile("Slot1.txt");

        UpdateUI(); // обновление интерфейса
    }

    #endregion
    #region AddListener and CharacterAttributsInitialize 

    private void Start()
    {
        // »нициализаци€ массивов текстовых полей и кнопок
        for (int i = 0; i < 6; i++)
        {
            // ѕодписываем методы увеличени€ и уменьшени€ атрибутов на кнопки
            int index = i; // —оздаем локальную переменную, чтобы избежать замыкани€
            buttonPlus[i].onClick.AddListener(() => IncreaseAttribute(index));
            buttonMines[i].onClick.AddListener(() => DecreaseAttribute(index));
        }  
    }
    #endregion
    #region UpdateUI
    private void UpdateUI()
    {
        // ќбновление текстовых полей дл€ отображени€ текущих значений атрибутов
        for (int i = 0; i < 6; i++)
        {
            textAttributes[i].text = $"{GetAttributeValue(i)}";
        }
        pointQuality.text = "Quality point: " + characterAttributes.point;
    }

    private int GetAttributeValue(int index)
    {
        // ћетод дл€ получени€ значени€ атрибута по индексу
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
    private void IncreaseAttribute(int index) // прибавление атрибута
    {
            characterAttributes.IncreaseAttribute(index);
            UpdateUI();
    }

    private void DecreaseAttribute(int index) // вычитание аттрибута
    {
            characterAttributes.DecreaseAttribute(index);
            UpdateUI();
    }
    #endregion
    private void LoadAttributesFromFile(string filePath) // загрузка данных из файла.
    {
        characterAttributesData = saveManager.LoadToFile(filePath);
        characterAttributes.LoadCharacterData(characterAttributesData);
    }
}
