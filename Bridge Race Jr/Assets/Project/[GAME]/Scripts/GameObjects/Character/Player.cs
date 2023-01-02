using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public GameObject stackParent;
    public GameObject refObject;
    private List<GameObject> brickList = new List<GameObject>();

    public float moveSpeed;
    public FixedJoystick joystick;

    private Rigidbody rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private float activePitch, activeYaw;
    public void FixedUpdate()
    {
        /*Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);*/

        //Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        //rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity.y, joystick.Vertical * moveSpeed * Time.fixedDeltaTime);
        Move();

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

   public override void OnTriggerEnter(Collider other)
   {
        StackParent = stackParent;
        RefObject = refObject;

        base.OnTriggerEnter(other);

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
       rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity.y, joystick.Vertical * moveSpeed * Time.fixedDeltaTime); 
   }
}
