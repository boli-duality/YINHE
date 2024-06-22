using System;
using Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class Player : Living
    {
        // 上一帧是否同时按下左右键
        private bool _lastKeepOnX;

        public bool IsFaceRight { get; set; } = true;

        private void Awake()
        {
            #region 状态机
            StateIdle = new States.Idle(this, stateMachine, "Idle");
            StateMove = new States.Move(this, stateMachine, "Move");
            StateJump = new States.Jump(this, stateMachine, "Jump");
            StateDash = new States.Dash(this, stateMachine, "Dash");
            #endregion
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Init(StateIdle);
        }

        protected override void OnBeforeUpdate()
        {
            TransformController();
        }

        protected override void OnUpdated()
        {
            TransformSettled();
        }

        private void TransformController()
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

        private void TransformSettled()
        {
            rigidbody2D.velocity = velocity;
        }

        private void Flip()
        {
            IsFaceRight = !IsFaceRight;
            transform.Rotate(0, 180, 0);
        }

        #region 状态机
        public State StateIdle { get; private set; }
        public State StateMove { get; private set; }
        public State StateJump { get; private set; }
        public State StateDash { get; private set; }
        #endregion
    }
}