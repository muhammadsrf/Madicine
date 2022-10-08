using UnityEngine;
using UnityEngine.AI;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyAIController : MonoBehaviour
    {
        [SerializeField] private float chaseDistance = 5f;
        [SerializeField] private float suspicionTime = 3f;
        [Range(0, 1)]
        [SerializeField] private float speedFraction = 0.2f;

        private EnemyMovement mover;
        private GameObject player;
        private float timeSinceLastSawPlayer = Mathf.Infinity;
        private float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        private float timeSinceAggrevated = Mathf.Infinity;

        private void Awake()
        {
            mover = GetComponent<EnemyMovement>();
            player = GameObject.FindWithTag("Player");
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
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                SuspicionBehaviour();
            }

            UpdateTimers();
        }

        private void AttackBehaviour()
        {
            mover.StartMoveAction(player.transform.position, speedFraction);
        }

        private bool IsAggrevated()
        {
            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
            return distanceToPlayer < chaseDistance;
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionEnemyScheduler>().CancelCurrentAction();
        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
            timeSinceAggrevated += Time.deltaTime;
        }
    }
}