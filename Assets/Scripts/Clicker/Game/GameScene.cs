using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Clicker.Game.Bonuses;
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
        [SerializeField] private BonusBox _bonusBox;

        private readonly float _maxBonusBoxSpawnTime = 10f;
        
        private Level _level;
        private GameFieldBounds _gameFieldBounds;
        private int _score;
        private float _elapsedTime;
        private bool _isGamePlaying;
        private HashSet<Bonus> _activeBonuses = new HashSet<Bonus>();

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

            _bonusBox.gameObject.SetActive(false);
            StartCoroutine(BonusBoxSpawning());
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

        private void OnEnable()
        {
            _clickTarget.PointsEarned += OnTargetClicked;
            _bonusBox.Clicked += OnBonusBoxClicked;
        }

        private void OnDisable()
        {
            _clickTarget.PointsEarned -= OnTargetClicked;
            _bonusBox.Clicked -= OnBonusBoxClicked;
        }

        private void OnBonusBoxClicked()
        {
            var allBonuses = _bonusBox.Bonuses;
            var readyBonuses = allBonuses.Where(bonus => !_activeBonuses.Contains(bonus)).ToList();

            if (readyBonuses.Count == 0)
            {
                _bonusBox.gameObject.SetActive(false);
                return;
            }

            var bonus = readyBonuses[Random.Range(0, readyBonuses.Count)];

            _clickTarget.ApplyBonus(bonus);
            _gameMediator.SetBonusIconActive(bonus, isActive: true);
            _activeBonuses.Add(bonus);
            
            bonus.Completed += OnBonusCompleted;
            
            _bonusBox.gameObject.SetActive(false);
        }

        private void OnBonusCompleted(Bonus bonus)
        {
            bonus.Completed -= OnBonusCompleted;
            _activeBonuses.Remove(bonus);
            _gameMediator.SetBonusIconActive(bonus, isActive: false);
        }

        private void OnTargetClicked(int points)
        {
            _score += points;
            _gameMediator.DisplayScore(_score);

            if (_score >= _level.GoalClickCount)
            {
                _gameMediator.DisplayGameFinishScreen((int)_elapsedTime);
                _level.AddGameResult(_gameData.PlayerID, _gameData.PlayerName, _elapsedTime);
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

        private IEnumerator BonusBoxSpawning()
        {
            void MoveToRandomPosition()
            {
                var randomPosition = _gameFieldBounds.GetRandomPositionForSquare(_bonusBox.Size);
                _bonusBox.Position = randomPosition;
            }

            bool IsPossibleBonusBoxSpawn()
            {
                if (_bonusBox.gameObject.activeSelf)
                {
                    return false;
                }
                
                return _activeBonuses.Count < _bonusBox.Bonuses.Count;
            }

            while (true)
            {
                yield return new WaitForSeconds(Random.Range(0f, _maxBonusBoxSpawnTime));
                
                if (IsPossibleBonusBoxSpawn())
                {
                    _bonusBox.gameObject.SetActive(true);
                    MoveToRandomPosition();
                }
            }
        }
    }
}
