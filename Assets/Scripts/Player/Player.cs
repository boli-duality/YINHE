using System;
using System.Diagnostics;
using Common;
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
        public State StateDash { get; private set; }
        public State StateGround { get; private set; }
        public State StateAir { get; private set; }
        public State StateWallSlide { get; private set; }
        public State StateWallJump { get; private set; }
        #endregion

        // 上一帧是否同时按下左右键
        private bool _lastKeepOnX;

        [Header("Dash")]
        public float dashDuration = .2f;
        public float dashCooldown = .5F;
        [NonSerialized] public float dashCooldownTimer;
        public bool CanDash => dashCooldownTimer <= 0 && !IsCheckedWall();
        public float dashSpeed = 60;
        [NonSerialized] public float dashDirection = 1;

        [NonSerialized] public float yInput;

        private void Awake()
        {
            #region 状态机
            StateIdle = new States.Idle(this, stateMachine, "Idle");
            StateMove = new States.Move(this, stateMachine, "Move");
            StateJump = new States.Jump(this, stateMachine, "Jump");
            StateDash = new States.Dash(this, stateMachine, "Dash");
            StateGround = new States.Ground(this, stateMachine, "Ground");
            StateAir = new States.Air(this, stateMachine, "Air");
            StateWallSlide = new States.WallSlide(this, stateMachine, "WallSlide");
            StateWallJump = new States.WallJump(this, stateMachine, "WallJump");
            #endregion
        }

        protected override void Start()
        {
            base.Start();
            stateMachine.Init(StateIdle);
        }

        protected override void OnUpdateStart()
        {
            MoveController();
            // 翻转控制
            FlipController();
            DashController();
        }

        protected override void OnUpdateEnd()
        {
            MoveSettled();
        }

        private void MoveController()
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

            yInput = Input.GetAxisRaw("Vertical");
        }

        private void MoveSettled()
        {
            rigidbody2D.velocity = velocity;
        }

        private void FlipController()
        {
            if (stateMachine.CurrentState == StateDash)
            {
                return;
            }

            switch (velocity.x)
            {
                case > 0 when !IsFaceRight:
                case < 0 when IsFaceRight:
                    IsFaceRight = !IsFaceRight;
                    moveDirection = IsFaceRight ? 1 : -1;
                    transform.Rotate(0, 180, 0);
                    break;
            }
        }

        private void DashController()
        {
            if (dashCooldownTimer > 0)
            {
                dashCooldownTimer -= Time.deltaTime;
            }
        }
    }
}