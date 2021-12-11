using System;
using Clicker.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clicker.UI
{
    public class LevelStartPanel : MonoBehaviour
    {
        public event Action StartLevelButtonClicked;
        
        [SerializeField] private Image _image;
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Stars _stars;
        [SerializeField] private LeaderBoard _leaderBoard;
        [SerializeField] private Button _startLevelButton;

        public void Initialize(Level level)
        {
            _image.sprite = level.BackgroundSprite;
            _title.text = level.LevelName;
            _stars.SetFullness(level.Stars);
            _leaderBoard.ShowLeadersForLevel(level.ID);
        }

        private void OnEnable() => _startLevelButton.onClick.AddListener(OnStartButtonClicked);
        private void OnDisable() => _startLevelButton.onClick.RemoveListener(OnStartButtonClicked);
        private void OnStartButtonClicked() => StartLevelButtonClicked?.Invoke();
    }
}
