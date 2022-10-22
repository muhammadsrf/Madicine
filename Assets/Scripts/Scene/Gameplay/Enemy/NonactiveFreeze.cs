using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class NonactiveFreeze : MonoBehaviour
    {
        private void OnDisable()
        {
            FindObjectOfType<WaveController>().freezeTimer = false;
        }
    }
}