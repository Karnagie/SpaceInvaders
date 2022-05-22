using DG.Tweening;
using UnityEngine;

namespace UI.Animations
{
    public class ButtonAnimation : IUIAnimation
    {
        private CanvasGroup _group;
        private float _speed;

        public ButtonAnimation(CanvasGroup transform, float speed)
        {
            _group = transform;
            _speed = speed;
        }
        
        public void TurnOff()
        {
            _group.DOFade(0, _speed);
        }

        public void TurnOn()
        {
            _group.DOFade(1, _speed);
        }
    }
}