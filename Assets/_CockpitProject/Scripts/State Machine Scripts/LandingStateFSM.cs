using UnityEngine;

public class LandingStateFSM : FlightFSM
{
    Rigidbody planeRb;

    public LandingStateFSM(FlightStateManager stateManager, State state, FlightValuesSO flightValues, Rigidbody rb) : base(stateManager, state, flightValues)
    {
        planeRb = rb;
    }

    public override void Update(float dt)
    {
        if (flightValues.GetPlaneVelocityInKnots(planeRb) <= 0)
        {
            UpdateState();
        }
    }

    public override void InitState()
    {
        EnteredNewState(stateManager, State.Landing);
        UpdateInteractable();
    }

    public override void UpdateState()
    {
        stateManager.SwitchState(State.SwitchOff);
    }
}