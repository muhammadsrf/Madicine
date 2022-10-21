using UnityEngine;
using ToolBox.Pools;

namespace Madicine.Scene.Gameplay.Enemy
{
    public class SpawnEnemyManager : MonoBehaviour
    {
        static public SpawnEnemyManager instance;

        private void Awake()
        {
            instance = this;
        }

        
        
    }
}