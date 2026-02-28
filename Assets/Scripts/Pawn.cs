using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
//Links to the mover
    protected Mover mover;

//links to controller. Hides it from view for developers
    [HideInInspector] public Controller controller;

//Player Options
     public abstract void Move(Vector3 directionToMove);

     public abstract void Rotate(Vector3 directionToRotate);

     public abstract void Shoot();

//Floats for movement
     public float moveSpeed;
     public float turnSpeed;

//Returns the Controller
     public Controller GetController()
    {
        return controller;
    }


//Gets the Mover
    public void Start()
    {
        mover = GetComponent<Mover>();
    }

//runs RotateTowards from mover
       public void RotateTowards(Vector3 position)
    {
        mover.RotateTowards(position, turnSpeed);
    }






}

