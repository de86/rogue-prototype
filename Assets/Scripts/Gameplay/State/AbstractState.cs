using UnityEngine;

public abstract class AbstractState<StateNames> : IState
{
    protected StateNames stateName;
    protected GameObject player;

    public AbstractState (GameObject player)
    {
        this.player = player;
    }

    public abstract void OnEnterState ();
    public abstract void OnExitState ();
    public abstract IState StateUpdate (float deltaTime);
    public abstract void Save ();
    public abstract void Restore ();
    public abstract StateNames GetStateName ();
    public abstract void Pause ();
    public abstract void Resume ();
    public abstract void Enable ();
    public abstract void Disable ();
}