using UnityEngine;
using UnityEngine.UI;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class HealthEnemyDisplay : MonoBehaviour
    {
        [SerializeField] private Transform _programmingModel;
        [SerializeField] private Image _healthBarFiller;
        private Vector2 _myPosition;
        private Vector2 _playerPosition;
        [SerializeField] private HealthEnemy _healthEnemy;

        private void OnEnable()
        {
            EnemyEvents.onEnemyHurt += SetHealthDisplay;
        }

        private void OnDisable()
        {
            EnemyEvents.onEnemyHurt -= SetHealthDisplay;
        }

        private void Awake()
        {
            _myPosition = new Vector2(transform.localPosition.x, transform.localPosition.z);
        }

        private void Update()
        {
            UpdatePositionBar();
        }

        private void UpdatePositionBar()
        {
            _playerPosition = new Vector2(_programmingModel.localPosition.x, _programmingModel.localPosition.z);
            if (_myPosition != _playerPosition)
            {
                transform.localPosition = new Vector3(_playerPosition.x, transform.localPosition.y, _playerPosition.y);
                _myPosition = _playerPosition;
            }

        }

        private void SetHealthDisplay(int health, HealthEnemy healthScript)
        {
            // ignoring event if call event is not from this Enemy health object
            if (healthScript != _healthEnemy) { return; }

            float value = (float)health / (float)_healthEnemy.GetEnemyData().GetHealthMax();

            if (value > 1)
            {
                value = 1;
            }
            else if (value < 0)
            {
                value = 0;
            }

            _healthBarFiller.fillAmount = value;
        }
    }
}