using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

namespace Madicine.Global.Audio
{
    [CreateAssetMenu]
    [System.Serializable]
    public class AudioData : ScriptableObject
    {
        [System.Serializable]
        public struct Bgm
        {
            public string BgmName;
            public AudioClip Clip;
        }
        [System.Serializable]
        public struct Sound
        {
            public string SoundName;
            public AudioClip Clip;
            [Range(0f, 1f)] public float Volume;
            public bool isLoop;
        }

        public List<Bgm> BgmList;
        public List<Sound> SoundList;
    }
}