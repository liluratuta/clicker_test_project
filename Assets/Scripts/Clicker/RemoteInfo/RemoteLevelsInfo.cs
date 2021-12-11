using System;
using System.Collections;
using System.Collections.Generic;
using Clicker.RemoteInfo.JSONTypes;
using UnityEngine;
using UnityEngine.Networking;

namespace Clicker.RemoteInfo
{
    public class RemoteLevelsInfo : MonoBehaviour, ILevelsInfo, IRemoteLevelsInfo
    {
        private const string URL = "https://api.npoint.io/013d8e4dfd4ab3d73b57";
        private readonly Queue<IDeferredResponse> _deferredResponses = new Queue<IDeferredResponse>();
        private Root _levelsInfo;
        private bool _isLevelInfoReady;

        public void RequestStars(int levelID, Action<int> response)
        {
            if (_isLevelInfoReady)
            {
                response?.Invoke(GetStarsFromLevel(levelID));
                return;
            }

            _deferredResponses.Enqueue(new StarsDeferredResponse(levelID, response));
        }

        public void RequestLeaderboards(int levelID, Action<List<Leaderboard>> response)
        {
            if (_isLevelInfoReady)
            {
                response?.Invoke(GetLeaderboardsFromLevel(levelID));
                return;
            }

            _deferredResponses.Enqueue(new LeaderboardsDeferredResponse(levelID, response));
        }

        public int GetStarsFromLevel(int levelID)
        {
            var level = GetLevelByID(levelID);
            return int.TryParse(level.stars, out int stars) ? stars : 0;
        }

        public List<Leaderboard> GetLeaderboardsFromLevel(int levelID)
        {
            var level = GetLevelByID(levelID);
            return level.leaderboard;
        }

        private void Awake()
        {
            _isLevelInfoReady = false;
            
            StartCoroutine(LoadJsonFromServer(URL, ParseJson));
        }

        private Level GetLevelByID(int levelID)
        {
            return levelID switch
            {
                1 => _levelsInfo.level_1,
                2 => _levelsInfo.level_2,
                3 => _levelsInfo.level_3,
                4 => _levelsInfo.level_4,
                _ => throw new ArgumentOutOfRangeException(nameof(levelID), levelID, null)
            };
        }

        private void ParseJson(string json)
        {
            _levelsInfo = JsonUtility.FromJson<Root>(json);
            _isLevelInfoReady = true;

            ExecuteDeferredResponses();
        }

        private void ExecuteDeferredResponses()
        {
            while (_deferredResponses.Count != 0)
            {
                var deferredResponse = _deferredResponses.Dequeue();
                deferredResponse.Execute(this);
            }
        }

        private IEnumerator LoadJsonFromServer(string serverURL, Action<string> response)
        {
            using var request = UnityWebRequest.Get(serverURL);
        
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                response?.Invoke(request.downloadHandler.text);
            }
        }
    }
}