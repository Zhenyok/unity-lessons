using UnityEngine;

namespace App.Scripts.Core.CustomBases
{
    public abstract class ActionBase: MonoBehaviour
    {
        [SerializeField] protected bool _executeOnStart;
        [SerializeField] protected bool _executeOnlyOnce;

        protected bool IsExecutedOnce;
        protected virtual void Start()
        {
            if (_executeOnStart)
            {
                Execute();
            }
        }

        public void Execute()
        {
            if (_executeOnStart && _executeOnlyOnce)
            {
                return;
            }
            
            IsExecutedOnce =  true;
            ExecuteInternal();
        }
        
        protected abstract void ExecuteInternal();
    }
}