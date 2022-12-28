using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour, IInteractable
{
    public bool isBuilding { get; set; }

    public void Interact()
    {
        StackManager.Instance.CollectStackObject(gameObject);
    }
    
    // void OnTriggerEnter(Collider other)
    // {
    //     IInteractable interactable = other.GetComponent<IInteractable>();

    //     if (interactable != null && other.gameObject.CompareTag(gameObject.tag))
    //     {
    //         interactable.Interact();
    //     }
    // }
}
