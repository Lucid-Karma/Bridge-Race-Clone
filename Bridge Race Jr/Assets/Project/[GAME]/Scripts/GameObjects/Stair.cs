using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stair : MonoBehaviour, IInteractable
{
    //public bool isBuilding { get; set => true; }

    public void Interact()
    {
        Debug.Log("staired");
        StackManager.Instance.UseStackObject();
        
    }
}
