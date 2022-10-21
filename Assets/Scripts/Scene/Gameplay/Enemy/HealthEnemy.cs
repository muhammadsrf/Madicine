using Madicine.Global.EnemyData;
using UnityEngine;
using System.Collections;
using Madicine.Global.Vfx;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class HealthEnemy : MonoBehaviour
    {
        public int health;
        [SerializeField] private AttributeEnemyData _enemyData;
        [SerializeField] private GameObject _virusGenome;

        private Animator _animator;
        private Collider _colliderenemy;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _colliderenemy = GetComponent<Collider>();
        }

        // for test function with keyboard
        private void Update()
        {
            if (!_colliderenemy.enabled){
                StartCoroutine(DelayEnableColider());
            }
        }

        public int SubtractHealth(int subtract)
        {
            health = Mathf.Max(0, health - subtract);

            // call event trigger enemy get attack / enemy hurt
            GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            if (health == 0)
            {
                _animator.SetTrigger("Die");

                //disable collider enemy
                _colliderenemy.enabled = !_colliderenemy.enabled;

                // drop virus genome
                Instantiate(_virusGenome, new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z), Quaternion.identity);
            }
            VisualEffectController.Instance.SpawnVFX(VisualEffectEnum.HitEnemy, this.transform);
            return health;
        }

        public int ResetHealth()
        {
            health = _enemyData.GetHealthMax();

            GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

            return health;
        }

        public int ResetHealth(int newHealth)
        {
            health = newHealth;

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

        IEnumerator DelayEnableColider(){
            yield return new WaitForSeconds(0.5f);
            if (!_colliderenemy.enabled){
                ResetHealth();
            }
            _colliderenemy.enabled = !_colliderenemy.enabled;
        }

    }
}