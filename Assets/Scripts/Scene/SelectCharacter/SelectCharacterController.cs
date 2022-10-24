using Madicine.Global.Character;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Madicine.Scene.CharacterSelector
{
    public class SelectCharacterController : MonoBehaviour
    {
        [SerializeField] TMP_Text _characterName;
        [SerializeField] CurrentCharacterSelected _currentCharacter;
        private int _character_id;
        Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(SetCurrentCharacter);
        }

        private void SetCurrentCharacter()
        {
            _currentCharacter.character_id = _character_id;
            SceneManager.LoadScene("Gameplay");
        }

        public void SetCharacterName(string name, int index)
        {
            _character_id = index;
            _characterName.text = name;
        }
    }
}