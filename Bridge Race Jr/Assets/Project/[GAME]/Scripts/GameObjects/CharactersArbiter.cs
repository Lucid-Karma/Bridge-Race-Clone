using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersArbiter : MonoBehaviour
{

    private List<GameObject> characterList = new List<GameObject>();
    public GameObject[] character;
    private int cIndex = 0;
    private Vector3 playerPos, firstNPC, secondNPC;

    void Awake()
    {
        for (int i = 0; i < character.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(character[i]);
            obj.SetActive(false);
            characterList.Add(obj);
        }
        playerPos = new Vector3(0f, 1.5f, 17f);
        firstNPC = new Vector3(3f, 1.5f, 17f);
        secondNPC = new Vector3(-3f, 1.5f, 17f);
    }

    public void Start()
    {
        CreatePlayer();
    }

    public GameObject GetPlayer()
    {
        cIndex = Random.Range(0, characterList.Count);
        Debug.Log("character " + cIndex);
        return characterList[cIndex];
    }

    public void CreatePlayer()
    {
        GameObject player = GetPlayer();
        Debug.Log("caharacter color is " + player.tag);
        //player.GetComponent<Player>().enabled = true;

        if(player != null)
        {
            player.GetComponent<Player>().enabled = true;
            player.transform.position = playerPos;
            player.SetActive(true);
            Debug.Log("character created");
        }
        else
        {
            Debug.Log("player null");
        }
    }
}
