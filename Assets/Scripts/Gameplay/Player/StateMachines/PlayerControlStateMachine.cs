using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerControlStates {
    Moving,
    Attacking,
    Blocking,
    Jumping,
    Interacting
}

public class PlayerControlStateMachine : MonoBehaviour, IStateMachine {

    [SerializeField]
    private IState currentState;
    private IState nextState;

    private IState playerMovementState;
    private IState loadingState;

    private IStateMachine playerStateMachine;
    private SwitchStateMachineState switchToPlayerStateMachine;


    private void Start () {
        playerStateMachine = GetComponent<PlayerStateMachine>();

        loadingState = new LoadingState(gameObject);
        playerMovementState = new PlayerMovementState(gameObject);
        
        switchToPlayerStateMachine = new SwitchStateMachineState(this, playerStateMachine, loadingState);

        currentState = playerMovementState;
        currentState.OnEnterState();
    }
	

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
        enabled = true;
    }


    public void Disable() {
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
