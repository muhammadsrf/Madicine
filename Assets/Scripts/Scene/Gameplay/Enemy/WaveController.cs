using Madicine.Scene.Gameplay.UI;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class WaveController : MonoBehaviour
    {
        public int currentWave = 1;
        public bool freezeTimer;
        [SerializeField] private WaveUI _waveUI;
        [SerializeField] private float _timerWave = 60;
        private float _timer;

        private void Start()
        {
            ShowWaveText();
        }

        private void ShowWaveText()
        {
            _waveUI.ShowAnimator(currentWave);
        }

        private void Update()
        {
            if (!freezeTimer)
            {
                _timer += Time.deltaTime;
                if (_timer > _timerWave)
                {
                    currentWave++;
                    ShowWaveText();
                    _timer = 0;

                    // for wave boss
                    if (currentWave == 3 || currentWave == 6 || currentWave == 9 || currentWave == 10)
                    {
                        freezeTimer = true;
                        _timer = 55;
                    }
                }

                if (currentWave > 10)
                {
                    Debug.Log("Win!");
                }
            }

        }
    }
}