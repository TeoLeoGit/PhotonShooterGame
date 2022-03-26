using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {
        movement.GetAnimator().SetBool("Running", true);
        
    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.GetMoveDir().magnitude < 0.1f) ExitState(movement, movement.idle);
        if (Input.GetKey(KeyCode.LeftControl)) ExitState(movement, movement.crouch);
    }

    void ExitState(MovementStateManager movement, MovementBaseState state)
    {
        movement.GetAnimator().SetBool("Running", false);
        movement.SwitchState(state);
    }
}
