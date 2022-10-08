using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class BarEnemyUI : MonoBehaviour
    {
        [SerializeField] private Transform _programmingModel;
        private Vector2 _myPosition;
        private Vector2 _playerPosition;

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
    }
}