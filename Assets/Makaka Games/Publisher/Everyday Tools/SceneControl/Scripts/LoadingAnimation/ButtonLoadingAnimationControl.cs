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

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonLoadingAnimationControl : MonoBehaviour
{
	[Space]
	[SerializeField]
	private Button button;

	[SerializeField]
	private Image imageOverlayOnComplete;

	[SerializeField]
	private GameObject loadingAnimation;
	
	public UnityEvent EmulClick;///////////// <summary>
	

	private void Start()
	{
		button.interactable = false;
	}

	public void Complete()
	{
		//Debug.LogError("Complete");
		button.interactable = true;
	
		imageOverlayOnComplete.enabled = true;
	
		loadingAnimation.SetActive(false);
		
		
		EmulClick?.Invoke();///////////////
		
	}
}
