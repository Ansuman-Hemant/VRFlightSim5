using UnityEngine;

public class Thrust : MonoBehaviour
{
    PokeLever thrustLever;

    public Observer<float> ThrustPercent = new(0);

    private void Awake()
    {
        thrustLever = GetComponent<PokeLever>();
    }

    private void Start()
    {
        thrustLever.OnLeverMove += OnThrustLeverMove;
    }

    void OnThrustLeverMove()
    {
        ThrustPercent.Value = thrustLever.GetThrottlePercentage();
    }

    [ContextMenu("Full throttle")]
    public void Debug_FullThrottle()
    {
        ThrustPercent.Value = 1;
    }
}
