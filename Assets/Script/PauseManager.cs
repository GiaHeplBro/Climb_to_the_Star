using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenu; // Kéo Panel Pause vào đây trong Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Dừng game
        isPaused = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Tiếp tục game
        isPaused = false;
    }

    public void LoadMainMenu()
    {
        // Tìm nhân vật và lưu vị trí trước khi thoát về menu
        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Đảm bảo nhân vật có tag "Player"
        if (player != null)
        {
            PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
            PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
            PlayerPrefs.Save();
            Debug.Log("✅ Đã lưu vị trí: " + player.transform.position.x + ", " + player.transform.position.y);
        }

        Time.timeScale = 1f; // Đảm bảo game tiếp tục khi quay lại menu
        SceneManager.LoadScene("Menu"); // Đổi thành tên scene menu của bạn
    }


    public void QuitGame()
    {
        Application.Quit(); // Thoát game
    }
}
