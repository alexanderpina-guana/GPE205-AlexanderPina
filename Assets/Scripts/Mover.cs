using UnityEngine;

public abstract class Mover : MonoBehaviour
{
   //Variable that makes the tank move
   public abstract void Move(Vector3 moveDirection, float moveSpeed);

   //Variable that makes the tank rotate
   public abstract void Rotate(Vector3 rotateDirection, float turnSpeed);
   
   public abstract void RotateTowards(Vector3 position, float turnSpeed);
}

