using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{
    private GameObject stackParent;
    public GameObject StackParent
    {
        get
        {
            if(stackParent != null)
            {
                return stackParent;
            }
            else
            {
                return null;
            }
        }

        set
        {
            stackParent = value;
        }
    }

    void Awake()
    {
        this.enabled = false;
    }

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
