using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    public List<GameObject> currentList = new List<GameObject>();
    private List<GameObject> usedList = new List<GameObject>();


    #region CollectVariables
    private GameObject stackParent;
    private GameObject refObject;
    private float distanceBetweenObjects;
    #endregion

    #region UseVariables
    /*[SerializeField]*/ private GameObject stairParent;
    /*[SerializeField]*/ private GameObject refStair;
    private float distanceBetweenStairsY, distanceBetweenStairsZ;

    Vector3 newRefPos;
    #endregion


    public void CollectStackObject(GameObject brick)
    {
        if (!usedList.Contains(brick))
        {
            stackParent = CharacterBase.StackParent;
	        refObject = CharacterBase.RefObject;
	
	        distanceBetweenObjects = refObject.transform.localScale.y;
	
	        brick.transform.parent = stackParent.transform;
	        Vector3 desiredPos = refObject.transform.localPosition;
	        desiredPos.y += distanceBetweenObjects;    
	        
	        brick.transform.localRotation = Quaternion.identity;
	        brick.transform.localPosition = desiredPos; 

            refObject.transform.position = brick.transform.position;
        }
    }


    private float stairScale;
    public void UseStackObject(List<GameObject> currentList, GameObject stairParent, GameObject refStair)
    {
        if(currentList.Count >= 1)
        {
            this.currentList = currentList;

            distanceBetweenStairsY = refStair.transform.localScale.y;
            distanceBetweenStairsZ = refStair.transform.localScale.z;

            stairScale = refStair.transform.localScale.x;

            currentList[currentList.Count -1].transform.parent = stairParent.transform;
            Vector3 desiredPos = refStair.transform.localPosition;
            desiredPos.y += distanceBetweenStairsY;
            desiredPos.z += distanceBetweenStairsZ;

            currentList[currentList.Count -1].transform.rotation = new Quaternion(0, 0, 0, 1);
            currentList[currentList.Count -1].transform.localPosition = desiredPos;

            refStair.transform.position = currentList[currentList.Count -1].transform.position;
            currentList[currentList.Count -1].transform.localScale = new Vector3(stairScale, 1, 1);
            usedList.Add(currentList[currentList.Count -1]);
            currentList.RemoveAt(currentList.Count - 1);

            newRefPos = CharacterBase.SRefObject.transform.localPosition;
            newRefPos.y -= 1;
            CharacterBase.SRefObject.transform.localPosition = newRefPos;
        }
    }
}
