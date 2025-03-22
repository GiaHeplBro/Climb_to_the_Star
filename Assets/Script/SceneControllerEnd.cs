using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string targetScene; // Đặt tên scene bạn muốn chuyển đến
    public float autoSkipTime = 60f; // Thời gian tự động chuyển Scene

    void Start()
    {
        // Bắt đầu đếm ngược để tự động chuyển Scene
        Invoke("SkipScene", autoSkipTime);
    }

    public void SkipScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}
