using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAttributesSingleton : MonoBehaviour
{
    private static CharacterAttributesSingleton instance;

    private ICharacterAttributes characterAttributes;

    public static CharacterAttributesSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<CharacterAttributesSingleton>();
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject("CharacterAttributesSingleton");
                    instance = singletonObject.AddComponent<CharacterAttributesSingleton>();
                }
            }
            return instance;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public ICharacterAttributes CharacterAttributes
    {
        get { return characterAttributes; }
        set { characterAttributes = value; }
    }
}
