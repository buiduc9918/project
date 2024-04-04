using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ManaSpawn : MonoBehaviour
{
    public GameObject[] prefabs;
    public Button button;
    public float spawnInterval = 2f;
    public float limitSpace = 1f; // Default value for limitSpace
    public float limitTimer = 10f;
    public float direction = 1;
    private int currentIndex;
    public Vector3 rotation1 = new Vector3(0, 0, 0);
    private Coroutine spawnCoroutine;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleSpawning);
    }

    public void ToggleSpawning()
    {
        if (spawnCoroutine != null)
        {
            StopCoroutine(spawnCoroutine);
            spawnCoroutine = null;
        }
        else
        {
            spawnCoroutine = StartCoroutine(SpawnWithDelay());
        }
    }

    private IEnumerator SpawnWithDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnPrefab();
        }
    }

    private void SpawnPrefab()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogWarning("No prefabs assigned to spawn.");
            return;
        }

        currentIndex = currentIndex % prefabs.Length;
        GameObject selectedPrefab = prefabs[currentIndex];

        if (selectedPrefab != null)
        {
            Vector2 spawnPosition = new Vector2(transform.position.x, transform.position.y + Random.Range(-limitSpace, limitSpace));
            GameObject prefabInstance = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
            prefabInstance.transform.Rotate(rotation1);
            Destroy(prefabInstance, limitTimer);
        }

        currentIndex++;
        if (currentIndex >= prefabs.Length)
        {
            currentIndex = 0;
        }
    }
}

/*
    private void Update()
    {

        if (prefabs.Length > 0)
        {
            timer += Time.deltaTime;
            if (timer > 5)
            {
                currentIndex = currentIndex % prefabs.Length;
                GameObject selectedPrefab = prefabs[currentIndex];
                if (selectedPrefab != null)
                {
                    //GameObject prefabsSpawn = Instantiate(selectedPrefab, transform.position, transform.rotation);
                    GameObject prefabsSpawn = Instantiate(selectedPrefab);
                    prefabsSpawn.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-limitspace, limitspace));
                    Destroy(prefabsSpawn, 10);
                    currentIndex = (currentIndex + 1) % prefabs.Length;
                }
                timer = 0;

            }
        }
    }
private void Update(): Đây là một phương thức MonoBehaviour trong Unity, được gọi mỗi frame.

if (prefabs.Length > 0): Kiểm tra xem mảng prefabs có chứa các phần tử không.

timer += Time.deltaTime;: Tăng biến timer lên bằng thời gian đã trôi qua kể từ frame trước.

if (timer > 5): Kiểm tra xem timer đã vượt quá 5 giây chưa.

currentIndex = currentIndex % prefabs.Length;: Đảm bảo rằng currentIndex không vượt quá kích thước của mảng prefabs.

GameObject selectedPrefab = prefabs[currentIndex] ;: Chọn prefab từ mảng dựa trên chỉ số hiện tại.

if (selectedPrefab != null) { ... }: Kiểm tra xem prefab được chọn có tồn tại không.

GameObject prefabsSpawn = Instantiate(selectedPrefab);: Tạo ra một thể hiện của prefab đã chọn.

prefabsSpawn.transform.position = new Vector2(transform.position.x, transform.position.y + Random.Range(-limitspace, limitspace));
: Đặt vị trí của prefab đã sinh ra thành một giá trị ngẫu nhiên theo trục Y trong khoảng được chỉ định.

Destroy(prefabsSpawn);: Hủy thể hiện của prefab ngay sau khi sinh ra. Câu này có thể cần sửa đổi
nếu bạn muốn giữ các đối tượng đã sinh ra trong cảnh.

currentIndex = (currentIndex + 1) % prefabs.Length;: Tăng chỉ số cho prefab tiếp theo để sinh ra, 
đảm bảo nó quay lại vị trí ban đầu nếu nó vượt qua cuối mảng.

timer = 0;: Thiết lập lại timer.

Tổng thể, đoạn mã này sinh ra các prefab từ một mảng sau mỗi khoảng thời gian là 5 giây và đặt vị trí của 
chúng ngẫu nhiên theo trục Y trong một phạm vi được chỉ định.
Thay đổi duy nhất là thêm một tham số trong hàm Destroy. Tham số này xác định thời gian trước khi đối
tượng được hủy. Trong trường hợp này,
prefabsSpawn sẽ được hủy sau 10 giây kể từ khi nó được sinh ra.

Nếu bạn muốn đối tượng sinh ra được giữ lại lâu hơn trước khi bị hủy, 
bạn có thể thay đổi giá trị thứ hai trong hàm Destroy thành một giá trị lớn hơn.

ChatGPT
Đoạn mã này được thiết kế để thực hiện hành động spawn (sinh ra) 
các prefab theo một khoảng thời gian nhất định. Dưới đây là một phân tích tổng quan:

Cấu trúc Update(): Phương thức Update() là một phương thức được gọi mỗi frame trong một MonoBehaviour trong Unity. 
Trong trường hợp này, nó được sử dụng để kiểm tra và thực hiện hành động spawn các prefab.

Kiểm tra độ dài của mảng prefabs: Đoạn mã kiểm tra xem mảng prefabs có chứa ít nhất một prefab hay không.
Nếu mảng không rỗng, nó tiếp tục thực hiện các hành động spawn prefab.

Tính thời gian chờ: Biến timer được tăng lên theo thời gian đã trôi qua từ frame trước (được tính bằng Time.deltaTime).
Mỗi khi timer vượt quá 5 giây, một prefab mới được sinh ra.

Lặp lại việc chọn prefab: Chỉ số currentIndex được sử dụng để lặp lại việc chọn prefab từ mảng prefabs. 
Nếu currentIndex vượt qua chỉ số cuối cùng của mảng, nó sẽ quay lại vị trí đầu tiên của mảng.

Spawn prefab và đặt vị trí: Một prefab được chọn từ mảng, và sau đó nó được sinh ra thông qua hàm Instantiate(). 
Vị trí của prefab được đặt là vị trí hiện tại của đối tượng chứa script cộng với một giá trị ngẫu nhiên trong khoảng từ -limitspace đến limitspace trên trục Y.

Hủy prefab sau một khoảng thời gian: Thay vì hủy ngay lập tức sau khi sinh ra, đoạn mã này sử dụng hàm Destroy() với một tham số thứ hai để hủy prefab
sau một khoảng thời gian nhất định. Trong trường hợp này, prefab sẽ bị hủy sau 10 giây.

Thiết lập lại timer: Sau khi prefab được sinh ra và hủy, timer được thiết lập lại về 0 để chu kỳ 
spawn tiếp theo bắt đầu.

Tóm lại, đoạn mã này là một cách đơn giản để tự động sinh ra các prefab trong Unity theo một khoảng 
thời gian nhất định và đặt vị trí của chúng một cách ngẫu nhiên trong một phạm vi được xác định.

*/