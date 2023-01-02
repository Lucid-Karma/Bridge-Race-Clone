using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stair : MonoBehaviour//, IInteractable
{

    void OnTriggerEnter(Collider other)
    {
        StackManager.Instance.UseStackObject(GetCharacterList(other.gameObject));
    }

    // // public void Interact()
    // // {
    // //     Debug.Log("staired");
    // //     StackManager.Instance.UseStackObject();
        
    // // }

    public List<GameObject> GetCharacterList(GameObject character)
    {
        if (character.CompareTag("blue"))
        {
            Debug.Log("blue");
            return CharacterBase.blueBrickList;
        }
        else if (character.CompareTag("green"))
        {
            Debug.Log("green");
            return CharacterBase.greenBrickList;
        }
        else if (character.CompareTag("red"))
        {
            Debug.Log("red");
            return CharacterBase.redBrickList;
        }
        else    return null;
    }
}
