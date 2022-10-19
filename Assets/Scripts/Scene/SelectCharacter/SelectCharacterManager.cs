using Madicine.Global.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Madicine.Scene.CharacterSelector
{
    public class SelectCharacterManager : MonoBehaviour
    {
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private SelectCharacterController _selectCharacterController;

        private void Start()
        {
            SpawnCharacterSelector();
        }
        private void SpawnCharacterSelector()
        {
            for(int i = 0; i < _characterData.Characters.Count; i++)
            {
                var obj = Instantiate(_selectCharacterController, parent: gameObject.transform);
                obj.SetCharacterName(_characterData.Characters[i].Character_Name);
            }
        }
    }
}