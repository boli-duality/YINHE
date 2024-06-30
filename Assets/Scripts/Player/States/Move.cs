using Common;

namespace Player.States
{
    public class Move : Ground
    {
        public Move(Player player, StateMachine stateMachine, string animationName)
            : base(player, stateMachine, animationName)
        {
        }

        public override void Update()
        {
            base.Update();

            if (player.velocity.x == 0 || player.IsCheckedWall())
            {
                stateMachine.ChangeState(player.StateIdle);
            }
        }
    }
}