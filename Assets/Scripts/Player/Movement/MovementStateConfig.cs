using UnityEngine;
[CreateAssetMenu]
public class MovementStateConfig : ScriptableObject
{
    [field: SerializeField] public float WalkMaxSpeed {  get; private set; }
    [field: SerializeField] public float RunMaxSpeed {  get; private set; }
    [field: SerializeField] public string IdleAnimationName { get; private set; }
    [field: SerializeField] public string WalkAnimationName { get; private set; }
    [field: SerializeField] public string RunAnimationName { get; private set; }
}

