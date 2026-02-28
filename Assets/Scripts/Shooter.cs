using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    //variable that points the bullet in a certain direction
    public Transform muzzleLocation;

    //variable that connects shooter to pawn
    public abstract void Shoot();

    //variable that calculates shoot force
    public abstract void Shoot(float shootForce);
}
