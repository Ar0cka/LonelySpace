using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
   private ICharacterAttributes characterAttributes;

    private void Awake()
    {
        CharacterAttributesSingleton.Instance.CharacterAttributes = new CharacterAttributes();
        characterAttributes = CharacterAttributesSingleton.Instance.CharacterAttributes;
    }

    private void Start()
    {
        characterAttributes.BeginAttributes();
        Debug.Log("���� " + characterAttributes.strength + " �������� " + characterAttributes.agility + " ��������� " + characterAttributes.intelligence +
            " ���������� " + characterAttributes.stealth + " ����������� " + characterAttributes.garden);
    }
}
