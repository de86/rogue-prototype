using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingState : AbstractState<PlayerStates> {

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;

    private IStateMachine PlayerControlStateMachine;
    private IStateMachine PlayerStateMachine;

    private IState PlayerMovementState;

    private SwitchStateMachineState SwitchToPlayerControlStateMachine;

    private Dictionary<PlayerStates, IState> stateTransitions = new Dictionary<PlayerStates, IState>();



    public LoadingState (GameObject player) : base (player) {
        stateName = PlayerStates.Loading;

        PlayerMovementState = new PlayerMovementState(player);

        movementController = player.GetComponent<PlayerMovementController>();
        weaponController = player.GetComponentInChildren<PlayerWeaponController>();

        PlayerControlStateMachine = player.GetComponent<PlayerControlStateMachine>();
        PlayerStateMachine = player.GetComponent<PlayerStateMachine>();

        SwitchToPlayerControlStateMachine = new SwitchStateMachineState(PlayerStateMachine, PlayerControlStateMachine, PlayerMovementState);
    }
	


    public void AddStateTransition (PlayerStates key, IState state)  {
        stateTransitions.Add(key, state);
    }



    public override void OnEnterState () {
        movementController.enabled = false;
        weaponController.enabled = false;
    }



    public override IState StateUpdate (float deltaTime) {
        Debug.Log("Updating " + stateName.ToString());

        if (Input.GetKeyDown("space")) {
            return SwitchToPlayerControlStateMachine;
        }

        return null;
    }



    public override void OnExitState () {
        movementController.enabled = true;
        weaponController.enabled = true;
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
