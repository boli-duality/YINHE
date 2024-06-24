using Common;
using UnityEngine;

namespace Player.States
{
    public class Grounded : PlayerState
    {
        protected Grounded(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.velocity.y = player.jumpForce;
                stateMachine.ChangeState(player.StateJump);
            }
        }
    }
}