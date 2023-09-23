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
}
