using System.Collections.Generic;
using Clicker.RemoteInfo;
using Clicker.RemoteInfo.JSONTypes;
using UnityEngine;

namespace Clicker.UI
{
    [RequireComponent(typeof(RemoteLevelsInfo))]
    public class LeaderBoard : MonoBehaviour
    {
        [SerializeField] private LeaderBoardLine _leaderBoardLinePrefab;
        private IRemoteLevelsInfo _remoteLevelsInfo;
        
        public void ShowLeadersForLevel(int levelID)
        {
            _remoteLevelsInfo.RequestLeaderboards(levelID, DisplayLeaderboard);
        }

        private void DisplayLeaderboard(List<Leaderboard> leaderboards)
        {
            ClearLines();
            
            foreach (var leaderboard in leaderboards)
            {
                AddLine(leaderboard.name, (float)leaderboard.time);
            }
        }

        private void Awake()
        {
            _remoteLevelsInfo = GetComponent<IRemoteLevelsInfo>();
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
