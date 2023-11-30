using UnityEngine;

public class CameraReset : MonoBehaviour
{
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    public Camera myCamera;

    private void Start()
    {
        // Store the original position and rotation of the camera
        originalPosition = myCamera.transform.position;
        originalRotation = myCamera.transform.rotation;
    }

    public void ResetCameraPosition()
    {
        // Move the camera back to the original position and rotation
        myCamera.transform.position = originalPosition;
        myCamera.transform.rotation = originalRotation;
    }
}