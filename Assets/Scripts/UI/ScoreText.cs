using Core.Characters;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI
{
    public class ScoreText : MonoBehaviour
    {
        [Inject] private Player _player;
    
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
        
            _player.OnScoreUpdate += OnScoreUpdate;
        }

        private void Start()
        {
            _text.text = 0.ToString();
        }

        private void OnScoreUpdate(int value)
        {
            _text.text = value.ToString();
        }
    }
}
