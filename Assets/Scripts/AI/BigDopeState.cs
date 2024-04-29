using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigDopeState : AIController
{
    public override void MakeDecisions()
    {
        switch (currentState)
        {
            case AIStates.Patrol:
                // Do work 
                DoPatrolState();
                // Check for transitions
                if (IsCanHear(target) == true)
                {
                    ChangeState(AIStates.Seek);
                    if (IsCanSee(target) == true)
                    {
                        ChangeState(AIStates.ChooseTarget);
                    }

                }
                break;
        }
    }
}
