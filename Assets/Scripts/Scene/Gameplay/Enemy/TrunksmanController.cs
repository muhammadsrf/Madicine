using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class TrunksmanController : MonoBehaviour
    {
        private void Awake()
        {
            // play VFX smoke
        }

        void YaySoundEffect()
        {
            // play sound effect
        }

        void Disappearing()
        {
            // play VFX 

            // destroying..
            Destroy(gameObject);
        }
    }
}