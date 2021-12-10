using Clicker.Game;
using Clicker.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Clicker.Mediators
{
    public class GameMediator : Mediator
    {
        [SerializeField] private TMP_Text _timerLabel;
        [SerializeField] private TMP_Text _goalScoreLabel;
        [SerializeField] private ScorePanel _scorePanel;
        [SerializeField] private BonusPanel _bonusPanel;
        [SerializeField] private GameFinishScreen _gameFinishScreen;
        [SerializeField] private Background _background;

        public void DisplayTimer(int time) => _timerLabel.text = time.ToString();
        public void DisplayGoalScore(int goalScore) => _goalScoreLabel.text = goalScore.ToString();

        public void InitializeScorePanel(int goalScore) => _scorePanel.Initialize(goalScore);
        public void DisplayScore(int score) => _scorePanel.DisplayScore(score);

        public void SetBonusIconActive(BonusType bonusType, bool isActive) =>
            _bonusPanel.SetBonusActive(bonusType, isActive);

        public void DisplayGameFinishScreen(int elapsedTime) => _gameFinishScreen.Display(elapsedTime);
        
        public void LoadMenu() => SceneManager.LoadScene("Menu");

        public void InitializeBackground(Sprite sprite, Vector2 size) => _background.Initialize(sprite, size);
    }
}
