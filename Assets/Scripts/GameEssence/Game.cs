using System;
using AliveObjects;
using UI.Buttons;
using UI.TestEssence;
using UnityEngine;
using Zenject;

namespace GameEssence
{
    public class Game : MonoBehaviour
    {
        [Inject] private IPausable[] _pausables;
        [Inject] private Remainder _remainder;
        [Inject] private RepeatButton _repeat;

        private void Awake()
        {
            foreach (var pausable in _pausables)
            {
                pausable.Pause();
            }

            _remainder.OnUpdate += CheckRemindShips;
        }

        private void CheckRemindShips(int remind)
        {
            if (remind == 0)
            {
                foreach (var pausable in _pausables)
                {
                    pausable.Pause();
                }
                _repeat.Show();
            }
        }
    }
}