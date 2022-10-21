using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Madicine.Scene.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        public static UnityAction OnGameplay;

        private void Start()
        {
            OnGameplay();
        }

        public void Exit()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}