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
        private float _timeSinceLastSawPlayer = Mathf.Infinity;
        private float _timeSinceArrivedAtWaypoint = Mathf.Infinity;
        private float _timeSinceAggrevated = Mathf.Infinity;

        private void Awake()
        {
            _mover = GetComponent<EnemyMovement>();
            _enemyAttack = GetComponent<EnemyAttack>();
            _player = GameObject.FindWithTag("Player");
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
            if (IsAggrevated())
            {
                AttackBehaviour();
            }
            else if (_timeSinceLastSawPlayer > _suspicionTime && !IsAggrevated())
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

        private void AttackBehaviour()
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