using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Madicine.UI
{
    public class Popup : MonoBehaviour
    {
        [SerializeField] private GameObject _popup;
        [SerializeField] private Button _closeButton;

        private void Start()
        {
            _closeButton.onClick.AddListener(ClosePopup);
        }

        private void ClosePopup()
        {
            _popup.SetActive(false);
        }
    }
}