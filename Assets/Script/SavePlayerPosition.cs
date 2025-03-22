using UnityEngine;

public class SavePlayerPosition : MonoBehaviour
{
    public Transform player; // Kéo nhân vật vào đây

    public void SavePosition()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.Save();
        Debug.Log("📀 Vị trí nhân vật đã được lưu!");
    }
}
