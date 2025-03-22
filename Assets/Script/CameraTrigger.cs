using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	public int targetCameraIndex;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Debug.Log("Player chạm vào Trigger của Camera " + targetCameraIndex);
			CameraSwitcher switcher = FindObjectOfType<CameraSwitcher>();
			if (switcher != null)
			{
				switcher.SwitchCamera(targetCameraIndex);
			}
			else
			{
				Debug.LogWarning("Không tìm thấy CameraSwitcher trong Scene!");
			}
		}
	}
}
