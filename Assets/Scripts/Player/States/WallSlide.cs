using Common;
using UnityEngine;

namespace Player.States
{
    public class WallSlide : Air
    {
        public WallSlide(Player player, StateMachine stateMachine, string animationName) : base(player, stateMachine,
            animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (!Input.GetKey(KeyCode.S))
            {
                player.velocity.y *= .7f;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateMachine.ChangeState(player.StateWallJump);
            }

            if (!player.IsCheckedWall())
            {
                stateMachine.ChangeState(player.velocity.y == 0 ? player.StateGround : player.StateAir);
            }

            if (player.IsCheckedGround())
            {
                stateMachine.ChangeState(player.StateGround);
            }
        }
    }
}