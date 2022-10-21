using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    [CreateAssetMenu(fileName = "WaveReferenceData", menuName = "Madicine/WaveReferenceData", order = 0)]
    public class WaveReferenceData : ScriptableObject
    {
        public List<DelayWave> waveAndDelay = new List<DelayWave>();
    }
}