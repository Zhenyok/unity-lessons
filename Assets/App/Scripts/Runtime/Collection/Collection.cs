using App.Scripts.Runtime.Actions;
using App.Scripts.Runtime.Player;
using UnityEngine;

namespace App.Scripts.Runtime.Collection
{
    public class Collection : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Character>(out _))
            {
                if (gameObject.TryGetComponent(out DestroyObjectAction destroyAction))
                {
                    destroyAction.DestroyGameObject = gameObject;
                    destroyAction.Execute();
                }
            }
        }
    }
}