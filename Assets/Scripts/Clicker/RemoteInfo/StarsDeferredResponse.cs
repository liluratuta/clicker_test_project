using System;

namespace Clicker.RemoteInfo
{
    public class StarsDeferredResponse : IDeferredResponse
    {
        private readonly int _levelID;
        private readonly Action<int> _response;

        public StarsDeferredResponse(int levelID, Action<int> response)
        {
            _levelID = levelID;
            _response = response;
        }

        public void Execute(ILevelsInfo levelsInfo)
        {
            var stars = levelsInfo.GetStarsFromLevel(_levelID);
            _response?.Invoke(stars);
        }             
    }
}
