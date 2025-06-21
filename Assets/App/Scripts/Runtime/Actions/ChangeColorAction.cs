using App.Scripts.Core.CustomBases;
using UnityEngine;

namespace App.Scripts.Runtime.Actions
{
    public class ChangeColorAction : ActionBase
    {
        [SerializeField] private SpriteRenderer _targetRenderer;
        [SerializeField] private Color _defaultColor;


        public void ChangeColor(Color newColor)
        {
            if (_targetRenderer == null)
            {
                return;
            }

            _targetRenderer.color = newColor;
        }

        public void ChangeColor()
        {
            ChangeColor(_defaultColor);
        }


        protected override void ExecuteInternal()
        {
            ChangeColor();
        }
    }
}