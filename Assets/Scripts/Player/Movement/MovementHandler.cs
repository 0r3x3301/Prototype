using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class MovementHandler
{
    private IMoving _player;
    private Dictionary<System.Type, MovementState> _movementStates = new();
    private MovementState _currentState;
    public System.Type CurrentStateType => _currentState.GetType();

    public MovementHandler(IMoving Player)
    {
        _player = Player;
        _movementStates.Add(typeof(StraightMovementState), new StraightMovementState(Player));
        _movementStates.Add(typeof(SquatMovementState), new SquatMovementState(Player));

        SetCurentState(typeof(StraightMovementState));
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            SetCurentState(typeof(SquatMovementState));
        }
        else
        {
            SetCurentState(typeof(StraightMovementState));
        }

        _currentState.Move();
    }

    private void SetCurentState(System.Type stateType)
    {
        if (_currentState == null || _currentState.GetType() != stateType)
        {
            _currentState = _movementStates[stateType];
        }
    }
}