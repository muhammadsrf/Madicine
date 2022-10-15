using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Madicine.Global.Audio
{
    public class AudioButtonSetting : MonoBehaviour
    {
        public static UnityEvent OnToggleBgmClick;
        public static UnityEvent OnToggleSoundCLick;

        [SerializeField] private Button _bgmButton;
        [SerializeField] private Button _soundButton;
        [SerializeField] private GameObject _bgmControl;
        [SerializeField] private GameObject _soundControl;
        [SerializeField] private Vector3 _onPos;
        [SerializeField] private Vector3 _offPos;
        [SerializeField] private Slider _volumeControl;
        [SerializeField] private AudioData _audioData;
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
            _audioData.Volume = _volumeControl.value;
        }

        private void Init()
        {
            _isBgmMute = _audioData.IsBgmMuted;
            _isSoundMute = _audioData.IsSoundsMuted;

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

            _volumeControl.value = _audioData.Volume;
        }

        private void SaveVolumeValue()
        {
            _audioData.Volume = _volumeControl.value;
        }

        private void ToggleBgm()
        {
            _isBgmMute = !_isBgmMute;
            _audioData.IsBgmMuted = _isBgmMute;
            OnToggleBgmClick?.Invoke();
            if (_isBgmMute)
            {
                _bgmControl.GetComponent<RectTransform>().anchoredPosition = _offPos;
            }
            else
            {
                _bgmControl.GetComponent<RectTransform>().anchoredPosition = _onPos;
            }

        }

        private void ToggleSound()
        {
            _isSoundMute = !_isSoundMute;
            _audioData.IsSoundsMuted = _isSoundMute;
            OnToggleSoundCLick?.Invoke();

            if (_isSoundMute)
            {
                _soundControl.GetComponent<RectTransform>().anchoredPosition = _offPos;
            }
            else
            {
                _soundControl.GetComponent<RectTransform>().anchoredPosition = _onPos;
            }
        }

    }
}