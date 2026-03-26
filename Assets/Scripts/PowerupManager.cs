using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{

    //List of existing powerups
    public List<Powerup> powerups;

    //Pawn that the powerups will be applied to
    private Pawn pawn;

    //Applies powerups to pawn
    public void Start()
    {
        pawn = GetComponent<Pawn>();
        powerups = new List<Powerup>();
    }

    //Updates the status of powerups
    public void Update()
    {
        UpdatePowerupLifespans();
        CheckForExpiredPowerups();
    }

    //Updates the powerup lifespans
    public void UpdatePowerupLifespans()
    {
        foreach (Powerup powerup in powerups)
        {
            powerup.lifespan -= Time.deltaTime;
        }
    }

//Checks if a powerup has been used up
    public void CheckForExpiredPowerups()
    {
        List<Powerup> powerupsToRemove = new List<Powerup>();

        foreach (Powerup powerup in powerups)
        {
            if (powerup.lifespan <= 0)
            {
                powerupsToRemove.Add(powerup);
            }
        }

        foreach (Powerup powerup in powerupsToRemove)
        {
            Remove(powerup);
        }
    }

//Adds a powerup to a pickup
    public void Add(Powerup powerup)
    {
        powerup.Apply(pawn);

        if(powerup.lifespan >= 0)
        {
            powerups.Add(powerup);
        }

        
    }

    //Removes a powerup when interacted with
    public void Remove(Powerup powerup)
    {
        powerup.Remove(pawn);

        powerups.Remove(powerup);
    }
}
