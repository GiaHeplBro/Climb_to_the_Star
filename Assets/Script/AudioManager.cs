using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource audioSource;
    public AudioClip[] backgroundMusic; // Mảng chứa nhạc cho từng VCam

    private int currentTrackIndex = -1; // Bài nhạc hiện tại

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Không bị reset khi load scene mới
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ChangeMusic(int index)
    {
        if (index >= 0 && index < backgroundMusic.Length && index != currentTrackIndex)
        {
            currentTrackIndex = index;
            audioSource.clip = backgroundMusic[index];
            audioSource.Play();
        }
    }
}
