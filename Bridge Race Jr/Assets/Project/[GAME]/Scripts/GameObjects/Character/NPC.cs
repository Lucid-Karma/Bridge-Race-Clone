using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : CharacterBase
{
    Vector3 direction;
    Quaternion rotation;
    [SerializeField] private float turnSpeed, moveSpeed;
    Vector3 newPos;
    public GameObject targetPos;

    private Rigidbody rb;

    NPC_PositionCreater positionCreate = new NPC_PositionCreater();
    NPC_States currentState;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        EventManager.OnTargetPositionReach.AddListener(UpdateTargetPosition);
    }
    void OnDisable()
    {
        EventManager.OnTargetPositionReach.RemoveListener(UpdateTargetPosition);
    }

    void Start()
    {
        newPos = positionCreate.SetNPCPosition(targetPos).transform.position;
    }

    void FixedUpdate()
    {
        Move();
        rb.MovePosition(transform.position + (transform.forward * moveSpeed * Time.fixedDeltaTime));
        //Move();
    }

    public override void Move()
    {
        direction = (newPos - transform.position).normalized;
        rotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, turnSpeed); // Smooth change rotation
    }

    public override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
    }

    private void UpdateTargetPosition()
    {
        newPos = positionCreate.SetNPCPosition(targetPos).transform.position;
        Debug.Log("target position: " + targetPos.transform.position);
    }

    public void SwitchState(NPC_States nextState)
    {
        currentState = nextState;
        currentState.EnterState(this);
    }
}
