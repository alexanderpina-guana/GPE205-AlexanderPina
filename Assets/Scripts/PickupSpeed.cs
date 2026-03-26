using UnityEngine;


public class PickupSpeed : Pickup
{
    //Connects to the speed powerup
    public PowerupSpeed powerup;

//Activates once contact is made
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
}
