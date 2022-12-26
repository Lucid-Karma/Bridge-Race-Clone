using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    public List<GameObject> stackedObjects = new List<GameObject>();

    #region CollectVariables
    /*[SerializeField]*/ private GameObject stackParent;
    /*[SerializeField]*/ private GameObject refObject;
    private float distanceBetweenObjects;
    #endregion

    #region UseVariables
    [SerializeField] private GameObject stairParent;
    [SerializeField] private GameObject refStair;
    private float distanceBetweenStairsY, distanceBetweenStairsZ;
    #endregion

    void Start()
    {
        stackParent = Player.Instance.stackParent;
        refObject = stackParent.transform.GetChild(0).gameObject;
        //refObject = Player.Instance.refObject;

        distanceBetweenObjects = refObject.transform.localScale.y;

        distanceBetweenStairsY = refStair.transform.localScale.y;
        distanceBetweenStairsZ = refStair.transform.localScale.z;
    }

    public void CollectStackObject(GameObject stack)
    {
        stack.transform.parent = stackParent.transform;
        Vector3 desiredPos = refObject.transform.localPosition;
        desiredPos.y += distanceBetweenObjects;
        
        stack.transform.localPosition = desiredPos; 
        
        refObject.transform.position = stack.transform.position;
        stackedObjects.Add(stack);
    }

    public void UseStackObject()
    {
        //for (int i = 0; i < stackedObjects.Count; i++) 
        //{
            stackedObjects[0].transform.parent = stairParent.transform;
            Vector3 desiredPos = refStair.transform.localPosition;
            desiredPos.y += distanceBetweenStairsY;
            desiredPos.z += distanceBetweenStairsZ;

            stackedObjects[0].transform.localPosition = desiredPos;

            refStair.transform.position = stackedObjects[0].transform.position;
            stackedObjects.Remove(stackedObjects[0]);
        //}
    }
}
