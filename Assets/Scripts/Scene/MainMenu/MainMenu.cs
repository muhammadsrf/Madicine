using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Madicine.Scene.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public static UnityAction OnMainMenu;
        [SerializeField] private GameObject _settingPopup;
        [SerializeField] private GameObject _creditPopup;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _creditButton;
        [SerializeField] private Button _optionButton;
        [SerializeField] private Button _exitButton;

        private void Start()
        {
            OnMainMenu?.Invoke();
            _optionButton.onClick.AddListener(SettingPopup);
        }

        private void SettingPopup()
        {
            _settingPopup.SetActive(true);
        }

        private void CreditPopup()
        {

        }

        private void ExitPopup()
        {

        }
    }
}