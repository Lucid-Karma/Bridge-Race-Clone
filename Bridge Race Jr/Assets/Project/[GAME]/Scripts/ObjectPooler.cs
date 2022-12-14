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

    private int[] possiblePos;
    int head = 14;


    void Awake() 
    {
        possiblePos = new int[10];

        for (int i = 0; i < objectToPool.Length; i++)
        {
            for (int j = 0; j < amountToPool; j++) 
            {
                GameObject obj = (GameObject)Instantiate(objectToPool[i]);
                obj.SetActive(false); 
                pooledObjects.Add(obj);
            }   
        }

        for (int i = 0; i < 10 ; i++)
        {
            possiblePos[i] = head;
            head -= 3;
        }
    }

    /*private void OnEnable()
    {
        EventManager.OnRightMove.AddListener(SpecificPosr);
        EventManager.OnLeftMove.AddListener(SpecificPosl);
        //EventManager.OnLevelStart.AddListener(GetObjFirstTime);
        EventManager.OnPlayerStartedRunning.AddListener(() => doesPlayerExist = true);
        EventManager.OnLevelFail.AddListener(() => doesPlayerExist = false);
        TrackManager.OnTrackCreate += Getobject;
    }

    private void OnDisable()
    {
        EventManager.OnRightMove.RemoveListener(SpecificPosr);
        EventManager.OnLeftMove.RemoveListener(SpecificPosl);
        //EventManager.OnLevelStart.RemoveListener(GetObjFirstTime);
        EventManager.OnPlayerStartedRunning.RemoveListener(() => doesPlayerExist = true);
        EventManager.OnLevelFail.RemoveListener(() => doesPlayerExist = false);
        TrackManager.OnTrackCreate -= Getobject;
    }*/

    void Start()
    {
        GetObject();
    }

    void Update()
    {
        //if (!doesPlayerExist)
          //  return;
    }

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
        
        return null;
    }

    /*public Vector3 GetObjectPosition()
    {
        int random = Random.Range(0, possiblePos.Length);
        int x = possiblePos[random];
        random = Random.Range(0, possiblePos.Length);
        int z = possiblePos[random];
        offset = new Vector3(x, 1, z);
        return offset;
    }*/

    private void GetObject()
    {
        targetObjCount = 10;

        for (int j = 0; j < targetObjCount; j++)
        {
            for (int i = 0; i < targetObjCount; i++)
            {
                GameObject obj = GetPooledObject();
                
                int x = possiblePos[j];
                int z = possiblePos[i];

                offset = new Vector3(x, 1, z);

                if(obj != null)
                {
                    obj.transform.position = offset;
                    obj.SetActive(true);
                    Debug.Log("obj: " + j+","+i+" offset: "+ obj.transform.position.x+", " + obj.transform.position.z);
                }
            }
        }
        Debug.Log(count);
    }

    public GameObject ChangePosition(Collider stackObj)
    {
        return stackObj.gameObject;
    }
}
