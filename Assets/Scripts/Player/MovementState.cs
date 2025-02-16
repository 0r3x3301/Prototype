using UnityEngine;
[System.Serializable]
public abstract class MovementState
{
    protected IMoving _player;
    protected MovementStateConfig _config;

    public MovementState(IMoving player)
    {
        _player = player;
    }

    public virtual void Move()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        if (direction != Vector3.zero)
        {
            float speed;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = _config.RunSpeed;
            }
            else
            {
                speed = _config.WalkSpeed;
            }
            _player.Transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    //protected abstract void SetStamina();
    protected abstract MovementStateConfig LoadConfig();
}
