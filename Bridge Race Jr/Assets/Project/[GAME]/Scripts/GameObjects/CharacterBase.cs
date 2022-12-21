using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBase : MonoBehaviour
{
    public virtual void Move()
    {
        
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null && other.gameObject.CompareTag(gameObject.tag))
        {
            interactable.Interact();
        }
    }
}
