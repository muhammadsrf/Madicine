using UnityEngine;
using Madicine.Scene.Gampalay.Weapons;

public class WeaponContoller : MonoBehaviour {
    
    private int SelectedWeapon = 0;
    private GameObject _weapon;
    private string nameTypeWeapon;
    public void Shoot(Transform spawner)
    {
        // this to get object in pooledObject
		GameObject objects = ProjectileSpewner.SharedInstance.GetPooledObject(nameTypeWeapon+"(Clone)");
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
        
    }

    // public BaseWeapon GetSelectedWeapon(){
    //     return BaseWeapon;
    // }

    private void Update() {
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

    private void Start() {
        _weapon = this.gameObject.transform.GetChild(0).gameObject;
        nameTypeWeapon = _weapon.GetComponent<BaseWeapon>().nameType;
    }
}