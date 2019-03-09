using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlState : AbstractState<PlayerStates> {

    private IStateMachine PlayerControlStateMachine;
    private IStateMachine PlayerStateMachine;

    private Dictionary<PlayerStates, IState> stateTransitions = new Dictionary<PlayerStates, IState>();



    public PlayerControlState (GameObject player) : base (player) {
        stateName = PlayerStates.PlayerControl;
        PlayerControlStateMachine = player.GetComponent<PlayerControlStateMachine>();
        PlayerStateMachine = player.GetComponent<PlayerStateMachine>();
    }
	


    public void AddStateTransition (PlayerStates key, IState state)  {
        stateTransitions.Add(key, state);
    }



    public override void OnEnterState () {
        PlayerControlStateMachine.Enable();
        PlayerStateMachine.Disable();
    }



    public override IState StateUpdate (float deltaTime) {
        // Not required. This state is used simply to switch between State Machines.
        // This shouldn't get called as the parent statemachine is disabled in OnEnterState.
        // Refactor if you think of a better solution

        return null;
    }



    public override void OnExitState () {
        // Not required. Parent State Machine will have it's state set directly upon
        // being enabled
    }



    public override void Save () {
        Debug.Log("Save ()");
    }



    public override void Restore () {
        Debug.Log("Restore ()");
    }



    public override PlayerStates GetStateName () {
        return stateName;
    }



    public override void Pause () {}
    public override void Resume () {}
    public override void Enable () {}
    public override void Disable () {}
}
