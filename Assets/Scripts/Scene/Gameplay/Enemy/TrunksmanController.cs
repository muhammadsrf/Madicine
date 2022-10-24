using UnityEngine;
using Madicine.Global.Vfx;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class TrunksmanController : MonoBehaviour
    {
        private void Awake()
        {
            // play VFX smoke
            VisualEffectController.Instance.SpawnVFX(VisualEffectEnum.EnemyHeal, this.transform);
        }

        void YaySoundEffect()
        {
            // play sound effect
        }

        void DisappearingEffect(){
            // play VFX 
            VisualEffectController.Instance.SpawnVFX(VisualEffectEnum.EnemyDisappear, this.transform);
        }

        void Disappearing()
        {
            

            // destroying..
            Destroy(gameObject);
        }
    }
}