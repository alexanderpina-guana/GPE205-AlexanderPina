using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.playerSpawnPoints.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//Destroys once game is ended
    void OnDestroy()
    {
        GameManager.instance.playerSpawnPoints.Remove(this);
    }
}
