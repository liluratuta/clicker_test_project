using TMPro;
using UnityEngine;

namespace Clicker.UI
{
    public class ScorePanel : MonoBehaviour
    {
        [SerializeField] private ProgressBar _progressBar;
        [SerializeField] private TMP_Text _label;
    
        private int _goalScore;
    
        public void Initialize(int goalScore)
        {
            _goalScore = goalScore;
            DisplayScore(0);
        }

        public void DisplayScore(int score)
        {
            if (score < 0 || score > _goalScore)
            {
                return;
            }
            
            _label.text = $"{score}/{_goalScore}";

            var fullness = (float) score / _goalScore;
            _progressBar.SetFullness(fullness);
        }
    }
}
