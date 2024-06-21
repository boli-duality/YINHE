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

        // 上一帧是否同时按下左右键
        private bool _lastKeepOnX;

        public bool IsFaceRight { get; set; } = true;

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

        protected override void OnBeforeUpdate()
        {
            Transforming();
        }

        protected override void OnUpdated()
        {
            Transformed();
        }

        private void Transforming()
        {
            var keepOnX = Input.GetAxisRaw("Horizontal") == 0 &&
                          (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) &&
                          (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow));
            if (!keepOnX)
            {
                velocity.x = Input.GetAxisRaw("Horizontal") * moveSpeed;
            }
            else if (!_lastKeepOnX)
            {
                velocity.x *= -1;
            }

            _lastKeepOnX = keepOnX;

            velocity.y = rigidbody2D.velocity.y;

            switch (velocity.x)
            {
                case > 0 when !IsFaceRight:
                case < 0 when IsFaceRight:
                    Flip();
                    break;
            }
        }

        private void Transformed()
        {
            rigidbody2D.velocity = velocity;
        }

        private void Flip()
        {
            IsFaceRight = !IsFaceRight;
            transform.Rotate(0, 180, 0);
        }
    }
}