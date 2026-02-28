using UnityEngine;

public class PawnTank : Pawn
{

    //variable that connects pawntank to shooter
    private ShooterTank shooter;

    //variable for the shoot force
    public float shootForce;

    //places the player tank
    public override void Start()
    {
        GameManager.instance.tanks.Add(this);
        shooter = GetComponent<ShooterTank>();
        base.Start();
    }

//destroys tank when they lose all their health
    public void OnDestroy()
    {
        GameManager.instance.tanks.Remove(this);
    }
    
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
        shooter.Shoot();
    }


}

