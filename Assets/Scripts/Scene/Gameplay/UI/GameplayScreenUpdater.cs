using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Madicine.Scene.Gameplay.Player;
using Madicine.Global.Upgrade;

namespace Madicine.Scene.Gameplay.UI
{
    [DefaultExecutionOrder(-10)]
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
        [SerializeField] private UpgradeReferenceData _upgradeReferenceData;

        private PlayerModel _playerModel;


        private void OnEnable()
        {
            PlayerEvents.onPlayerHurt += PlayerHurt;
            PlayerEvents.onWeaponChange += SwapWeaponIndicator;
            PlayerEvents.onExpChange += ExpUpdate;
            PlayerEvents.onUpgradeChange += UpdateLevelNumber;
        }

        private void ExpUpdate()
        {
            _expText.text = $"EXP POINT: {_upgradeReferenceData.totalExp}";
            _fillExp.fillAmount = _upgradeReferenceData.GetFillExp();
            if (_fillExp.fillAmount == 1.0f)
            {
                GetComponent<GameplayNavigator>().SetActiveUpgradeScreen(true);
            }
        }

        private void OnDisable()
        {
            PlayerEvents.onPlayerHurt -= PlayerHurt;
            PlayerEvents.onWeaponChange -= SwapWeaponIndicator;
            PlayerEvents.onExpChange -= ExpUpdate;
            PlayerEvents.onUpgradeChange -= UpdateLevelNumber;
        }

        private void Start()
        {
            _upgradeReferenceData.ResetExperience();
            _playerModel = FindObjectOfType<PlayerModel>();
            ExpUpdate();
            PlayerHurt(_playerModel.health);
        }

        private void PlayerHurt(int health)
        {
            _fillHP.fillAmount = (float)health / _playerData.health;
            _hpText.text = $"HP: {health}/{_playerData.health}";
            _healthLevelNumber.text = _playerModel.level.ToString();
            _weaponLevelNumber.text = _playerModel.weaponLevel.ToString();
        }

        private void UpdateLevelNumber(int health)
        {
            _upgradeReferenceData.ExpSetNextPoint();
            _fillHP.fillAmount = (float)health / _playerData.health;
            _hpText.text = $"HP: {health}/{_playerData.health}";
            _healthLevelNumber.text = _playerModel.level.ToString();
            _weaponLevelNumber.text = _playerModel.weaponLevel.ToString();
            ExpUpdate();
        }

        private void SwapWeaponIndicator()
        {
            _oneTwo[0].SetActive(!_oneTwo[0].activeSelf);
            _oneTwo[1].SetActive(!_oneTwo[1].activeSelf);
        }
    }
}