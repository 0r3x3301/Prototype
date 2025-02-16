using UnityEngine;
[System.Serializable]
public abstract class MovementState
{
    protected IMoving _player;
    protected MovementStateConfig _config;
    protected Vector3 _currentDirection = Vector3.zero;

    public MovementState(IMoving player)
    {
        _player = player;
    }

    public virtual void Move()
    {
        var direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        float maxSpeed = 0;
        if (direction != Vector3.zero)
        {
            _currentDirection = direction;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                maxSpeed = _config.RunMaxSpeed;
            }
            else
            {
                maxSpeed = _config.WalkMaxSpeed;
            }
        }
        else
        {
            maxSpeed = 0;
        }

        if (Mathf.Abs(direction.x) + Mathf.Abs(direction.z) > 1)
        {
            _currentDirection = new Vector3(direction.x / 1.2f, 0f, direction.z / 1.2f);
        }

        _player.Transform.Translate(_currentDirection * maxSpeed * Time.deltaTime);
    }

    //protected abstract void SetStamina();
    protected abstract MovementStateConfig LoadConfig();
}
