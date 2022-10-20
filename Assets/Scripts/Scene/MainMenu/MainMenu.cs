using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Madicine.Scene.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public static UnityAction OnMainMenu;
        [SerializeField] private GameObject _settingPopup;
        [SerializeField] private GameObject _creditPopup;
        [SerializeField] private GameObject _confirExitPopup;
        [SerializeField] private Button _playButton;
        [SerializeField] private Button _creditButton;
        [SerializeField] private Button _optionButton;
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _confirExitButton;

        private void Start()
        {
            OnMainMenu?.Invoke();
            _playButton.onClick.AddListener(Play);
            _optionButton.onClick.AddListener(SettingPopup);
            _creditButton.onClick.AddListener(CreditPopup);
            _exitButton.onClick.AddListener(ConfirExitPopup);
            _confirExitButton.onClick.AddListener(Exit);
        }

        private void Play()
        {
            SceneManager.LoadScene("SelectCharacter");
        }

        private void SettingPopup()
        {
            _settingPopup.SetActive(true);
        }

        private void CreditPopup()
        {
            _creditPopup.SetActive(true);
        }

        private void ConfirExitPopup()
        {
            _confirExitPopup.SetActive(true);
        }

        private void Exit()
        {
            Debug.Log("Exit");
            Application.Quit();
        }
    }
}