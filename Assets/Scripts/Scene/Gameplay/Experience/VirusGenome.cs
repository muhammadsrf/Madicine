using Madicine.Scene.Gameplay.Player;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Experience
{
    public class VirusGenome : MonoBehaviour
    {
        public int addExp = 5;
        public ExperienceData experienceData;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            {
                experienceData.AddExperience(addExp);
                Destroy(gameObject);
            }
        }
    }
}