using UnityEngine;

namespace Madicine.Scene.Gampalay.Weapons{
    public class ProjectileSpray : BaseProjectile {
        private float timing = 2f;

        private void Update() {
            if(timing < 0){
                DestroyProjectile();
                timing = 2f;
            }else{timing -= Time.deltaTime;}
        }
        private void Start(){
            _rg.AddForce(transform.up * 3f, ForceMode.VelocityChange);
        }
    }

}