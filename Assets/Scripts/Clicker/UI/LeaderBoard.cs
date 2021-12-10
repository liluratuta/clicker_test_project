using System.Collections.Generic;
using UnityEngine;

namespace Clicker.UI
{
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private LeaderBoardLine _leaderBoardLinePrefab;

        public void ShowLeaders(List<(string name, int value)> leaders)
        {
            foreach (var (label, value) in leaders)
            {
                var line = CreateLine();

                line.Label = label;
                line.Value = value;
            }
        }

        private LeaderBoardLine CreateLine()
        {
            var line = Instantiate(_leaderBoardLinePrefab, transform);
            return line;
        }
    }
}
