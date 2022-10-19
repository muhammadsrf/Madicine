using Madicine.Scene.MainMenu;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Global.Audio
{
    public class AudioManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private AudioSource _soundFXSource;
        [SerializeField] private AudioData _audioData;
        [SerializeField] private AudioSetting _audioSetting;
        private bool _isBgmMute;
        private bool _isSoundMute;

        public static AudioManager Instance;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            Init();
        }

        private void FixedUpdate()
        {
            _bgmSource.volume = _audioSetting.Volume;
        }

        private void OnEnable()
        {
            MainMenu.OnMainMenu += OnMainMenu;
        }

        private void OnDisable()
        {
            MainMenu.OnMainMenu -= OnMainMenu;
        }

        private void Init()
        {
            _isBgmMute = _audioSetting.IsBgmMuted;
            _isSoundMute = _audioSetting.IsSoundsMuted;
        }

        private void SetCurrentBgmClip(string clip)
        {
            for (int i = 0; i < _audioData.BgmList.Count; i++)
            {
                var soundName = _audioData.BgmList[i].BgmName;
                if (soundName == clip)
                {
                    var currentClip = _audioData.BgmList[i].Clip;
                    _bgmSource.clip = currentClip;
                    if (!_isBgmMute)
                    {
                        _bgmSource.Play();
                    }
                    else
                    {
                        _bgmSource.Stop();
                    }
                    break;
                }
            }
        }

        private void SetCurrentSoundFXClip(string clip)
        {
            for (int i = 0; i < _audioData.SoundList.Count; i++)
            {
                var soundName = _audioData.SoundList[i].SoundName;
                if (soundName == clip)
                {
                    _soundFXSource.clip = _audioData.SoundList[i].Clip;
                    _soundFXSource.volume = _audioData.SoundList[i].Volume * _audioSetting.Volume;
                    if (!_isSoundMute)
                    {
                        _soundFXSource.Play();
                    }
                    else
                    {
                        _soundFXSource.Stop();
                    }
                }
            }
        }

        private void OnMainMenu()
        {
            Debug.Log("Play BGM MainMenu");
            //SetCurrentBgmClip("MainMenu");
        }

        private void OnGameplay()
        {
            SetCurrentBgmClip("OnGameplay");
        }

        private void OnPlayerMove()
        {

        }

        private void OnPlayerAttack()
        {

        }

        public void OnClickButton()
        {

        }


    }
}
