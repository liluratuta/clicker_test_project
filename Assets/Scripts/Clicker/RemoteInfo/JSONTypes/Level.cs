using System;
using System.Collections.Generic;

namespace Clicker.RemoteInfo.JSONTypes
{
    [Serializable]
    public class Level
    {
        public string stars;
        public List<Leaderboard> leaderboard;
    }
}
