using Clicker.Mediators;
using Clicker.ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Clicker.Menu
{
    public class MenuScene : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        [SerializeField] private MenuMediator _mediator;
        
        private void Start() => _mediator.DisplayLevels(_gameData.Levels, selectHandler: OnLevelSelected);

        private void OnLevelSelected(Level level) => _mediator.DisplayLevelStartScreen(level);

        public void LoadLevel(Level level)
        {
            _gameData.SelectedLevel = level;
            SceneManager.LoadScene("Game");
        }
    }
}
