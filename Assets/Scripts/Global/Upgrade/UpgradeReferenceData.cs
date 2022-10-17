using Madicine.Scene.Gameplay.Player;
using UnityEngine;

namespace Madicine.Global.Upgrade
{
    [CreateAssetMenu(fileName = "UpgradeReferenceData", menuName = "Madicine/UpgradeReferenceData", order = 0)]
    public class UpgradeReferenceData : ScriptableObject
    {
        public int totalExp;
        public int[] expReference = { 20, 40, 80, 140, 220, 320, 440, 580, 740, 920 };
        public int[] hpReference = { 120, 200, 320, 480, 680, 920, 1200, 1520, 1880, 2280 };
        public int[] atkReference = { 2, 3, 4, 5, 7, 9, 11, 15, 20, 26, 33, 41, 50, 60 };
        private int _experienceLevel = 0;
        private int _expTemp = 0;

        [SerializeField] private bool _debugLog = false;

        public void ResetExperience()
        {
            totalExp = 0;
            _expTemp = 0;
            _experienceLevel = 0;
        }

        public void AddExperience(int addExp)
        {
            totalExp += addExp;
            _expTemp += addExp;
            
            PlayerEvents.ExperienceChange();
        }

        public int GetExperienceReference()
        {
            // exp level over the reference length
            if (_experienceLevel > expReference.Length)
            {
                string information = $"Exp Reference sudah mentok di {expReference[expReference.Length]}.";
                MyDebug(information);

                return expReference[expReference.Length];
            }

            return expReference[_experienceLevel];
        }

        public int GetHpReference(int hpLevel)
        {
            // hp level over the reference length
            if (hpLevel > hpReference.Length)
            {
                string information = $"Hp Reference sudah mentok di {hpReference[hpReference.Length - 1]}.";
                MyDebug(information);

                return hpReference[hpReference.Length - 1];
            }

            return hpReference[hpLevel - 1];
        }

        public int GetAtkReference(int atkLevel)
        {
            // atk level over the reference length
            if (atkLevel > atkReference.Length)
            {
                string information = $"Atk Reference sudah mentok di {atkReference[atkReference.Length - 1]}.";
                MyDebug(information);

                return hpReference[hpReference.Length - 1];
            }

            return atkReference[atkLevel - 1];
        }

        public float GetFillExp()
        {
            float fillAmount = (float)_expTemp / GetExperienceReference();
            return fillAmount;
        }

        public void ExpSetNextPoint()
        {
            _experienceLevel += 1;
            _expTemp = 0;
        }

        private void MyDebug(string information)
        {
            if (_debugLog)
            {
                Debug.Log(information);
            }
        }
    }
}