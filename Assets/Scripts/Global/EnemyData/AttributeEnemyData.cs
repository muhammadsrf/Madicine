using UnityEngine;

namespace Madicine.Global.EnemyData
{
    [CreateAssetMenu(fileName = "AttributeEnemyData", menuName = "Madicine/AttributeEnemyData", order = 0)]
    public class AttributeEnemyData : ScriptableObject
    {
        public EnemyClass typeEnemy;
        [Range(1, 1000)]
        [SerializeField] private int _healthMax = 100;
        [Range(1, 100)]
        public int _damage = 1;

        public int GetHealthMax()
        {
            return _healthMax;
        }
    }
}