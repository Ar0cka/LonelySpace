using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AttributesController : MonoBehaviour
{
    private ICharacterAttributes characterAttributes;

    // ������� ��� �������� ��������� ����� � ������
    [SerializeField] private TextMeshProUGUI[] textAttributes = new TextMeshProUGUI[6];
    [SerializeField] private Button[] buttonMines = new Button[6];
    [SerializeField] private Button[] buttonPlus = new Button[6];

    private void Awake()
    {
        characterAttributes = CharacterAttributesSingleton.Instance.CharacterAttributes;
    }

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

        // ���������� ���������� ��� �������
        UpdateUI();
    }

    private void UpdateUI()
    {
        // ���������� ��������� ����� ��� ����������� ������� �������� ���������
        for (int i = 0; i < 6; i++)
        {
            textAttributes[i].text = $"{GetAttributeValue(i)}";
        }
        Debug.Log("���� " + characterAttributes.strength + " �������� " + characterAttributes.agility + " �������� " + characterAttributes.intelligence + " ����� " + characterAttributes.craft + " ���������� " +
           characterAttributes.stealth + " ����������� " + characterAttributes.garden);
    }

    private int GetAttributeValue(int index)
    {
        // ����� ��� ��������� �������� �������� �� �������
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
        // ����� ��� ���������� �������� �� �������
        switch (index)
        {
            case 0:
                characterAttributes.strength += 1;
                Debug.Log("������"); break;
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
        // ����� ��� ���������� �������� �� �������
        switch (index)
        {
            case 0:
                characterAttributes.strength -= 1;
                Debug.Log("������"); break;
            case 1: characterAttributes.agility -= 1; break;
            case 2: characterAttributes.intelligence -= 1; break;
            case 3: characterAttributes.craft-= 1; break;
            case 4: characterAttributes.stealth -= 1; break;
            case 5: characterAttributes.garden -= 1; break;
        }

        UpdateUI();
    }
}
