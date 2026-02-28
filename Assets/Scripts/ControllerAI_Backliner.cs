using UnityEngine;

public class ControllerAI_Backliner : ControllerAi
{
    public Vector3 patrolDirection;
    public Vector3 backlinePosition;

//unfinished FSM meant for an AI tank that attacks from the edges of the arena
    public override void MakeDecisions()
    {
        if (target == null) return; 
        
        switch (currentState)
        {
            case AISTATES.Realign:
            DoRealign();
            if(!CanMoveForward(target) && CanSee(target))
                {
                    ChangeState(AISTATES.Patrol);
                }
            break;
            case AISTATES.Patrol:
            if(Time.time - transitionChangeTime < 0.1f)
                {
                    ChoosePatrolDirection();
                }
            DoPatrol();
            if(HasTimeElapsed(2))
                {
                    ChangeState(AISTATES.TurnAndShoot);
                }
            break;
            case AISTATES.TurnAndShoot:
            DoTurnAndShoot();
            if(CanMoveForward(target) && CanSee(target))
                {
                    ChangeState(AISTATES.Realign);
                }
            else
                {
                    ChangeState(AISTATES.Patrol);
                }
            break;

        }
    }

//function intended to a direction to patrol
    public void ChoosePatrolDirection()
    {
        int dir = Random.Range(0, 2) == 0 ? -1 : 1;
        patrolDirection = new Vector3(dir, 0, 0);
    }

//function intended to assign tank to the backline
    public void DoRealign()
    {
        Seek(backlinePosition);
    }

//function intended to make the tank patrol the backline
    public void DoPatrol()
    {
        pawn.Move(patrolDirection);
        pawn.RotateTowards(target.position);
    }

//function intended to make the tank shoot at the player
    public void DoTurnAndShoot()
    {
        pawn.RotateTowards(target.position);
        pawn.Shoot();
    }
}
