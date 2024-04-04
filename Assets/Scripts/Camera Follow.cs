using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FollowObjectWithLimits : MonoBehaviour
{
    public Transform target; // Đối tượng mà camera sẽ theo dõi
    public float smoothSpeed = 0.02f; // Tốc độ camera di chuyển đến vị trí của đối tượng
    public float fixedZ = -16.4f; // Giá trị trục z cố định
    private Camera mainCamera;
    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        Vector3 targetPosition = target.position;
        Vector3 currentPosition = transform.position;

        // Đảm bảo camera không vượt quá giới hạn hiển thị xác định
        targetPosition.x = Mathf.Clamp(targetPosition.x, -20, 12);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -3, 3);
        targetPosition.z = fixedZ; // Đặt giá trị trục z cố định

        // Di chuyển camera một cách mượt mà đến vị trí của đối tượng
        Vector3 smoothedPosition = Vector3.Lerp(currentPosition, targetPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
