using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.GetAnimator().SetBool("Crouching", true);
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (Input.GetKeyUp(KeyCode.LeftControl)) 
        {
            ExitState(movement, movement.run);
            if (movement.GetMoveDir().magnitude < 0.1f) ExitState(movement, movement.idle);
        }
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.GetAnimator().SetBool("Crouching", false);
        movement.SwitchState(state);
    }
}
