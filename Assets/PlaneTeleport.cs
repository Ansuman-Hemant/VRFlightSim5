using UnityEngine;

public class PlaneTeleport : MonoBehaviour
{
    [SerializeField] Transform planeTransform;
    [SerializeField] Transform teleportPoint;
    Interactable interactable;

    bool autopilotEnabled;

    void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    private void OnEnable()
    {
        interactable.OnComplete += OnAutopilotDisable;
    }

    private void OnDisable()
    {
        interactable.OnComplete -= OnAutopilotDisable;
    }

    void OnAutopilotDisable()
    {
        if (!autopilotEnabled)
        {
            autopilotEnabled = true;
            return;
        }

        planeTransform.position = teleportPoint.position;
    }
}
