using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public enum BrickType
// {
//     BLUE,
//     GREEN,
//     RED
// }
public abstract class CharacterBase : MonoBehaviour
{

    public static GameObject StackParent;
    public static GameObject RefObject;

    //public BrickType brickType;

    public static List<GameObject> blueBrickList = new List<GameObject>();
    public static List<GameObject> greenBrickList = new List<GameObject>();
    public static List<GameObject> redBrickList = new List<GameObject>();


    // private GameObject stackParent;
    // public GameObject StackParent
    // {
    //     get
    //     {
    //         // if(stackParent != null)
    //         // {
    //              return stackParent;
    //         // }
    //         // else
    //         // {
    //         //     return null;
    //         // }
    //     }

    //     set
    //     {
    //         stackParent = value;
    //     }
    // }

    public void Awake()
    {
        this.enabled = false;
    }

    public abstract void Move();

    public virtual void OnTriggerEnter(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null && other.gameObject.CompareTag(gameObject.tag) )//|| other.gameObject.CompareTag("Stair"))
        {
            //interactable.Interact();

            if (other.gameObject.CompareTag("blue"))
            {
                blueBrickList.Add(other.gameObject);
            }
            else if (other.gameObject.CompareTag("green"))
            {
                greenBrickList.Add(other.gameObject);
            }
            else if (other.gameObject.CompareTag("red"))
            {
                redBrickList.Add(other.gameObject);
            }
            
            interactable.Interact();
        }
    }
}
