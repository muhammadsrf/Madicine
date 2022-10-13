using System;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Player
{
    public class HealthPlayer : MonoBehaviour
    {
        public int health;
        [SerializeField] private PlayerDataSO _playerData;

        private void OnEnable()
        {
            ResetHealth();
            PlayerEvents.onPlayerDeath += OnDie;
        }

        private void OnDisable()
        {
            PlayerEvents.onPlayerDeath -= OnDie;
        }

        private void OnDie(int health)
        {
        }

        public int SubtractHealth(int subtract)
        {
            health = Mathf.Max(0, health - subtract);

            // call event trigger enemy get attack / enemy hurt
            PlayerEvents.PlayerGetAttack(health);

            if (health == 0)
            {
                // call event trigger enemy death
                PlayerEvents.PlayerDeath(health);
            }
            return health;
        }

        public int ResetHealth()
        {
            health = _playerData.health;

            PlayerEvents.PlayerGetAttack(health);

            return health;
        }

        public PlayerDataSO GetPlayerData()
        {
            return _playerData;
        }
    }
}