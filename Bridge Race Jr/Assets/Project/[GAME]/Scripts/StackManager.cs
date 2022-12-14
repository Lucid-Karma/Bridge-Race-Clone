using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    private GameObject stackObject;
    [SerializeField] private GameObject stackParent;
    private float distanceBetweenObjects;

    /*void Start()
    {
        stackObject = ObjectPooler.Instance.ChangePosition(stack);
        distanceBetweenObjects = stackObject.transform.localScale.y;
    }*/

    public void StackObject(Collider stack)
    {
        stackObject = ObjectPooler.Instance.ChangePosition(stack);
        distanceBetweenObjects = stackObject.transform.localScale.y;
        stackObject.transform.parent = stackParent.transform;
        Vector3 desiredPos = stackParent.transform.localPosition;
        desiredPos.y += distanceBetweenObjects;
        
        stackObject.transform.localPosition = desiredPos; //new Vector3(stackParent.transform.position.x, distanceBetweenObjects, stackParent.transform.position.z);

        stackParent.transform.localPosition = stackObject.transform.localPosition;
    }
}
