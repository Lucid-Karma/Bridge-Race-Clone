using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour, IInteractable
{
    //public bool isBuilding { get; set => true; }

    public void Interact()
    {
        StackManager.Instance.UseStackObject();
    }
}
