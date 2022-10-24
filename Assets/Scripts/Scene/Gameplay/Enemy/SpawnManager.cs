using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class SpawnManager : MonoBehaviour
    {
        /* not used temporary
        [SerializeField] private int _maxToSpawn;        
        // [SerializeField] private int _amountToPool;
        // [SerializeField] private float _timeForSpawn = 5.0f;
        // Please dont delete this */

        [Header("Enemy Prefabs List:")]
        [SerializeField] private List<GameObject> _enemies;
        [SerializeField] private GameObject _trunksMan;
        [SerializeField] private List<Transform> _listTransform = new List<Transform>();
        [Header("Spawn Information:")]
        [SerializeField] private int _currentWave = 1;
        public List<WaveClass> listWaveEnemy = new List<WaveClass>();
        public int countSpawn;
        public bool canSpawn;

        private Dictionary<int, Vector3> _disPosition = new Dictionary<int, Vector3>();

        [HideInInspector] public List<GameObject> _pooledEnemies;

        private int _enemyActive;
        private float _timer;

        private void Awake()
        {
            // create dictionary for list position
            int key = 0;
            foreach (var item in _listTransform)
            {
                _disPosition.Add(key, item.position);
                key++;
            }
        }

        private void Start()
        {
            SpawnInit();
            Spawn();
            _enemyActive++;
        }

        private void Update()
        {
            _timer += Time.deltaTime;

            if (canSpawn)
            {
                if (_timer >= GetTimeSpawn())
                {
                    Spawn();
                    _timer = 0;
                }
            }
            else if (!canSpawn)
            {
                // add +1 to current wave
                if (countSpawn == 0)
                {
                    _currentWave++;
                    DestroyAllInstance();
                    SpawnInit();
                    canSpawn = true;
                }
            }
        }

        private void OnEnable()
        {
            EnemyEvents.onEnemyTransition += ReleaseOneEnemy;
        }

        // event saat enemy disembuhkan -> transisi menjadi orang sehat
        private void ReleaseOneEnemy(int health, HealthEnemy healthScript)
        {
            AddToPool(healthScript.transform.parent.gameObject);
            Vector3 trunksPosition = new Vector3(healthScript.transform.position.x, 0, healthScript.transform.position.z);

            // spawn orang sehat
            GameObject orangSehat = Instantiate(_trunksMan, trunksPosition, Quaternion.identity);
            EnemyEvents.Cured();

            if (!canSpawn)
            {
                countSpawn--;
            }
        }

        private void OnDisable()
        {
            EnemyEvents.onEnemyTransition -= ReleaseOneEnemy;
        }

        private int GetEnemyHP()
        {
            int hp = 0;
            foreach (var item in listWaveEnemy)
            {
                if (item.wave == _currentWave)
                {
                    hp = item.hp;
                    break;
                }
            }
            return hp;
        }

        private int GetMaxSpawn()
        {
            int maxSpawn = 0;
            foreach (var item in listWaveEnemy)
            {
                if (item.wave == _currentWave)
                {
                    maxSpawn = item.actualEnemy;
                    break;
                }
            }
            return maxSpawn;
        }

        private int GetTimeSpawn()
        {
            int timeSpawn = 0;
            foreach (var item in listWaveEnemy)
            {
                if (item.wave == _currentWave)
                {
                    timeSpawn = item.timePerSpawn;
                    break;
                }
            }
            return timeSpawn;
        }

        private void SpawnInit()
        {
            for (int i = 0; i < GetMaxSpawn(); i++) // obj pool max
            {
                for (int j = 0; j < _enemies.Count; j++)
                {
                    int randomValue = Random.Range(0, _disPosition.Count - 1);
                    bool checkValue = _disPosition.TryGetValue(randomValue, out Vector3 positionSpawn);

                    if (!checkValue) { continue; }

                    var tmp = Instantiate(_enemies[j], positionSpawn, Quaternion.identity);
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
            for (int i = 0; i < GetMaxSpawn(); i++) // obj pool max
            {
                int random = Random.Range(0, GetMaxSpawn());
                if (_enemyActive <= GetMaxSpawn())
                {
                    if (!_pooledEnemies[random].activeInHierarchy)
                    {
                        GameObject enemy = _pooledEnemies[random];

                        // set hp to default reference
                        enemy.GetComponentInChildren<HealthEnemy>().GetEnemyData().SetHealthMax(GetEnemyHP());
                        enemy.GetComponentInChildren<HealthEnemy>().ResetHealth(GetEnemyHP());

                        enemy.SetActive(true);
                        _enemyActive++;
                        countSpawn++;

                        if (countSpawn == GetMaxSpawn())
                        {
                            canSpawn = false;
                        }

                        break;
                    }
                }
            }
        }

        public void AddToPool(GameObject obj)
        {
            if (obj.activeInHierarchy)
            {
                obj.SetActive(false);
                _enemyActive--;
            }
        }

        private void DestroyAllInstance()
        {
            foreach (var item in _pooledEnemies)
            {
                Destroy(item);
            }

            _pooledEnemies.Clear();
            _enemyActive = 0;
        }
    }
}