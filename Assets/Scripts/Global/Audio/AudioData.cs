using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Global.Audio
{
    [CreateAssetMenu]
    [System.Serializable]
    public class AudioData : ScriptableObject
    {
        [System.Serializable]
        public struct BackgroundMusic
        {
            public string SoundName;
            public AudioClip CLip;
            public bool IsLOop;
        }
        public struct Sounds
        {
            public string SoundName;
            public AudioClip clip;
            public bool isLopp;
            [Range(0f, 1f)] public float _volume;
        }

        public List<BackgroundMusic> Bgm;
        public List<Sounds> SoundFX;
    }
}
    