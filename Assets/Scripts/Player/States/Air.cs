using Common;
using UnityEngine;

namespace Player.States
{
    public class Air : PlayerState
    {
        public Air(Player player, StateMachine stateMachine, string animationName) : base(player, stateMachine,
            animationName)
        {
        }

        public override State EnterInterceptor(State state)
        {
            if (state != player.StateAir)
            {
                return base.EnterInterceptor(state);
            }

            if (player.velocity.y > 0)
            {
                return player.StateJump;
            }
            else
            {
                return player.IsCheckedWall() ? player.StateWallSlide : player.StateJump;
            }
        }
    }
}