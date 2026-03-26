using UnityEngine;
[System.Serializable]
public class PowerupSpeed : Powerup
{
    //Float to calculate speed to a powerup
    public float speed;

    //Applies the effect of speed to the tank
    public override void Apply(Pawn target)
    {
        
        target.moveSpeed += speed;
    }

    //For the removal of the speed effect
    public override void Remove(Pawn target)
    {
        target.moveSpeed -= speed;
    }

}
