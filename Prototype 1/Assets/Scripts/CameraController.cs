using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Vector3 cameraOffset;

    // Update is called once per frame
    void Update()
    {
        UpdateCameraPosition();
    }
    
    private void UpdateCameraPosition()
    {
        transform.position = playerTransform.position + cameraOffset;
    }
}
