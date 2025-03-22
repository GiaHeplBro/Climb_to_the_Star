using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Rigidbody2D rb;
	private float moveInput;
	public float speed;

	public static bool isWalking; 

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		moveInput = Input.GetAxisRaw("Horizontal");
		isWalking = Mathf.Abs(moveInput) > 0;
	}

	void FixedUpdate()
	{
		rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);
	}
}
