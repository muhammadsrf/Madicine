using Madicine.Scene.Gameplay.Player;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Madicine.Scene.Gameplay.UI
{
    public class GameplayNavigator : MonoBehaviour
    {
        [SerializeField] private GameObject _pauseScreen;
        [SerializeField] private GameObject _upgradeScreen;
        [SerializeField] private GameObject _gameOverScreen;

        private void OnEnable()
        {
            PlayerEvents.onPlayerDeath += PlayerDie;
        }

        private void OnDisable()
        {
            PlayerEvents.onPlayerDeath -= PlayerDie;
        }

        private void Update()
        {
            // pause / resume with escape in keyboard
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SetActivePauseScreen(!_pauseScreen.activeSelf);
            }
        }

        public void RestartLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync("Gameplay");
        }

        public void SetActivePauseScreen(bool value)
        {
            _pauseScreen.SetActive(value);
            if (value)
            {
                // stop the gameplay
                Time.timeScale = 0;
            }
            else if (!value)
            {
                // resume the gameplay
                Time.timeScale = 1;
            }
        }

        private void PlayerDie(int health)
        {
            StartCoroutine(delay());
        }

        IEnumerator delay()
        {
            yield return new WaitForSeconds(0.7f);
            _gameOverScreen.SetActive(true);

            Time.timeScale = 0;
        }

        public void SetActiveUpgradeScreen(bool value)
        {
            _upgradeScreen.SetActive(value);
            if (value)
            {
                // stop the gameplay
                Time.timeScale = 0;
            }
            else if (!value)
            {
                // resume the gameplay
                Time.timeScale = 1;
            }
        }

        public void Home()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync("MainMenu");
        }
    }
}