using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string sceneToLoad; // Đặt tên scene cần chuyển trong Inspector

    public void PlayGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game exited!"); // Chỉ hiển thị trên Editor, không hoạt động khi build game
    }
}
