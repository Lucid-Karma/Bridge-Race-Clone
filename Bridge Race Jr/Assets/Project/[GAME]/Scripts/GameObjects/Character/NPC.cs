using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ExecutingState
{
    BEAR,
    PATROL
}
public class NPC : CharacterBase
{
    public GameObject stackParent;
    public GameObject refObject;
    
    Vector3 direction;
    Quaternion rotation;
    /*[SerializeField] private*/ public float turnSpeed, moveSpeed;
    Vector3 newPos;
    public GameObject targetPos;

    public Rigidbody rb;
    private Animator animator;

    NPC_PositionCreater positionCreate = new NPC_PositionCreater();

    [SerializeField] private GameObject[] bridge;


    NPC_States currentState;

    public PatrolState patrolState = new PatrolState();
    public BearState bearState = new BearState();

    public ExecutingState executingState;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        targetPos.SetActive(false);
    }

    void OnEnable()
    {
        targetPos.SetActive(true);
    }

    void Start()
    {
        executingState = ExecutingState.PATROL;

        GetBridgeTransform();
        
        currentState = patrolState;
        currentState.EnterState(this);  // ????

        newPos = positionCreate.SetNPCPosition(targetPos).transform.position;
        animator.SetBool("isRunning", true);
    }

    void FixedUpdate()
    {
        currentState.UpdateState(this);
    }

    public override void Move()
    {
        direction = (newPos - transform.position).normalized;
        rotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed); // Smooth change rotation
    }

    public override void OnTriggerEnter(Collider other)
    {
        if (!enabled) return;
        
        // StackParent = stackParent;
        // RefObject = refObject;
        StackParent = stackParent;

        SRefObject = refObject;
        RefObject = SRefObject;
        
        base.OnTriggerEnter(other);

        if(inBridge && GetList().Count > 0)
        {
            transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y + 0.5f
            , transform.position.z);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (!enabled) return;

        if (other.gameObject == targetPos)
        {
            newPos = positionCreate.SetNPCPosition(targetPos).transform.position;
        }
    }

    #region BUILD

    float collectTime;
    public float GetBuidTime()
    {
        collectTime = Random.Range(3f, 20f);
        return collectTime;
    }
    public IEnumerator BuildWait(float duration)
    {
        yield return new WaitForSeconds(duration);
        executingState = ExecutingState.BEAR;
    }

    int bridgeIndex;
    Transform bridgeTransform;
    public void GetBridgeTransform()
    {
        bridgeIndex = Random.Range(0, bridge.Length);
        bridgeTransform = bridge[bridgeIndex].transform;
    }

    public void MoveToBridge()
    {
        direction = (bridgeTransform.position - transform.position).normalized;
        rotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed);
    }
    Vector3 goBackPos;
    public int stairStep;
    public void LeaveBridge()
    {
        stairStep = GetList().Count;
        goBackPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y
            , gameObject.transform.position.z * -1);

        direction = (goBackPos - transform.position).normalized;
        rotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed);

        if(stairStep == 0)  executingState = ExecutingState.PATROL;
    }

    public List<GameObject> GetList()
    {
        if(gameObject.CompareTag("blue"))   return blueBrickList;
        else if(gameObject.CompareTag("green"))     return greenBrickList;
        else if(gameObject.CompareTag("red"))   return redBrickList;

        return null;
    }

    void OnTriggerExit(Collider other)
    {
        if (!enabled) return;

        IInteractable interactable = other.GetComponent<IInteractable>();

        if(other.gameObject.name == "bridgeColliderArea")
        {
            inBridge = false;
        }

        if (inBridge)
        {
            if(interactable != null && GetList().Count <= 0)
            {
                transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y - 0.5f
                , transform.position.z);
            }
        }
    }
    
    #endregion

    public void SwitchState(NPC_States nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
