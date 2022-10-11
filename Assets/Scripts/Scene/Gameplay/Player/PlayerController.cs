using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Madicine.Scene.Gampalay.Weapons;

namespace Madicine.Scene.Gampalay.Players
{
    public class PlayerController : MonoBehaviour
    {


        //data player
        [SerializeField] private Transform _transformModel;
        [SerializeField] private PlayerDataSO _dataplayerSO;
        private PlayerModel _model;
        private int _maxHealth;
        private bool _isgrounded;
        private BaseWeapon _weapons;

        //input
        private UserInput _userInput;
        private Vector3 _input;

        //control move 
        [SerializeField] private float _speed = 5f;
        [SerializeField] private GameObject _nozelWeapon;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private WeaponContoller _weaponController;
        [SerializeField] private float _dashDistance = 3f;
        [SerializeField] private float _dashSpeed = 6 ;
        private Camera _mainCamera;
        private Vector3 _currentMovement;
        private CharacterController _controller;
        private float _dashStoppingSpeed = 0.1f;
        private const float _maxDistance = 1.0f;
        private float _currentDashTime = _maxDistance;

        private void Awake() {
            _mainCamera = Camera.main;
            _userInput = new UserInput();
            _controller = GetComponent<CharacterController>();
        }

        private void Start()
        {
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
            _userInput.PlayerMove.Dash.performed += (ctx) => _currentDashTime = 0;
            _userInput.PlayerMove.Enable();
            _userInput.PlayerMove.Move.performed += (ctx) => _input = ctx.ReadValue<Vector3>();
            _isgrounded = _controller.isGrounded;
            FaceTo(_input); 
            MoveTo(_input);
            Aim();
        }

        private void MoveTo(Vector3 vector)
        {
            if(_currentDashTime < _maxDistance) {
                _currentMovement = new Vector3 (vector.x, _isgrounded ? 0.0f : -1.0f, vector.z) * Time.deltaTime * _dashSpeed * _dashDistance;
                _currentDashTime += _dashStoppingSpeed;
            }else
            {
                _currentMovement = new Vector3 (vector.x, _isgrounded ? 0.0f : -1.0f, vector.z) * Time.deltaTime * _speed;
            }
            _controller.Move(_currentMovement);
        }

        public void DashMOve(){
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