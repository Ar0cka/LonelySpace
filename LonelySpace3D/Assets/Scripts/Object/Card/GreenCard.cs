using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenCard : MonoBehaviour, IItemInteractable
{
    private bool isTrigger = false;
    private bool isObjectUp = false;
    [SerializeField] private GameObject greenCard;

    private StateObjectSingleton singleton;

    private void Awake()
    {
        try
        {
            singleton = StateObjectSingleton.Instance;
        }
        catch (Exception e)
        {
            Debug.LogException(e);
        }

        if (singleton != null && greenCard != null)
            singleton.AddNewObjectInDictionary(greenCard, isObjectUp);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
        }
    }

    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.F))
            Interact();
    }

    public void Interact()
    {
        isObjectUp = true;
        singleton.AddNewObjectInDictionary(greenCard, isObjectUp);
        Destroy(greenCard);
    }
}
