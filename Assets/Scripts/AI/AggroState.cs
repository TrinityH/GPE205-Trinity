using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggroState : AIController
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
                if (IsCanHear(target) == true || IsCanSee(target) == true && !IsDistanceLessThan(target, fleeDistance))
                {
                    ChangeState(AIStates.Attack);
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
                break;
            case AIStates.ChooseTarget:

                DoChooseTargetState();

                if (IsHasTarget() == true)
                {
                    if (IsDistanceLessThan(target, attackDistance))
                    {
                        ChangeState(AIStates.Attack);
                    }
                }
                break;
 
        }
    }
}
