using UnityEngine;
using System.Collections.Generic;
public class Tile : MonoBehaviour
{

//Variable for setting randomized spawn points
   public Transform playerSpawnPoints;

//A north wall that disappears when tile is generated
    public GameObject doorNorth;
//A south wall that disappears when tile is generated
    public GameObject doorSouth;
//An east wall that disappears when tile is generated
    public GameObject doorEast;
//A west wall that disappears when tile is generated
    public GameObject doorWest;
}
