using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Madicine.Global.Audio.AudioData;

namespace Madicine.Global.Audio
{
    [CreateAssetMenu]
    [System.Serializable]
    public class AudioSetting : ScriptableObject
    {
        public bool IsBgmMuted;
        public bool IsSoundsMuted;
        [Range(0f, 1f)] public float Volume;
    }
}