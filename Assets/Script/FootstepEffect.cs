using UnityEngine;

public class FootstepEffect : MonoBehaviour
{
	public GameObject grassEffectPrefab;
	public GameObject snowEffectPrefab;
	public GameObject metalEffectPrefab;

	private string currentSurface = "";

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Xác định bề mặt hiện tại
		if (other.CompareTag("Grass"))
		{
			currentSurface = "Grass";
		}
		else if (other.CompareTag("Snow"))
		{
			currentSurface = "Snow";
		}
		else if (other.CompareTag("Metal"))
		{
			currentSurface = "Metal";
		}
	}

	public void SpawnFootstepEffect()
	{
		GameObject effectPrefab = null;

		// Chọn hiệu ứng phù hợp
		if (currentSurface == "Grass")
		{
			effectPrefab = grassEffectPrefab;
		}
		else if (currentSurface == "Snow")
		{
			effectPrefab = snowEffectPrefab;
		}
		else if (currentSurface == "Metal")
		{
			effectPrefab = metalEffectPrefab;
		}

		if (effectPrefab != null)
		{
			Vector3 spawnPosition = transform.position + new Vector3(0, -0.5f, 0);
			Instantiate(effectPrefab, spawnPosition, Quaternion.identity);
		}
	}
}
