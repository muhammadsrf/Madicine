using UnityEngine;

public class ProjectileSpray : BaseProjectile {
    private Rigidbody _rg;
    private void Update() {
        _rg.AddForce(Vector3.forward);
    }
}