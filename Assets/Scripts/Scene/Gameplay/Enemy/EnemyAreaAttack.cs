using UnityEngine;
using Madicine.Global.EnemyData;
using Madicine.Scene.Gameplay.Player;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class EnemyAreaAttack : MonoBehaviour, IAction
    {
        [SerializeField] private Transform _areaChase;
        [SerializeField] private float _areaDistance;
        [SerializeField] private float _delayAreaDamage = 3.0f;
        [SerializeField] private int _damage;
        private bool _isAttack;
        private float _timeSinceArea;
        private AttributeEnemyData _enemyData;
        private Animator _animator;
        private GameObject _player;

        private void Awake()
        {
            _enemyData = GetComponent<HealthEnemy>().GetEnemyData();
            _animator = GetComponent<Animator>();
            _areaChase.localScale = Vector3.one * _areaDistance * 2;
        }

        private void Update()
        {
            _timeSinceArea += Time.deltaTime;
        }

        public void StartAttack(GameObject player, float distanceToPlayer)
        {
            _player = player;
            if (_timeSinceArea > _delayAreaDamage && distanceToPlayer < _areaDistance)
            {
                _animator.SetTrigger("attack");
                _timeSinceArea = 0;
                _isAttack = true;
            }
        }

        public void AreaAttack()
        {
            _player.GetComponent<PlayerController>().SubtractHealth(_damage);
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