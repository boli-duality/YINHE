using Common;

namespace Player.States
{
    public class Idle : Ground
    {
        public Idle(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (player.velocity.x != 0)
            {
                stateMachine.ChangeState(player.StateMove);
            }
        }
    }
}