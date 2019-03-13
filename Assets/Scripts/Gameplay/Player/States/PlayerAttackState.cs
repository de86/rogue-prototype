using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : AbstractState<PlayerStates> {

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;

    private Dictionary<PlayerStates, IState> stateTransitions = new Dictionary<PlayerStates, IState>();


    public PlayerAttackState (GameObject player) : base (player) {
        stateName = PlayerStates.PlayerControl;

        movementController = player.GetComponent<PlayerMovementController>();
        weaponController = player.GetComponentInChildren<PlayerWeaponController>();
    }


    public void AddStateTransition (PlayerStates key, IState state)  {
        stateTransitions.Add(key, state);
    }

    // attakc state that attacks and pauses movement
    // IStateTransition object containing next state object and components enabled state

    private IState GetStateMachineSwitchState () {
        IStateMachine playerControlStateMachine = player.GetComponent<PlayerControlStateMachine>();
        IStateMachine playerStateMachine = player.GetComponent<PlayerStateMachine>();
        IState loadingState = new LoadingState(player);

        return new SwitchStateMachineState(playerControlStateMachine, playerStateMachine, loadingState);
    }


    public override void OnEnterState () {
        Debug.Log("OnEnterState ()");

        movementController.enabled = false;
        weaponController.enabled = true;
    }



    public override IState StateUpdate (float deltaTime) {
        Debug.Log("Updating " + stateName.ToString());

        if (Input.GetKeyDown("space")) {
            return GetStateMachineSwitchState();
        }

        return null;
    }



    public override void OnExitState () {
        Debug.Log("OnExitState ()");

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
