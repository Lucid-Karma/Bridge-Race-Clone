using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_PositionCreater 
{
    //private List<Vector3> randomPositions = new List<Vector3>();
    private float choosePos;
    private Vector3 position;


    public GameObject SetNPCPosition(GameObject target)
    {
        choosePos = Random.Range(-14, 14);
        position = new Vector3(choosePos, 1, choosePos);
        target.transform.position = position;
        //randomPositions.Add(position);
        return target;
    }
}
