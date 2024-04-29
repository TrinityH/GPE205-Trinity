﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : AIController
{


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
                    ChangeState(AIStates.Seek);
                    ChangeState(AIStates.ChooseTarget);
                }
                if (IsHasTarget() == true)
                {
                    ChangeState(AIStates.Patrol);
                }

                break;

            case AIStates.Patrol:
                //Do Work
                DoPatrolState();
                
                if (IsCanHear(target) == true || IsCanSee(target) == true && !IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Attack);
                }
                else if (IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Flee);
                }
                else if (!IsCanSee(target) && !IsCanHear(target) && IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Patrol);
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
                if (!IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Idle);
                }

                else if (IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Flee);
                }
                break;
            case AIStates.Flee:

                DoFleeState();

                if (IsHasTarget() == false && IsCanHear(target) == true && IsCanSee(target) == true)
                {
                    ChangeState(AIStates.ChooseTarget);
                }

                if (!IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Idle);
                }

                else if (!IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Attack);
                }
                break;
            case AIStates.ChooseTarget:

                DoChooseTargetState();

                if (IsHasTarget() == true)
                {
                    if (IsDistanceLessThan(target, fleeDistance))
                    {
                        ChangeState(AIStates.Attack);
                    }

                    else if (!IsDistanceLessThan(target, fleeDistance))
                    {
                        ChangeState(AIStates.Flee);
                    }
                }
                break;
        }
    }
}
