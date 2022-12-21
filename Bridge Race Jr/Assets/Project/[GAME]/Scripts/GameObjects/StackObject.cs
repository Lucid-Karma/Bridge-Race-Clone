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
}
