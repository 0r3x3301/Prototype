using UnityEngine;

public class Player : MonoBehaviour, IMoving, IJumping
{
    [SerializeField] private float _stamina;
    [SerializeField] private float _jumpForce = 10;

    public Transform Transform => _transform;
    public float Stamina => _stamina;
    public Animator Animator => _animator;
    public float JumpForce => _jumpForce;
    public Rigidbody Rigidbody => _rigidbody;

    private Transform _transform;
    private Rigidbody _rigidbody;
    private Animator _animator;

    private MovementHandler _movementHadler;
    private JumpingHandler _jumpingHadler;

    private bool _canMoving = true;
    private bool _canJumping = true;
    private bool _isGrounded = false;

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        _movementHadler = new(this);
        _jumpingHadler = new(this);
    }

    private void Update()
    {
        if (_canMoving)
        {
            Move();
        }

        if (_canJumping && _isGrounded && _movementHadler.CurrentStateType == typeof(StraightMovementState))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }
    }

    public void Move()
    {
        _movementHadler.Move();
    }

    public void Jump()
    {
        _jumpingHadler.Jump();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = true;
            _canMoving = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isGrounded = false;
            _canMoving = false;
        }
    }



}
