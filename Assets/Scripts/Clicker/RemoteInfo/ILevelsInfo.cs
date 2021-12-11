using System.Collections.Generic;
using Clicker.RemoteInfo.JSONTypes;

namespace Clicker.RemoteInfo
{
    public interface ILevelsInfo
    {
        int GetStarsFromLevel(int levelID);
        List<Leaderboard> GetLeaderboardsFromLevel(int levelID);
    }
}
