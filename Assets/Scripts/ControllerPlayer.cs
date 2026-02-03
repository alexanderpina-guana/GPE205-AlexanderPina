using UnityEngine;


public class ControllerPlayer : Controller
{

    //List of player keys to be edited
      public KeyCode moveForwardKey;
      public KeyCode moveBackwardKey;
      public KeyCode TurnRightKey;
      public KeyCode TurnLeftKey;
      public KeyCode ShootKey;
      public KeyCode ReloadKey;

  
    //Make Decisions function that make the key inputs move the tank
    public override void MakeDecisions()
    {

        if (Input.GetKey(moveForwardKey))
        {
            pawn.Move(Vector3.forward);
        }

        if (Input.GetKey(moveBackwardKey))
        {
            pawn.Move(-Vector3.forward);
        }

        if (Input.GetKey(TurnRightKey))
        {
            pawn.Rotate(Vector3.right);
        }

        if (Input.GetKey(TurnLeftKey))
        {
            pawn.Rotate(-Vector3.right);
        }

    }

//Updates game
    public override void Update()
    {
        base.Update();
    }
}
