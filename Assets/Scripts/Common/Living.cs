using UnityEngine;

namespace Common
{
    public class Living : MonoBehaviour
    {
        public Animator animator;
        public float xAxis;

        // Start is called before the first frame update
        protected virtual void Start()
        {
            animator = GetComponentInChildren<Animator>();
        }

        // Update is called once per frame
        protected void Update()
        {
            xAxis = Input.GetAxisRaw("Horizontal");
        }
    }
}