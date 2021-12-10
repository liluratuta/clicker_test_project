using System.Collections.Generic;
using UnityEngine;

namespace Clicker.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "Clicker/Game Data")]
    public class GameData : ScriptableObject
    {
        public Level SelectedLevel { get; set; }
        public List<Level> Levels => _levels;
        
        [SerializeField] private List<Level> _levels;
    }
}
