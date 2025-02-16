using UnityEngine;

public class JumpingHandler
{
    private IJumping _player;

    public JumpingHandler(IJumping player)
    {
        _player = player;
    }

    public void Jump()
    {
        var direction = new Vector3(Input.GetAxis("Horizontal"), 1, Input.GetAxis("Vertical"));
        _player.Rigidbody.AddForce(direction * _player.JumpForce, ForceMode.VelocityChange);
    }
}
