using System;
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Leaderboard_Scripts
{
    public class Leaderboard : MonoBehaviour
    {
        // Start is called before the first frame update
        private DateTime _time;
        [SerializeField] private UnityEvent _onGetText;
        [SerializeField] private GameObject root;
        [SerializeField] private Font _font;
        [SerializeField] private RectTransform canvas;
        [SerializeField] private float size = 50;

        void Start()
        {
            this._onGetText.AddListener(Call);
            StartCoroutine(LeaderboardNetwork.GetText(this._onGetText));
        }

        private void Call()
        {
            for (int i = 0; i < this.root.transform.childCount; i++)
            {
                Destroy(this.root.transform.GetChild(i).gameObject);
            }

            LeaderboardNetwork._models.ForEach(m =>
            {
                var newText = new GameObject("Player", typeof(RectTransform));
                Text text = newText.AddComponent<Text>();
                text.text = $"{m.player} - {m.score}";
                text.font = this._font;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                newText.transform.SetParent(this.root.transform);
            });
            var l = this.canvas.sizeDelta;
            l.y = LeaderboardNetwork._models.Count * this.size;
            this.canvas.sizeDelta = l;
            // LeaderboardNetwork._models;
        }

        // private void FixedUpdate()
        // {
        //     if (LeaderboardNetwork._models.Count > 0)
        //         Debug.Log(LeaderboardNetwork._models[0]);
        // }
    }
}