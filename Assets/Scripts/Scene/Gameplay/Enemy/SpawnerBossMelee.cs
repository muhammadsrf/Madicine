using UnityEngine;
using ToolBox.Pools;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class SpawnerBossMelee : MonoBehaviour
    {
        public bool canSpawn;
        [SerializeField] private WaveReferenceData _data;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private int _amountToPool;
        [SerializeField] private Transform _position;

        private WaveController _waveController;
        private int _tempWaveNumber;

        private void Awake()
        {
            _waveController = GetComponent<WaveController>();
            _prefab.Populate(count: _amountToPool);
        }

        private void Update()
        {
            if (_waveController.freezeTimer)
            {
                return;
            }

            CheckDatabase();

            if (canSpawn)
            {
                Spawn();
                _waveController.freezeTimer = true;
            }
        }

        private void CheckDatabase()
        {
            foreach (var item in _data.waveAndDelay)
            {
                if (item.wave == _waveController.currentWave)
                {
                    canSpawn = true;
                    return;
                }
            }

            canSpawn = false;
        }

        private void Spawn()
        {
            Vector3 newPosition = new Vector3(_position.position.x, 0, _position.position.z);
            GameObject _enemySpawn = _prefab.Reuse(newPosition, Quaternion.identity);
            _enemySpawn.transform.GetChild(0).localPosition = new Vector3(0, 0, 0);
            _enemySpawn.transform.GetChild(1).localPosition = new Vector3(0, 1.6f, 0);
            _enemySpawn.GetComponentInChildren<HealthEnemy>().ResetHealth(10);
        }

        public void DestroyAll()
        {
            _prefab.Clear(destroyActive: true);
        }
    }


}
