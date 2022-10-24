using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    [System.Serializable]
    public class NewWaveClass
    {
        public int wave;
        public List<GameObject> enemyNormal = new List<GameObject>();
        public float timeDelay;
        public List<GameObject> boss = new List<GameObject>();
        public float timeDelayBoss;
        public GameObject minion;
        public float timeDelayMinion;
    }
}
