using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StateType
{
    COLLECT,
    COLLIDE,
    BUILD
}
public abstract class CharacterBase : MonoBehaviour
{
    CharacterStates currentState;

    public CollectState collectState = new CollectState();
    public CollideState collideState = new CollideState();
    public BuildState buildState = new BuildState(); 

    public StateType stateType;

    public static GameObject StackParent;
    public static GameObject RefObject;

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

    void Awake()
    {
        this.enabled = false;
    }

    public void Start()
    {
        currentState = collectState;
        currentState.EnterState(this);
    }

    void Update()
    {
        currentState.UpdateState(this);
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
        else if(other.gameObject.CompareTag("Stair"))
        {
            stateType = StateType.BUILD;
            Debug.Log("build");
        }
    }

    public void SwitchState(CharacterStates nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
