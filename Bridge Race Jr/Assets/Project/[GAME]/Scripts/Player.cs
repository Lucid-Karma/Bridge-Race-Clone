using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
   {
        if (other.gameObject.CompareTag("StackObj"))
        {
            StackManager.Instance.StackObject(other);
        }
   }
}
