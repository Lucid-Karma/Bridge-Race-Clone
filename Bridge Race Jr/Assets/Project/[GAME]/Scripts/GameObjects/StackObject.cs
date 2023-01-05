using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour, IInteractable
{
    //public bool isBuilding { get; set; }
    public static bool isBuilding;

    public void Interact()
    {
        // if (!Stair.isTriggered)
        // {
        //     StackManager.Instance.CollectStackObject(gameObject);
        // }
        // else    return;
        StackManager.Instance.CollectStackObject(gameObject);
    }
}
