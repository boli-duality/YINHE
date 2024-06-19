using UnityEngine;

namespace Common
{
    public abstract class State
    {
        protected readonly StateMachine stateMachine;
        protected readonly string animationName;

        protected State(StateMachine stateMachine, string animationName)
        {
            this.stateMachine = stateMachine;
            this.animationName = animationName;
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