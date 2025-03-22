using UnityEngine;

public class FloatingEndScene : MonoBehaviour
{
    public float floatSpeed = 1f; // Tốc độ dao động
    public float floatHeight = 0.5f; // Độ cao dao động

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position; // Lưu vị trí ban đầu
    }

    void Update()
    {
        // Tạo hiệu ứng dao động lên xuống bằng Sin
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
