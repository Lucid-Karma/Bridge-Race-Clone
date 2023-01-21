using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterBase : MonoBehaviour
{

    public static GameObject StackParent;
    public static GameObject RefObject;

    public static GameObject SRefObject;


    public static List<GameObject> blueBrickList = new List<GameObject>();
    public static List<GameObject> greenBrickList = new List<GameObject>();
    public static List<GameObject> redBrickList = new List<GameObject>();

    public List<GameObject> usedBrickList = new List<GameObject>(); // This list is created to control whether a brick is already stack or not, to call only one of the StackManager main methods when a character triggered with refObject and brick at he same time because sometimes it causes some bugs due to not knowing currentList's last element. 


    public bool inBridge;

    //StackObject stackObject = new StackObject(true);

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

    // void Awake()
    // {
    //     this.enabled = false;
    // }

    public abstract void Move();

    public virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "bridgeColliderArea")   inBridge = true;

        IInteractable interactable = other.GetComponent<IInteractable>();

        if (interactable != null && other.gameObject.CompareTag(gameObject.tag) && !usedBrickList.Contains(other.gameObject))
        {
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
            usedBrickList.Add(other.gameObject);
        }
    }
}
