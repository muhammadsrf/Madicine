using UnityEngine;
using Madicine.Scene.Gampalay.Weapons;

namespace Madicine.Scene.Gampalay.Weapons{

    public class WeaponContoller : MonoBehaviour {
        
        private int _seletedWeapon = 0;
        private string _typeProjectile;
        private string _weaponName;
        private GameObject _weapon;
        public void Shoot(Transform spawner)
        {
            // this to get object in pooledObject
            GameObject objects = ProjectileSpewner.SharedInstance.GetPooledObject(_typeProjectile+"(Clone)");
            // this to save object from object pooling
            // loop to check object
            if (objects != null)
            {
                objects.transform.position = spawner.transform.position;
                objects.transform.rotation = spawner.transform.rotation;
                objects.SetActive(true);
            }
        }

        public void SelectWeapon(int i){
            _seletedWeapon = i;
        }

        public string Get_seletedWeapon(){
            return _weaponName;
        }

        public void Setlevel(int newlevel){
            _weapon.GetComponent<BaseWeapon>().level = newlevel;
        }

        private void Update() {
            if(this.gameObject.transform.childCount > _seletedWeapon){
                _weapon = this.gameObject.transform.GetChild(_seletedWeapon).gameObject;
            }else{
                _weapon = this.gameObject.transform.GetChild(0).gameObject;
            }
            _typeProjectile = _weapon.GetComponent<BaseWeapon>().projectileType;
            _weaponName = _weapon.GetComponent<BaseWeapon>().nameWeapon;
        }

        private void DestroyinControoler(GameObject objects) {
            //to destroy
            objects.SetActive(false);
            // orthis
            if (objects.gameObject.tag == "Enemy")
            {
                if (gameObject.tag == "objectsInPolled")
                {
                    gameObject.SetActive(false);
                } else {
                    Destroy(gameObject);
                }
            }
        }

    }
}