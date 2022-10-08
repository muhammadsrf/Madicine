using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _enemies;
        [SerializeField] private int _maxToSpawn;
        [SerializeField] private int _amountToPool;
        [SerializeField] private Vector3 _maxPosition;

        [HideInInspector] public List<GameObject> _pooledEnemies;

        private int _enemyActive;
        private float _timer;

        private void Start()
        {
            SpawnInit();
            Spawn();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if(_timer >= 5)
            {
                Spawn();
                _timer = 0;
            }
        }

        private void OnEnable()
        {
            //subscribe event enemy hit, add enemy to pool
        }

        private void OnDisable()
        {
            //unsubscribe event enemy hit, add enemy to pool
        }

        private void SpawnInit()
        {
            for(int i = 0; i < _amountToPool; i++)
            {
                for(int j = 0; j < _enemies.Count; j++)
                {
                    Vector3 ranPos = new Vector3(Random.Range(-_maxPosition.x, _maxPosition.x), Random.Range(-_maxPosition.y, _maxPosition.y), Random.Range(-_maxPosition.z, _maxPosition.z));
                    var tmp = Instantiate(_enemies[j], ranPos, Quaternion.identity);
                    tmp.transform.SetParent(this.transform);
                    _pooledEnemies.Add(tmp);
                    if (tmp.activeInHierarchy)
                    {
                        tmp.SetActive(false);
                    }
                }
               
            }
        }

        private void Spawn()
        {
            for(int i = 0; i < _pooledEnemies.Count; i++)
            {
                int random = Random.Range(0, _pooledEnemies.Count);
                if(_enemyActive <= _maxToSpawn)
                {
                    if (!_pooledEnemies[random].activeInHierarchy)
                    {
                        _pooledEnemies[random].SetActive(true);
                        _enemyActive++;
                        break;
                    }
                }
            }
        }

        public void AddToPool(GameObject obj)
        {
            if(obj.activeInHierarchy)
            {
                obj.SetActive(false);
                _enemyActive--;
            }
        }

    }
}