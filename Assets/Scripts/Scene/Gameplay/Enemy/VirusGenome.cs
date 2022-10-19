using Madicine.Global.Upgrade;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class VirusGenome : MonoBehaviour
    {
        public int addExp = 5;
        public UpgradeReferenceData upgradeRefData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                upgradeRefData.AddExperience(addExp);
                Destroy(gameObject);
            }
        }
    }
}