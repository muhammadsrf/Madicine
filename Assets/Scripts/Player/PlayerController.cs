using UnityEngine;
using UnityEngine.UI;

namespace Madicine.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 5f;
        [SerializeField]
        private Transform transformModel;

        private UserInput _userInput;
        private Vector3 _input;
        private CharacterController controller;

        private void Start()
        {
            _userInput = new UserInput();
            controller = GetComponent<CharacterController>();
        }
        
        private void Update()
        {
            _userInput.PlayerMove.Enable();
            _userInput.PlayerMove.Move.performed += (ctx) => _input = ctx.ReadValue<Vector3>();
            Debug.Log($"input vectore : {_input}");
            FaceTo(_input); 
            MoveTo(_input);
        }

        private void MoveTo(Vector3 vector)
        {
            controller.Move( vector * _speed * Time.deltaTime);
        }

        private void FaceTo( Vector3 vector)
        {
            if (vector != Vector3.zero){
                var relative = (transformModel.position + vector) - transformModel.position;
                var rot = Quaternion.LookRotation(relative, Vector3.up);
                Debug.Log($"Face to vector : {rot}");
                transformModel.rotation = rot;
            }
        }
    }
}