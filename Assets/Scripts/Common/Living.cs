using UnityEngine;

namespace Common
{
    public class Living : MonoBehaviour
    {
        public Animator animator;
        public new Rigidbody2D rigidbody2D;

        public StateMachine stateMachine;

        [Header("Move Speed")]
        [SerializeField]
        protected float moveSpeed;
        [SerializeField]
        protected float jumpForce = 10f;

        public Vector2 velocity;

        protected virtual void Start()
        {
            animator = GetComponentInChildren<Animator>();
            rigidbody2D = GetComponent<Rigidbody2D>();
            stateMachine = new StateMachine();
        }

        protected void Update()
        {
            OnUpdating();
            OnUpdated();
        }

        protected virtual void OnUpdating()
        {
            stateMachine.CurrentState.Update();
        }

        protected virtual void OnUpdated()
        {
        }
    }
}