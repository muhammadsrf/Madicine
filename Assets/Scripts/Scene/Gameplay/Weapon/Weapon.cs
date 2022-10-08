using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Scene.Gampalay.Weapons
{
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
    public class Weapon : ScriptableObject {
        public string nameType;
        public int level;
        public int demage;
    }
}