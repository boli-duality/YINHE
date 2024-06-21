using UnityEngine;

namespace Common
{
    public abstract class State
    {
        protected readonly StateMachine stateMachine;
        protected readonly int animationHash;

        protected State(StateMachine stateMachine, string animationName)
        {
            this.stateMachine = stateMachine;
            animationHash = Animator.StringToHash(animationName);
        }

        public abstract void Enter();

        public abstract void Exit();

        public abstract void Update();
    }
}