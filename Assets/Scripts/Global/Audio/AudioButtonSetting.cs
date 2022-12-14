using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Madicine.Global.Audio
{
    public class AudioButtonSetting : MonoBehaviour
    {
        public static UnityAction<bool> OnToggleBgmClick;
        public static UnityAction<bool> OnToggleSoundCLick;

        [SerializeField] private Button _bgmButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private GameObject _bgmControl;
        [SerializeField] private GameObject _soundControl;
        [SerializeField] private Vector3 _onPos;
        [SerializeField] private Vector3 _offPos;
        [SerializeField] private Slider _volumeControl;
        [SerializeField] private AudioData _audioData;
        [SerializeField] private AudioSetting _audioSetting;
        private bool _isBgmMute;
        private bool _isSoundMute;

        private void Start()
        {
            Init();
            _bgmButton.onClick.AddListener(ToggleBgm);
            _soundButton.onClick.AddListener(ToggleSound);
        }

        private void FixedUpdate()
        {
            _audioSetting.Volume = _volumeControl.value;
        }

        private void Init()
        {
            _isBgmMute = _audioSetting.IsBgmMuted;
            _isSoundMute = _audioSetting.IsSoundsMuted;

            if(_isBgmMute)
            {
                _bgmControl.GetComponent<RectTransform>().anchoredPosition = _offPos;
            }
            else
            {
                _bgmControl.GetComponent<RectTransform>().anchoredPosition = _onPos;
            }

            if( _isSoundMute)
            {
                _soundControl.GetComponent<RectTransform>().anchoredPosition = _offPos;
            }
            else
            {
                _soundControl.GetComponent<RectTransform>().anchoredPosition = _onPos;
            }

            _volumeControl.value = _audioSetting.Volume;
        }

        private void SaveVolumeValue()
        {
            _audioSetting.Volume = _volumeControl.value;
        }

        private void ToggleBgm()
        {
            _isBgmMute = !_isBgmMute;
            _audioSetting.IsBgmMuted = _isBgmMute;
            OnToggleBgmClick?.Invoke(_isBgmMute);
            if (_isBgmMute)
            {
                _bgmControl.GetComponent<RectTransform>().anchoredPosition = _offPos;
            }
            else
            {
                _bgmControl.GetComponent<RectTransform>().anchoredPosition = _onPos;
                _bgmControl.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            }

        }

        private void ToggleSound()
        {
            _isSoundMute = !_isSoundMute;
            _audioSetting.IsSoundsMuted = _isSoundMute;
            OnToggleSoundCLick?.Invoke(_isSoundMute);

            if (_isSoundMute)
            {
                _soundControl.GetComponent<RectTransform>().anchoredPosition = _offPos;
            }
            else
            {
                _soundControl.GetComponent<RectTransform>().anchoredPosition = _onPos;
                _soundControl.GetComponent<Transform>().localScale = new Vector3(-1, 1, 1);
            }
        }

    }
}