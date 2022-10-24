using Madicine.Scene.Gameplay.Player;
using UnityEngine;

namespace Madicine.Scene.Gameplay.UI
{
    public class UpgradeScreenController : MonoBehaviour
    {
        [SerializeField] private GameplayNavigator _gameNav;
        [SerializeField] private bool _debugLog;

        private PlayerController _player;

        private void Awake()
        {
            _player = FindObjectOfType<PlayerController>();
        }

        public void HealthPointClick()
        {
            if (_player == null)
            {
                MyDebug("player controller can't accessed. (UpgradeScreenController).");
                return;
            }

            _player.UpgradeHealthLevel();
            _gameNav.SetActiveUpgradeScreen(false);
        }

        public void WeaponPointClick()
        {
            if (_player == null)
            {
                MyDebug("player controller can't accessed. (UpgradeScreenController).");
                return;
            }

            _player.UpgradeAttackLevel();
            _gameNav.SetActiveUpgradeScreen(false);
        }

        // for debug only
        private void MyDebug(string information)
        {
            if (_debugLog)
            {
                Debug.Log(information);
            }
        }
    }
}