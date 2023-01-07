using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stair : MonoBehaviour//, IInteractable
{
    public static int isblue, isgreen, isred;

    void OnTriggerEnter(Collider other)
    {
        StackManager.Instance.UseStackObject(GetCharacterList(other.gameObject), other.gameObject);

        if (other.gameObject.CompareTag("blue"))
        {
            isblue ++;
        }
        else if (other.gameObject.CompareTag("green"))
        {
            isgreen ++;
        }
        else if (other.gameObject.CompareTag("red"))
        {
            isred ++;
        }
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
