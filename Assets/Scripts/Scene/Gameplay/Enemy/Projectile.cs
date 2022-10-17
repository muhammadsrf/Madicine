using UnityEngine;
using ToolBox.Pools;
using Madicine.Scene.Gameplay.Player;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private ProjectileData _enemyProjectile;
        private float _timer;
        private Rigidbody _rb;
        private Transform _target;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void Tembak()
        {
            Vector3 arah = Vector3.Normalize(_target.position - transform.position);
            _rb.velocity = new Vector3(arah.x * _enemyProjectile.GetSpeed(), arah.y, arah.z * _enemyProjectile.GetSpeed());
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer > _enemyProjectile.GetTimeVisible())
            {
                ReleaseMe();
                _timer = 0;
            }
        }

        private void ReleaseMe()
        {
            _rb.velocity = Vector3.zero;
            gameObject.Release();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                other.GetComponent<PlayerController>().SubtractHealth(_enemyProjectile.damage);
                ReleaseMe();
            }
        }
    }
}