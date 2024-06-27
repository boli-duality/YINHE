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

            if (!player.IsCheckedWall())
            {
                if (player.velocity.y == 0)
                {
                    stateMachine.ChangeState(player.StateGround);
                }
                else
                {
                    stateMachine.ChangeState(player.StateAir);
                }
            }

            if (player.IsCheckedGround())
            {
                stateMachine.ChangeState(player.StateGround);
            }
        }
    }
}