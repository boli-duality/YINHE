using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Common
{
    public class Living : MonoBehaviour
    {
        public Animator animator;
        public new Rigidbody2D rigidbody2D;
        [HideInInspector] public Vector2 velocity;

        [Header("Move Speed")]
        [SerializeField] protected float moveSpeed = 20;
        [SerializeField] public float jumpForce = 20;
        [FormerlySerializedAs("moveCoefficient")]
        [HideInInspector]
        public int moveDirection = 1;

        [Header("Collision info")]
        [SerializeField] public LayerMask groundLayer;
        [SerializeField] public Transform groundCheck;
        [SerializeField] public float groundCheckDistance;
        [SerializeField] public LayerMask wallLayer;
        [SerializeField] public Transform wallCheck;
        [SerializeField] public float wallCheckDistance;

        public bool isGrounded;
        public bool IsFaceRight { get; set; } = true;

        public readonly StateMachine stateMachine = new();

        protected virtual void Start()
        {
            animator = GetComponentInChildren<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
        }

        protected void Update()
        {
            OnUpdateStart();
            OnUpdate();
            OnUpdateEnd();
        }

        protected virtual void OnUpdateStart()
        {
        }

        protected virtual void OnUpdate()
        {
            stateMachine.CurrentState.Update();
        }

        protected virtual void OnUpdateEnd()
        {
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = true;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                isGrounded = false;
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawLine(groundCheck.position,
                new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
            Gizmos.DrawLine(wallCheck.position,
                new Vector3(wallCheck.position.x + wallCheckDistance * moveDirection, wallCheck.position.y));
        }

        public bool IsCheckedGround()
        {
            return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        }

        public bool IsCheckedWall()
        {
            return Physics2D.Raycast(wallCheck.position, Vector2.right * moveDirection, wallCheckDistance, wallLayer);
        }
    }
}