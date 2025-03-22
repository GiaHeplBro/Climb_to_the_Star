using UnityEngine;

public class WindZone : MonoBehaviour
{
	public float windForce = 5f;
	private Vector2 windDirection = Vector2.right;
	public float switchTime = 3f;
	private float timer;

	public WindEffectController windEffectController; // Tham chiếu đến hiệu ứng gió

	private void Start()
	{
		timer = switchTime;
	}

	private void Update()
	{
		timer -= Time.deltaTime;
		if (timer <= 0)
		{
			windDirection *= -1; // Đảo chiều gió
			timer = switchTime;
			Debug.Log("Gió đã đổi hướng: " + windDirection);

			// Cập nhật hiệu ứng tuyết rơi
			if (windEffectController != null)
			{
				windEffectController.ChangeWindDirection(windDirection);
			}
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				rb.AddForce(windDirection * windForce, ForceMode2D.Force);
				Debug.Log("Gió đang đẩy nhân vật: " + windDirection);
			}
		}
	}
}
