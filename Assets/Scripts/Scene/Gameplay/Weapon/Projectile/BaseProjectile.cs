using UnityEngine;
using System;

namespace Madicine.Scene.Gameplay.Weapons
{
    [Serializable]
    public class BaseProjectile : MonoBehaviour
    {
        [HideInInspector] public int indexProjectile;
        public int amountToPool;
        public GameObject objectToPool;
        [SerializeField] protected Rigidbody _rg;

        public void DestroyProjectile()
        {
            //this.objectToPool.gameObject.SetActive(false);
            ProjectileSpewner.SharedInstance.DestroyProjec(indexProjectile);
        }

        

    }

}