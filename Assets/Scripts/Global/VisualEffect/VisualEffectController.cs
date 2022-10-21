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
                case VisualEffectEnum.Enemy:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.Enemy);
                    break;
                case VisualEffectEnum.Inject:
                    spawnObject = resourceListVFX.FindVFX(VisualEffectEnum.Inject);
                    break;
                default:
                    break;
            }

            if (spawnObject !=null) spawnObject = Object.Instantiate(spawnObject, transf);
            Object.Destroy(spawnObject, 0.5f);
        }
    }
}