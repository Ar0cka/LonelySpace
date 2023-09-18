using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttributesController : MonoBehaviour
{
    private ICharacterAttributes characterAttributes;

    // Массивы для хранения текстовых полей и кнопок
    [SerializeField] private TextMeshProUGUI[] textAttributes = new TextMeshProUGUI[6];
    [SerializeField] private Button[] buttonMines = new Button[6];
    [SerializeField] private Button[] buttonPlus = new Button[6];

    private void Awake()
    {
        characterAttributes = CharacterAttributesSingleton.Instance.CharacterAttributes;
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

        // Обновление интерфейса при запуске
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Обновление текстовых полей для отображения текущих значений атрибутов
        for (int i = 0; i < 6; i++)
        {
            textAttributes[i].text = $"{GetAttributeValue(i)}";
        }
        Debug.Log("Сила " + characterAttributes.strength + " Ловкость " + characterAttributes.agility + " интелект " + characterAttributes.intelligence + " крафт " + characterAttributes.craft + " скрытность " +
           characterAttributes.stealth + " садоводство " + characterAttributes.garden);
    }

    private int GetAttributeValue(int index)
    {
        // Метод для получения значения атрибута по индексу
        switch (index)
        {
            case 0: return characterAttributes.strength;
            case 1: return characterAttributes.agility;
            case 2: return characterAttributes.intelligence;
            case 3: return characterAttributes.craft;
            case 4: return characterAttributes.stealth;
            case 5: return characterAttributes.garden;
            default: return 0;
        }
    }

    private void IncreaseAttribute(int index)
    {
        // Метод для увеличения атрибута по индексу
        switch (index)
        {
            case 0:
                characterAttributes.strength += 1;
                Debug.Log("Нажата"); break;
            case 1: characterAttributes.agility+= 1; break;
            case 2: characterAttributes.intelligence += 1; break;
            case 3: characterAttributes.craft+= 1; break;
            case 4: characterAttributes.stealth += 1; break;
            case 5: characterAttributes.garden += 1; break;
        }

        UpdateUI();
    }

    private void DecreaseAttribute(int index)
    {
        // Метод для уменьшения атрибута по индексу
        switch (index)
        {
            case 0:
                characterAttributes.strength -= 1;
                Debug.Log("Нажата"); break;
            case 1: characterAttributes.agility -= 1; break;
            case 2: characterAttributes.intelligence -= 1; break;
            case 3: characterAttributes.craft-= 1; break;
            case 4: characterAttributes.stealth -= 1; break;
            case 5: characterAttributes.garden -= 1; break;
        }

        UpdateUI();
    }
}
