using UnityEngine;

public class StateMachine : MonoBehaviour {
    
    [SerializeField]
    protected IState currentState;
    protected IState nextState;

    protected void Init (IState initialState) {
        this.SetState(initialState);
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
        this.enabled = false;
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