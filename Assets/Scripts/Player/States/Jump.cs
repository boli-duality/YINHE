using Common;
using UnityEngine;

namespace Player.States
{
    public class Jump : PlayerState
    {
        private readonly int _velocityYHash = Animator.StringToHash("velocityY");

        public Jump(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            var y = player.velocity.y;

            player.animator.SetFloat(_velocityYHash, y);

            if (player.isGrounded && y == 0)
            {
                player.stateMachine.ChangeState(player.velocity.x == 0 ? player.StateIdle : player.StateMove);
            }
        }
    }
}