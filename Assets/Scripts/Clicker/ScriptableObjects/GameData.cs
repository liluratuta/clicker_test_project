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
        public string PlayerName => _playerName;

        public Level SelectedLevel
        {
            get => _selectedLevel;
            set => _selectedLevel = value;
        }

        public List<Level> Levels => _levels;

        [Header("Player")]
        [SerializeField] private int _playerID;
        [SerializeField] private string _playerName;
        [Header("Levels")]
        [SerializeField] private List<Level> _levels = new List<Level>();
        [SerializeField] private Level _selectedLevel;
    }
}
