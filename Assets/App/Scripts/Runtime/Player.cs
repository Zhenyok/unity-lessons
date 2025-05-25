using UnityEngine;

namespace Runtime
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private BoxCollider2D _collider;
        
        void Update()
        {
            float moveX = 0f;
            float moveY = 0f;

            if (Input.GetKey(KeyCode.A)) moveX = -1f;
            if (Input.GetKey(KeyCode.D)) moveX = 1f; 
            if (Input.GetKey(KeyCode.W)) moveY = 1f;
            if (Input.GetKey(KeyCode.S)) moveY = -1f;

            Vector3 moveDirection = new Vector3(moveX, moveY, 0f).normalized;
            
            transform.position += moveDirection * 5f * Time.deltaTime;
        }
    
        void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("Зіткнення з: " + collision.gameObject.name);
        }
    
        void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log("Продовжується контакт з: " + collision.gameObject.name);
        }
    
        void OnCollisionExit2D(Collision2D collision)
        {
            Debug.Log("Зіткнення завершено з: " + collision.gameObject.name);
        }
    }
}
