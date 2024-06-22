using Common;

namespace Player.States
{
    public class Dash : PlayerState
    {
        public Dash(Player player, StateMachine stateMachine, string animationName) : base(player, stateMachine,
            animationName)
        {
        }
    }
}