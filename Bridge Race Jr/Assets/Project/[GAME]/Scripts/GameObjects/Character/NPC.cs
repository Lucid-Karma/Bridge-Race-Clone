using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : CharacterBase
{
    public GameObject stackParent;
    public GameObject refObject;
    
    Vector3 direction;
    Quaternion rotation;
    [SerializeField] private float turnSpeed, moveSpeed;
    Vector3 newPos;
    public GameObject targetPos;

    private Rigidbody rb;
    private Animator animator;

    NPC_PositionCreater positionCreate = new NPC_PositionCreater();
    
    //NPC_States currentState;


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
        newPos = positionCreate.SetNPCPosition(targetPos).transform.position;
        animator.SetBool("isRunning", true);
    }

    void FixedUpdate()
    {
        Move();
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.fixedDeltaTime));
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
        
        StackParent = stackParent;
        RefObject = refObject;
        
        base.OnTriggerEnter(other);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == targetPos)
        {
            newPos = positionCreate.SetNPCPosition(targetPos).transform.position;
        }
    }

    // public void SwitchState(NPC_States nextState)
    // {
    //     currentState = nextState;
    //     currentState.EnterState(this);
    // }
}
