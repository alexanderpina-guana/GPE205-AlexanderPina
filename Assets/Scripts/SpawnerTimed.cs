using UnityEngine;

public class SpawnerTimed : MonoBehaviour
{
    //Sets an object to spawn
    public GameObject objectToSpawn;
    //sets the time between spawns
    public float timeBetweenSpawns;
    //sets if the object should spawn on the start
    public bool isSpawnOnStart;
    //Sets a timer for the spawner
    private float countdownTimer;
    //The spawned object
    private GameObject spawnedObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isSpawnOnStart)
        {
            countdownTimer = 0;
        }
        else
        {
            countdownTimer = timeBetweenSpawns;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (spawnedObject == null)
        {
          countdownTimer -= Time.deltaTime;

          if(countdownTimer <= 0)
          {
            spawnedObject = Instantiate(objectToSpawn, transform.position, transform.rotation) as GameObject;
            countdownTimer = timeBetweenSpawns;
          }
        }

    }
}
