using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine, IStateMachine {

    private PlayerStates currentStateName;

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;
    

    private void Start () {
        movementController = GetComponent<PlayerMovementController>();
        weaponController = GetComponentInChildren<PlayerWeaponController>();

        base.Init(new LoadingState(gameObject));
    }

    public new void Disable() {
        movementController.enabled = false;
        weaponController.enabled = false;

        base.Disable();
    }
}
