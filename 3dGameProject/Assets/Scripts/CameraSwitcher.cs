using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera[] cameras;
    private int currentCameraIndex = 0;

    private void Update()
    {
        // Check for the 'P' key press
        if (Input.GetKeyDown(KeyCode.P))
        {
            SwitchCamera();
        }
    }

    private void SwitchCamera()
    {
        // Disable the current camera
        DisableCurrentCamera();

        // Move to the next camera
        currentCameraIndex = (currentCameraIndex + 1) % cameras.Length;

        // Enable the new camera
        EnableCamera(cameras[currentCameraIndex]);
    }

    private void EnableCamera(Camera camera)
    {
        camera.enabled = true;
    }

    private void DisableCurrentCamera()
    {
        cameras[currentCameraIndex].enabled = false;
    }
}
