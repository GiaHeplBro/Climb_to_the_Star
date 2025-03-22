using UnityEngine;

public class WindEffectController : MonoBehaviour
{
	public Vector3 leftPosition;   // Vị trí khi gió từ phải -> trái
	public Vector3 rightPosition;  // Vị trí khi gió từ trái -> phải

	public float leftRotationZ = 20f;  // Góc quay khi gió từ phải -> trái
	public float rightRotationZ = -20f; // Góc quay khi gió từ trái -> phải

	public void ChangeWindDirection(Vector2 windDirection)
	{
		if (windDirection.x > 0)
		{
			// Gió từ trái sang phải
			transform.position = rightPosition;
			transform.rotation = Quaternion.Euler(0, 0, rightRotationZ);
		}
		else
		{
			// Gió từ phải sang trái
			transform.position = leftPosition;
			transform.rotation = Quaternion.Euler(0, 0, leftRotationZ);
		}
	}
}
