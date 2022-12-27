using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersArbiter : MonoBehaviour
{

    public List<GameObject> characterList = new List<GameObject>();
    private int cIndex = 0;
    private Vector3 playerPos, firstNPC, secondNPC;
    private List<Vector3> npcPosition = new List<Vector3>();

    void Awake()
    {
        for (int i = 0; i < characterList.Count; i++)
        {
            characterList[i].SetActive(false);
        }

        playerPos = new Vector3(0f, 1.5f, 17f);
        firstNPC = new Vector3(3f, 1.5f, 17f);
        secondNPC = new Vector3(-3f, 1.5f, 17f);

        npcPosition.Add(firstNPC);
        npcPosition.Add(secondNPC);
    }

    public void Start()
    {
        CreatePlayer();
        CreateNPC();
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
        characterList.Remove(player);
        Debug.Log("caharacter color is " + player.tag);

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

    public void CreateNPC()
    {
        for(int i = 0; i < characterList.Count; i++)
        {
            if (!characterList[i].activeInHierarchy)
            {
                characterList[i].GetComponent<NPC>().enabled = true;
                characterList[i].transform.position = npcPosition[i];
                characterList[i].SetActive(true);
            }

            Debug.Log("npc " + i);
        }
        Debug.Log("npc done");
    }
}
