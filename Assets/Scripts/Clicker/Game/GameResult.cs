using System;

namespace Clicker.Game
{
    [Serializable]
    public struct GameResult
    {
        public int playerID;
        public string playerName;
        public float time;

        public GameResult(int playerID, string playerName, float time)
        {
            this.playerID = playerID;
            this.playerName = playerName;
            this.time = time;
        }
    }
}
