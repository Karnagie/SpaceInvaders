using System;
using TMPro;
using UnityEngine;

namespace UI.TestEssence
{
    public class Remainder : MonoBehaviour
    {
        [SerializeField] private string _text = "Ship remains:";
        
        private TMP_Text _tmp;
        private int _shipCount;

        public Action<int> OnUpdate;

        private void Awake()
        {
            _tmp = GetComponent<TMP_Text>();
        }

        public void Init(int count)
        {
            _shipCount = count;
            _tmp.text = $"{_text} {_shipCount}";
        }

        public void RemoveShip()
        {
            _tmp.text = $"{_text} {--_shipCount}";
            OnUpdate?.Invoke(_shipCount);
        }
    }
}