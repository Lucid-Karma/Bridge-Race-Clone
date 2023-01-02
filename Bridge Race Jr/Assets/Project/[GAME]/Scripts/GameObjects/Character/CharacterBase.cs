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

    public static List<GameObject> BrickList = new List<GameObject>();
    //public BrickType brickType;

    // public List<GameObject> blueBrickList = new List<GameObject>();
    // public List<GameObject> greenBrickList = new List<GameObject>();
    // public List<GameObject> redBrickList = new List<GameObject>();

    CharactersArbiter charactersArbiter;


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

    void Awake()
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

            // if (other.gameObject.CompareTag("blue"))
            // {
            //     //brickType = BrickType.BLUE;
            //     blueBrickList.Add(other.gameObject);
            //     //BrickList = blueBrickList;
            // }
            // if (other.gameObject.CompareTag("green"))
            // {
            //     //brickType = BrickType.GREEN;
            //     greenBrickList.Add(other.gameObject);
            //     //BrickList = greenBrickList;
            // }
            // if (other.gameObject.CompareTag("red"))
            // {
            //     //brickType = BrickType.RED;
            //     redBrickList.Add(other.gameObject);
            //     //BrickList = redBrickList;
            // }

            BrickList.Add(other.gameObject);
            Debug.Log("base "+ BrickList[0].name);
            interactable.Interact();
        }
        // else if(interactable != null && other.gameObject.CompareTag("Stair"))
        // {
        //     interactable.Interact();
        // }
    }

    // public List<GameObject> GetCharacterList()
    // {
    //     if (charactersArbiter.brickType == BrickType.BLUE)
    //     {
    //         return blueBrickList;
    //     }
    //     else if (charactersArbiter.brickType == BrickType.GREEN)
    //     {
    //         return greenBrickList;
    //     }
    //     else if (charactersArbiter.brickType == BrickType.RED)
    //     {
    //         return redBrickList;
    //     }
    //     else    return null;
    // }
}
