using UnityEngine;

public class JumpAnimation : MonoBehaviour
{
    public Animator anim;
    private Rigidbody2D rb;
    private Jump jumpScript;

    private bool isFallingHard = false;
    public float dropThreshold = -20f; // Tăng ngưỡng rơi mạnh để rơi sâu hơn mới kích hoạt

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpScript = GetComponent<Jump>(); // Lấy script Jump trên nhân vật
    }

    void Update()
    {
        if (jumpScript == null) return;

        // **1. Đứng yên**
        anim.SetBool("isIdle", jumpScript.isGrounded && Mathf.Abs(rb.linearVelocity.x) < 0.1f && Mathf.Abs(rb.linearVelocity.y) < 0.1f);

        // **2. Vận sức nhảy**
        anim.SetBool("isChargingJump", Input.GetKey("space") && jumpScript.isGrounded && jumpScript.canJump);

        // **3. Nhảy lên**
        anim.SetBool("isJumpingUp", rb.linearVelocity.y > 0.1f);

        // **4. Rơi xuống**
        anim.SetBool("isJumpingDown", rb.linearVelocity.y < -0.1f);

        // **5. Rơi mạnh -> "Drop"**
        if (!isFallingHard && !jumpScript.isGrounded && rb.linearVelocity.y < dropThreshold && transform.position.y < -5f)
        {
            isFallingHard = true;
            anim.SetBool("isFallingHard", true);
        }

        // **6. Đập mặt khi tiếp đất mạnh**
        if (isFallingHard && jumpScript.isGrounded)
        {
            anim.SetTrigger("isFaceplant");
            anim.SetBool("isFallingHard", false); // Tắt trạng thái rơi mạnh
            isFallingHard = false;
        }

        // **7. Di chuyển**
        anim.SetBool("isWalking", jumpScript.isGrounded && Mathf.Abs(rb.linearVelocity.x) > 0.1f);

        // **8. Thoát Faceplant nếu di chuyển hoặc đang vận sức nhảy**
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Faceplant") && jumpScript.isGrounded &&
            (Mathf.Abs(rb.linearVelocity.x) > 0.1f || anim.GetBool("isChargingJump")))
        {
            anim.SetTrigger("ForceExitFaceplant"); // Thêm trigger mới
        }
    }
}
