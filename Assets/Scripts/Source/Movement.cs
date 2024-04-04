using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Tốc độ di chuyển của đối tượng

    public Vector3 velocity;

    private void Start()
    {
    }
    void Update()
    {
        velocity = Input.GetMouseButton(0) ? new Vector3(0, 3, 0) : new Vector3(0, -3, 0);
        transform.Translate(velocity * Time.deltaTime);

        transform.eulerAngles = new Vector3(0, 0, 0);

    }
}
// private Vector3 targetPosition; // Vị trí mục tiêu mới
//// Kiểm tra xem người dùng có nhấp chuột trái không
//if (Input.GetMouseButtonDown(0))
//{
//    // Lấy vị trí của chuột trên màn hình
//    Vector3 mousePosition = Input.mousePosition;

//    // Chuyển đổi vị trí của chuột từ không gian màn hình sang không gian thế giới của trò chơi
//    targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, Camera.main.transform.position.z));

//    // Đảm bảo rằng vị trí Z của đối tượng là 0 (phù hợp với mặt phẳng của màn hình)
//    targetPosition.z = 0f;
//}

//// Di chuyển đến vị trí mục tiêu mới với tốc độ được chỉ định
//transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);