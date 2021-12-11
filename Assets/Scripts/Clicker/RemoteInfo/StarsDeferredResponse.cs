using System;

namespace Clicker.RemoteInfo
{
    public class StarsDeferredResponse : IDeferredResponse
    {
        private readonly int _levelID;
        private readonly Action<int, int> _response;

        public StarsDeferredResponse(int levelID, Action<int, int> response)
        {
            _levelID = levelID;
            _response = response;
        }

        public void Execute(ILevelsInfo levelsInfo)
        {
            var stars = levelsInfo.GetStarsFromLevel(_levelID);
            _response?.Invoke(_levelID, stars);
        }             
    }
}
