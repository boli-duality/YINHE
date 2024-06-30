using Common;
using UnityEngine;

namespace Player.States
{
    public class WallJump : Air
    {
        private float _stateTimer;

        public WallJump(Player player, StateMachine stateMachine, string animationName) : base(player, stateMachine,
            animationName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _stateTimer = .2f;
            player.velocity.y = player.jumpForce;
            player.velocity.x = -player.moveDirection * player.moveSpeed;
        }

        public override void Update()
        {
            base.Update();
            _stateTimer -= Time.deltaTime;
            var velocity = player.rigidbody2D.velocity;
            player.velocity.x = velocity.x;
            player.velocity.y = velocity.y;
            Debug.Log("_stateTimer: " + _stateTimer);
            if (_stateTimer < 0)
            {
                stateMachine.ChangeState(player.StateAir);
            }
        }
    }
}