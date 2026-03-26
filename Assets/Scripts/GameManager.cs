using UnityEngine;

public class GameManager : MonoBehaviour
{
//The instance of the game manager
    public static GameManager instance;

    //The level asset
    public Level level;
    
    [Header("Prefabs")]

//The controller asset
    public GameObject playerControllerPrefab;
    
//Another version of the pawn
    public GameObject playerPawnPrefab;

    [Header("Up-to-Date Lists")]
        
        //pawn list
    
    public List<Pawn> tanks;

//controller list
    public List<Controller> players;

    //List of player spawn points
    public List<PlayerSpawn> playerSpawnPoints;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

               tanks = new List<Pawn>();
       players = new List<Controller>();
    }

//This function causes the Pawn Tank to get possessed when the game starts
    void Start()
    {
        StartGame();

    }

//Function that spawn the player
    public void StartGame()
    {
        level.mapGenerator.GenerateMap();
        
        SpawnPlayer();
 
    }

//function with internal workings that spawn the player
    public void SpawnPlayer()
    {
        Vector3 playerSpawnPosition;
        if(playerSpawnPoints.Count > 0)
        {
             Transform playerSpawn = playerSpawnPoints[Random.Range(0, playerSpawnPoints.Count)].transform;
             playerSpawnPosition = playerSpawn.position;
        }
        else
        {
            playerSpawnPosition = Vector3.zero;
        }
        Pawn playerPawn = SpawnTank(playerPawnPrefab, Vector3.zero);
        Controller playerController = SpawnPlayerController(playerControllerPrefab);
        playerController.Possess(playerPawn);

        AssignAITargets(playerPawn.transform);

        playerPawn.transform.position = playerSpawnPosition;
    }

//function that spawns a tank
    public Pawn SpawnTank(GameObject prefab, Vector3 position)
    {
        GameObject tempTankObject = Instantiate(prefab, position, Quaternion.identity);
        return tempTankObject.GetComponent<Pawn>();

    }

//function that spawn a player controller
    public Controller SpawnPlayerController(GameObject prefab)
    {
        GameObject tempPlayer = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity);
        return tempPlayer.GetComponent<Controller>();
    }

//functions that is meant to assign targets to the AI tanks
    void AssignAITargets(Transform playersTransform)
    {
        ControllerAi[] ais = FindObjectsByType<ControllerAi>(FindObjectsSortMode.None);

        foreach(ControllerAi ai in ais)
        {
            ai.target = playersTransform;
        }
    }


}

