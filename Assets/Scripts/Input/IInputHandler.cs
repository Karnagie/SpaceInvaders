using System;
using UnityEngine;

namespace Input
{
    public interface IInputHandler
    {
        public Action OnShoot { get; set; }
        
        Vector2 GetVelocity();
    }
}