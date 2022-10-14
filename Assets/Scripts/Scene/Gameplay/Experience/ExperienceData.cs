using Madicine.Scene.Gameplay.Player;
using UnityEngine;

namespace Madicine.Scene.Gameplay.Experience
{
    [CreateAssetMenu(fileName = "ExperienceData", menuName = "Madicine/ExperienceData", order = 0)]
    public class ExperienceData : ScriptableObject
    {
        public int experience;
        public int[] expReference = { 20, 40, 80, 140, 220, 320, 440, 580, 740, 920 };
        private int _experienceLevel = 0;

        public void ResetExperience()
        {
            experience = 0;
            _experienceLevel = 0;
        }

        public void AddExperience(int addExp)
        {
            experience += addExp;

            PlayerEvents.ExperienceChange();
        }

        public int GetExperienceReference()
        {
            return expReference[_experienceLevel];
        }

        public float GetFillExp()
        {
            return (float)experience / GetExperienceReference();
        }
    }
}