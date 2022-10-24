using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Madicine.Scene.Credit
{
    public class CreditScene : MonoBehaviour
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