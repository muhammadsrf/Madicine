using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Madicine.Scene.Gameplay
{
    public class GameplayScene : MonoBehaviour
    {
        public static UnityAction OnGameplay;

        private void Start()
        {
            OnGameplay();
        }
    }
}