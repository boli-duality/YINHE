using Common;
using UnityEngine;

namespace Player.States
{
    public class GroundedState : PlayerState
    {
        private readonly int _velocityYHash = Animator.StringToHash("velocityY");

        protected GroundedState(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            player.animator.SetFloat(_velocityYHash, player.velocity.y);
        }
    }
}