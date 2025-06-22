using System.Collections.Generic;
using App.Scripts.Core.CustomBases;
using App.Scripts.Runtime.Actions;
using UnityEngine;

namespace App.Scripts.Runtime.Player
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private List<ActionBase> _executeWhenCharacterTouch;

        protected bool _isInitiated;

        private void Update()
        {
            if (_isInitiated)
            {
                _collider.enabled = _target.transform.position.y > transform.position.y;
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<Character>(out Character character))
            {
                foreach (ActionBase actionBase in _executeWhenCharacterTouch)
                {

                    if (actionBase is ChangeColorAction)
                    {
                        if (character.IsTouchGround && _collider.enabled)
                        {
                            actionBase.Execute();
                        }
                        
                        continue;
                    }

                    actionBase.Execute();
                }
            }
        }

        public void Init(Transform target)
        {
            _target = target;
            _isInitiated = true;
        }
    }
}