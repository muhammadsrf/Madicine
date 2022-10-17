using UnityEngine;
using Madicine.Global.Upgrade;

namespace Madicine.Scene.Gameplay.Player
{
    [CreateAssetMenu(fileName = "Playerdata", menuName = "Player/Data", order = 0)]
    public class PlayerDataSO : ScriptableObject
    {
        [SerializeField] private UpgradeReferenceData _upgradeRefData;

        public string nameCharcter;
        public int health;

        // health level
        public int level;

        // def level
        public int armoreLevel;

        // weapon level
        public int weaponLevel;

        // not used
        [HideInInspector] public GameObject skin;


        // set health to base data reference on enable
        private void OnEnable()
        {
            health = _upgradeRefData.hpReference[0];
        }
    }
}