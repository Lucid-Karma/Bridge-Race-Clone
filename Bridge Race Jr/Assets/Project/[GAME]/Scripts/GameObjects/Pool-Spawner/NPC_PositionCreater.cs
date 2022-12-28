using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_PositionCreater 
{
    private Vector3 position;


    public GameObject SetNPCPosition(GameObject target)
    {
        position = new Vector3(Random.Range(-14, 14), 1, Random.Range(-14, 14));
        target.transform.position = position;
        return target;
    }
}
