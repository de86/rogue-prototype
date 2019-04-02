using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{
    [SerializeField]
    private bool resetOnStart;
    [SerializeField]
    private float initialValue;
    [SerializeField]
    private float value;

    private void OnEnable () {
        if (resetOnStart)
        {
            value = initialValue;
        }
    }

    public float GetValue () {
        return value;
    }

    public void SetValue (float newValue) {
        value = newValue;
    }
}
