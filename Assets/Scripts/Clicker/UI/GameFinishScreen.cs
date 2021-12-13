using System;
using Clicker.Game;
using Clicker.Mediators;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(ScreenAnimator))]
    public class GameFinishScreen : MonoBehaviour
    {
        [SerializeField] private GameMediator _gameMediator;
        [SerializeField] private TMP_Text _timeLabel;
        [SerializeField] private Button _menuButton; 
        
        private ScreenAnimator _screenAnimator;
        
        public void Display(int time)
        {
            gameObject.SetActive(true);
            _timeLabel.text = time.ToString("F1");
            _screenAnimator.AnimateAppearance();
        }

        public void Hide() => gameObject.SetActive(false);

        private void Awake() => _screenAnimator = GetComponent<ScreenAnimator>();

        private void OnEnable() => _menuButton.onClick.AddListener(_gameMediator.LoadMenu);
        private void OnDisable() => _menuButton.onClick.RemoveListener(_gameMediator.LoadMenu);
    }
}
