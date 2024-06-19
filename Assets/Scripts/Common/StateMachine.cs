namespace Common
{
    public abstract class StateMachine
    {
        private State CurrentState { get; set; }

        private void Init(State state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        private void ChangeState(State state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}