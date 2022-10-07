using UnityEngine;

namespace Madicine.Scene.Gampalay.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon/inject")]
    public class WeaponInject : BaseWeapon
    {
        private Rigidbody _rb;
        private void Init(Vector3 velosity){
            _rb.AddForce(velosity, ForceMode.Impulse);
        }

    }
}
