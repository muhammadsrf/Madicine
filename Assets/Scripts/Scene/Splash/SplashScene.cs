using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Madicine.Scene.Splash
{
    public class SplashScene : MonoBehaviour
    {
        private float _time = 5;

        private void Update()
        {
            _time -= Time.deltaTime;
            if(_time <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}