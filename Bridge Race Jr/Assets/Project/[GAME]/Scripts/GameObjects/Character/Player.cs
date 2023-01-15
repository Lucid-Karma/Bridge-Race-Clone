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

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

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
        if (!enabled) return;
        

        StackParent = stackParent;

        SRefObject = refObject;
        RefObject = SRefObject;

        base.OnTriggerEnter(other);

        if(inBridge && joystick.Vertical > 0)
        {
            transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y + 0.5f
            , transform.position.z);
        }
   }

   public override void Move()
   {
       rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity.y, joystick.Vertical * moveSpeed * Time.fixedDeltaTime); 
   }

   IEnumerator GoDownStairs()
   {
        yield return new WaitForSeconds(.00025f);
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
   }


    void OnTriggerExit(Collider other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();

        if(other.gameObject.name == "bridgeColliderArea")
        {
            inBridge = false;
        }

        if (inBridge)
        {
            if(interactable != null && joystick.Vertical < 0)
            {
                transform.position = new Vector3(transform.position.x, other.gameObject.transform.position.y - 0.5f
                , transform.position.z);
            }
        }
    }
}
