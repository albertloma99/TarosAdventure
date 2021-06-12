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

        private void OnEnable()
        {
            Cursor.lockState = CursorLockMode.None;
        }

        private void Call()
        {
            for (int i = 0; i < this.root.transform.childCount; i++)
            {
                Destroy(this.root.transform.GetChild(i).gameObject);
            }

            Destroy(FindObjectOfType<PlayerMovement>());
            Destroy(FindObjectOfType<Orbit>());

            for (int i = 0; i < LeaderboardNetwork._models.Count; i++)
            {
                var m = LeaderboardNetwork._models[1];
                var newText = new GameObject("Player", typeof(RectTransform));
                var r = newText.GetComponent<RectTransform>();
                var s = r.sizeDelta;
                s.y = 50;
                r.sizeDelta = s;
                Text text = newText.AddComponent<Text>();
                if (LeaderboardNetwork.lastModel != null)
                    if (m.score.Equals(LeaderboardNetwork.lastModel.score))
                        text.color = Color.yellow;


                var ts = TimeSpan.FromTicks(long.Parse(m.score));
                text.text = $"{i} - {m.player} - {ts}";
                text.font = this._font;
                text.alignment = TextAnchor.MiddleCenter;
                text.resizeTextForBestFit = true;
                newText.transform.SetParent(this.root.transform);
            }

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