using UnityEngine;

public class Jump : MonoBehaviour
{
    public float walkSpeed;
    public float jumpValue = 0.0f;
    public bool isGrounded;
    public bool canJump = true;
    private bool isChargingJump = false;

    private float moveInput;
    private Rigidbody2D rb;
    public LayerMask groundMask;
    public PhysicsMaterial2D bouncerMat, normalMat;

    public float wallBounceForce = 5f; // 🔹 Lực phản khi va vào tường

    Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        rb = gameObject.GetComponent<Rigidbody2D>();

        // Load vị trí từ PlayerPrefs nếu có
        float x = PlayerPrefs.GetFloat("PlayerX", transform.position.x);
        float y = PlayerPrefs.GetFloat("PlayerY", transform.position.y);
        transform.position = new Vector2(x, y);
        Debug.Log("✅ Đã load vị trí nhân vật: " + x + ", " + y);
    }


    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // Kiểm tra nhân vật có đang đứng trên mặt đất hay không
        isGrounded = Physics2D.OverlapBox(new Vector2(transform.position.x, transform.position.y - 0.5f), new Vector2(0.9f, 0.4f), 0f, groundMask);

        // Khi chạm đất, reset trạng thái nhảy
        if (isGrounded && !isChargingJump)
        {
            canJump = true;
        }

        // Khi nhân vật không vận sức nhảy, cho phép di chuyển
        if (jumpValue == 0.0f && isGrounded && canJump && !isChargingJump)
        {
            rb.linearVelocity = new Vector2(moveInput * walkSpeed, rb.linearVelocity.y);
        }

        // Chuyển vật liệu bề mặt khi vận sức nhảy
        rb.sharedMaterial = (jumpValue > 0) ? bouncerMat : normalMat;

        // **BẮT ĐẦU VẬN SỨC NHẢY**
        if (Input.GetKey("space") && isGrounded && canJump)
        {
            isChargingJump = true;
            jumpValue += 0.5f;

            // Giới hạn tối đa jumpValue (ví dụ: 25)
            jumpValue = Mathf.Clamp(jumpValue, 0, 25);

            rb.linearVelocity = Vector2.zero;
        }

        // **THỰC HIỆN NHẢY**
        if (Input.GetKeyUp("space") && isGrounded && canJump)
        {
            if (jumpValue > 0)
            {
                rb.linearVelocity = new Vector2(moveInput * walkSpeed, jumpValue);
                canJump = false; // Vô hiệu hóa nhảy tiếp khi chưa chạm đất
                isChargingJump = false; // Hủy trạng thái vận sức

                FindObjectOfType<ScoreManager>().AddJumpScore();
            }
            jumpValue = 0.0f; // Reset lực nhảy
        }

        // **CƠ CHẾ PHẢN LỰC KHI VA CHẠM TƯỜNG (WALL BOUNCE)**
        if (!isGrounded)
        {
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.6f, groundMask);
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.6f, groundMask);

            if (hitLeft.collider != null)
            {
                // Nếu va vào tường bên trái, đẩy sang phải
                rb.linearVelocity = new Vector2(wallBounceForce, rb.linearVelocity.y);
            }
            else if (hitRight.collider != null)
            {
                // Nếu va vào tường bên phải, đẩy sang trái
                rb.linearVelocity = new Vector2(-wallBounceForce, rb.linearVelocity.y);
            }
        }

        // **KHÔI PHỤC NHẢY KHI CHẠM ĐẤT**
        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            canJump = true;
            isChargingJump = false; // Đảm bảo không bị kẹt trong trạng thái vận sức
        }



        // **HÀM QUAY ĐẦU**
        FlipCharacter();

        Respawn();
    }

    // Quay đầu nhân vật theo hướng di chuyển
    void FlipCharacter()
    {
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Quay mặt phải
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Quay mặt trái
    }

    // Respawn khi nhấn R
    private void Respawn()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = startPos;
            transform.rotation = new Quaternion();
        }
        else if (Input.GetKeyDown(KeyCode.T))
        {
            startPos = transform.position;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.5f), new Vector2(0.9f, 0.4f));

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * 0.6f);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * 0.6f);
    }
}
