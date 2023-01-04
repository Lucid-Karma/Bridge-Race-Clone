using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    public List<GameObject> currentList = new List<GameObject>();


    #region CollectVariables
    private GameObject stackParent;
    private GameObject refObject;
    private float distanceBetweenObjects;
    #endregion

    #region UseVariables
    [SerializeField] private GameObject stairParent;
    [SerializeField] private GameObject refStair;
    private float distanceBetweenStairsY, distanceBetweenStairsZ;
    #endregion



    public void CollectStackObject(GameObject brick)
    {
        stackParent = CharacterBase.StackParent;
        refObject = CharacterBase.RefObject;

        distanceBetweenObjects = refObject.transform.localScale.y;

        brick.transform.parent = stackParent.transform;
        Vector3 desiredPos = refObject.transform.localPosition;
        desiredPos.y += distanceBetweenObjects / 2;     //problematic.
        
        brick.transform.localRotation = Quaternion.identity;
        brick.transform.localPosition = desiredPos; 
        
        refObject.transform.position = brick.transform.position;
    }

    public void UseStackObject(List<GameObject> currentList)
    {
            // stackParent = CharacterBase.StackParent;
            // refObject = CharacterBase.RefObject;
            // distanceBetweenObjects = refObject.transform.localScale.y;
            // Vector3 updatedRefObjPos = refObject.transform.localPosition;
            // updatedRefObjPos.y -= distanceBetweenObjects / 2;

            distanceBetweenStairsY = refStair.transform.localScale.y / 2;
            distanceBetweenStairsZ = refStair.transform.localScale.z / 2;

            currentList[currentList.Count -1].transform.parent = stairParent.transform;
            Vector3 desiredPos = refStair.transform.localPosition;
            desiredPos.y += distanceBetweenStairsY;
            desiredPos.z += distanceBetweenStairsZ;

            currentList[currentList.Count -1].transform.rotation = new Quaternion(0, 0, 0, 1);
            currentList[currentList.Count -1].transform.localPosition = desiredPos;

            refStair.transform.position = currentList[currentList.Count -1].transform.position;
            currentList.Remove(currentList[currentList.Count -1]);


            //refObject.transform.position = updatedRefObjPos;
    }
}
