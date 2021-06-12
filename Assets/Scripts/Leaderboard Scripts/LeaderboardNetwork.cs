using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using Debug = UnityEngine.Debug;

namespace Leaderboard_Scripts
{
    public static class LeaderboardNetwork
    {
        public static List<ScoreModel> _models { get; private set; }

        static LeaderboardNetwork()
        {
            _models = new List<ScoreModel>();
        }

        public static IEnumerator Upload(string playerName, string ticks)
        {
            UnityWebRequest www = UnityWebRequest.Get($"http://may66.ddns.net:6060/add/{playerName}/{ticks}");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                // Or retrieve results as binary data
                // byte[] results = www.downloadHandler.data;
            }
        }

        public static IEnumerator GetText(UnityEvent onEnd)
        {
            UnityWebRequest www = UnityWebRequest.Get("http://may66.ddns.net:6060/scores");
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                var a = JsonUtility.FromJson<RootScoreModel>("{\"scores\":" + www.downloadHandler.text + "}");
                _models.AddRange(a.scores);
                onEnd.Invoke();
            }
        }
    }
}