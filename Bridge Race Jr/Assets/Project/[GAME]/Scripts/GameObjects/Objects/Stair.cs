using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stair : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        // if (other.gameObject.name == "BlueCharacter" || 
        // other.gameObject.name == "GreenCharacter" ||
        // other.gameObject.name == "RedCharacter")
        // {
        //     StackManager.Instance.UseStackObject(GetCharacterList(other.gameObject) 
        // /*,other.gameObject/*, GetCharacterNum(other.gameObject)*/);
        // Debug.Log(other.gameObject.name);
        // }
         StackManager.Instance.UseStackObject(GetCharacterList(other.gameObject) );
        // /*,other.gameObject/*, GetCharacterNum(other.gameObject)*/);
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
}
