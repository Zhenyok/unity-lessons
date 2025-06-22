using App.Scripts.Core.CustomBases;
using UnityEngine;

namespace App.Scripts.Runtime.Actions
{
    public class DestroyObjectAction : ActionBase
    {
        private GameObject _destroyObject;

        public GameObject DestroyGameObject
        {
            set => _destroyObject = value;
        }

        protected override void ExecuteInternal()
        {
            // play some animation
            Destroy(_destroyObject);
        }
    }
}