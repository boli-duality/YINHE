using Common;

namespace Player.States
{
    public class Move : GroundedState
    {
        public Move(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (player.velocity.x == 0)
            {
                player.stateMachine.ChangeState(player.StateIdle);
            }
        }
    }
}