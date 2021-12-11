using System;
using System.Collections.Generic;
using Clicker.RemoteInfo.JSONTypes;

namespace Clicker.RemoteInfo
{
    public interface IRemoteLevelsInfo
    {
        void RequestStars(int levelID, Action<int> response);
        void RequestLeaderboards(int levelID, Action<List<Leaderboard>> response);
    }
}
