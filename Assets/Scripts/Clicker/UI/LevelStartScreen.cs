using System;
using Clicker.Mediators;
using Clicker.Menu;
using Clicker.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    [RequireComponent(typeof(ScreenAnimator))]
    public class LevelStartScreen : MonoBehaviour
    {
        [SerializeField] private MenuMediator _menuMediator;
        [SerializeField] private LevelStartPanel _levelStartPanel;
        [SerializeField] private Button _closeButton;

        private ScreenAnimator _screenAnimator;
        private Level _selectedLevel;
        
        public void Display(Level level)
        {
            _selectedLevel = level;
            gameObject.SetActive(true);
            _levelStartPanel.Initialize(level);
            _screenAnimator.AnimateAppearance();
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        private void Awake() => _screenAnimator = GetComponent<ScreenAnimator>();
        private void OnEnable()
        {
            _closeButton.onClick.AddListener(Hide);
            _levelStartPanel.StartLevelButtonClicked += OnStartLevelButtonClicked;
        }

        private void OnDisable()
        {
            _closeButton.onClick.RemoveListener(Hide);
            _levelStartPanel.StartLevelButtonClicked -= OnStartLevelButtonClicked;
        }

        private void OnStartLevelButtonClicked() => _menuMediator.LoadLevel(_selectedLevel);
    }
}
