using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Madicine.Scene.Gampalay.Weapons;

public class ProjectileSpewner : MonoBehaviour
{
    public static ProjectileSpewner SharedInstance;

    public List<GameObject> pooledObjects;
    public List<BaseProjectile> objectToPooleds;

    private void Awake() {
        SharedInstance = this;

    }

    private void Start() {
        pooledObjects = new List<GameObject>();
        foreach (BaseProjectile item in objectToPooleds)
        {
            for (int i = 0; i < item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
				obj.GetComponent<BaseProjectile>().index = i;
                obj.SetActive(false);
                pooledObjects.Add(obj);
                Debug.Log($" init : {obj}");
            }
        }

    }

    public GameObject GetPooledObject(string name){
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            Debug.Log(!pooledObjects[i].activeInHierarchy && pooledObjects[i].name == name);
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].name == name)
            {
                return pooledObjects[i];
			}
        }
        // foreach (BaseProjectile  item in objectToPooled)
        // {
        //     if (item.objectToPool.name == name)
        //     {
        //         if (item.shouldExpand)
        //         {
        //             GameObject obj = (GameObject)Instantiate(objectToPooled);
        //             obj.SetActive(false);
        //             pooledObject.Add(obj);
        //             return obj;
        //         }
        //     }
        // }
        return null;
    }

	public void DestroyProjec(int i){
        Debug.Log($" destroy |= {pooledObjects[i].GetComponent<BaseProjectile>().index}");
		pooledObjects[i].SetActive(false);
	}


}