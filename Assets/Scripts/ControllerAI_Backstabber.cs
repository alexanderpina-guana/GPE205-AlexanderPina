using UnityEngine;

public class ControllerAI_Backstabber : ControllerAi
{

    //function for an AI tank sneaks behind the player

    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AISTATES.Roam:
            DoRoam();
            if(!CanMoveForward(target))
                {
                    ChangeState(AISTATES.ChooseRoamDirection);
                }
            if(HasTimeElapsed(3))
                {
                    ChangeState(AISTATES.ChooseRoamDirection);
                }
            if( CanMoveForward(target) && CanSee(target))
                {
                    ChangeState(AISTATES.Attack);
                }
            break;
            case AISTATES.ChooseRoamDirection: 
            DoChooseRoamDirection();
            if(HasTimeElapsed(4))
                {
                    ChangeState(AISTATES.Roam);
                }
            break;
            case AISTATES.Attack:
            DoAttack();
            if(!CanMoveForward(target))
                {
                    ChangeState(AISTATES.TurnAndShoot);
                } 
            break;
            case AISTATES.TurnAndShoot:
            DoTurnAndShoot();
            if(CanMoveForward(target))
                {
                    ChangeState(AISTATES.Roam);
                }
            break;          
        }

    }

//function for roaming around the arena
    public void DoRoam()
    {
        Seek(target.position);
    }

//function for checking if the roam direction has been chosen
    public void DoChooseRoamDirection()
    {
        IsRoamDirectionChosen();
    }

//function intended to make tank shoot
    public void DoAttack()
    {
        Seek(target.position);
        pawn.Shoot();
    }

//function intended to make the tank turn and shoot when it can no longer move
    public void DoTurnAndShoot()
    {
        pawn.RotateTowards(target.position);
        pawn.Shoot();
    }
}
