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

    private PlayerMovementController movementController;
    private PlayerWeaponController weaponController;
    

    private void Start () {
        movementController = GetComponent<PlayerMovementController>();
        weaponController = GetComponentInChildren<PlayerWeaponController>();

        currentState = new LoadingState(gameObject);
        currentState.OnEnterState();
    }
	

    // Created working FSM! maybe look at abstract state and fsm class next

	// Update is called once per frame
	private void Update () {
		nextState = currentState.StateUpdate(Time.deltaTime);

        if (nextState != null) {
            SetState(nextState);
        }
	}

    public void SetState(IState nextState) {
        currentState.OnExitState();
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
