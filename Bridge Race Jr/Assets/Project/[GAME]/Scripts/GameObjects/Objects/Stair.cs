using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Stair : MonoBehaviour
{
    public GameObject parentStair;
    public GameObject referanceStair;

    void Awake()
    {
        parentStair = gameObject.transform.parent.gameObject;
        referanceStair = gameObject;
    }
    void OnTriggerEnter(Collider other)
    {
        StackManager.Instance.UseStackObject(GetCharacterList(other.gameObject), parentStair, referanceStair);
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
