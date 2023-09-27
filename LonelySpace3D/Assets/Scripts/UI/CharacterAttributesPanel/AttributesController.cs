using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class AttributesController : MonoBehaviour
{
    [Inject] private ICharacterAttributes characterAttributes; // inject ���������
    #region Serialize
    [Header("TextMeshPro")]
    [SerializeField] private TextMeshProUGUI[] textAttributes = new TextMeshProUGUI[6]; //������ ����, ������� ��������� �� ���������� ������������� ��������
    [SerializeField] private TextMeshProUGUI pointQuality; // ���������� �������
    [Header("Buttons")]
    [SerializeField] private Button[] buttonMines = new Button[6]; // ������ ������ ���������� �� ��������� ��������
    [SerializeField] private Button[] buttonPlus = new Button[6]; // ������ ������ ���������� �� ����������� ���������

    [HideInInspector]
    private SaveManager saveManager; // ����� � ������� ����������� ������ ���������� ������ � ����� � ������� Json
    [HideInInspector]
    public CharacterData characterAttributesData; // ����� ������� ������ � ���� ������ ��� �������� � �������� ������.

    private void Awake()
    {
        saveManager = GetComponent<SaveManager>();

        if (CurrentSlot.currentSlot == 1) // �������� �� ��, ����� ���� ��� �������
            LoadAttributesFromFile("Slot1.txt");

        else if (CurrentSlot.currentSlot == 2)
            LoadAttributesFromFile("Slot2.txt");

        else if (CurrentSlot.currentSlot == 3)
            LoadAttributesFromFile("Slot3.txt");

        else LoadAttributesFromFile("Slot1.txt");

        UpdateUI(); // ���������� ����������
    }

    #endregion
    #region AddListener and CharacterAttributsInitialize 

    private void Start()
    {
        // ������������� �������� ��������� ����� � ������
        for (int i = 0; i < 6; i++)
        {
            // ����������� ������ ���������� � ���������� ��������� �� ������
            int index = i; // ������� ��������� ����������, ����� �������� ���������
            buttonPlus[i].onClick.AddListener(() => IncreaseAttribute(index));
            buttonMines[i].onClick.AddListener(() => DecreaseAttribute(index));
        }  
    }
    #endregion
    #region UpdateUI
    private void UpdateUI()
    {
        // ���������� ��������� ����� ��� ����������� ������� �������� ���������
        for (int i = 0; i < 6; i++)
        {
            textAttributes[i].text = $"{GetAttributeValue(i)}";
        }
        pointQuality.text = "Quality point: " + characterAttributes.point;
    }

    private int GetAttributeValue(int index)
    {
        // ����� ��� ��������� �������� �������� �� �������
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
    private void IncreaseAttribute(int index) // ����������� ��������
    {
            characterAttributes.IncreaseAttribute(index);
            UpdateUI();
    }

    private void DecreaseAttribute(int index) // ��������� ���������
    {
            characterAttributes.DecreaseAttribute(index);
            UpdateUI();
    }
    #endregion
    private void LoadAttributesFromFile(string filePath) // �������� ������ �� �����.
    {
        characterAttributesData = saveManager.LoadToFile(filePath);
        characterAttributes.LoadCharacterData(characterAttributesData);
    }
}
