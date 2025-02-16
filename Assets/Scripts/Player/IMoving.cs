using UnityEngine;

public interface IMoving : IAnimatable
{
    public Transform Transform { get; }
    public float Stamina { get; }
    public void Move();
}
