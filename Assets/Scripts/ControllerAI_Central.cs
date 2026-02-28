using UnityEngine;

public class ControllerAI_Central : ControllerAi
{

//unfinished FSM meant for an AI Tank that attacks from the center of the arena
    public override void MakeDecisions()
    {
        switch(currentState)
        {
            case AISTATES.Idle:
            DoIdle2();
            if(CanMoveForward(target) && CanSee(target))
                {
                    ChangeState(AISTATES.Flee);
                }
            break;
            case AISTATES.Flee:
            DoFlee();
            if(HasTimeElapsed(3))
                {
                    ChangeState(AISTATES.Realign);
                }
            break;
            case AISTATES.Realign:
            DoRealign();
            if(!CanMoveForward(target))
                {
                    ChangeState(AISTATES.Idle);
                }
            break;
        }
    }

//function intended to make the tank shoot while idle
    public void DoIdle2()
    {
        pawn.RotateTowards(target.position);
        pawn.Shoot();
    }

//function intended to make the tank return to its center position after fleeing
    public void DoRealign()
    {
        pawn.Move(Vector3.forward);
    }
}
