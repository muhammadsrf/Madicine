using UnityEngine;
using TMPro;
using Madicine.Scene.Gameplay.Enemy;

namespace Madicine.Scene.Gameplay.UI
{
    public class CountEnemyCured : MonoBehaviour
    {
        public int saving;
        [SerializeField] private TextMeshProUGUI _savingText;

        private void OnEnable()
        {
            EnemyEvents.onEnemyCured += AddSaving;
        }

        private void OnDisable()
        {
            EnemyEvents.onEnemyCured -= AddSaving;
        }

        private void AddSaving()
        {
            saving++;
        }

        private void Update()
        {
            // update text saving
            _savingText.text = saving.ToString();
        }
    }
}