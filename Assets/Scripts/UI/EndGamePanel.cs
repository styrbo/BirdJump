using Core.Characters;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class EndGamePanel : MonoBehaviour
    {
        [SerializeField] private Button _buttonForAnimate;
        
        [Inject] private Player _player;

        public bool Active
        {
            set
            {
                _group.alpha = value ? 1 : 0;
                _group.interactable = value;
                _group.blocksRaycasts = value;
            }
        }

        private CanvasGroup _group;

        private void Awake()
        {
            _group = GetComponent<CanvasGroup>();
            Active = false;
            _player.OnDead += OnDead;
        }

        private void Start()
        {
            _buttonForAnimate.transform.DOScale(Vector3.one * 1.1f, 1f).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDead()
        {
            Active = true;
        }

        public void RestartButton()
        {
            SceneManager.LoadScene(0);
        }
    }
}