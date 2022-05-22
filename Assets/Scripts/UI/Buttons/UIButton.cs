using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Buttons
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour
    {
        private Button _button;
        
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(OnClick);
        }

        protected abstract void OnClick();
        
        protected void TurnOn()
        {
            _button.onClick.AddListener(OnClick);
        }

        protected void TurnOff()
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }
}