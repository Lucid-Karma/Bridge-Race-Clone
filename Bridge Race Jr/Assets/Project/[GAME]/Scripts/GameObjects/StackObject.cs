using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackObject : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        StackManager.Instance.CollectStackObject(gameObject);
    }
}
