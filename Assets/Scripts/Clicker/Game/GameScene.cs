using Clicker.Game.ClickTargets;
using Clicker.Mediators;
using Clicker.ScriptableObjects;
using UnityEngine;

namespace Clicker.Game
{
    public class GameScene : MonoBehaviour
    {
        private const float NonGameFramePercent = 0.2f;

        [SerializeField] private GameMediator _gameMediator;
        [SerializeField] private GameData _gameData;
        [SerializeField] private ClickTarget _clickTarget;

        private Level _level;
        private GameFieldBounds _gameFieldBounds;
        private int _score;
        private float _elapsedTime;
        private bool _isGamePlaying;

        private void Awake()
        {
            _gameFieldBounds = new GameFieldBounds(Camera.main, NonGameFramePercent);
            _level = _gameData.SelectedLevel;
        }

        private void Start()
        {
            _gameMediator.InitializeBackground(_level.BackgroundSprite, _gameFieldBounds.Size);
            _isGamePlaying = true;
            
            _clickTarget.Sprite = _level.ButtonSprite;
            _score = 0;
            _elapsedTime = 0;
            
            _gameMediator.DisplayGoalScore(_level.GoalClickCount);
            _gameMediator.InitializeScorePanel(_level.GoalClickCount);
        }

        private void Update()
        {
            if (!_isGamePlaying)
            {
                return;
            }
            
            _elapsedTime += Time.deltaTime;
            _gameMediator.DisplayTimer(_elapsedTime);
        }

        private void OnEnable() => _clickTarget.PointsEarned += OnTargetClicked;
        private void OnDisable() => _clickTarget.PointsEarned -= OnTargetClicked;

        private void OnTargetClicked(int points)
        {
            _score++;
            _gameMediator.DisplayScore(_score);

            if (_score >= _level.GoalClickCount)
            {
                _gameMediator.DisplayGameFinishScreen((int)_elapsedTime);
                _gameData.AddGameResult(_elapsedTime);
                StopGame();
                return;
            }
            
            TryMoveTargetToRandomPosition();
        }

        private void StopGame()
        {
            _isGamePlaying = false;
        }

        private bool TryMoveTargetToRandomPosition()
        {
            if (!_clickTarget.IsChangePositionPossible())
            {
                return false;
            }

            MoveTargetToRandomPosition();
            return true;
        }

        private void MoveTargetToRandomPosition()
        {
            var randomPosition = _gameFieldBounds.GetRandomPositionForSquare(_clickTarget.Size);
            _clickTarget.SetPosition(randomPosition);
        }
    }
}
