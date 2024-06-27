using Common;
using UnityEngine;

namespace Player.States
{
    public class Jump : Air
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

            if (y <= 0 && player.IsCheckedWall())
            {
                stateMachine.ChangeState(player.StateWallSlide);
            }

            if (player.IsCheckedGround() && y == 0)
            {
                stateMachine.ChangeState(player.StateGround);
            }
        }
    }
}