﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingState : AbstractState<PlayerStates> {

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;

    private Dictionary<PlayerStates, IState> stateTransitions = new Dictionary<PlayerStates, IState>();



    public LoadingState (GameObject player) : base (player) {
        stateName = PlayerStates.Loading;

        movementController = player.GetComponent<PlayerMovementController>();
        weaponController = player.GetComponentInChildren<PlayerWeaponController>();
    }
	

    private IState GetStateMachineSwitchState () {
        IStateMachine PlayerControlStateMachine = player.GetComponent<PlayerControlStateMachine>();
        IStateMachine PlayerStateMachine = player.GetComponent<PlayerStateMachine>();
        IState PlayerMovementState = new PlayerMovementState(player);

        return new SwitchStateMachineState(PlayerStateMachine, PlayerControlStateMachine, PlayerMovementState);
    }


    public void AddStateTransition (PlayerStates key, IState state)  {
        stateTransitions.Add(key, state);
    }



    public override void OnEnterState () {
        player.GetComponent<PlayerMovementController>().enabled = false;
        player.GetComponentInChildren<PlayerWeaponController>().enabled = false;
    }



    public override IState StateUpdate (float deltaTime) {
        Debug.Log("Updating " + stateName.ToString());

        if (Input.GetKeyDown("space")) {
            return GetStateMachineSwitchState();
        }

        return null;
    }



    public override void OnExitState () {
        player.GetComponent<PlayerMovementController>().enabled = true;
        player.GetComponentInChildren<PlayerWeaponController>().enabled = true;
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
