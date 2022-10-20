using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Madicine.Scene.CharacterSelector
{
    public class SelectCharacterScene : MonoBehaviour
    {
        [SerializeField] private Button _backBtn;

        private void Start()
        {
            _backBtn.onClick.AddListener(Back);
        }

        private void Back()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}