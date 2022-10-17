using UnityEngine;

namespace Madicine.Scene.Gameplay.Player
{
    [CreateAssetMenu(fileName = "Playerdata", menuName = "Player/Data", order = 0)]
    public class PlayerDataSO : ScriptableObject
    {
        public string nameCharcter;
        public int health;

        // health level
        public int level;
        
        // def level
        public int armoreLevel;

        // weapon level
        public int weaponLevel;

        public GameObject skin;
    }
}