using System;
using UnityEngine;

namespace Leaderboard_Scripts
{
    public class LeaderboardTrigger : MonoBehaviour
    {
        private DateTime _time;
        private bool activated = false;

        private void Start()
        {
            _time = DateTime.Now;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (this.activated) return;
            if (!other.TryGetComponent(out PlayerMovement pc)) return;
            this.activated = true;
            var ts = DateTime.Now - _time;
            StartCoroutine(LeaderboardNetwork.Upload("Player", ts.Ticks.ToString()));
        }
    }
}