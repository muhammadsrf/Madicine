using Madicine.Global.EnemyData;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyAttack : MonoBehaviour, IAction
    {
        [SerializeField] private float _delayShotProjectile = 3.0f;
        [SerializeField] private float _delayAreaDamage = 3.0f;

        private float _timeSinceShot;
        private float _timeSinceArea;
        private AttributeEnemyData _enemyData;

        private void Awake()
        {
            _enemyData = GetComponent<HealthEnemy>().GetEnemyData();
        }

        private void Update()
        {
            _timeSinceArea += Time.deltaTime;
            _timeSinceShot += Time.deltaTime;
        }

        public void StartAttack(GameObject player)
        {
            if (_timeSinceArea > _delayAreaDamage)
            {
                AreaAttack(player);
                _timeSinceArea = 0;
            }

            if (_timeSinceShot > _delayShotProjectile)
            {
                ShotProjectile();
                _timeSinceShot = 0;
            }
        }

        public void AreaAttack(GameObject player)
        {
            if (_enemyData.typeEnemy == EnemyClass.EnemyArea)
            {
                Debug.Log("Give Damage to " + player.name + "!");
            }
        }

        public void ShotProjectile()
        {
            if (_enemyData.typeEnemy == EnemyClass.EnemyShot)
            {
                if (ShotProjectileManajer.instance)
                {
                    ShotProjectileManajer.instance.Shot(transform.position);
                }
            }
        }

        public void Cancel()
        {

        }
    }
}