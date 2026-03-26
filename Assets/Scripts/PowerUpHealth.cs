using UnityEngine;
[System.Serializable]

public class PowerUpHealth : Powerup
{
//A float of how much is going to heal
    public float AmountToHeal;
    
//Applies the effect of the powerup
    public override void Apply(Pawn target)
    {
        if (target.health != null)
        {
            target.health.Heal(AmountToHeal);
        }
    }

//Removes the effect of the powerup
    public override void Remove(Pawn target)
    {
        
    }
}
