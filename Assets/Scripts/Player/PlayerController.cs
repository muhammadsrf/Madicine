using UnityEngine;
using UnityEngine.UI;

namespace Madicine.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5f;
        [SerializeField]
        private Transform model;

        private Rigidbody myRigidbody;

        private UserInput _userInput = new UserInput();

        private void Start()
        {
            myRigidbody = GetComponent<Rigidbody>();
            _userInput.PlayerMove.Enable();
        }

        private void Update()
        {
            _userInput.PlayerMove.Move.performed += (ctx) => MoveTo(ctx.ReadValue<Vector3>());
            /*   
            if (Input.GetKey(KeyCode.W))
            {
                MoveTo(Vector3.forward);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                MoveTo(Vector3.zero);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                MoveTo(Vector3.back);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                MoveTo(Vector3.zero);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                MoveTo(Vector3.left);
            }
            else if (Input.GetKeyUp(KeyCode.A))
            {
                MoveTo(Vector3.zero);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                MoveTo(Vector3.right);
            }
            else if (Input.GetKeyUp(KeyCode.D))
            {
                MoveTo(Vector3.zero);
            }
            */
        }

        private void MoveTo(Vector3 vector)
        {
            if (vector == Vector3.forward) { FaceTo(0); }
            if (vector == Vector3.right) { FaceTo(90); }
            if (vector == Vector3.back) { FaceTo(180); }
            if (vector == Vector3.left) { FaceTo(270); }
            myRigidbody.velocity = vector * speed;
        }

        private void FaceTo(float degree)
        {
            model.rotation = Quaternion.Euler(0, degree, 0);
        }
    }
}