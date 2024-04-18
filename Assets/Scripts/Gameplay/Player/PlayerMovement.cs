using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private const string AxisHorizontal = "Horizontal";
    private const string AxisVertical = "Vertical";
    private const string ButtonJump = "Jump";

    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;

    [SerializeField] private KeyCode _runButton;

    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _groundDistance;
    [SerializeField] private float _gravityForce;

    [SerializeField] private float _defaultFieldOfView;
    [SerializeField] private float _runFieldOfView;

    private CharacterController _characterController;
    private Vector3 _velocity;
    private bool _isGrounded;
    private float _startVelocityY;
    private Vector3 _moveDirection;
    private float _movementSpeed;

    private float _smoothInputVelocity;
    private float _moveStateSmoothness = 0.2f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        _isGrounded = GetIsGrounded();

        if (_isGrounded && _velocity.y < 0f)
        {
            _velocity.y = _startVelocityY;
        }

        Move();
        Jump();
        Fall();
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxisRaw(AxisHorizontal);
        float verticalInput = Input.GetAxisRaw(AxisVertical);

        _movementSpeed = SetMovementSpeed();

        _moveDirection = (transform.right * horizontalInput + transform.forward * verticalInput).normalized;

        _characterController.Move(_moveDirection * _movementSpeed * Time.deltaTime);
    }

    private float SetMovementSpeed()
    {
        if (Input.GetKey(_runButton) && _moveDirection.magnitude > 0.1f)
        {
            _camera.fieldOfView = Mathf.SmoothDamp(_camera.fieldOfView, _runFieldOfView, ref _smoothInputVelocity, _moveStateSmoothness);

            return _runSpeed;
        }

        _camera.fieldOfView = Mathf.SmoothDamp(_camera.fieldOfView, _defaultFieldOfView, ref _smoothInputVelocity, _moveStateSmoothness);

        return _walkSpeed;
    }

    private void Jump()
    {
        if (Input.GetButtonDown(ButtonJump) && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpForce * -2f * _gravityForce);
        }
    }

    private bool GetIsGrounded()
    {
        return Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundLayer);
    }

    private void Fall()
    {
        _velocity.y += _gravityForce * Time.deltaTime;

        _characterController.Move(_velocity * Time.deltaTime);
    }
}
