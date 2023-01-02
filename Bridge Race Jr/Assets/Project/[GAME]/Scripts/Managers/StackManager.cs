using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : Singleton<StackManager>
{
    CharacterBase active;
    CharactersArbiter charactersArbiter;

    public List<GameObject> currentList = new List<GameObject>();

    public List<GameObject> blueBrickList = new List<GameObject>();
    public List<GameObject> greenBrickList = new List<GameObject>();
    public List<GameObject> redBrickList = new List<GameObject>();

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

    // void Start()
    // {
    //     distanceBetweenStairsY = refStair.transform.localScale.y;
    //     distanceBetweenStairsZ = refStair.transform.localScale.z;
    // }

    public void CollectStackObject(GameObject brick)
    {
        stackParent = CharacterBase.StackParent;
        refObject = CharacterBase.RefObject;

        distanceBetweenObjects = refObject.transform.localScale.y;

        brick.transform.parent = stackParent.transform;
        Vector3 desiredPos = refObject.transform.localPosition;
        desiredPos.y += distanceBetweenObjects /2;     //problematic.
        
        brick.transform.localRotation = Quaternion.identity;
        brick.transform.localPosition = desiredPos; 
        
        refObject.transform.position = brick.transform.position;
        //currentList.Add(brick);
        //ChooseCharacterBase.BrickList();
    }

    public void UseStackObject(List<GameObject> currentList)
    {
        //for (int i = 0; i < currentList.Count; i++) 
        //{
            //currentList[currentList.Count -1] = CharacterBase.CharacterBase.BrickList[CharacterBase.CharacterBase.BrickList.Count -1];
            //currentList[0] = CharacterBase.CharacterBase.BrickList[0];
            //ChooseCharacterBase.BrickList();
            //currentList.Add(CharacterBase.CharacterBase.BrickList[CharacterBase.CharacterBase.BrickList.Count -1]);
        
            //Debug.Log(currentList.Count);

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
        //}
    }

    // private void ChooseCharacterBase.BrickList()
    // {
    //     if (active.brickType == BrickType.BLUE)
    //     {
    //         currentList = active.blueCharacterBase.BrickList;
    //     }
    //     else if (active.brickType == BrickType.GREEN)
    //     {
    //         currentList = active.greenCharacterBase.BrickList;
    //     }
    //     else if (active.brickType == BrickType.RED)
    //     {
    //         currentList = active.redCharacterBase.BrickList;
    //     }
    // }

    public List<GameObject> GetCharacterList(GameObject character)
    {
        //foreach (GameObject CharacterBase.BrickList[i] in CharacterBase.CharacterBase.BrickList)
        for (int i = 0; i < CharacterBase.BrickList.Count; i++)
        {
            if (character.CompareTag("blue") && CharacterBase.BrickList[i].CompareTag("blue"))
            {
                blueBrickList.Add(CharacterBase.BrickList[i]);
                Debug.Log(CharacterBase.BrickList[i].name);
                return blueBrickList;
            }
            
            else if (character.CompareTag("green") && CharacterBase.BrickList[i].CompareTag("green"))
            {
                greenBrickList.Add(CharacterBase.BrickList[i]);
                return greenBrickList;
            }
            else if (character.CompareTag("red") && CharacterBase.BrickList[i].CompareTag("red"))
            {
                redBrickList.Add(CharacterBase.BrickList[i]);
                return redBrickList;
            }
            else    return null;
            
        }
        return null;
    }
}
