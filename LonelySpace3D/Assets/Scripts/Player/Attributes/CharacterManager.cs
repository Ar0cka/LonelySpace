using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class CharacterManager : MonoBehaviour
{
   [Inject] private ICharacterAttributes characterAttributes;

    private void Start()
    {
        //characterAttributes.BeginAttributes();
    }
}
