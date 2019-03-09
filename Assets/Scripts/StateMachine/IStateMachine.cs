public interface IStateMachine
{
	void SetState(IState state);
    void PauseState();
    void ResumeState();
    void SaveState();
    void RestoreState();
    IState GetCurrentState();
    void Enable();
    void Disable();
}
