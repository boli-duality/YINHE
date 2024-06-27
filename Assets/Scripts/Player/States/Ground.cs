using Common;
using UnityEngine;

namespace Player.States
{
    public class Ground : PlayerState
    {
        public Ground(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override State EnterInterceptor(State state)
        {
            if (state != player.StateGround)
            {
                return base.EnterInterceptor(state);
            }

            return player.velocity.x == 0 ? player.StateIdle : player.StateMove;
        }

        public override void Update()
        {
            base.Update();

            if (!player.IsCheckedGround())
            {
                stateMachine.ChangeState(player.StateAir);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) && player.IsCheckedGround())
            {
                player.velocity.y = player.jumpForce;
                player.isGrounded = false;
                stateMachine.ChangeState(player.StateJump);
            }
        }
    }
}