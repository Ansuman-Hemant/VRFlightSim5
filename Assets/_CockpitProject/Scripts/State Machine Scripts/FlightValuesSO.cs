using UnityEngine;

[CreateAssetMenu(menuName = "FlightSim/FlightValuesSO", fileName = "FlightValuesSO")]
public class FlightValuesSO : ScriptableObject
{
    /// <summary>
    /// Knots
    /// </summary>
    public int TakeOffSpeed = 110;

    /// <summary>
    /// Altitude to enter Climb state (metres) - Random number
    /// </summary>
    public int ClimbAltitude = 50;

    /// <summary>
    /// Altitude to enter Cruise state (metres)
    /// </summary>
    public int CruiseAltitude = 13716;

    /// <summary>
    /// Metres - Random number
    /// </summary>
    public int AltitudeBeforeSlippingDownToClimb = 12000;

    /// <summary>
    /// Metres - Random number
    /// </summary>
    public int ApproachAltitude = 500;


    /// <summary>
    /// Metres - Random number
    /// </summary>
    public int LandAltitude = 5;

    [Header("DEBUGGING")]
    public float Altitude = 0;
    public float Speed = 0;

    /// <summary>
    /// Returns velocity in m/s
    /// </summary>
    public float GetPlaneVelocity(Rigidbody rb)
    {
        return rb.velocity.magnitude * Weather.speedMultiplier;
    }

    public float GetPlaneVelocityInKnots(Rigidbody rb)
    {
        return Speed;
        //return Utility.mpsToKnots(GetPlaneVelocity(rb));
    }
}
