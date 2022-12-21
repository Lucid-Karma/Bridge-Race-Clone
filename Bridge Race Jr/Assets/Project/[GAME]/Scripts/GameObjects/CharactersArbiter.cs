using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersArbiter : MonoBehaviour
{
    //[SerializeField] Player playerSC;
    //[SerializeField] CharacterBase _NPC;

    public GameObject[] character;
    private int cIndex;
    private Vector3 playerPos, firstNPC, secondNPC;

    void Awake()
    {
        for (int i = 0; i < character.Length; i++)
        {
            GameObject obj = (GameObject)Instantiate(character[i]);
            obj.SetActive(false);
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
        cIndex = Random.Range(0, character.Length);
        return character[cIndex];
    }

    public void CreatePlayer()
    {
        GameObject player = GetPlayer();
        //player.AddComponent<Player>();
        if(player != null)
        {
            player.transform.position = playerPos;
            player.SetActive(true);
        }
        else
        {
            Debug.Log("player null");
        }
    }
}
