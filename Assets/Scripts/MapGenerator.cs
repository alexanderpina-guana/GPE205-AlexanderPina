using UnityEngine;
using System.Collections.Generic;
using System;

public enum RandomType { Random, Seeded, MapOfTheDay };

public class MapGenerator : MonoBehaviour
{

    //Data that is randomized to set up the map.
    [Header("RandomData")]
    public RandomType randomType;
    public int seed = 27;

    //Various lists and variables relating to the map's tiles.
    [Header("TileData")]
    public List<Tile> availableTiles;
    public Tile enemyTile;
    public Vector2 enemyTileLocation;
    public float tileWidth;
    public float tileLength;
    public int mapCols;
    public int mapRows;
    public Tile[,] grid;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InitializeRandom();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Randomizes seed depending on the mode the map generator randomizer is set to.
    public void InitializeRandom()
    {
        if(randomType == RandomType.Seeded)
        {
            UnityEngine.Random.InitState(seed);
        }
        else if(randomType == RandomType.Random)
        {
            UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        }
        else if(randomType == RandomType.MapOfTheDay)
        {
            UnityEngine.Random.InitState(DateToInt(DateTime.Now.Date));
        }
        
    }

//Converts the current date to and integer and seed.
    public int DateToInt(DateTime date)
    {
        return date.Year + date.Month + date.Day + date.Hour + date.Minute + date.Second;
    }

//Function that works to generate the map
    public void GenerateMap()
    {
        grid = new Tile[mapCols, mapRows];

        for (int currentRow = 0; currentRow < mapRows; currentRow++)
        {
            for (int currentCol = 0; currentCol < mapCols; currentCol++)
            {
                Tile tempTile;
                if(currentCol == enemyTileLocation.x && currentRow == enemyTileLocation.y)
                {
                    tempTile = Instantiate<Tile>(enemyTile) as Tile;
                }
                else
                {
                    tempTile = Instantiate<Tile>(GetRandomTile()) as Tile;
                }

                
                Vector3 correctPosition = Vector3.zero;
                correctPosition.z = currentRow * tileWidth;
                correctPosition.x = currentCol * tileLength;
                tempTile.transform.position = correctPosition;

                if(currentRow == 0)
                {
                    tempTile.doorNorth.SetActive(false);
                }
                else if (currentRow == mapRows - 1)
                {
                    tempTile.doorSouth.SetActive(false);
                }
                else
                {
                    tempTile.doorNorth.SetActive(false);
                    tempTile.doorSouth.SetActive(false);
                }

                if(currentCol == mapCols - 1)
                {
                    tempTile.doorWest.SetActive(false);
                }
                else if(currentCol == 0)
                {
                    tempTile.doorEast.SetActive(false);
                }
                else
                {
                    tempTile.doorWest.SetActive(false);
                    tempTile.doorEast.SetActive(false);
                }

                grid[currentCol, currentRow] = tempTile;
            }
        }
    }

    //Gets a random tile from the tiles that exist
    public Tile GetRandomTile()
    {
        int tileNumber = UnityEngine.Random.Range(0, availableTiles.Count);
        return availableTiles[tileNumber];
    }
}
