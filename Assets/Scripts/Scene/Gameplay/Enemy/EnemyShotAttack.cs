using UnityEngine;
using Madicine.Global.EnemyData;
using Madicine.Global.Vfx;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyShotAttack : MonoBehaviour, IAction
    {
        [SerializeField] private float _delayShotProjectile = 3.0f;

        private bool _isAttack;
        private float _timeSinceShot;
        private AttributeEnemyData _enemyData;
        private Animator _animator;

        private void Awake()
        {
            _enemyData = GetComponent<HealthEnemy>().GetEnemyData();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _timeSinceShot += Time.deltaTime;
        }

        public void StartAttack(GameObject player)
        {
            if (_timeSinceShot > _delayShotProjectile)
            {
                _animator.SetTrigger("attack");
                GetComponent<ActionEnemyScheduler>().StartAction(this);
                _isAttack = true;
                _timeSinceShot = 0;
            }
        }

        public void ShotProjectile()
        {
            if (_enemyData.typeEnemy == EnemyClass.EnemyShot)
            {
                if (ShotProjectileManajer.instance)
                {
                    VisualEffectController.Instance.SpawnVFX(VisualEffectEnum.EnemyShoot, transform);
                    ShotProjectileManajer.instance.Shot(transform.position);
                    _isAttack = false;
                }
            }
        }

        public void Cancel()
        {
            _isAttack = false;
        }

        public bool IsAttack()
        {
            return _isAttack;
        }
    }
}