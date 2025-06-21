using UnityEngine;

namespace App.Scripts.Runtime.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private float _jumpForce = 10;
        [SerializeField] private float _groundCheckDistance = 0.86f;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private float _moveSpeed;
    
        private bool _isJump = false;
        private bool _isTouchGround = false;
        private float _moveDirection;
        
        private Vector3 _lookRight;
        private Vector3 _lookLeft;

        void Start()
        {
            _lookRight = _rigidbody.transform.localScale;
            
            _lookLeft = new Vector3(
                -_rigidbody.transform.localScale.x, 
                _rigidbody.transform.localScale.y, 
                _rigidbody.transform.localScale.z
            );
        }
        
        void Update()
        {
            JumpAction();
            CalculateSpeedAction();
        }

        private void CalculateSpeedAction()
        {
            _moveDirection = Input.GetAxis("Horizontal");

            if (_moveDirection < 0)
            {
                _rigidbody.transform.localScale = _lookLeft;
            }
            else
            {
                _rigidbody.transform.localScale = _lookRight;
            }
        }

        private void JumpAction()
        {
            if (!_isTouchGround)
            {
                _isTouchGround = Physics2D.Raycast(
                        _rigidbody.position, 
                        Vector2.down, 
                        _groundCheckDistance, 
                        _groundMask
                    )
                ;
            }
        
            Debug.DrawRay(_rigidbody.position, Vector2.down * _groundCheckDistance, Color.red);
        
            if (Input.GetKeyDown(KeyCode.W))
            {
                _isJump = true;
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                _isJump = false;
            }
        }

        private void FixedUpdate()
        {
            if (_isTouchGround && _isJump)
            {
                _rigidbody.linearVelocity = Vector2.up * _jumpForce;
                _isJump = _isTouchGround = false;
            }

            _rigidbody.linearVelocity = new Vector2(_moveDirection * _moveSpeed, _rigidbody.linearVelocity.y);
        }
    }
}
