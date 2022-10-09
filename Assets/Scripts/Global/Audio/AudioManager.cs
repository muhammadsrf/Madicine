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
        private bool _isBgmMute;
        private bool _isSoundMute;

        public static AudioManager Instance;
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void SetCurrentBgmClip(string clip)
        {
            for(int i = 0; i < _audioData.Bgm.Count; i ++)
            {
                var soundName = _audioData.Bgm[i].SoundName;
                if(soundName == clip)
                {
                    var currentClip = _audioData.Bgm[i].CLip;
                    _bgmSource.clip = currentClip;
                    if(!_isBgmMute)
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
            for(int i = 0; i < _audioData.SoundFX.Count; i ++)
            {
                var soundName = _audioData.SoundFX[i].SoundName;
                if(soundName == clip)
                {
                    _soundFXSource.clip = _audioData.SoundFX[i].clip;
                    if(!_isSoundMute)
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

        }

        private void OnGameplay()
        {

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