using System;
using System.Collections.Generic;
using Clicker.RemoteInfo.JSONTypes;

namespace Clicker.RemoteInfo
{
    public class LeaderboardsDeferredResponse : IDeferredResponse
    {
        private readonly int _levelID;
        private readonly Action<List<Leaderboard>> _response;

        public LeaderboardsDeferredResponse(int levelID, Action<List<Leaderboard>> response)
        {
            _levelID = levelID;
            _response = response;
        }

        public void Execute(ILevelsInfo levelsInfo)
        {
            var leaderboards = levelsInfo.GetLeaderboardsFromLevel(_levelID);
            _response?.Invoke(leaderboards);
        }
    }
}
