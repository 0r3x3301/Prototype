using UnityEngine;

public class Player : MonoBehaviour, IMoving
{
    [SerializeField] private float _stamina;
    [SerializeField] private Animator _animator;

    public Transform Transform => _transform;
    public float Stamina => _stamina;
    public Animator Animator => _animator;

    private Transform _transform;
    private MovementHandler _movementHadler;
    private bool _canMoving = true;

    private void OnValidate()
    {
        _transform = GetComponent<Transform>();
    }

    private void Awake()
    {
        _movementHadler = new(this);
    }

    private void Update()
    {
        if (_canMoving)
        {
            Move();
        }
    }

    public void Move()
    {
        _movementHadler.Move();
    }
}
