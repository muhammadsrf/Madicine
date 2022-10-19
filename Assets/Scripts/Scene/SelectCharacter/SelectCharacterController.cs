using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Madicine.Scene.CharacterSelector
{
    public class SelectCharacterController : MonoBehaviour
    {
        [SerializeField] TMP_Text _characterName;
        Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
        }

        public void SetCharacterName(string name)
        {
            _characterName.text = name;
        }
    }
}