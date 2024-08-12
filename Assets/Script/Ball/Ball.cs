using UnityEngine;

namespace Script.Ball
{
    public class Ball : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        public void SetVelocity(float value)
        {
            _rb.velocity = new Vector2(value, 0f);
        }
    }
}