using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : AbstractState<PlayerStates> {

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;

    private PlayerControlStateMachine playerControlStateMachine;
    private PlayerStateMachine playerStateMachine;

    private IState loadingState;

    private SwitchStateMachineState SwitchToPlayerStateMachine;

    private Dictionary<PlayerStates, IState> stateTransitions = new Dictionary<PlayerStates, IState>();


    public PlayerMovementState (GameObject player) : base (player) {
        stateName = PlayerStates.PlayerControl;

        playerControlStateMachine = player.GetComponent<PlayerControlStateMachine>();
        playerStateMachine = player.GetComponent<PlayerStateMachine>();

        loadingState = new LoadingState(player);

        SwitchToPlayerStateMachine = new SwitchStateMachineState(playerControlStateMachine, playerStateMachine, loadingState);

        movementController = player.GetComponent<PlayerMovementController>();
        weaponController = player.GetComponentInChildren<PlayerWeaponController>();
    }
	


    public void AddStateTransition (PlayerStates key, IState state)  {
        stateTransitions.Add(key, state);
    }



    public override void OnEnterState () {
        Debug.Log("OnEnterState ()");

        movementController.enabled = true;
        weaponController.enabled = true;
    }



    public override IState StateUpdate (float deltaTime) {
        Debug.Log("Updating " + stateName.ToString());

        if (Input.GetKeyDown("space")) {
            return SwitchToPlayerStateMachine;
        }

        return null;
    }



    public override void OnExitState () {
        Debug.Log("OnExitState ()");

        movementController.enabled = false;
        weaponController.enabled = false;
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
