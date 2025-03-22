using UnityEngine;

public class JumpSound : MonoBehaviour
{
    public AudioSource jumpUpAudioSource; // Âm thanh khi nhảy lên
    public AudioSource moveAudioSource;   // Âm thanh khi di chuyển
    public AudioSource jumpDownAudioSource; // Âm thanh khi tiếp đất

    public AudioClip jumpUpSound;    // Âm thanh khi thả Space sau khi dồn lực
    public AudioClip moveSound;      // Âm thanh bước chân khi di chuyển
    public AudioClip jumpDownSound;  // Âm thanh khi tiếp đất

    private Jump jumpScript;
    private bool wasGrounded;
    private bool hasChargedJump = false; // Đã dồn lực nhảy chưa

    void Start()
    {
        jumpScript = GetComponent<Jump>();
        wasGrounded = jumpScript.isGrounded;

        if (jumpUpAudioSource == null) jumpUpAudioSource = gameObject.AddComponent<AudioSource>();
        if (moveAudioSource == null) moveAudioSource = gameObject.AddComponent<AudioSource>();
        if (jumpDownAudioSource == null) jumpDownAudioSource = gameObject.AddComponent<AudioSource>();

        moveAudioSource.loop = true; // Âm bước chân sẽ phát liên tục khi di chuyển
    }

    void Update()
    {
        bool isChargingJump = Input.GetKey(KeyCode.Space) && jumpScript.isGrounded && jumpScript.canJump;
        bool isJumping = Input.GetKeyUp(KeyCode.Space) && hasChargedJump; // Chỉ nhảy nếu đã dồn lực
        bool isMoving = Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0.1f;

        // 🎵 Đánh dấu rằng nhân vật đã dồn lực khi giữ Space
        if (isChargingJump)
        {
            hasChargedJump = true;
        }

        // 🎵 Khi THẢ Space sau khi đã dồn lực → phát JumpUp Sound
        if (isJumping)
        {
            PlayJumpUpSound();
            hasChargedJump = false; // Reset lại trạng thái dồn lực
        }

        // 🎵 Phát âm thanh bước chân khi di chuyển (trừ khi đang dồn lực nhảy)
        if (jumpScript.isGrounded && isMoving && !isChargingJump)
        {
            if (!moveAudioSource.isPlaying)
            {
                moveAudioSource.clip = moveSound;
                moveAudioSource.Play();
            }
        }
        else
        {
            moveAudioSource.Stop();
        }

        // 🎵 Phát âm thanh khi tiếp đất
        if (jumpScript.isGrounded && !wasGrounded)
        {
            PlayJumpDownSound();
        }

        wasGrounded = jumpScript.isGrounded;
    }

    void PlayJumpUpSound()
    {
        if (jumpUpSound != null)
        {
            Debug.Log("🔊 Phát JumpUpSound"); // Debug để kiểm tra
            jumpUpAudioSource.PlayOneShot(jumpUpSound);
        }
        else
        {
            Debug.LogWarning("⚠️ jumpUpSound chưa được gán!");
        }
    }

    void PlayJumpDownSound()
    {
        if (jumpDownSound != null)
        {
            jumpDownAudioSource.PlayOneShot(jumpDownSound);
        }
    }
}
