using System.Collections;
using UnityEngine;

public class UltimateCloud : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Collider2D cloudCollider;
    private Vector3 startPosition;

    public Vector3 moveDirection = Vector3.right; // Hướng di chuyển (Vector3.right: ngang, Vector3.up: lên xuống)
    public float moveDistance = 3f; // Khoảng cách di chuyển
    public float moveSpeed = 2f; // Tốc độ di chuyển
    public float bounceForce = 15f; // Lực bật nhảy
    public float disappearDelay = 1f; // Thời gian trước khi mây biến mất
    public float reappearDelay = 3f; // Thời gian xuất hiện lại

    private bool movingForward = true;
    private bool isDisappearing = false; // Tránh kích hoạt nhiều lần

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cloudCollider = GetComponent<Collider2D>();
        startPosition = transform.position;
    }

    private void Update()
    {
        MoveCloud();
    }

    private void MoveCloud()
    {
        float movement = moveSpeed * Time.deltaTime;
        if (movingForward)
        {
            transform.position += moveDirection * movement;
            if (Vector3.Distance(startPosition, transform.position) >= moveDistance)
                movingForward = false;
        }
        else
        {
            transform.position -= moveDirection * movement;
            if (Vector3.Distance(startPosition, transform.position) <= 0.1f)
                movingForward = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // 🔵 Bật nhân vật lên cao hơn bình thường
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, bounceForce);
            }

            // 🏗 Gán nhân vật làm con của mây để di chuyển theo
            collision.transform.SetParent(transform);

            if (!isDisappearing) // Chỉ kích hoạt 1 lần
            {
                StartCoroutine(DisappearAndReappear(collision.transform));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ❌ Hủy quan hệ cha-con khi rời khỏi mây
            collision.transform.SetParent(null);
        }
    }

    IEnumerator DisappearAndReappear(Transform player)
    {
        isDisappearing = true;
        yield return new WaitForSeconds(disappearDelay);

        // 🌫 Làm mờ dần mây
        for (float alpha = 1; alpha > 0; alpha -= 0.1f)
        {
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0.05f);
        }

        spriteRenderer.enabled = false;
        cloudCollider.enabled = false;

        // 💥 Khi mây biến mất, nhân vật rơi xuống
        if (player != null)
        {
            player.SetParent(null);
        }

        yield return new WaitForSeconds(reappearDelay);

        spriteRenderer.enabled = true;
        cloudCollider.enabled = true;

        // Hiện dần lại
        for (float alpha = 0; alpha < 1; alpha += 0.1f)
        {
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            yield return new WaitForSeconds(0.05f);
        }

        isDisappearing = false;
    }
}
