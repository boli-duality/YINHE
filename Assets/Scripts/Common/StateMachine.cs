using UnityEngine;

namespace Common
{
    public class StateMachine
    {
        public State CurrentState { get; private set; }

        public void Init(State state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public void ChangeState(State state)
        {
            CurrentState.Exit();
            CurrentState = state.EnterInterceptor(state);
            CurrentState.Enter();
        }
    }
}