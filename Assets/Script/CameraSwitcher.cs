using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
	public CinemachineVirtualCamera[] cameras;
	private int currentCameraIndex = 0;

	void Start()
	{
		ActivateCamera(currentCameraIndex);
	}

	public void SwitchCamera(int targetIndex)
	{
		if (targetIndex >= 0 && targetIndex < cameras.Length)
		{
			currentCameraIndex = targetIndex;
			ActivateCamera(currentCameraIndex);
		}
	}

	void ActivateCamera(int index)
	{
		for (int i = 0; i < cameras.Length; i++)
		{
			cameras[i].Priority = (i == index) ? 10 : 1;
		}
		Debug.Log("Camera đã chuyển đến: " + index);
	}
}
