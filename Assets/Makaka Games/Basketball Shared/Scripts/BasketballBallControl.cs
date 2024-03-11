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

using System;

using UnityEngine;

#pragma warning disable 649

[HelpURL("https://makaka.org/unity-assets")]
public class BasketballBallControl : MonoBehaviour 
{
	[SerializeField]
	private ThrowingObject throwingObject;

	public SphereCollider sphereCollider;

	[SerializeField]
	private int failMaterialIndex = 0;
	
	private bool isFloored = false; 
	private bool isRingTriggerPassed = false; 
	private bool isNetTriggerPassed = false;
	private bool isFail = false;
	private bool isGoaled = false;
	private bool isClear = false;
	
	public static Action OnFail;
	public static Action <bool> OnGoal;
	
	private void Awake()
	{
		throwingObject.OnResetPhysicsBase += ResetBall;
	}

	public static BasketballBallControl GetComponent(
		ThrowingObject throwingObject)
	{
		if (throwingObject & throwingObject.monoBehaviourCustom)
		{
			return (BasketballBallControl)throwingObject.monoBehaviourCustom;
		}
		else
		{
			return null;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == BasketballTagControl.NetTrigger) 
		{
			if (isRingTriggerPassed)
			{
				SetGoaled();
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag) 
		{
			case BasketballTagControl.RingTrigger:

				if (!isNetTriggerPassed)
				{
					isRingTriggerPassed = true;
				}

				//DebugPrinter.Print("Ball — OnTriggerEnter() with Tag: "
				//+ other.gameObject.tag);

				break;

			case BasketballTagControl.NetTrigger:

				throwingObject.PlayAudioRandomlyDependingOnSpeed(
					BasketballAudioControl.Instance.netSoundsIndex, 
					false,
					BasketballAudioControl.Instance.netAudioSource);
				
				// BasketballAudioControl.Instance.netSoundsIndex;
				// BasketballAudioControl.Instance.netAudioSource;
				// Debug.Log("audioNet");

				isNetTriggerPassed = true;

				if (!isRingTriggerPassed)
				{
					SetFailed();

					//DebugPrinter.Print("failed, touched basket");
				}

				break;
		}
		
		if (other.gameObject.tag == BasketballTagControl.FailZone) 
		{
			SetFailed();

			//DebugPrinter.Print("failed, FailZone: " + other.gameObject.tag);
		}
	}
	
	private void OnCollisionEnter (Collision other)
	{
		if (BasketballAudioControl.Instance)
		{
			switch (other.gameObject.tag)
			{
				case BasketballTagControl.Ring:

					isClear = false;

					throwingObject.PlayAudioRandomlyDependingOnSpeed(
						BasketballAudioControl.Instance.ringSoundsIndex,
						false,
						BasketballAudioControl.Instance.ringAudioSource);

					break;

				case BasketballTagControl.Floor:

					if (!isFloored)
					{
						isFloored = true;

						SetFailed();

						//DebugPrinter.Print("failed, floor");
					}

					throwingObject.PlayAudioRandomlyDependingOnSpeed(
						BasketballAudioControl.Instance.floorSoundsIndex,
						false,
						BasketballAudioControl.Instance.floorAudioSource);

					break;

				case BasketballTagControl.Backboard:

					throwingObject.PlayAudioRandomlyDependingOnSpeed(
						 BasketballAudioControl.Instance.backboardSoundsIndex,
						false,
						BasketballAudioControl.Instance.backboardAudioSource);

					break;

				case BasketballTagControl.Pole:

					throwingObject.PlayAudioRandomlyDependingOnSpeed(
						BasketballAudioControl.Instance.poleSoundsIndex,
						false,
						BasketballAudioControl.Instance.poleAudioSource);

					break;

				case BasketballTagControl.Net:

					throwingObject.PlayAudioRandomlyDependingOnSpeed(
						BasketballAudioControl.Instance.netSoundsIndex,
						false,
						BasketballAudioControl.Instance.netAudioSource);

					break;
			}
		}
        else
        {
			DebugPrinter.Print(
				"BasketballAudioControl.Instance does not exists!");
		}
	}

	private void ResetBall()
	{
		//DebugPrinter.Print("Reset Ball.");

		isFloored = isRingTriggerPassed = isNetTriggerPassed =
			isFail = isGoaled = false;
		
		isClear = true;
	}
	
	private void SetGoaled()
	{
		if (!isGoaled && !isFail) 
		{
			isGoaled = true;

			if (OnGoal != null)
			{
				OnGoal(isClear);
			}
		}
	}

	private void SetFailed()
	{
		if (!isFail && !isGoaled) 
		{
			isFail = true;

			throwingObject.SetMaterial(failMaterialIndex);

			if (OnFail != null)
			{
				OnFail();
			}
		}
	}

}