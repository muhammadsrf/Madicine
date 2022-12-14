using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Madicine.Scene.Gameplay.Weapons;
using Madicine.Global.Upgrade;

namespace Madicine.Scene.Gameplay.Player
{
    [DefaultExecutionOrder(-11)]
    public class PlayerController : MonoBehaviour
    {
        //data player
        [Header("Base Data:")]
        [SerializeField] private PlayerDataSO _dataplayerSO;
        [SerializeField] private UpgradeReferenceData _upgradeRefData;

        [Header("Data Player:")]
        [SerializeField] private Transform _transformModel;
        private PlayerModel _model;
        private int _maxHealth;
        private bool _isgrounded;
        private BaseWeapon _weapons;

        //input
        private UserInput _userInput;
        private Vector3 _input;

        //control move 
        [Header("Control Move:")]
        [SerializeField] private float _speed = 5f;
        [SerializeField] private GameObject _nozelWeapon;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private WeaponContoller _weaponController;
        [SerializeField] private float _dashDistance = 3f;
        [SerializeField] private float _dashSpeed = 6;
        private Camera _mainCamera;
        private Vector3 _currentMovement;
        private CharacterController _controller;
        private float _dashStoppingSpeed = 0.1f;
        private const float _maxDistance = 1.0f;
        private float _currentDashTime = _maxDistance;

        //animasi 
        Animator animator;

        //shoot
        [Header("Shoot:")]
        [SerializeField] private float _fireRate;
        private bool _allowfire = true;
        private bool _inFire;
        private bool _aimOn = true;

        private void OnEnable()
        {
            PlayerEvents.onExpChange += UpdateExperience;
            PlayerEvents.onPlayerDeath += OnDie;
        }

        private void OnDisable()
        {
            PlayerEvents.onExpChange -= UpdateExperience;
            PlayerEvents.onPlayerDeath -= OnDie;
        }

        private void OnDie(int health)
        {
            _aimOn = false;
            animator.SetBool("death", true);
        }

        private void UpdateExperience()
        {
            _model.experience = _upgradeRefData.totalExp;
        }

        private void Awake()
        {
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
            _model.armoreLevel = _dataplayerSO.armoreLevel;
            _model.skin = _dataplayerSO.skin;
            _model.weaponLevel = _dataplayerSO.weaponLevel;
            _maxHealth = _model.health;
            _weaponController.TemporaryDamageAtk = _upgradeRefData.atkReference[0];
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _userInput.PlayerMove.Attact.performed += (ctx) => _inFire = true;
            _userInput.PlayerMove.Attact.canceled += (ctx) => _inFire = false;
            StartCoroutine(Shoot());

            _userInput.PlayerMove.Dash.performed += (ctx) => _currentDashTime = 0;
            _userInput.PlayerMove.Enable();
            _userInput.PlayerMove.Move.performed += (ctx) => _input = ctx.ReadValue<Vector3>();
            _isgrounded = _controller.isGrounded;
            FaceTo(_input);
            MoveTo(_input);
            Aim();
            SwapWeapon();
        }

        private void MoveTo(Vector3 vector)
        {
            if (_currentDashTime < _maxDistance)
            {
                _currentMovement = new Vector3(vector.x, _isgrounded ? 0.0f : -1.0f, vector.z) * Time.deltaTime * _dashSpeed * _dashDistance;
                _currentDashTime += _dashStoppingSpeed;
            }
            else
            {
                _currentMovement = new Vector3(vector.x, _isgrounded ? 0.0f : -1.0f, vector.z) * Time.deltaTime * _speed;
            }
            _controller.Move(_currentMovement);

            if (_currentMovement.x != 0 || _currentMovement.z != 0)
            {
                animator.SetBool("walk", true);
            }
            else if (_currentMovement.x == 0 && _currentMovement.z == 0)
            {
                animator.SetBool("walk", false);
            }
        }


        private void FaceTo(Vector3 vector)
        {
            if (vector != Vector3.zero)
            {
                var relative = (_transformModel.position + vector) - _transformModel.position;
                var rot = Quaternion.LookRotation(relative, Vector3.up);
                _transformModel.rotation = rot;
            }
        }

        private void Aim()
        {
            if (_aimOn)
            {
                var (success, position) = GetMousePosition();
                if (success)
                {
                    var direction = position - transform.position;
                    direction.y = 0;

                    transform.forward = direction;
                }
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

        IEnumerator Shoot()
        {
            if (_allowfire && _inFire)
            {
                _allowfire = false;
                _weaponController.Shoot(_nozelWeapon.transform);
                yield return new WaitForSeconds(_fireRate);
                _allowfire = true;
            }
        }

        public int SubtractHealth(int damage)
        {
            _model.health = Mathf.Max(0, _model.health - damage);

            // call event trigger enemy get attack / enemy hurt
            PlayerEvents.PlayerGetAttack(_model.health);

            if (_model.health == 0)
            {
                // harus ada delay sebelum code dibawah di 
                // call event trigger enemy death
                PlayerEvents.PlayerDeath(_model.health);
            }
            return _model.health;
        }

        public int ResetHealth()
        {
            _model.health = _dataplayerSO.health;

            PlayerEvents.PlayerGetAttack(_model.health);

            return _model.health;
        }

        public int GetcurrentHealth()
        {
            return _model.health;
        }

        public void SwapWeapon()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _nozelWeapon.GetComponent<WeaponContoller>().SelectWeapon();
                PlayerEvents.SwapWeapon();
            }
        }

        /// <summary>
        /// for upgrade hp level player
        /// </summary>
        public void UpgradeHealthLevel()
        {
            _model.level += 1;
            _model.health = _upgradeRefData.GetHpReference(_model.level); 
            _dataplayerSO.health = _model.health;
            PlayerEvents.UpgradeChange(_model.health);
        }

        /// <summary>
        /// for upgrade atk/weapon level player
        /// </summary>
        public void UpgradeAttackLevel()
        {
            _model.weaponLevel += 1;
            _weaponController.TemporaryDamageAtk = _upgradeRefData.GetAtkReference(_model.weaponLevel);
            _model.health = _upgradeRefData.GetHpReference(_model.level);
            _dataplayerSO.health = _model.health;
            PlayerEvents.UpgradeChange(_model.health);
        }

    }
}