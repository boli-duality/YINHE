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

        public bool isGrounded;

        public readonly StateMachine stateMachine = new();

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
                new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
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

        public bool IsCheckedGround()
        {
            return Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, groundLayer);
        }
    }
}