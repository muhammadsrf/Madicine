using Madicine.Global.EnemyData;
using UnityEngine;
using ToolBox.Pools;
using System.Collections;
using Madicine.Global.Vfx;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class HealthEnemy : MonoBehaviour
    {
        public int health;
        [SerializeField] private AttributeEnemyData _enemyData;
        [SerializeField] private GameObject _virusGenome;
        [SerializeField] private GameObject _trunksMan;

        private Animator _animator;
        private Collider _colliderenemy;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _colliderenemy = GetComponent<Collider>();
        }

        private void OnEnable()
        {
            if (!_colliderenemy.enabled)
            {
                _colliderenemy.enabled = true;
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
                EnemyEvents.EnemyGetDown(health, this);

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

            // GetComponent<EnemyEvents>().EnemyGetAttack(health, this);

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

            Vector3 trunksPosition = new Vector3(transform.position.x, 0, transform.position.z);

            transform.localPosition = Vector3.zero;
            transform.parent.position = Vector3.zero;
            transform.parent.GetChild(1).position = new Vector3(0, 0.16f, 0);

            transform.parent.gameObject.Release();

            // spawn orang sehat
            GameObject orangSehat = Instantiate(_trunksMan, trunksPosition, Quaternion.identity);
            EnemyEvents.Cured();
        }

        IEnumerator DelayEnableColider()
        {
            yield return new WaitForSeconds(0.5f);
            if (!_colliderenemy.enabled)
            {
                ResetHealth();
            }
            _colliderenemy.enabled = !_colliderenemy.enabled;
        }
    }
}