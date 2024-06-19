using Common;

namespace Player.State
{
    public class Move : Common.State
    {
        private readonly Player _player;

        public Move(Player player, StateMachine stateMachine, string animationName)
            : base(stateMachine, animationName)
        {
            _player = player;
        }

        public override void Enter()
        {
            base.Enter();

            _player.animator.SetBool(animationName, true);
        }

        public override void Exit()
        {
            base.Exit();
            _player.animator.SetBool(animationName, false);
        }

        public override void Update()
        {
            base.Update();

            if (_player.xAxis == 0)
            {
                stateMachine.ChangeState(_player.stateIdle);
            }
        }
    }
}