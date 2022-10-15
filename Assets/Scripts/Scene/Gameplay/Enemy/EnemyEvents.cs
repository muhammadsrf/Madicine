using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyEvents : MonoBehaviour
    {
        // delegate name for event combat stats
        public delegate void EnemyCombatStats(int health, HealthEnemy healthScript);
        // event name for delegate enemy
        public static event EnemyCombatStats onEnemyHurt;
        public static event EnemyCombatStats onEnemyDeath;

        public void EnemyGetAttack(int health, HealthEnemy healthScript)
        {
            if (onEnemyHurt != null)
            {
                onEnemyHurt(health, healthScript);
            }
        }

        public void EnemyDeath(int health, HealthEnemy healthScript)
        {
            if (onEnemyDeath != null)
            {
                onEnemyDeath(health, healthScript);
            }
        }
    }
}