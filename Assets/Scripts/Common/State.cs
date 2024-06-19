namespace Common
{
    public abstract class State
    {
        protected StateMachine stateMachine;
        private string _animationName;

        protected State(StateMachine stateMachine, string animationName)
        {
            this.stateMachine = stateMachine;
            _animationName = animationName;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }
    }
}