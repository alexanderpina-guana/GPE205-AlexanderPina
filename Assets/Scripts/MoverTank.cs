using UnityEngine;

public class MoverTank : Mover
{
   
   //The tank's rigidboy collider
    private Rigidbody rb;

    //Gets the rigidbody for editing
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Function that makes the tank move
    public override void Move(Vector3 moveDirection, float moveSpeed)
    {
        Vector3 moveVector = transform.forward * moveDirection.z;
        rb.MovePosition(rb.position + moveVector * moveSpeed * Time.fixedDeltaTime);
    }
    //Function that makes the tank rotate
    public override void Rotate(Vector3 rotateDirection, float turnSpeed)
    {
        float rotationAmount = rotateDirection.x;
        rotationAmount *= (turnSpeed);
        rotationAmount *= Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }

    //Function that makes an AI tank rotate towards a position
    public override void RotateTowards(Vector3 position, float turnSpeed)
    {
        Vector3 vectorToTarget = position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(vectorToTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, turnSpeed * Time.deltaTime);
    }
    
}

