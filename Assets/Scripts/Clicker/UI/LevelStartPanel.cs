using System;
using System.Collections.Generic;
using System.Linq;
using Clicker.Game;
using Clicker.RemoteInfo;
using Clicker.RemoteInfo.JSONTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Level = Clicker.ScriptableObjects.Level;

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
        [SerializeField] private RemoteLevelsInfo _remoteLevelsInfo;

        private Level _level;

        public void Initialize(Level level)
        {
            _level = level;
            _image.sprite = _level.BackgroundSprite;
            _title.text = _level.LevelName;
            _remoteLevelsInfo.RequestStars(_level.ID, DisplayStars);
            _remoteLevelsInfo.RequestLeaderboards(_level.ID, DisplayLeaderboard);
        }

        private void OnEnable() => _startLevelButton.onClick.AddListener(OnStartButtonClicked);
        private void OnDisable() => _startLevelButton.onClick.RemoveListener(OnStartButtonClicked);
        private void OnStartButtonClicked() => StartLevelButtonClicked?.Invoke();

        private void DisplayLeaderboard(int levelID, List<Leaderboard> leaderboards)
        {
            if (levelID != _level.ID)
            {
                return;
            }
            
            var localGameResults = _level.LocalGameResults;
            var allGameResults = JoinGameResults(localGameResults, leaderboards);
            
            allGameResults.Sort((x, y) => x.time.CompareTo(y.time));

            _leaderBoard.Display(allGameResults);
        }

        private void DisplayStars(int levelID, int stars)
        {
            if (levelID != _level.ID)
            {
                return;
            }
            
            _stars.SetFullness(stars);
        }

        private static List<GameResult> JoinGameResults(IEnumerable<GameResult> local, IEnumerable<Leaderboard> remote)
        {
            var results = new List<GameResult>();

            results.AddRange(local);
            results.AddRange(remote.Select(leaderboard => new GameResult(leaderboard.id, leaderboard.name, (float) leaderboard.time)));

            return results;
        }
    }
}
