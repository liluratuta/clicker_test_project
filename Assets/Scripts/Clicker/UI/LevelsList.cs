using System;
using System.Collections.Generic;
using System.Linq;
using Clicker.RemoteInfo;
using Clicker.ScriptableObjects;
using UnityEngine;

namespace Clicker.UI
{
    public class LevelsList : MonoBehaviour
    {
        private readonly Dictionary<LevelPanel, Level> _levelsDict = new Dictionary<LevelPanel, Level>();
        
        [SerializeField] private LevelPanel _levelPanelPrefab;
        [SerializeField] private RemoteLevelsInfo _remoteLevelsInfo;

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
            _levelsDict.Add(levelPanel, level);

            levelPanel.Title = level.LevelName;
            levelPanel.Image = level.BackgroundSprite;
            _remoteLevelsInfo.RequestStars(level.ID, DisplayStars);

            levelPanel.Selected += OnLevelSelected;
        }

        private void OnLevelSelected(LevelPanel levelPanel) => _selectHandler?.Invoke(_levelsDict[levelPanel]);

        private void DisplayStars(int levelID, int stars)
        {
            var levelPanel = _levelsDict.First(pair => pair.Value.ID == levelID).Key;
            levelPanel.Stars = stars;
        }
    }
}
