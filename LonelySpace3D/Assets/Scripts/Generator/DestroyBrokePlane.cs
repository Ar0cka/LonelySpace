using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DestroyBrokePlane : MonoBehaviour
{
    [SerializeField] GameObject brokePanel;
    [SerializeField] Collider triggerZoneGenerators;
    [SerializeField] Animator animator;

    private bool isDestroy;
    private bool isTrigger;

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
    void Update()
    {
        if (isTrigger && Input.GetKey(KeyCode.F))
            OnDestroyBrokePlane();
    }

    private void OnDestroyBrokePlane()
    {
        isDestroy = true;
        animator.SetBool("isDestroy", isDestroy);
        triggerZoneGenerators.enabled = true;
    }
}
