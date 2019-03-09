using UnityEngine;

public class SwitchStateMachineState : IState {

    private IStateMachine nextStateMachine;
    private IStateMachine currentStateMachine;

    private IState nextState;


    public SwitchStateMachineState (IStateMachine currentStateMachine, IStateMachine nextStateMachine, IState nextState) {
        this.nextStateMachine = nextStateMachine;
        this.currentStateMachine = currentStateMachine;

        this.nextState = nextState;
    }


    public void OnEnterState () {
        nextStateMachine.Enable();
        nextStateMachine.SetState(nextState);
        currentStateMachine.Disable();
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