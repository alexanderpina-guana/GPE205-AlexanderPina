using UnityEngine;

public class PickupHealth : Pickup
{
    //How many health pickups are currently in the scene
    public static int count;

    //Connects to the actual powerup
    public PowerUpHealth powerup;

    //Loads in the pickup
    public override void Start()
    {
        count++;
        base.Start();
    }

//Activates when contacted
   public override void OnTriggerEnter(Collider other)
    {
        PowerupManager otherManager = other.GetComponent<PowerupManager>();
        if(otherManager != null)
        {
            otherManager.Add(powerup);
            
            Destroy(gameObject);
        }

        base.OnTriggerEnter(other);
    }

//Destroys after contact
    public override void OnDestroy()
    {
        count--;
        base.OnDestroy();
    }

    
}
