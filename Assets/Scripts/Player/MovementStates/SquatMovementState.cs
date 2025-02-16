using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

public class SquatMovementState : MovementState
{
    public SquatMovementState(IMoving player) : base(player)
    {
        _config = LoadConfig().Result;
    }
    protected override async Task<MovementStateConfig> LoadConfig()
    {
        return await Addressables.LoadAssetAsync<MovementStateConfig>("Assets/Data/Configs/MovementStates/SquatMoving.asset").Task;
    }
}
