using Madicine.Global.EnemyData;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class HealthEnemy : MonoBehaviour
    {
        [SerializeField] private AttributeEnemyData _enemyData;
        public int health;
        private HealthEnemyDisplay _healthEnemyDisplay;

        private void Awake()
        {
            _healthEnemyDisplay = transform.parent.GetComponentInChildren<HealthEnemyDisplay>();
            ResetHealth();
        }

        // for test function with keyboard
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (SubtractHealth(10) == 0)
                {
                    Debug.Log("Mati!");
                }
            }
        }

        public int SubtractHealth(int subtract)
        {
            health = Mathf.Max(0, health - subtract);
            _healthEnemyDisplay.SetHealthDisplay((float)health / (float)_enemyData.GetHealthMax());
            return health;
        }

        public int ResetHealth()
        {
            health = _enemyData.GetHealthMax();
            _healthEnemyDisplay.SetHealthDisplay(1);
            return health;
        }

        public AttributeEnemyData GetEnemyData()
        {
            return _enemyData;
        }
    }
}