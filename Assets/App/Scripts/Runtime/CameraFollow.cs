using UnityEngine;

namespace App.Scripts.Runtime
{
    public class CameraFollow: MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private float _speed;
        [Space] 
        [SerializeField] private bool _followByX;
        [SerializeField] private bool _followByY;
        [SerializeField] private bool _followByZ;

        void LateUpdate()
        {
            var targetPosition = new Vector3(
                _followByX ? _target.position.x : transform.position.x,
                _followByY ? _target.position.y : transform.position.y,
                _followByZ ? _target.position.z : transform.position.z
            );
            
            transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);
        }
    }
}
