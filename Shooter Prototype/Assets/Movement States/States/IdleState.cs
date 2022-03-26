using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MovementBaseState
{
    public override void EnterState(MovementStateManager movement)
    {

    }

    public override void UpdateState(MovementStateManager movement)
    {
        if (movement.GetMoveDir().magnitude > 0.1f)
        {
            movement.SwitchState(movement.run);

        }
        if (Input.GetKeyDown(KeyCode.LeftControl)) movement.SwitchState(movement.crouch);
    }
}
