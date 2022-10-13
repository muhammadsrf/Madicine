using System;
using Madicine.Scene.Gameplay.Player;
using UnityEngine;
using UnityEngine.AI;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        [SerializeField] private float _chaseDistance = 5f;
        [SerializeField] private float _suspicionTime = 3f;
        [Range(0, 1)]
        [SerializeField] private float _speedFraction = 0.2f;
        [SerializeField] private Transform _areaChase;

        private EnemyMovement _mover;
        private EnemyAttack _enemyAttack;
        private GameObject _player;
        private HealthEnemy _healthEnemy;
        private bool _enemyDeath;
        private float _timeSinceLastSawPlayer = Mathf.Infinity;
        private float _timeSinceArrivedAtWaypoint = Mathf.Infinity;
        private float _timeSinceAggrevated = Mathf.Infinity;

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
            SpawnManager.AddToPoolObject(transform.parent.gameObject);
        }

        private void Awake()
        {
            _healthEnemy = GetComponent<HealthEnemy>();
            _mover = GetComponent<EnemyMovement>();
            _enemyAttack = GetComponent<EnemyAttack>();
            _player = GameObject.FindObjectOfType<PlayerController>().gameObject;
            _areaChase.localScale = Vector3.one * _chaseDistance * 2;
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

            MoveBehaviour();
            
            if (_timeSinceLastSawPlayer > _suspicionTime && !IsAggrevated())
            {
                SuspicionBehaviour();
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                _enemyAttack.ShotProjectile();
                _enemyAttack.AreaAttack(_player);
            }

            UpdateTimers();
        }

        private void MoveBehaviour()
        {
            _timeSinceAggrevated = 0;
            _timeSinceLastSawPlayer = 0;

            _mover.StartMoveAction(_player.transform.position, _speedFraction);
            _enemyAttack.StartAttack(_player);
        }

        private bool IsAggrevated()
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer < _chaseDistance;
        }

        private float CheckDistanceToPlayer()
        {
            float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
            return distanceToPlayer;
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionEnemyScheduler>().CancelCurrentAction();
        }

        private void UpdateTimers()
        {
            _timeSinceLastSawPlayer += Time.deltaTime;
            _timeSinceArrivedAtWaypoint += Time.deltaTime;
            _timeSinceAggrevated += Time.deltaTime;
        }
    }
}