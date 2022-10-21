using Madicine.Global.EnemyData;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class HealthEnemy : MonoBehaviour
    {
        public int health;
        [SerializeField] private AttributeEnemyData _enemyData;
        [SerializeField] private GameObject _virusGenome;

        private Animator _animator;
        private bool _healthNull;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public int SubtractHealth(int subtract)
        {
            if (_healthNull) { return 0; }

            health = Mathf.Max(0, health - subtract);

            // call event trigger enemy get attack / enemy hurt
            GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            if (health == 0)
            {
                _animator.SetTrigger("Die");
                _healthNull = true;
                EnemyEvents.EnemyGetDown(health, this);

                // drop virus genome
                Instantiate(_virusGenome, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z), Quaternion.identity);
            }
            return health;
        }

        public int ResetHealth()
        {
            health = _enemyData.GetHealthMax();
            _healthNull = false;

            // GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            return health;
        }

        public int ResetHealth(int newHealth)
        {
            health = newHealth;
            _healthNull = false;

            GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            return health;
        }

        public AttributeEnemyData GetEnemyData()
        {
            return _enemyData;
        }

        // for event animation
        void EnemyTransitionToTrunksman()
        {
            // call event trigger enemy death
            GetComponent<EnemyEvents>().EnemyTransition(health, this);
        }

    }
}