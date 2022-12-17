using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

namespace MyGame.Logic
{
    public class GameLogic : MonoBehaviour
    {
        public bool _isPaused { get; private set; } = false;

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        public void PauseUnpause()
        {
            if (_isPaused)
            {
                Time.timeScale = 1;
                _isPaused = false;
            }
            else
            {
                Time.timeScale = 0;
                _isPaused = true;
            }
        }
    }
}


