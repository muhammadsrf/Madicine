using UnityEngine;

namespace Madicine.Scene.Gameplay.Player
{
    [CreateAssetMenu(fileName = "Playerdata", menuName = "Player/Data", order = 0)]
    public class PlayerDataSO : ScriptableObject
    {
        public string nameCharcter;
        public int health;
        public int level;
        public int armoreLevel;
        public GameObject skin;
    }
}