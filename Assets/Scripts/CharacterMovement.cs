using Interfaces;
using UnityEngine;

public class CharacterMovement : MonoBehaviour, ICharacter
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private float _verticalVelocity;
    private const float Gravity = -9.81f;
    
    private float _horizontalMovement;
    private float _verticalMovement;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>(); 
    }

    private void Update()
    {
        _horizontalMovement = Input.GetAxis("Horizontal");
        _verticalMovement = Input.GetAxis("Vertical");
        CharacterJump();
    }

    private void FixedUpdate()
    {
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        Vector3 moveVector = new Vector3(_horizontalMovement, 0f, _verticalMovement).normalized;
        _characterController.Move(moveVector * _speed * Time.deltaTime);
    }

    private void CharacterJump()
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = Gravity * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                _verticalVelocity = _jumpForce;
            }
        }
        else
        {
            _verticalVelocity += Gravity * Time.deltaTime;
        }
        Vector3 jumpVector = new Vector3(0, _verticalVelocity, 0);
        _characterController.Move(jumpVector * Time.deltaTime);

    }
}
