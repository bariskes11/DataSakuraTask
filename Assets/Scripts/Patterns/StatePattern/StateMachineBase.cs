using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineBase : MonoBehaviour
{
    public IState CurrentState { get; private set; }
    public IState _previousState;
    bool _inTransition = false;
    public void ChangeState(IState newState)
    {
        if (CurrentState == newState || _inTransition)
            return;
        ChangeStateRoutine(newState);

    }
    public void RevertState()
    {
        if (_previousState != null)
            ChangeState(_previousState);
    }
    void ChangeStateRoutine(IState newState)
    {
        _inTransition = true;
        if (CurrentState != null)
            CurrentState.Exit();
        if (_previousState != null)
            _previousState = CurrentState;
        CurrentState = newState;
        CurrentState.Enter();
        _inTransition = false;
    }
    private void Update()
    {
        if (CurrentState != null && !_inTransition)
            CurrentState.Tick();
    }
    private void FixedUpdate()
    {
        if (CurrentState != null && !_inTransition)
            CurrentState.FixedTick();
    }

}