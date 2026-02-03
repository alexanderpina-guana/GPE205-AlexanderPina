using UnityEngine;

public class PawnTank : Pawn
{
    //A pawn function that tells the mover to move the tank
    public override void Move(Vector3 directionToMove)
    {
        mover.Move(directionToMove, moveSpeed);
    }
    
    //A pawn function that tells the mover to rotate the tank
    public override void Rotate(Vector3 directionToRotate)
    {
        mover.Rotate(directionToRotate, turnSpeed);
    }

    //Currently unused shoot pawn function
    public override void Shoot()
    {
        
    }


}
