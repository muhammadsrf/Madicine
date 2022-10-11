using UnityEngine;
using Madicine.Scene.Gameplay.Weapons;

namespace Madicine.Scene.Gameplay.Players
{
    [CreateAssetMenu(fileName = "Playerdata", menuName = "Player/Data", order = 0)]
    public class ScriptTableObjectPlayerData : ScriptableObject
    {
        public string nameCharcter;
        public int health;
        public int level;
        public Weapon weapon;
        public GameObject skin;
    }
}