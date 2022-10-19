using UnityEngine;

namespace Madicine.Scene.Gameplay.Player
{
    public class PlayerModel : MonoBehaviour
    {
        public string nameCharcter;

        [Header("Realtime Data:")]
        public int health;
        public int experience;
        public int level;
        public int armoreLevel;
        public int weaponLevel;

        // belum dipakai
        [HideInInspector] public GameObject skin;
    }
}
