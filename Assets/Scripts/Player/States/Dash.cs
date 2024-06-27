using System.Timers;
using Common;
using UnityEngine;

namespace Player.States
{
    public class Dash : PlayerState
    {
        private float _countdown;

        public Dash(Player player, StateMachine stateMachine, string animationName) : base(player, stateMachine,
            animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _countdown = player.dashDuration;
        }

        public override void Update()
        {
            base.Update();
            _countdown -= Time.deltaTime;
            player.velocity.x = player.dashDirection * player.dashSpeed;
            player.velocity.y = 0;
            if (_countdown <= 0)
            {
                stateMachine.ChangeState(player.StateGround);
            }
            else if (player.IsCheckedWall())
            {
                stateMachine.ChangeState(player.StateWallSlide);
            }
        }
    }
}