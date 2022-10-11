using UnityEngine;

namespace Madicine.Scene.Gampalay.Weapons{
    public class ProjectileInject : BaseProjectile {
        [SerializeField] private float _speed;
        private float timing = 3f;

        private void Update() {
            if(timing < 0){
                DestroyProjectile();
                timing = 3f;
            }else{timing -= Time.deltaTime;}
        }

        private void FixedUpdate() {
            _rg.AddForce(transform.up * _speed , ForceMode.Impulse);
            
        }

        private void Start() {
        }

    }

}