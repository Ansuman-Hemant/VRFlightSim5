using System.Threading;
using UnityEngine;

public class CruiseStateFSM : FlightFSM
{
    Rigidbody planeRb;
    float autopilotDuration = 5;

    CountDownTimer autoPilotCountdown;

    bool startedCountDown;

    public CruiseStateFSM(FlightStateManager stateManager, State state, FlightValuesSO flightValues, Rigidbody rb) : base(stateManager, state, flightValues)
    {
        planeRb = rb;
    }

    public override void Update(float dt)
    {
        //if (Weather.GetAltitude(planeRb.position.y) < flightValues.AltitudeBeforeSlippingDownToClimb)
        if (flightValues.Altitude < flightValues.AltitudeBeforeSlippingDownToClimb)
        {
            stateManager.SwitchState(State.Climb);
        }

        // After finishing autopilot, call UpdateState()
        if (startedCountDown)
            autoPilotCountdown.Tick(dt);
    }

    public override void InitState()
    {
        EnteredNewState(stateManager, State.Cruise);
        UpdateInteractable();

        autoPilotCountdown = new CountDownTimer(autopilotDuration);
        autoPilotCountdown.OnTimerStart += () => startedCountDown = true;
        autoPilotCountdown.OnTimerStop += UpdateState;
    }

    public override void UpdateState()
    {
        stateManager.SwitchState(State.Descent);
    }

    protected override void FinishedStateInteractions()
    {
        // After autopilot is done, this gets called. Go to next state after 5 seconds
        autoPilotCountdown.Start();
        UpdatePromptUI("");
    }
}
