using UnityEngine;
using UnityEditor;
using Unity.XR.Oculus;

[InitializeOnLoad]
public class OculusSetupManager
{
    static OculusSetupManager()
    {
        EditorApplication.playModeStateChanged += HandlePlayModeStateChanged;
    }

    private static void HandlePlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingPlayMode)
        {
            DisableOculusSetup();
        }
    }

    private static void DisableOculusSetup()
    {
        OculusLoader loader = new OculusLoader();
        loader.Stop();

        // Disable Oculus XR Plugin
        UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.StopSubsystems();
        UnityEngine.XR.Management.XRGeneralSettings.Instance.Manager.DeinitializeLoader();

        Debug.Log("Oculus setup disabled on exiting Play Mode");
    }
}