using Zenject;

public class StraightMovementState : MovementState
{
    public StraightMovementState(IMoving player) : base(player)
    {
        _config = LoadConfig();
    }

    protected override MovementStateConfig LoadConfig()
    {
        return ProjectContext.Instance.GetComponent<ConfigsHolder>().StraightMovementStateConfig;
    }
}
