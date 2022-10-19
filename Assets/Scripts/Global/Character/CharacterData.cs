using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Global.Character
{
    [CreateAssetMenu]
    [System.Serializable]
    public class CharacterData : ScriptableObject
    {
        [System.Serializable]
        public struct Character
        {
            public int Character_Id;
            public string Character_Name;
        }

        public List<Character> Characters;
    }
}