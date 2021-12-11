using System;
using System.Collections.Generic;

namespace Clicker.RemoteInfo.JSONTypes
{
    [Serializable]
    public class Level1
    {
        public string stars;
        public List<Leaderboard> leaderboard;
    }
    [Serializable]
    public class Level2
    {
        public string stars;
        public List<Leaderboard> leaderboard;
    }
    [Serializable]
    public class Level3
    {
        public string stars;
        public List<Leaderboard> leaderboard;
    }
    [Serializable]
    public class Level4
    {
        public string stars;
        public List<Leaderboard> leaderboard;
    }
    
    [Serializable]
    public class Root
    {
        public Level level_1;
        public Level level_2;
        public Level level_3;
        public Level level_4;
    }
}
