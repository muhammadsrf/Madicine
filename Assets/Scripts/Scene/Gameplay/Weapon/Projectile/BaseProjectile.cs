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

        private void OnCollisionEnter(Collision other)
        {
            if (other.transform.tag == "Enemy")
            {
                //call function to reduce enemy healt
            }
        }

    }

}