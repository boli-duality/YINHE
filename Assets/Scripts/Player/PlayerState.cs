using Common;
using UnityEngine;

namespace Player
{
    public class PlayerState : State
    {
        protected readonly Player player;

        protected PlayerState(Player player, StateMachine stateMachine, string animationName)
            : base(stateMachine, animationName)
        {
            this.player = player;
        }

        public override void Enter()
        {
            player.animator.SetBool(animationHash, true);
        }

        public override void Exit()
        {
            player.animator.SetBool(animationHash, false);
        }

        public override void Update()
        {
        }
    }
}