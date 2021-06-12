using UnityEngine;
using UnityEngine.SceneManagement;

namespace Main_Menu
{
    public class MainMenuBehaviour : MonoBehaviour
    {
        public GameObject leaderBoard;
        public GameObject mainMenu;

        public void SwitchLeaderboard()
        {
            var active = this.mainMenu.activeSelf;
            this.mainMenu.SetActive(!active);
            this.leaderBoard.SetActive(active);
        }

        public void LoadFirstLevel()
        {
            SceneManager.LoadScene(1);
        }

        public void LoadSecondLevel()
        {
            SceneManager.LoadScene(2);
        }

        public void Exit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            UnityEngine.Application.Quit();
#endif
        }
    }
}