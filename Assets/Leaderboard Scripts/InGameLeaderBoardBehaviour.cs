using UnityEngine;
using UnityEngine.SceneManagement;

namespace Leaderboard_Scripts
{
    public class InGameLeaderBoardBehaviour : MonoBehaviour
    {
        public void Exit()
        {
            SceneManager.LoadScene(0);
        }
    }
}