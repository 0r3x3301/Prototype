using UnityEngine;

public interface IJumping : IAnimatable
{
    public float JumpForce { get; }
    public Rigidbody Rigidbody { get; }
    public void Jump();
}
