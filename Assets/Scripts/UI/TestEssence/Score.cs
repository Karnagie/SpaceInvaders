using System;
using TMPro;
using UnityEngine;

namespace UI.TestEssence
{
    [RequireComponent(typeof(TMP_Text))]
    public class Score : MonoBehaviour
    {
        [SerializeField] private string _text = "Score:";
        
        private TMP_Text _tmp;
        private int _score;

        private void Awake()
        {
            _tmp = GetComponent<TMP_Text>();
            _score = PlayerPrefs.GetInt("Score", 0);
            _tmp.text = $"{_text} {_score}";
        }

        public void AddPoint()
        {
            _tmp.text = $"{_text} {++_score}";
            PlayerPrefs.SetInt("Score", _score);
        }
    }
}