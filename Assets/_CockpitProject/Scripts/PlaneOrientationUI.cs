using UnityEngine;
using TMPro;  // Don't forget to add this for TextMeshPro support!

public class PlaneOrientationUI : MonoBehaviour
{
    [SerializeField] PlaneOrientation planeOrientation;
    [SerializeField] TextMeshProUGUI pitchRollYawText;

    void Update()
    {
        // Update the text with pitch, roll, and yaw values
        UpdatePitchRollYawUI();
    }

    private void UpdatePitchRollYawUI()
    {
        if (planeOrientation != null && pitchRollYawText != null)
        {
            // Format the text to display the pitch, roll, and yaw on different lines
            pitchRollYawText.text = "Pitch: " + planeOrientation.pitch.ToString("F2") +
                                    "\nRoll: " + planeOrientation.roll.ToString("F2") +
                                    "\nYaw: " + planeOrientation.yaw.ToString("F2");
        }
    }
}
