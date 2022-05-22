using System.Collections.Generic;
using AliveObjects;
using UI.Animations;
using UnityEngine;
using Zenject;

namespace UI.Buttons
{
    [RequireComponent(typeof(CanvasGroup))]
    public class PlayButton : UIButton
    {
        [SerializeField] private float _fadeSpeed = 0.5f;
        
        [Inject] private IPausable[] _pausables;

        protected override void OnClick()
        {
            CanvasGroup group = GetComponent<CanvasGroup>();
            IUIAnimation fade = new ButtonAnimation(group, _fadeSpeed);
            fade.TurnOff();
            
            foreach (var freezable in _pausables)
            {
                if(freezable.IsPaused) freezable.Unpause();
                else freezable.Pause();
            }
            TurnOff();
        }
    }
}