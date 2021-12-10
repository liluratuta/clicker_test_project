using System;
using System.Collections.Generic;
using Clicker.Menu;
using Clicker.ScriptableObjects;
using Clicker.UI;
using UnityEngine;

namespace Clicker.Mediators
{
    public class MenuMediator : Mediator
    {
        [SerializeField] private LevelStartScreen _levelStartScreen;
        [SerializeField] private LevelsList _levelsList;
        [SerializeField] private MenuScene _menuScene;

        public void LoadLevel(Level level) => _menuScene.LoadLevel(level);
        
        public void DisplayLevelStartScreen(Level level) => _levelStartScreen.Display(level);
        
        public void HideLevelStartScreen() => _levelStartScreen.Hide();
        
        public void DisplayLevels(List<Level> levels, Action<Level> selectHandler) =>
            _levelsList.Display(levels, selectHandler);
        
    }
}
