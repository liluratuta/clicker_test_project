using System.Collections.Generic;
using Clicker.Game;
using UnityEngine;

namespace Clicker.UI
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private LeaderBoardLine _leaderBoardLinePrefab;

        public void Display(List<GameResult> gameResults)
        {
            ClearLines();

            foreach (var result in gameResults)
            {
                AddLine(result.playerName, result.time);
            }
        }

        private void AddLine(string playerName, float time)
        {
            var line = Instantiate(_leaderBoardLinePrefab, transform);

            line.Label = playerName;
            line.Value = time;
        }

        private void ClearLines()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
