using UnityEngine;
using System;

[Serializable]   
public class BaseProjectile : MonoBehaviour{

    private Rigidbody _rg;
	public int indexProjectile;
    public int amountToPool;
    public GameObject objectToPool;

    public void DestroyProjectile(){
        //this.objectToPool.gameObject.SetActive(false);
		ProjectileSpewner.SharedInstance.DestroyProjec(indexProjectile);
    }
    
}