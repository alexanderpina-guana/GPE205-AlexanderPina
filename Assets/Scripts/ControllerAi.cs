using UnityEngine;

public abstract class ControllerAi : Controller
{
    //list of ai states
    public enum AISTATES { Idle, Chase, Flee, ChaseAndShoot, Patrol, Rest, ChooseRoamDirection, Roam, Attack, TurnAndShoot, Realign }

    //automic roam variable
    protected AISTATES currentState = AISTATES.Roam;

    //variable for targeting the player
    public Transform target;

    //variable for flee distance
    public float fleeDistance = 10.0f;

    //variable for state changing
    public float lastStateChange;

    //variables for sensing
    public float hearingDistance = 1.0f;
    public float visionDistance = 10.0f;
    public float FOVAngle = 60.0f;

    //variable for roam direction
    public Quaternion roamDirection = Quaternion.identity;

    //variable for transition time
    protected float transitionChangeTime;
    

///Meant to make ai tanks get possessed
    public override void Start()
    {
        Pawn p = GetComponent<Pawn>();
        Possess(p);
    }


//controls transition change time
    public override void MakeDecisions()
    {
        transitionChangeTime = Time.deltaTime;
    }

//changes AI states
    public void ChangeState(AISTATES newState)
    {
        currentState = newState;
        transitionChangeTime = Time.time;
    }

    //For idle state
    public void DoIdle()
    {
        
    }

    //follows player
    public void Seek(Vector3 targetPosition)
    {
        pawn.RotateTowards(targetPosition);
        pawn.Move(Vector3.forward);
    }

    //make AI track the player
    public void DoChase()
    {
       Seek(target.position);
    }

    //makes AI flee from player
    public void DoFlee()
    {
        Vector3 vectorToTarget = pawn.transform.position - target.position;
        float distanceToPlayer = vectorToTarget.magnitude;
        Vector3 flippedVectorToTarget = -vectorToTarget;
        vectorToTarget.Normalize();
        float percentOfFleeDistance = distanceToPlayer/fleeDistance;
        percentOfFleeDistance = Mathf.Clamp01(percentOfFleeDistance);
        float flippedPercentOfFleeDistance = 1 - percentOfFleeDistance;
        float newFleeDistance = flippedPercentOfFleeDistance * fleeDistance;

        Vector3 targetPosition = pawn.transform.position + (flippedVectorToTarget * newFleeDistance);

        Seek(targetPosition);
    }

    //Method of detection for the AI
    public bool CanSee(Transform target)
    {
        RaycastHit hit;

        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        if (Physics.Raycast(pawn.transform.position, vectorToTarget, out hit, visionDistance))
        {
            if(hit.collider.gameObject == target)
            {
                return true;
            }
        }
        return false;
    }

    //Another method of detection for the AI
    public bool CanHear(Transform target)
    {
        NoiseMaker targetNoiseMaker = target.GetComponent<NoiseMaker>();
        if (targetNoiseMaker == null) return false;

        if(targetNoiseMaker.noiseVolume > 0)
        {
            float totalDistance = Vector3.Distance(target.transform.position, pawn.transform.position);
            if (totalDistance < targetNoiseMaker.noiseVolume + hearingDistance)
            {
                return true;
            }
        }

        return false;
    }

    //Meant to make the tanks determine if they can move forward
    public bool CanMoveForward(Transform target)
    { 


        RaycastHit hit;

        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        if(Physics.Raycast(pawn.transform.position, pawn.transform.forward, out hit, vectorToTarget.magnitude))
        {
            if(hit.collider.gameObject == target.gameObject)
            {
                return false;
            }
        }
        return true;
    }

    //detects if object is in range
    public bool IsObjectRange(Transform objectToCheck, float range)
    {
        if(Vector3.Distance(objectToCheck.position, pawn.transform.position) < range)
        {
            return true;
        }
        return false;
    }

    //meant for AI tank to detemine if a direction is chosen
    public bool IsRoamDirectionChosen()
    {
        if (roamDirection != Quaternion.identity)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //counts time passed
    public bool HasTimeElapsed(float seconds)
    {
        if (Time.time - transitionChangeTime >= seconds)
        {
            return true;
        }
        return false;
    }



}
