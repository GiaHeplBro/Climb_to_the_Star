using UnityEngine;
using Cinemachine;

public class CameraMusicController : MonoBehaviour
{
    public CinemachineBrain cinemachineBrain;
    public CinemachineVirtualCamera[] virtualCameras; // Gán CM_VCam1 -> CM_VCam4

    private void Start()
    {
        // Gọi ngay khi bắt đầu để đảm bảo nhạc đúng
        UpdateMusic();
    }

    private void Update()
    {
        UpdateMusic();
    }

    private void UpdateMusic()
    {
        for (int i = 0; i < virtualCameras.Length; i++)
        {
            if (virtualCameras[i].Priority == cinemachineBrain.ActiveVirtualCamera.Priority)
            {
                AudioManager.instance.ChangeMusic(i);
                break;
            }
        }
    }
}
