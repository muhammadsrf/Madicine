using UnityEngine;

public class ProjectileInject : BaseProjectile {
    [SerializeField] private Rigidbody _rg;
    private float timing = 2f;

    private void Update() {
        if(timing < 0){
            DestroyProjectile();
            timing = 2f;
        }else{timing -= Time.deltaTime;}
    }

    private void Start() {
        _rg.AddForce(transform.up * 3f, ForceMode.VelocityChange);
    }

    
}