using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Madicine.Scene.Gameplay.Player;
using Madicine.Scene.Gameplay.Experience;

namespace Madicine.Scene.Gameplay.UI
{
    public class GameplayScreenUpdater : MonoBehaviour
    {
        [SerializeField] private Image _fillHP;
        [SerializeField] private Image _fillExp;
        [SerializeField] private TextMeshProUGUI _hpText;
        [SerializeField] private TextMeshProUGUI _expText;
        [SerializeField] private TextMeshProUGUI _healthLevelNumber;
        [SerializeField] private TextMeshProUGUI _weaponLevelNumber;
        [SerializeField] private PlayerDataSO _playerData;
        [SerializeField] private GameObject[] _oneTwo;
        [SerializeField] private ExperienceData _experienceData;

        private void OnEnable()
        {
            PlayerEvents.onPlayerHurt += PlayerHurt;
            PlayerEvents.onWeaponChange += SwapWeaponIndicator;
            PlayerEvents.onExpChange += ExpUpdate;
        }

        private void ExpUpdate()
        {
            _expText.text = $"EXP POINT: {_experienceData.experience}";
            _fillExp.fillAmount = _experienceData.GetFillExp();
            if (_fillExp.fillAmount == 1.0f)
            {
                GetComponent<GameplayNavigator>().SetActiveUpgradeScreen(true);

                // pause
                Time.timeScale = 0;
            }
        }

        private void OnDisable()
        {
            PlayerEvents.onPlayerHurt -= PlayerHurt;
            PlayerEvents.onWeaponChange -= SwapWeaponIndicator;
            PlayerEvents.onExpChange -= ExpUpdate;
        }

        private void Awake()
        {
            _experienceData.ResetExperience();
            ExpUpdate();
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