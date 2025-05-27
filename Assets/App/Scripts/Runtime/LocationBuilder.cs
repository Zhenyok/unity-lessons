using UnityEngine;

namespace Runtime
{
    public class LocationBuilder : MonoBehaviour
    {
        public Sprite squareSprite;
        
        void Start()
        {
            var ground = new GameObject("Ground");
            var sr = ground.AddComponent<SpriteRenderer>();

            sr.sprite = squareSprite;
                    
            ground.transform.localScale = new Vector3(70f, -4.8f, 0);
            ground.transform.position = new Vector3(1.3f, -4.5f, 0);
    
            ground.AddComponent<BoxCollider2D>();
            var rb2d = ground.AddComponent<Rigidbody2D>();
            rb2d.gravityScale = 0;
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }
}
