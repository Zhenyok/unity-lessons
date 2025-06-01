using System;
using UnityEngine;

namespace Runtime
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private float _groundCheckDistance = 1.1f;
        [SerializeField] private LayerMask _groundMask;
    
        private bool _isJump;
        private bool _isTouchGround;
        
        void Update()
        {
            JumpAction();
        }

        private void JumpAction()
        {
            _isTouchGround = Physics2D.Raycast(
                    _rigidbody.position, 
                    Vector2.down, 
                    _groundCheckDistance, 
                    _groundMask
                )
            ;
        
            Debug.DrawRay(_rigidbody.position, Vector2.down * _groundCheckDistance, Color.red);
        
            if (Input.GetKeyDown(KeyCode.W))
            {
                _isJump = true;
            }
        }

        private void FixedUpdate()
        {
            if (!_isTouchGround)
            {
                return;
            }

            if (_isJump)
            {
                _rigidbody.AddForce(Vector2.up * _jumpForce , ForceMode2D.Impulse);
                _isJump = false;
            }
        }
    }
}
