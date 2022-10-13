using Madicine.Global.EnemyData;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class HealthEnemy : MonoBehaviour
    {
        public int health;
        [SerializeField] private AttributeEnemyData _enemyData;

        private void OnEnable()
        {
            ResetHealth();
        }

        // for test function with keyboard
        private void Update()
        {
            // if (Input.GetKeyDown(KeyCode.K))
            // {
            //     if (SubtractHealth(10) == 0)
            //     {
            //         Debug.Log("Mati!");
            //     }
            // }
        }

        public int SubtractHealth(int subtract)
        {
            health = Mathf.Max(0, health - subtract);

            // call event trigger enemy get attack / enemy hurt
            GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            if (health == 0)
            {
                // call event trigger enemy death
                GetComponent<EnemyEvents>().EnemyDeath(health, this);
            }
            return health;
        }

        public int ResetHealth()
        {
            health = _enemyData.GetHealthMax();

            GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            return health;
        }

        public AttributeEnemyData GetEnemyData()
        {
            return _enemyData;
        }
    }
}