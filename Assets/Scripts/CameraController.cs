using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Tooltip("How far from the target we want the camera to be")]
    public Vector3 offset = new Vector3(0, 1, -10);
    [Range(0f, 5f)]
    public float cameraRotationSpeed = 3f;
    public float minRotationY = -89f;
    public float maxRotationY = 82f;

    private float inputX, inputY;
    private float yaw = 0f, pitch = 0f;
    private GameObject target;

    // Saving computation power with rotation limits, probably will backfire when it'll become an option in Settings
    void Start()
    {
        (minRotationY, maxRotationY) = (minRotationY / cameraRotationSpeed, maxRotationY / cameraRotationSpeed);
    }

    // Called when the script becomes active
    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Calling all Camera scripts from LateUpdate allows to skip Lerping it if we want it to smoothly follow something
    void LateUpdate()
    {
        AttachCamera();
        RotateCameraMouse();
    }

    /// <summary>
    /// Collects and returns mouse inputs
    /// </summary>
    /// <returns>Tuple object (x, y) with values being in range of [0, 1]</returns>
    private (float x, float y) GetMouseInput()
    {
        return (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }

    /// <summary>
    /// Makes Camera rotate based on mouse inputs, then rotates target towards Camera's rotation (make sure this method happens in LateUpdate)
    /// </summary>
    private void RotateCameraMouse()
    {
        (inputX, inputY) = GetMouseInput();

        yaw += inputX;
        pitch -= inputY;
        
        pitch = Mathf.Clamp(pitch, minRotationY, maxRotationY); // rotation * speed = max actual rotation, that's why we divide limits by rotation speed in Start()

        transform.eulerAngles = new Vector3 (pitch, yaw, 0f) * cameraRotationSpeed;
        target.transform.Rotate(Vector3.up * inputX * cameraRotationSpeed);
    }

    /// <summary>
    /// Attaches Camera's transform at target's transform and adds some offset to it
    /// </summary>
    private void AttachCamera()
    {
        transform.position = target.gameObject.transform.position + offset;
    }
}
