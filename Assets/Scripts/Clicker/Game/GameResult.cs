using System;

namespace Clicker.Game
{
    [Serializable]
    public struct GameResult
    {
        public int levelID;
        public float time;

        public GameResult(int levelID, float time)
        {
            this.levelID = levelID;
            this.time = time;
        }
    }
}
