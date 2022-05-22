using System;
using System.Collections.Generic;
using AliveObjects;
using AliveObjects.PlayerEssence;
using Input;
using ModestTree;
using PickUpEssence;
using UI.Buttons;
using UI.TestEssence;
using UnityEngine;
using Zenject;

namespace GameEssence
{
    public class Game : MonoBehaviour
    {
        [Inject] private List<IPausable> _pausables;
        [Inject] private Remainder _remainder;
        [Inject] private RepeatButton _repeat;
        [Inject] private IInputHandler _input;

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

        private void OnDestroy()
        {
            _input.Clear();
        }

        public void AddPausable(IPausable pausable)
        {
            _pausables.Add(pausable);
        }
    }
}