using Madicine.Scene.Gameplay.Enemy;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Weapons
{
    public class ProjectileInject : BaseProjectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage = 10;
        private float _timing = 2f;

        private void Update()
        {
            if (_timing < 0)
            {
                DestroyProjectile();
                _timing = 2f;
            }
            else { _timing -= Time.deltaTime; }
        }

        private void FixedUpdate()
        {
            _rg.AddForce(transform.up * _speed, ForceMode.Impulse);

        }

        private void Start()
        {
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                other.GetComponent<HealthEnemy>().SubtractHealth(_damage);
            }
        }

    }

}