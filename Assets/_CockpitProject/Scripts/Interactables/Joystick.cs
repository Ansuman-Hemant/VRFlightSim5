using UnityEngine;

public class Joystick : MonoBehaviour
{

    [SerializeField] Transform joystickTransform;
    [SerializeField] Transform targetTransform;
    [SerializeField] float range = 0.3f;

    float targetLocalYPos;

    [Header("DEBUGGING")]
    [SerializeField] bool useDebuggingInput;
    [SerializeField, Range(-1, 1)] float debugginInputX;
    [SerializeField, Range(-1, 1)] float debuggingInputY;

    private void Start()
    {
        targetLocalYPos = 0.5f;
        targetTransform.localPosition = Vector3.up * targetLocalYPos;
    }

    public void SetJoystickVal(float inputX, float inputY)
    {
        if (useDebuggingInput)
        {
            SetTargetPos(debugginInputX, debuggingInputY);
        } else
        {
            SetTargetPos(inputX, inputY);
        }

        FaceTarget();
    }

    void SetTargetPos(float inputX, float inputY)
    {
        Vector2 input = new Vector2(inputX, inputY);
        Vector2 clampedInput = Vector2.ClampMagnitude(input, 1.0f);  // Clamp input to max magnitude of 1
        Vector2 targetVector = clampedInput.normalized * clampedInput.magnitude * range;  // Scale both axes uniformly
        targetTransform.localPosition = new Vector3(targetVector.x, targetLocalYPos, targetVector.y);
    }



    void FaceTarget()
    {
        joystickTransform.LookAt(targetTransform.position);
    }

    private void OnValidate()
    {
        if (useDebuggingInput)
        {
            SetTargetPos(debugginInputX, debuggingInputY);
            FaceTarget();
        }
    }
}
