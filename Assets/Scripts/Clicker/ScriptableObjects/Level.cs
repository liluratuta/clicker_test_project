using System.Collections.Generic;
using Clicker.Game;
using UnityEngine;

namespace Clicker.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Level", menuName = "Clicker/Level")]
    public class Level : ScriptableObject
    {
        public List<GameResult> LocalGameResults => _localGameResults;
        public int ID => _id;
        public string LevelName => _levelName;

        public int GoalClickCount => _goalClickCount;

        public Sprite BackgroundSprite => _backgroundSprite;

        public Sprite ButtonSprite => _buttonSprite;

        public Sprite BonusBoxSprite => _bonusBoxSprite;

        [SerializeField, Min(0)] private int _id;
        [SerializeField] private string _levelName;
        [SerializeField, Min(0)] private int _goalClickCount;
        [SerializeField] private Sprite _backgroundSprite;
        [SerializeField] private Sprite _buttonSprite;
        [SerializeField] private Sprite _bonusBoxSprite;
        
        [SerializeField, HideInInspector]
        private List<GameResult> _localGameResults = new List<GameResult>();

        public void AddGameResult(int playerID, string playerName, float time)
        {
            _localGameResults.Add(new GameResult(playerID, playerName, time));
        }
    }
}
