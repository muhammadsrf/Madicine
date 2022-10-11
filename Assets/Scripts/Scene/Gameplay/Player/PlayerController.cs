using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Madicine.Scene.Gampalay.Weapons;

namespace Madicine.Scene.Gampalay.Players
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private Transform _transformModel;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private GameObject _nozelWeapon;
        [SerializeField] private PlayerDataSO _dataplayerSO;

        private Camera _mainCamera;
        private PlayerModel _model;
        private int _maxHealth;
        private UserInput _userInput;
        private Vector3 _input;
        private Vector3 _currentMovement;
        private bool _isgrounded;
        private CharacterController _controller;
        private BaseWeapon _weapons;

        [SerializeField] private WeaponContoller _weaponController;

        private void Start()
        {
            _mainCamera = Camera.main;
            _userInput = new UserInput();
            _controller = GetComponent<CharacterController>();
            _model = GetComponent<PlayerModel>();
            _model.nameCharcter = _dataplayerSO.nameCharcter;
            _model.health = _dataplayerSO.health;
            _model.level = _dataplayerSO.level;
            _model.skin = _dataplayerSO.skin;
            _maxHealth = _model.health;
        }
        
        private void Update()
        {
            _userInput.PlayerMove.Attact.performed += (ctx) => Shoot();
            _userInput.PlayerMove.Enable();
            _userInput.PlayerMove.Move.performed += (ctx) => _input = ctx.ReadValue<Vector3>();
            _isgrounded = _controller.isGrounded;
            FaceTo(_input); 
            MoveTo(_input);
            Aim();
        }

        private void MoveTo(Vector3 vector)
        {
            _currentMovement = new Vector3 (vector.x, _isgrounded ? 0.0f : -1.0f, vector.z) * Time.deltaTime * _speed;
            _controller.Move(_currentMovement);
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
            _weaponController.Shoot(_nozelWeapon.transform);
        }

        public void SubtractHealth(int demage){
            _model.health -= demage;
            if(_model.health > 1 ){
                Debug.Log("gameover");
            }
        }

        public int GetcurrentHealth(){
            return _model.health;
        }
    }
}