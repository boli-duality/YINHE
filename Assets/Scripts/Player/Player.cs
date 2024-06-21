using System;
using Common;
using Player.States;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Player : Living
    {
        #region 状态机
        public State StateIdle { get; private set; }
        public State StateMove { get; private set; }
        public State StateJump { get; private set; }
        #endregion

        private void Awake()
        {
            #region 状态机
            StateIdle = new Idle(this, stateMachine, "Idle");
            StateMove = new Move(this, stateMachine, "Move");
            StateJump = new Jump(this, stateMachine, "Jump");
            #endregion
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Init(StateIdle);
        }

        protected override void OnUpdating()
        {
            Transforming();
            base.OnUpdating();
        }

        protected override void OnUpdated()
        {
            Transformed();
        }

        private void Transforming()
        {
            velocity.x = Input.GetAxisRaw("Horizontal") * moveSpeed * 5;
            velocity.y = rigidbody2D.velocity.y;

            if (!Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }

            velocity.y = jumpForce;
            stateMachine.ChangeState(StateJump);
        }

        private void Transformed()
        {
            rigidbody2D.velocity = velocity;
        }
    }
}