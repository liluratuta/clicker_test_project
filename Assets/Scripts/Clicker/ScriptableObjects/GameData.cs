using System.Collections.Generic;
using System.Linq;
using Clicker.Game;
using UnityEngine;

namespace Clicker.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "Clicker/Game Data")]
    public class GameData : ScriptableObject
    {
        public int PlayerID => _playerID;

        public Level SelectedLevel
        {
            get => _selectedLevel;
            set => _selectedLevel = value;
        }

        public List<Level> Levels => _levels;

        [SerializeField] private int _playerID;
        [SerializeField] private List<Level> _levels = new List<Level>();
        [SerializeField] private Level _selectedLevel;
        [SerializeField] private List<GameResult> _gameResults = new List<GameResult>();

        public void AddGameResult(float time)
        {
            var levelID = _selectedLevel.ID;
            _gameResults.Add(new GameResult(levelID, time));
        }

        public List<GameResult> GetGameResultsByLevelID(int levelID)
        {
            var result = _gameResults.Where(gameResult => gameResult.levelID == levelID).ToList();
            return result;
        }
    }
}
