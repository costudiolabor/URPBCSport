/*
===================================================================
Unity Assets by MAKAKA GAMES: https://makaka.org/o/all-unity-assets
===================================================================

Online Docs (Latest): https://makaka.org/unity-assets
Offline Docs: You have a PDF file in the package folder.

=======
SUPPORT
=======

First of all, read the docs. If it didn’t help, get the support.

Web: https://makaka.org/support
Email: info@makaka.org

If you find a bug or you can’t use the asset as you need, 
please first send email to info@makaka.org
before leaving a review to the asset store.

I am here to help you and to improve my products for the best.
*/

using System.Collections;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

using TMPro;

[HelpURL("https://makaka.org/unity-assets")]
public class ARThrowingControl : MonoBehaviour
{
	[Header("UI")]

	[SerializeField]
	private GameObject canvasPause;

	[SerializeField]
	private GameObject canvasStart;

	[SerializeField]
	private TextMeshProUGUI canvasStartTextInfo;

	[SerializeField]
	[TextArea(3, 4)]
	private string canvasStartTextInfoARFoundation;

	[SerializeField]
	[TextArea(3, 4)]
	private string canvasStartTextInfoARCameraGYRO;

	[SerializeField]
	[TextArea(3, 4)]
	private string canvasStartTextInfoARCameraGYROAccelerometer;

	[Space]
	[SerializeField]
	private GameObject canvasesHUD;

	[Header("Game")]

	[SerializeField]
	private ThrowControl throwControl;

	[Space]
	[SerializeField]
	private UnityEvent OnARFoundationGameWorldInitialization;

	private bool isFirstStart = true;

    public void InitGameForARCameraGYRO(bool isAccelerometerMode = false)
	{
		StartCoroutine(InitGameForARCameraGYROCoroutine(isAccelerometerMode));
	}

	private IEnumerator InitGameForARCameraGYROCoroutine(
		bool isAccelerometerMode = false)
	{
		canvasStart.SetActive(true);

		canvasesHUD.SetActive(true);

		canvasStartTextInfo.text =
			isAccelerometerMode
			? canvasStartTextInfoARCameraGYROAccelerometer
			: canvasStartTextInfoARCameraGYRO;

		yield return null;

		InitThrowing(null);
	}

	public void SetARFoundationReady()
    {
		canvasesHUD.SetActive(false);
	}

	public void InitGameForARFoundationWithCamera(Transform camera)
    {
		StartCoroutine(
			InitGameForARFoundationWithCameraCoroutine(camera));
	}

	private IEnumerator InitGameForARFoundationWithCameraCoroutine(
		Transform camera)
    {
		canvasStart.SetActive(true);
		canvasStartTextInfo.text = canvasStartTextInfoARFoundation;

		canvasesHUD.SetActive(true);

		Vector3 playerLocalPosLast =
			ARPlayerControl.Current.transform.localPosition;

		Quaternion playerLocalRotLast =
			ARPlayerControl.Current.transform.localRotation;

		ARPlayerControl.Current.transform.parent = camera;
		ARPlayerControl.Current.transform.localPosition = playerLocalPosLast;
		ARPlayerControl.Current.transform.localRotation = playerLocalRotLast;

		yield return null;

		OnARFoundationGameWorldInitialization.Invoke();

		yield return null;
		
		InitThrowing(camera.GetComponent<Camera>());
	}

	public void RestartGame()
	{
		canvasStart.SetActive(false);

		if (isFirstStart)
		{
			isFirstStart = false;

			throwControl.GetFirstThrow();
		}
	}

	private void InitThrowing(Camera camera)
	{
		StartCoroutine(InitThrowingCoroutine(camera));
	}

	private IEnumerator InitThrowingCoroutine(Camera camera)
	{
		if (camera)
		{
			throwControl.cameraMain = camera;
		}

		yield return null;

		throwControl.gameObject.SetActive(true);
	}

	public void PauseGameWhenPlayerLeftSafeZone()
	{
		canvasPause.SetActive(true);

        if (isFirstStart)
        {
			canvasStart.SetActive(false);
		}
	}

	public void PlayGameWhenPlayerEnteredSafeZone()
	{
		canvasPause.SetActive(false);

		if (isFirstStart)
		{
			canvasStart.SetActive(true);
		}
	}
}
