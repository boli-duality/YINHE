using Common;
using UnityEngine;

namespace Player.States
{
    public class GroundedState : PlayerState
    {
        protected GroundedState(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (!Input.GetKeyDown(KeyCode.Space)) return;
            player.velocity.y = player.jumpForce;
            stateMachine.ChangeState(player.StateJump);
        }
    }
}