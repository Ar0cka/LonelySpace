using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    private bool isTrigerZone = false;
    public bool isGeneratorActivated { get; private set; }

    private void Start()
    {
        isGeneratorActivated = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigerZone = true;
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigerZone = false;
            
        }  
    }

    private void Update()
    {
        if (!isGeneratorActivated && isTrigerZone && Input.GetKeyUp(KeyCode.F))
                OnGeneration();
    }

    private void OnGeneration()
    {
        isGeneratorActivated = true;
    }
}
