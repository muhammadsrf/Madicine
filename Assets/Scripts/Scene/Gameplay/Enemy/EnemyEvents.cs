using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyEvents : MonoBehaviour
    {
        // delegate name for event combat stats
        public delegate void EnemyCombatStats(int health, HealthEnemy healthScript);
        public delegate void EnemyCured();
        // event name for delegate enemy
        public static event EnemyCombatStats onEnemyHurt;
        public static event EnemyCombatStats onEnemyTransition;
        public static event EnemyCombatStats onEnemyFall;
        public static event EnemyCured onEnemyCured;

        public void EnemyGetAttack(int health, HealthEnemy healthScript)
        {
            if (onEnemyHurt != null)
            {
                onEnemyHurt(health, healthScript);
            }
        }

        public void EnemyTransition(int health, HealthEnemy healthScript)
        {
            if (onEnemyTransition != null)
            {
                onEnemyTransition(health, healthScript);
            }
        }

        public static void Cured()
        {
            if (onEnemyFall != null)
            {
                onEnemyCured();
            }
        }

        public static void EnemyGetDown(int health, HealthEnemy healthScript)
        {
            if (onEnemyFall != null)
            {
                onEnemyFall(health, healthScript);
            }
        }
    }
}