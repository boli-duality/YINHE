using System;
using UnityEngine;

namespace Common
{
    public class Living : MonoBehaviour
    {
        public Animator animator;
        public new Rigidbody2D rigidbody2D;

        public readonly StateMachine stateMachine = new();

        [Header("Move Speed")]
        [SerializeField] protected float moveSpeed;
        [SerializeField] public float jumpForce = 10f;

        [Header("Collision info")]
        [SerializeField] public LayerMask groundLayer;
        [SerializeField] public Transform groundCheck;
        [SerializeField] public float groundCheckDistance;
        [SerializeField] public LayerMask wallLayer;
        [SerializeField] public Transform wallCheck;
        [SerializeField] public float wallCheckDistance;

        [HideInInspector] public Vector2 velocity;

        protected virtual void Start()
        {
            animator = GetComponentInChildren<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected void Update()
        {
            OnBeforeUpdate();
            OnUpdating();
            OnUpdated();
        }

        protected virtual void OnBeforeUpdate()
        {
        }

        protected virtual void OnUpdating()
        {
            stateMachine.CurrentState.Update();
        }

        protected virtual void OnUpdated()
        {
        }

        public bool IsGrounded()
        {
            return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(groundCheck.position,
                new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position,
                new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
        }
    }
}