using UnityEngine;
using UnityEngine.SceneManagement; // Import SceneManager

public class EndGameTrigger : MonoBehaviour
{
    public string sceneToLoad; // Nhập tên scene cần load trong Unity Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Kiểm tra nếu nhân vật chạm vào
        {
            SceneManager.LoadScene(sceneToLoad); // Chuyển scene
        }
    }
}
