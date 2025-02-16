using Zenject;

public class SquatMovementState : MovementState
{
    public SquatMovementState(IMoving player) : base(player)
    {
        _config = LoadConfig();
    }

    protected override MovementStateConfig LoadConfig()
    {
        return ProjectContext.Instance.GetComponent<ConfigsHolder>().SquatMovementStateConfig;
    }
}
