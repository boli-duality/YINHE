using Common;

namespace Player.States
{
    public class Idle : Grounded
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
                player.stateMachine.ChangeState(player.StateMove);
            }
        }
    }
}