using UnityEngine;
using TMPro;

namespace Madicine.Scene.Gameplay.UI
{
    public class WaveUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textMesh;
        [SerializeField] private Animator _animator;

        public void ShowAnimator(int waveNumber)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("WaveShow"))
            {
                _animator.Play("WaveShow2", 0);
            }
            else
            {
                _animator.Play("WaveShow", 0);
            }

            _textMesh.text = "Wave " + waveNumber.ToString();
        }
    }
}