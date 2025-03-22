using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public GameObject infoPanel; // Kéo Panel vào đây trong Inspector

    // Hàm mở panel
    public void ShowPanel()
    {
        infoPanel.SetActive(true);
    }

    // Hàm đóng panel
    public void HidePanel()
    {
        infoPanel.SetActive(false);
    }
}
