using UnityEngine;

namespace Madicine.Scene.Gampalay.Weapons{
    public class ProjectileInject : BaseProjectile {
        [SerializeField] private float _speed;
        private float timing = 2f;

        private void Update() {
            if(timing < 0){
                DestroyProjectile();
                timing = 2f;
            }else{timing -= Time.deltaTime;}
        }

        private void FixedUpdate() {
            _rg.AddForce(transform.up * _speed , ForceMode.Impulse);
            
        }

        private void Start() {
        }

    }

}