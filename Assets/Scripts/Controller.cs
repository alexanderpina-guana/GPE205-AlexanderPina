using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    //Pawn link, hidden from view of developer
      [HideInInspector] public Pawn pawn;

//Update that activates player choices
      public virtual void Update()
    {
        MakeDecisions();
    }

//The player input variable
      public abstract void MakeDecisions();

//Possesses Pawn Tank

      public void Possess(Pawn pawnToPossess)
      {
          pawnToPossess.controller = this;
          this.pawn = pawnToPossess;
      }

//Unpossess when you pause game
     public void Unpossess()
    {
        this.pawn.controller = null;
        pawn = null;
    }

}
