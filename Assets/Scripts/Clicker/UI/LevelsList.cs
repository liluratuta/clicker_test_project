using System;
using System.Collections.Generic;
using Clicker.ScriptableObjects;
using UnityEngine;

namespace Clicker.UI
{
    public class LevelsList : MonoBehaviour
    {
        private readonly Dictionary<LevelPanel, Level> _levelsDict = new Dictionary<LevelPanel, Level>();
        
        [SerializeField] private LevelPanel _levelPanelPrefab;
        
        private Action<Level> _selectHandler;

        public void Display(List<Level> levels, Action<Level> selectHandler)
        {
            _selectHandler = selectHandler;
            
            foreach (var level in levels)
            {
                CreateLevelPanel(level);
            }
        }
        
        private void CreateLevelPanel(Level level)
        {
            var levelPanel = Instantiate(_levelPanelPrefab, transform);

            levelPanel.Title = level.LevelName;
            levelPanel.Image = level.BackgroundSprite;
            levelPanel.Stars = level.Stars;

            _levelsDict.Add(levelPanel, level);
            
            levelPanel.Selected += OnLevelSelected;
        }

        private void OnLevelSelected(LevelPanel levelPanel) => _selectHandler?.Invoke(_levelsDict[levelPanel]);
    }
}
