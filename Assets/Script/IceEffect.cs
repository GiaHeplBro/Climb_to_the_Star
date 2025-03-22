using UnityEngine;

public class IceEffect : MonoBehaviour
{
	public float slideForce = 5f; // Điều chỉnh mức độ trượt
	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ice"))
		{
			Vector2 slideDirection = new Vector2(rb.linearVelocity.x, 0).normalized;
			rb.AddForce(slideDirection * slideForce, ForceMode2D.Force);
		}
	}
}
