using System;
using UnityEngine;

namespace Input
{
    public class KeyboardInput : IInputHandler
    {
        private MainActions _actions;

        public KeyboardInput()
        {
            _actions = new MainActions();
            _actions.Player.Shoot.started += ctx => OnShoot?.Invoke();
            _actions.Enable();
        }

        public Action OnShoot { get; set; }

        public Vector2 GetVelocity()
        {
            return _actions.Player.Velocity.ReadValue<Vector2>();
        }
    }
}