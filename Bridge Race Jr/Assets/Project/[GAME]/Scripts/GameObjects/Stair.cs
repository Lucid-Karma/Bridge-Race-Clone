using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stair : MonoBehaviour//, IInteractable
{
    //public bool isBuilding { get; set => true; }
    // CharacterBase activeCharacter;
    // // public List<GameObject> blueBrickList = new List<GameObject>();
    // // public List<GameObject> greenBrickList = new List<GameObject>();
    // // public List<GameObject> redBrickList = new List<GameObject>();

    void OnTriggerEnter(Collider other)
    {
        //StackManager.Instance.GetCharacterList(other.gameObject)
        StackManager.Instance.UseStackObject(StackManager.Instance.GetCharacterList(other.gameObject));
    }

    // // public void Interact()
    // // {
    // //     Debug.Log("staired");
    // //     StackManager.Instance.UseStackObject();
        
    // // }

    // public List<GameObject> GetCharacterList(GameObject character)
    // {
    //     // if (character.CompareTag("blue"))
    //     // {
    //     //     Debug.Log("blue");
    //     //     return activeCharacter.blueBrickList;
    //     // }
    //     // else if (character.CompareTag("green"))
    //     // {
    //     //     Debug.Log("green");
    //     //     return activeCharacter.greenBrickList;
    //     // }
    //     // else if (character.CompareTag("red"))
    //     // {
    //     //     Debug.Log("red");
    //     //     return activeCharacter.redBrickList;
    //     // }
    //     // else    return null;

    //     // if (CharacterBase.BrickList.Where(x => x.tag == "blue").Any())
    //     // {
    //     //     blueBrickList = CharacterBase.BrickList;
    //     //     return blueBrickList;
    //     // }
    //     // if (CharacterBase.BrickList.Where(x => x.tag == "green").Any())
    //     // {
    //     //     greenBrickList = CharacterBase.BrickList;
    //     //     return greenBrickList;
    //     // }
    //     // if (CharacterBase.BrickList.Where(x => x.tag == "red").Any())
    //     // {
    //     //     redBrickList = CharacterBase.BrickList;
    //     //     return redBrickList;
    //     // }

    //     if (CharacterBase.BrickList.Where(x => x.tag == character.tag).Any())
    //     {
    //         blueBrickList.Clear();
    //         //blueBrickList = CharacterBase.BrickList;
    //         foreach (GameObject usingBrick in CharacterBase.BrickList)
    //         {
    //             if (usingBrick.CompareTag(character.tag))
    //             {
    //                 blueBrickList.Add(usingBrick);
    //             }
    //         }

    //         return blueBrickList;
    //     }
    //     else    return null;
    // }
}
