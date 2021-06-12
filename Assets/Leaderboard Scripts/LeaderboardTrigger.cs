using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Leaderboard_Scripts
{
    public class LeaderboardTrigger : MonoBehaviour
    {
        public Leaderboard leaderboard;
        private DateTime _time;
        private bool activated = false;
        public UnityEvent onEnter;

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
            this.onEnter.Invoke();
            // StartCoroutine(LeaderboardNetwork.Upload("Player", ts.Ticks.ToString()));
            leaderboard.gameObject.SetActive(true);
            this.leaderboard.SetInputTime();
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}