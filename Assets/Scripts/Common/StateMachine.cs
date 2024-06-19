using UnityEngine;

namespace Common
{
    public abstract class StateMachine
    {
        public State CurrentState { get; private set; }

        public virtual void Init(State state)
        {
            CurrentState = state;
            CurrentState.Enter();
        }

        public virtual void ChangeState(State state)
        {
            CurrentState.Exit();
            CurrentState = state;
            CurrentState.Enter();
        }
    }
}