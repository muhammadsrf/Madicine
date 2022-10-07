using UnityEngine;
using Madicine.Scene.Gampalay.Weapons;

namespace Madicine.Scene.Gampalay.Players
{
    [CreateAssetMenu(fileName = "Playerdata", menuName = "Player/Data", order = 0)]
    public class ScriptTableObjectPlayerData : ScriptableObject {
        public string nameCharcter;
        public int health;
        public int level;
        public BaseWeapon weapon;
        public GameObject skin;
    }
}