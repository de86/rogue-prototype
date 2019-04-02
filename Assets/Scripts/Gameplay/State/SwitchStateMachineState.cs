using UnityEngine;

public class SwitchStateMachineState : IState {

    private IStateMachine nextStateMachine;
    private IStateMachine fromStateMachine;

    private IState nextState;


    public SwitchStateMachineState (IStateMachine fromStateMachine, IStateMachine nextStateMachine, IState nextState) {
        this.nextStateMachine = nextStateMachine;
        this.fromStateMachine = fromStateMachine;

        this.nextState = nextState;
    }


    public void OnEnterState () {
        nextStateMachine.Enable();
        fromStateMachine.Disable();
        nextStateMachine.SetState(nextState);
    }

    public IState StateUpdate (float deltaTime) {
        // Not required. This state is used simply to switch between State Machines.
        // This shouldn't get called as the parent statemachine is disabled in OnEnterState.
        // Refactor if you think of a better solution

        return null;
    }

    public void OnExitState () {
        // Not required. Parent State Machine will have it's state set directly upon
        // being enabled
    }
}