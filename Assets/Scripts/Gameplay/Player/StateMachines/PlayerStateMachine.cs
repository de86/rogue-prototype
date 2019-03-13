using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Move to enum file
public enum PlayerStates
{
    Loading,
    Saving,
    PlayerControl,
    Cutscene,
    SwitchToPlayerControlSM
}

public class PlayerStateMachine : MonoBehaviour, IStateMachine {

    [SerializeField]
    private IState currentState;
    private IState nextState;

    private PlayerStates currentStateName;

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;
    

    private void Start () {
        movementController = GetComponent<PlayerMovementController>();
        weaponController = GetComponentInChildren<PlayerWeaponController>();

        currentState = new LoadingState(gameObject);
        currentState.OnEnterState();
    }

	// Update is called once per frame
	private void Update () {
		nextState = currentState.StateUpdate(Time.deltaTime);

        if (nextState != null) {
            SetState(nextState);
        }
	}

    public void SetState(IState nextState) {
        if (currentState != null) {
            currentState.OnExitState();
        }
        
        currentState = nextState;
        currentState.OnEnterState();
    }

    public void Enable() {
        this.enabled = true;
    }

    public void Disable() {
        movementController.enabled = false;
        weaponController.enabled = false;

        enabled = false;
    }

    public void PauseState() {
        Debug.Log("PauseState()");
    }

    public void ResumeState() {
        Debug.Log("ResumeState()");
    }

    public void SaveState() {
        Debug.Log("SaveState()");
    }

    public void RestoreState() {
        Debug.Log("RestoreState()");
    }

    public IState GetCurrentState() {
        return currentState;
    }
}
