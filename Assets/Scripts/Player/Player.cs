using System;
using Common;
using Player.State;
using UnityEngine;

namespace Player
{
    public class Player : Living
    {
        private StateMachine _stateMachine;
        public Common.State stateIdle;
        public Common.State stateMove;

        private void Awake()
        {
            _stateMachine = new StateMachine();
            stateIdle = new Idle(this, _stateMachine, "Idle");
            stateMove = new Move(this, _stateMachine, "Move");
        }

        // Start is called before the first frame update
        protected override void Start()
        {
            base.Start();
            _stateMachine.Init(stateIdle);
        }

        // Update is called once per frame
        private new void Update()
        {
            base.Update();
            _stateMachine.CurrentState.Update();
        }
    }
}