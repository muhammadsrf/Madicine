using UnityEngine;
using Madicine.Scene.Gameplay.Enemy;

namespace Madicine.Scene.Gameplay.Weapons
{
    public class ProjectileSpray : BaseProjectile
    {
        [SerializeField] private float _speed;
        [SerializeField] private int _damage = 10;
        private float _timing = 0.3f;
        [SerializeField] private Vector3 _baseScale;
        private Vector3 _updateScale;

        private void Update()
        {
            if (_timing < 0)
            {
                _updateScale = _baseScale;
                _timing = 0.3f;
                DestroyProjectile();
            }
            else { _timing -= Time.deltaTime; }
        }

        private void Start() {
            _updateScale = _baseScale;
        }

        private void FixedUpdate()
        {
            _updateScale += _updateScale * 7 *  Time.deltaTime;

            _rg.transform.localScale = _updateScale;
            _rg.AddForce(transform.up * _speed, ForceMode.Impulse);

        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                other.GetComponent<HealthEnemy>().SubtractHealth(_damage);
                DestroyProjectile();
            }
        }

        public void SetDamage(int newDamage)
        {
            _damage = newDamage;
        }
    }

}