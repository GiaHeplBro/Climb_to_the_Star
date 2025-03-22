using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI jumpScoreText;
    private int jumpScore;

    void Start()
    {
        // 🔹 Load số lần nhảy từ PlayerPrefs
        jumpScore = PlayerPrefs.GetInt("JumpScore", 0);
        UpdateJumpScoreUI();
    }

    public void AddJumpScore()
    {
        jumpScore++;
        UpdateJumpScoreUI();

        // 🔹 Lưu điểm số vào PlayerPrefs
        PlayerPrefs.SetInt("JumpScore", jumpScore);
        PlayerPrefs.Save(); // Đảm bảo lưu dữ liệu ngay lập tức
    }

    private void UpdateJumpScoreUI()
    {
        jumpScoreText.text = "Jumps: " + jumpScore;
    }
}
