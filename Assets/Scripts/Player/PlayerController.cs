using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

namespace Madicine.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Transform _transformModel;
        [SerializeField] private LayerMask _groundMask;

        private Camera _mainCamera;

        private UserInput _userInput;
        private Vector3 _input;
        private CharacterController controller;

        private void Start()
        {
            _userInput = new UserInput();
            controller = GetComponent<CharacterController>();
            _mainCamera = Camera.main;
        }
        
        private void Update()
        {
            _userInput.PlayerMove.Attact.performed += (ctx) => Shoot();
            _userInput.PlayerMove.Enable();
            _userInput.PlayerMove.Move.performed += (ctx) => _input = ctx.ReadValue<Vector3>();
            FaceTo(_input); 
            MoveTo(_input);
            Aim();

        }

        private void MoveTo(Vector3 vector)
        {
            controller.Move( vector * _speed * Time.deltaTime);
        }

        private void FaceTo( Vector3 vector)
        {
            if (vector != Vector3.zero){
                var relative = (_transformModel.position + vector) - _transformModel.position;
                var rot = Quaternion.LookRotation(relative, Vector3.up);
               _transformModel.rotation = rot;
            }
        }

        private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                var direction = position - transform.position;
                direction.y = 0;

                transform.forward = direction;
            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            Vector3 mousePos = Mouse.current.position.ReadValue(); 
            var ray = _mainCamera.ScreenPointToRay(mousePos);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
            {
                return (success: true, position: hitInfo.point);
            }
            else
            {
                return (success: false, position: Vector3.zero);
            }
        }

        private void Shoot(){
            Debug.Log("sprayyy wryyyyyy.....");
        }
    }
}