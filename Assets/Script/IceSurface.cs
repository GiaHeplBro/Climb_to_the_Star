using UnityEngine;
using System.Collections;

public class IceSurface : MonoBehaviour
{
	public float slideForce = 300f; // Lực trượt, tăng nếu thấy trượt yếu
	public float slideTime = 0.5f;  // Thời gian trượt

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				Vector2 slideDirection = new Vector2(rb.linearVelocity.x >= 0 ? 1 : -1, 0); // Hướng trượt theo vận tốc trước đó
				rb.AddForce(slideDirection * slideForce); // Thêm lực đẩy nhân vật trượt

				StartCoroutine(SlowDown(rb));
			}
		}
	}

	private IEnumerator SlowDown(Rigidbody2D rb)
	{
		float time = 0;
		while (time < slideTime)
		{
			rb.linearVelocity = new Vector2(rb.linearVelocity.x * 0.98f, rb.linearVelocity.y); // Giảm tốc dần dần
			time += Time.deltaTime;
			yield return null;
		}
	}
}
