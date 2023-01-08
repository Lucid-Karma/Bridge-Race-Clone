using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stair : MonoBehaviour
{
    public int isblue, isgreen, isred;

    void OnTriggerEnter(Collider other)
    {
        //StackManager.Instance.GetNewPos(other.gameObject);
        StackManager.Instance.UseStackObject(GetCharacterList(other.gameObject) 
        /*,other.gameObject/*, GetCharacterNum(other.gameObject)*/);
        Debug.Log(other.gameObject.name);
    }

    public List<GameObject> GetCharacterList(GameObject character)
    {
        if (character.CompareTag("blue"))
        {
            return CharacterBase.blueBrickList;
        }
        else if (character.CompareTag("green"))
        {
            return CharacterBase.greenBrickList;
        }
        else if (character.CompareTag("red"))
        {
            return CharacterBase.redBrickList;
        }
        else    return null;
    }

    public int GetCharacterNum(GameObject character)
    {
        if (character.CompareTag("blue"))
        {
            isblue ++;
            return isblue;
        }
        else if (character.CompareTag("green"))
        {
            isgreen ++;
            return isgreen;
        }
        else //if (character.CompareTag("red"))
        {
            isred ++;
            return isred;
        }
        //return 0;
    }
}
