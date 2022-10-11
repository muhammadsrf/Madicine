using UnityEngine;

namespace Madicine.Scene.Gameplay.Weapons
{
    public class ProjectileSpray : BaseProjectile
    {
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
        private void Start()
        {
            _rg.AddForce(transform.up * 3f, ForceMode.VelocityChange);
        }
    }

}