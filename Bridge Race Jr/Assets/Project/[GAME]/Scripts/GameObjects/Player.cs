using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : CharacterBase
{
    public float moveSpeed;
    public FixedJoystick joystick;
    private Rigidbody rb;

    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        /*Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);*/

        //Vector3 direction = Vector3.forward * joystick.Vertical + Vector3.right * joystick.Horizontal;
        //rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity.y, joystick.Vertical * moveSpeed * Time.fixedDeltaTime);
        Move();
    }

   public override void OnTriggerEnter(Collider other)
   {
        base.OnTriggerEnter(other);
   }

   public override void Move()
   {
       rb.velocity = new Vector3(joystick.Horizontal * moveSpeed * Time.fixedDeltaTime, rb.velocity.y, joystick.Vertical * moveSpeed * Time.fixedDeltaTime); 
   }
}
