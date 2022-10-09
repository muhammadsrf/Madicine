using UnityEngine;

namespace Madicine.Scene.Gameplay.Enemy
{
    using UnityEngine;

    [CreateAssetMenu(fileName = "EnemyProjectile", menuName = "Madicine/EnemyProjectileData", order = 0)]
    public class ProjectileData : ScriptableObject
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private float _timeVisible = 3f;

        public float GetSpeed()
        {
            return _speed;
        }

        public float GetTimeVisible()
        {
            return _timeVisible;
        }
    }
}