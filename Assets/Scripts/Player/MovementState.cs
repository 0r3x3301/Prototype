using System.Collections;
using System.Threading.Tasks;
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
                //_player.Animator.SetBool(_config.RunAnimationName, true);
                //_player.Animator.SetBool(_config.IdleAnimationName, false);
                //_player.Animator.SetBool(_config.WalkAnimationName, false);
            }
            else
            {
                speed = _config.WalkSpeed;
                //_player.Animator.SetBool(_config.WalkAnimationName, true);
                //_player.Animator.SetBool(_config.IdleAnimationName, false);
                //_player.Animator.SetBool(_config.RunAnimationName, false);
            }
            _player.Transform.Translate(direction * speed * Time.deltaTime);
        }
        else
        {
            //_player.Animator.SetBool(_config.IdleAnimationName, true);
            //_player.Animator.SetBool(_config.RunAnimationName, false);
            //_player.Animator.SetBool(_config.WalkAnimationName, false);
        }
    }

    //protected abstract void SetStamina();
    protected abstract Task<MovementStateConfig> LoadConfig();
}
