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
            DashController();
        }

        private void DashController()
        {
            if (!player.CanDash || !Input.GetKeyDown(KeyCode.LeftShift))
            {
                return;
            }

            player.dashDirection = Input.GetAxisRaw("Horizontal");
            if (player.dashDirection == 0)
            {
                player.dashDirection = player.moveDirection;
            }

            player.dashCooldownTimer = player.dashCooldown;
            stateMachine.ChangeState(player.StateDash);
        }
    }
}