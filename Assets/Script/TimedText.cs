using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimedText : MonoBehaviour
{
    public Text messageText; // Gán UI Text vào đây
    public float delayBeforeShow = 2f; // Thời gian chờ trước khi hiện (giây)
    public float duration = 5f; // Thời gian hiển thị (giây)

    void Start()
    {
        if (messageText == null)
        {
            Debug.LogError("⚠️ Chưa gán UI Text vào script TimedText!");
            return;
        }

        messageText.gameObject.SetActive(false); // Ẩn Text ban đầu
        StartCoroutine(ShowTextWithDelay());
    }

    IEnumerator ShowTextWithDelay()
    {
        Debug.Log("⏳ Đang chờ để hiển thị Text...");
        yield return new WaitForSeconds(delayBeforeShow); // Chờ trước khi hiện

        Debug.Log("✅ Hiển thị Text!");
        messageText.gameObject.SetActive(true); // Hiển thị Text

        yield return new WaitForSeconds(duration); // Chờ trong khoảng thời gian hiển thị

        Debug.Log("❌ Ẩn Text!");
        messageText.gameObject.SetActive(false); // Ẩn Text
    }
}
