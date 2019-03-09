public interface IState
{
	void OnEnterState ();
    void OnExitState ();
    IState StateUpdate (float deltaTime);
}
