using Madicine.Scene.Gameplay.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyAIShot : MonoBehaviour
    {
        [SerializeField] private float _attackDistanceArea = 5f;
        [Range(0, 1)]
        [SerializeField] private float _speedFraction = 0.2f;
        [SerializeField] private Transform _areaChase;

        private EnemyMovement _mover;
        private EnemyShotAttack _enemyAttack;
        private GameObject _player;
        private HealthEnemy _healthEnemy;
        private bool _enemyDeath;

        private void OnEnable()
        {
            _enemyDeath = false;
            // listening to event death enemy
            EnemyEvents.onEnemyDeath += this.EnemyDeath;
        }

        private void OnDisable()
        {
            // cancel listening to event death enemy
            EnemyEvents.onEnemyDeath -= this.EnemyDeath;
        }

        private void EnemyDeath(int hp, HealthEnemy healthEnemy)
        {
            // ignoring event if call event is not from this healthEnemy object
            if (healthEnemy != _healthEnemy) { return; }

            _enemyDeath = true;
        }

        private void Awake()
        {
            _healthEnemy = GetComponent<HealthEnemy>();
            _mover = GetComponent<EnemyMovement>();
            _enemyAttack = GetComponent<EnemyShotAttack>();
            _player = GameObject.FindObjectOfType<PlayerController>().gameObject;
            // _areaChase.localScale = Vector3.one * _chaseDistance * 2;
        }

        public void Reset()
        {
            NavMeshAgent navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private Vector3 GetGuardPosition()
        {
            return transform.position;
        }

        private void Update()
        {
            if (_enemyDeath) { return; }

            _enemyAttack.StartAttack(_player);

            if (_enemyAttack.IsAttack())
            {
                return;
            }

            MoveBehaviour();
        }

        private void MoveBehaviour()
        {
            _mover.StartMoveAction(_player.transform.position, _speedFraction);
        }

        private float CheckDistanceToPlayer()
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer;
        }
    }
}