using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private bool _isOpened;
    private bool isTrigger = false;

    [SerializeField] private Animator _animator;
    [SerializeField] Generator generator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = true;
            Debug.Log("EntexTrigerZone");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isTrigger = false;
            Debug.Log("ExitTrigerZone");
        }
    }

    private void Update()
    {
        if (isTrigger && Input.GetKeyDown(KeyCode.F))
            Open();
    }
        

    private void Open()
    {
       if (generator.isGeneratorActivated)
        {
            _animator.SetBool("isOpened", _isOpened);
            _isOpened = !_isOpened;
        }
    }
}
