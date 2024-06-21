using Common;

namespace Player.States
{
    public class Jump : PlayerState
    {
        public Jump(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (player.velocity.y == 0)
            {
                player.stateMachine.ChangeState(player.StateIdle);
            }
        }
    }
}