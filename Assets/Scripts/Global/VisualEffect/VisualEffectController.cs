using UnityEngine;

namespace Madicine.Global.Vfx
{
    public class VisualEffectController : MonoBehaviour {
        
        public static VisualEffectController Instance;

        public VisualEffectResaourcesSO resourceListVFX;

        private void Awake() {
            if (Instance == null){
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void SpawnVFX(VisualEffectEnum nameFVX, Transform transf){
            GameObject spawnObject = null;

            switch (nameFVX)
            {
                case VisualEffectEnum.Spray:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.Spray);
                    break;
                case VisualEffectEnum.Inject:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.Inject);
                    break;
                case VisualEffectEnum.HitEnemy:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.HitEnemy);
                    break;
                case VisualEffectEnum.EnemyHeal:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.EnemyHeal);
                    break;
                case VisualEffectEnum.EnemyDisappear:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.EnemyDisappear);
                    break;
                case VisualEffectEnum.EnemyShoot:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.EnemyShoot);
                    break;
                default:
                    break;
            }

            if (spawnObject !=null) spawnObject = Object.Instantiate(spawnObject, transf);
            Object.Destroy(spawnObject, 0.5f);
        }
    }
}