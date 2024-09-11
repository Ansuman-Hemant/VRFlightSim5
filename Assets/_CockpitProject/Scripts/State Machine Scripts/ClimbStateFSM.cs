using System.Numerics;
using UnityEngine;

public class ClimbStateFSM : FlightFSM
{
    //FlightStateManager stateM;
    Rigidbody planeRb;

    public ClimbStateFSM(FlightStateManager stateManager, State state, FlightValuesSO flightValues, Rigidbody planeRb) : base(stateManager, state, flightValues)
    {
        //stateM = stateManager;
        this.planeRb = planeRb;
    }

    //public override void InitState()
    //{
    //    //Debug.Log("INSIDE CLIMB STATE");
    //    //currentSubState = ClimbSubState.PullThrottle;
    //    //stateManager.climbSubStateMap[currentSubState].Initialize();
    //    //Debug.Log("pull throttle");
    //}

    public override void Update(float dt)
    {
        //if (Weather.GetAltitude(planeRb.position.y) > flightValues.CruiseAltitude)
        if (flightValues.Altitude > flightValues.CruiseAltitude)
        {
            UpdateState();
        }
    }

    public override void InitState()
    {
        EnteredNewState(stateManager, State.Climb);
        UpdateInteractable();
    }

    public override void UpdateState()
    {
        stateManager.SwitchState(State.Cruise);
    }
}
