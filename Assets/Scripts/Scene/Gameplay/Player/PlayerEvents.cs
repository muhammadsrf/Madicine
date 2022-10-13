using UnityEngine;

namespace Madicine.Scene.Gameplay.Player
{
    public class PlayerEvents : MonoBehaviour
    {
        // delegate name for event combat stats
        public delegate void PlayerCombatStats(int health);
        // event name for delegate enemy
        public static event PlayerCombatStats onPlayerHurt;
        public static event PlayerCombatStats onPlayerDeath;

        public delegate void PlayerUIStats();
        public static event PlayerUIStats onWeaponChange;
        public static event PlayerUIStats onExpChange;

        public static void PlayerGetAttack(int health)
        {
            if (onPlayerHurt != null)
            {
                onPlayerHurt(health);
            }
        }

        public static void PlayerDeath(int health)
        {
            if (onPlayerDeath != null)
            {
                onPlayerDeath(health);
            }
        }

        public static void SwapWeapon()
        {
            if (onWeaponChange != null)
            {
                onWeaponChange();
            }
        }

        public static void ExperienceChange()
        {
            if (onExpChange != null)
            {
                onExpChange();
            }
        }
    }
}