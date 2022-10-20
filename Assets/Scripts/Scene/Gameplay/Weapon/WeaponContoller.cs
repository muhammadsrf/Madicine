using UnityEngine;

namespace Madicine.Scene.Gameplay.Weapons
{
    public class WeaponContoller : MonoBehaviour
    {
        private int _seletedWeapon = 0;
        private string _typeProjectile;
        private string _weaponName;
        private GameObject _weapon;

        // save atk damage temporary
        [SerializeField] private int _temporaryDamageAtk;
        public int TemporaryDamageAtk
        {
            set
            {
                if (value > 0)
                {
                    _temporaryDamageAtk = value;
                }
                else
                {
                    _temporaryDamageAtk = 1;
                }
            }
            get
            {
                return _temporaryDamageAtk;
            }
        }

        public void Shoot(Transform spawner)
        {
            // this to get object in pooledObject
            GameObject objects = ProjectileSpewner.SharedInstance.GetPooledObject(_typeProjectile + "(Clone)");
            // this to save object from object pooling
            // loop to check object
            if (objects != null)
            {

                // sinchronize damage projectile with reference damage
                if (_seletedWeapon == 0)
                {
                    objects.GetComponent<ProjectileInject>().SetDamage(_temporaryDamageAtk);
                }
                else if (_seletedWeapon == 1)
                {
                    objects.GetComponent<ProjectileSpray>().SetDamage(_temporaryDamageAtk);

                }
                
                objects.transform.position = spawner.transform.position;
                objects.transform.rotation = spawner.transform.rotation;

                objects.SetActive(true);
            }
        }

        public void SelectWeapon()
        {
            if (_seletedWeapon == 0)
            {
                _seletedWeapon = 1;
            }
            else if (_seletedWeapon == 1)
            {
                _seletedWeapon = 0;
            }
        }

        public void SelectWeapon(int i)
        {
            _seletedWeapon = i;
        }

        public int Get_seletedWeapon()
        {
            return _seletedWeapon;
        }

        private void Update()
        {
            if (this.gameObject.transform.childCount > _seletedWeapon)
            {
                _weapon = this.gameObject.transform.GetChild(_seletedWeapon).gameObject;
            }
            else
            {
                _weapon = this.gameObject.transform.GetChild(0).gameObject;
            }
            _typeProjectile = _weapon.GetComponent<BaseWeapon>().projectileType;
            _weaponName = _weapon.GetComponent<BaseWeapon>().nameWeapon;
        }

        private void DestroyinControoler(GameObject objects)
        {
            //to destroy
            objects.SetActive(false);
            // orthis
            if (objects.gameObject.tag == "Enemy")
            {
                if (gameObject.tag == "objectsInPolled")
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }

    }
}