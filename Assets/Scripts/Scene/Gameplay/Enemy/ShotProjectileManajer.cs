using UnityEngine;
using ToolBox.Pools;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class ShotProjectileManajer : MonoBehaviour
    {
        static public ShotProjectileManajer instance;

        [SerializeField] private GameObject _projectile;
        [Range(1, 1000)]
        [SerializeField] private int _jumlahMax = 100;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _projectile.Populate(count: _jumlahMax);
        }

        public void ClearProjectile()
        {
            _projectile.Clear(destroyActive: true);
        }

        public void Shot(Vector3 position)
        {
            var projectileOut = _projectile.Reuse<Rigidbody>();
            projectileOut.velocity = Vector3.zero;
            projectileOut.transform.position = new Vector3(position.x, _projectile.transform.position.y, position.z);
            projectileOut.GetComponent<Projectile>().Tembak();
        }
    }
}