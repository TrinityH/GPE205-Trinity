using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : Controller
{
    //Variables
    public enum AIStates { Guard, Chase, Flee, Patrol, Attack, ChooseTarget, BackToPost, Idle, Seek };
    public AIStates currentState;
    private float lastStateChangeTime;
    public GameObject target;
    public float fleeDistance;
    public Transform[] waypoints;
    public float waypointStopDistance;
    private int currentWaypoint = 0;
    // Start is called before the first frame update
    public override void Start()
    {

        // Run the parent (base) Start
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        // Make decisions
        MakeDecisions();
        // Run the parent (base) Update
        base.Update();
    }

    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIStates.Idle:
                // Do work 
                DoIdleState();
                // Check for transitions
                if (IsHasTarget() == false)
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                if (IsDistanceLessThan(target, 20))
                {
                    ChangeState(AIStates.Attack);
                }

                else if (IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIStates.Flee);
                }
                break;
            case AIStates.Attack:
                // Do work
                DoAttackState();
                // Check for transitions
                if (IsHasTarget() == false)
                {
                    ChangeState(AIStates.ChooseTarget);
                }
                if (!IsDistanceLessThan(target, 20))
                {
                    ChangeState(AIStates.Idle);
                }

                else if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIStates.Flee);
                }
                break;
            case AIStates.Flee:

                DoFleeState();

                if (IsHasTarget() == false)
                {
                    ChangeState(AIStates.ChooseTarget);
                }

                if (!IsDistanceLessThan(target, 20))
                {
                    ChangeState(AIStates.Idle);
                }

                else if (!IsDistanceLessThan(target, 10))
                {
                    ChangeState(AIStates.Attack);
                }
                break;
            case AIStates.ChooseTarget:

                DoChooseTargetState();

                if (IsHasTarget() == true)
                {
                    if (IsDistanceLessThan(target, 20))
                    {
                        ChangeState(AIStates.Attack);
                    }

                    else if (IsDistanceLessThan(target, 10))
                    {
                        ChangeState(AIStates.Flee);
                    }
                }
                break;
            case AIStates.Patrol:

                DoPatrolState();
                break;
        }
    }

    //When to change states
    public void ChangeState(AIStates newState)
    {
        // Change the current state
        currentState = newState;
        // Save the time when we changed states
        lastStateChangeTime = Time.time;

    }

    //Seek target
    public void Seek(GameObject target)
    {
        // RotateTowards the Function
        pawn.RotateTowards(target.transform.position);
        // Move Forward
        pawn.MoveForward();
    }

    public void Seek(Vector3 targetPosition)
    {
        // RotateTowards the Funciton
        pawn.RotateTowards(targetPosition);
        // Move Forward
        pawn.MoveForward();
    }

    public void Seek(Transform targetTransform)
    {
        // Seek the position of our target Transform
        Seek(targetTransform.position);
    }

    public void Seek(Pawn targetPawn)
    {
        // Seek the pawn's transform!
        Seek(targetPawn.transform);
    }

    public void DoSeekState()
    {
        // Seek our target
        Seek(target);
    }

    public void Shoot()
    {
        pawn.Shoot();
    }

    protected virtual void DoChaseState()
    {
        Seek(target);
    }

    protected virtual void DoIdleState()
    {
        // Do Nothing
    }

    protected virtual void DoAttackState()
    {
        Seek(target);
        Shoot();
    }

    protected virtual void DoFleeState()
    {
        Flee();
    }

    protected virtual void DoChooseTargetState()
    {
        TargetPlayerOne();
    }

    protected virtual void DoPatrolState()
    {
        Patrol();
    }
    protected bool IsDistanceLessThan(GameObject target, float distance)
    {
        if (Vector3.Distance(pawn.transform.position, target.transform.position) < distance)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    protected void Flee()
    {
        // Find the Vector to our target
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        // Find the Vector away from our target by multiplying by -1
        Vector3 vectorAwayFromTarget = -vectorToTarget;
        // Find the vector we would travel down in order to flee
        Vector3 fleeVector = vectorAwayFromTarget.normalized * fleeDistance;
        // Seek the point that is "fleeVector" away from our current position
        Seek(pawn.transform.position + fleeVector);
    }

    protected void Scan()
    {

    }

    protected void Patrol()
    {
        // If we have a enough waypoints in our list to move to a current waypoint
        if (waypoints.Length > currentWaypoint)
        {
            // Then seek that waypoint
            Seek(waypoints[currentWaypoint]);
            // If we are close enough, then increment to next waypoint
            if (Vector3.Distance(pawn.transform.position, waypoints[currentWaypoint].position) <= waypointStopDistance)
            {
                currentWaypoint++;
            }
        }
        else
        {
            RestartPatrol();
        }
    }

    protected void RestartPatrol()
    {
        // Set the index to 0
        currentWaypoint = 0;
    }

    public void TargetPlayerOne()
    {
        // If the GameManager exists
        if (GameManager.instance != null)
        {
            // And the array of players exists
            if (GameManager.instance.players != null)
            {
                // And there are players in it
                if (GameManager.instance.players.Count > 0)
                {
                    //Then target the gameObject of the pawn of the first player controller in the list
                    target = GameManager.instance.players[0].pawn.gameObject;
                }
            }
        }
    }

    protected bool IsHasTarget()
    {
        // return true if we have a target, false if we don't
        return (target != null);
    }

    protected void TargetNearestTank()
    {
        // Get a list of all the tanks (pawns)
        Pawn[] allTanks = FindObjectsOfType<Pawn>();

        // Assume that the first tank is closest
        Pawn closestTank = allTanks[0];
        float closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);

        // Iterate through them one at a time
        foreach (Pawn tank in allTanks)
        {
            // If this one is closer than the closest
            if (Vector3.Distance(pawn.transform.position, tank.transform.position) <= closestTankDistance)
            {
                // It is the closest
                closestTank = tank;
                closestTankDistance = Vector3.Distance(pawn.transform.position, closestTank.transform.position);
            }
        }

        // Target the closest tank
        target = closestTank.gameObject;
    }


}