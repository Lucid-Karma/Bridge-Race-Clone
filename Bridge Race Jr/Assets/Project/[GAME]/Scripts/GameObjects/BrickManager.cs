using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BrickManager : MonoBehaviour
{/*
    void Start()
    {
        List<Tile> Map = new List<Tile>();
        
        int borderX = 9;
        int borderZ = 10;
        
        for(int i = 0; i<borderX; i++) 
        {
            for(int j = 0; j<borderZ; j++) 
            {
                Tile tile = new Tile();
                tile.Vector3 = new Vector3(i,0,j);
                tile.IsEmpty = true;
                Map.Add(new tile);
            }
        }

        int red = 0;
        int green = 1;
        int blue = 2;
        int counter = 0;
        

        while(Map.Any(y => y.IsEmpty)) 
        {
            Vector3 RandomVector = new vector3(RandomInt(0,borderX),0,RandomInt(0,borderZ));
            if(Map.Where(x => x.Vector3 == RandomVector && x.IsEmpty).Any()) 
            {
                if (counter % 3 == 0)
                {
                    var redTile = new Tile();
                    Map.Add(redTile);
                }
                if (counter % 3 == 1)
                {
                    var greenTile = new Tile();
                    Map.Add(greenTile);
                }
                if (counter % 3 == 2)
                {
                    var blueTile = new Tile();
                    Map.Add(blueTile);
                }
                counter++;
            }
            else
            {
                continue;
            }
            
        }
    }*/
}
