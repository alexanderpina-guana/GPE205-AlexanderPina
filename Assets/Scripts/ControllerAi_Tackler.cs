using UnityEngine;

public class ControllerAi_Tackler : ControllerAi
{

//Unfinished FSM meant to create an aggressive AI that rushes towards the player and shoots when in range.
    public override void MakeDecisions()
    {
        switch(currentState)
        {
            case AISTATES.Idle:
            DoIdle();
            if(CanMoveForward(target))
                {
                    ChangeState(AISTATES.Attack);
                }
            break;
            case AISTATES.Attack:
            DoAttack();
            if(!CanMoveForward(target))
                {
                    ChangeState(AISTATES.Idle);
                }
            break;
        }
    }


//function intended to run an shoot attack
    public void DoAttack()
    {
        Seek(target.position);
        pawn.Shoot();
    }
}
