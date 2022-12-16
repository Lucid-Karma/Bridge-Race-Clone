using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    //private GameObject stackObject;
    [SerializeField] private GameObject stackParent;
    [SerializeField] private GameObject refObject;
    private float distanceBetweenObjects;

    /*void Start()
    {
        stackObject = ObjectPooler.Instance.ChangePosition(stack);
        distanceBetweenObjects = stackObject.transform.localScale.y;
    }*/

    public void CollectStackObject(GameObject stack)
    {
        distanceBetweenObjects = stack.transform.localScale.y;
        stack.transform.parent = stackParent.transform;
        Vector3 desiredPos = refObject.transform.localPosition;
        desiredPos.y += distanceBetweenObjects;
        
        stack.transform.localPosition = desiredPos; //new Vector3(stackParent.transform.position.x, distanceBetweenObjects, stackParent.transform.position.z);

        refObject.transform.localPosition = stack.transform.localPosition;
    }
}
