using UnityEngine;
using System;

[Serializable]   
public class BaseProjectile : MonoBehaviour{

    private Rigidbody _rg;
	public int index;
    public int amountToPool;
    public GameObject objectToPool;

    public void DestroyProjectile(){
        //this.objectToPool.gameObject.SetActive(false);
		ProjectileSpewner.SharedInstance.DestroyProjec(index);
        Debug.Log($"(ProjectileInject destroy)name projectile : {index}|{this.objectToPool.gameObject.name} {objectToPool.GetComponent<BaseProjectile>().index}");
    }
    
}