using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Madicine.Scene.Gameplay.Player;
using System;

namespace Madicine.Scene.Gameplay.UI
{
    public class GameplayScreenUpdater : MonoBehaviour
    {
        [SerializeField] private Image _fillHP;
        [SerializeField] private Image _fillExp;
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _healthLevelNumber;
        [SerializeField] private TextMeshProUGUI _weaponLevelNumber;
        [SerializeField] private PlayerDataSO _playerData;
        [SerializeField] private GameObject[] _oneTwo;

        private void OnEnable()
        {
            PlayerEvents.onPlayerHurt += PlayerHurt;
            PlayerEvents.onWeaponChange += SwapWeaponIndicator;
        }

        private void OnDisable()
        {
            PlayerEvents.onPlayerHurt -= PlayerHurt;
            PlayerEvents.onWeaponChange -= SwapWeaponIndicator;
        }

        private void Awake()
        {
            PlayerHurt(_playerData.health);
        }

        private void PlayerHurt(int health)
        {
            _fillHP.fillAmount = (float)health / _playerData.health;
            _hpText.text = $"HP: {health}/{_playerData.health}";
            _healthLevelNumber.text = _playerData.level.ToString();
            _weaponLevelNumber.text = _playerData.armoreLevel.ToString();
        }

        private void SwapWeaponIndicator()
        {
            _oneTwo[0].SetActive(!_oneTwo[0].activeSelf);
            _oneTwo[1].SetActive(!_oneTwo[1].activeSelf);
        }
    }
}