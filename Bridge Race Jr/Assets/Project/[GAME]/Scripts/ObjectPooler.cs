using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : Singleton<ObjectPooler>
{
    public List<GameObject> pooledObjects = new List<GameObject>();
    public GameObject[] objectToPool;
    public int amountToPool;


    private Vector3 offset;
    //private bool doesPlayerExist;
    private int targetObjCount;

    //private int[] possiblePos;
    //int head = 14;

    List<Vector3> possiblePos = new();
    int maxX = 14;
    int maxZ = 14;


    void Awake() 
    {
        //possiblePos = new int[10];

        for (int i = 0; i < objectToPool.Length; i++)
        {
            for (int j = 0; j < amountToPool; j++) 
            {
                GameObject obj = (GameObject)Instantiate(objectToPool[i]);
                obj.SetActive(false); 
                pooledObjects.Add(obj);
            }   
        }

        // for (int i = 0; i < 10 ; i++)
        // {
        //     possiblePos[i] = head;
        //     head -= 3;
        // }
    }

    void Start()
    {
        PossiblePos();
        GetObject();
    }

    // void Update()
    // {
    //     //if (!doesPlayerExist)
    //       //  return;
    // }

    private int count = 0;
    private int randomObj;
    public GameObject GetPooledObject() 
    {
        for (int i = 0; i < pooledObjects.Count; i++) 
        {
            randomObj = Random.Range(0, pooledObjects.Count);
            if (!pooledObjects[i].activeInHierarchy) 
            {
                try
                {
                    count++;
                    return pooledObjects[randomObj];
                }
                catch (System.Exception ex)
                {
                    Debug.LogError("Can't find a Object prefab " + ex.ToString());
                    return null;
                }
            }
        }
        Debug.Log("null");
        return null;
    }

    // private void GetObject()
    // {
    //     targetObjCount = 10;

    //     for (int j = 0; j < targetObjCount; j++)
    //     {
    //         for (int i = 0; i < targetObjCount; i++)
    //         {
    //             GameObject obj = GetPooledObject();
                
    //             int x = possiblePos[j];
    //             int z = possiblePos[i];

    //             offset = new Vector3(x, 1, z);

    //             if(obj != null)
    //             {
    //                 obj.transform.position = offset;
    //                 obj.SetActive(true);
    //                 Debug.Log("obj: " + j+","+i+" offset: "+ obj.transform.position.x+", " + obj.transform.position.z);
    //             }
    //         }
    //     }
    //     Debug.Log(count);
    // }

    List<Vector3> PossiblePos()
    {

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector3 newPos = new Vector3(maxX,1f,maxZ);
                possiblePos.Add(newPos);
                maxX -= 3;
                //counter++;
            }
            maxZ -= 3;
            maxX = 14;
        }
        Debug.Log("Possible positions count " + possiblePos.Count);
        //Debug.Log("counter " + counter);
        return possiblePos;
    }

    Vector3 GetRandomPosition()
    {
        int randomPos = Random.Range(0,possiblePos.Count);
        Vector3 newPos = possiblePos[randomPos];
        possiblePos.Remove(possiblePos[randomPos]);
        return newPos;
    }

    private void GetObject()
    {
        targetObjCount = 10;

        for (int j = 0; j < targetObjCount; j++)
        {
            for (int i = 0; i < targetObjCount; i++)
            {
                GameObject obj = GetPooledObject();

                offset = GetRandomPosition();

                if(obj != null)
                {
                    obj.transform.position = offset;
                    obj.SetActive(true);
                    //Debug.Log("obj: " + j+","+i+" offset: "+ obj.transform.position.x+", " + obj.transform.position.z);
                }
            }
        }
    }
}
