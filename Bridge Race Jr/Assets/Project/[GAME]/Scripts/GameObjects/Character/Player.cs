using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public GameObject stackParent;
    public GameObject refObject;

    public float moveSpeed;
    public FixedJoystick joystick;
    private Animator animator;

    private Rigidbody rb;
//Vector3 pos;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = /*gameObject.*/GetComponent<Animator>();
        //pos.y = 0.6f;
    }

    //float y = 0;
    public void FixedUpdate()
    {
            Move();

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
            animator.SetBool("isRunning", true);    //animator.GetBool("isRunning")
        }
        else    animator.SetBool("isRunning", false);
    }

   public override void OnTriggerEnter(Collider other)
   {
        StackParent = stackParent;
        RefObject = refObject;

        SRefObject = refObject;

        base.OnTriggerEnter(other);
        // Debug.Log(transform.position);
        // y += 0.5f;
        // Debug.Log(transform.position);

        // if(other.gameObject.CompareTag("Stair"))
        // {
        //     if (joystick.Vertical != 0)
        //     {
        //         rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, joystick.Vertical * moveSpeed * Time.fixedDeltaTime, rb.velocity.z); 
        //     }
        // }
   }

   public override void Move()
   {
       rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity/*pos*/.y, joystick.Vertical * moveSpeed * Time.fixedDeltaTime); 
   }
}
