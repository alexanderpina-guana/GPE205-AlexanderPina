using UnityEngine;

public class GameManager : MonoBehaviour
{
//The instance of the game manager
    public static GameManager instance;

//The controller asset
    public Controller playerOne;

//Another version of the pawn
    public Pawn startPawn;

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
    }

//This function causes the Pawn Tank to get possessed when the game starts
    void Start()
    {
        playerOne.Possess(startPawn);
    }


}
