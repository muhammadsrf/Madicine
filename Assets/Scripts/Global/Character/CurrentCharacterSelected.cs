using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Global.Character
{
    [CreateAssetMenu]
    [System.Serializable]
    public class CurrentCharacterSelected : ScriptableObject
    {
        public int character_id;
    }
}