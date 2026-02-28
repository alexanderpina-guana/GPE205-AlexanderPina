using UnityEngine;

public class GameManager : MonoBehaviour
{
//The instance of the game manager
    public static GameManager instance;
   
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
        SpawnPlayer();

 
    }

//function with internal workings that spawn the player
    public void SpawnPlayer()
    {
        Pawn playerPawn = SpawnTank(playerPawnPrefab, Vector3.zero);
        Controller playerController = SpawnPlayerController(playerControllerPrefab);
        playerController.Possess(playerPawn);

        AssignAITargets(playerPawn.transform);
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

