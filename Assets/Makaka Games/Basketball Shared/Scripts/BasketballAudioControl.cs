﻿/*
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

using System.Collections;

#pragma warning disable 649

[HelpURL("https://makaka.org/unity-assets")]
public class BasketballAudioControl : MonoBehaviour 
{
	public static BasketballAudioControl Instance;
	
	[Header("Goal: Normal")]
	[SerializeField]
	private AudioSource goalNormalAudioSource;
	
	[SerializeField]
	private AudioClip goalNormal;
	
	[SerializeField]
	private float goalNormalDelay = 0f;
	
	[Header("Goal: Clear")]
	[SerializeField]
	private AudioSource goalClearAudioSource;
	
	[SerializeField]
	private AudioClip goalClear;
	
	[SerializeField]
	private float goalClearDelay = 0f;

	[Header("Goal: Set Big Ring")]
	[SerializeField]
	private AudioSource goalSetBigRingAudioSource;
	
	[SerializeField]
	private AudioClip goalSetBigRing;
	
	[SerializeField]
	private float goalSetBigRingDelay = 0f;

	[Header("Goal: Hoop Movement")]
	[SerializeField]
	private AudioSource goalHoopMovementAudioSource;
	
	[SerializeField]
	private AudioClip goalHoopMovement;
	
	[SerializeField]
	private float goalHoopMovementDelay = 0f;

	[Header("Fail")]
	[SerializeField]
	private AudioSource failAudioSource;
	
	[SerializeField]
	private AudioClip[] failCollisions;

	[Header("Collisions")]
	public AudioSource floorAudioSource;
	public int floorSoundsIndex = 1;

	[Space]
	public AudioSource poleAudioSource;
	public int poleSoundsIndex = 2;

	[Space]
	public AudioSource backboardAudioSource;
	public int backboardSoundsIndex = 3;

	[Space]
	public AudioSource ringAudioSource;
	public int ringSoundsIndex = 4;

	[Space]
	public AudioSource netAudioSource;
	public int netSoundsIndex = 5;

	private void Start()
	{
		Instance = this;
	}
	
	public void PlayGoalNormal()
	{
		StartCoroutine(PlayGoalNormalCoroutine());
	}

	public IEnumerator PlayGoalNormalCoroutine()
	{
        yield return new WaitForSeconds(goalNormalDelay);

        goalNormalAudioSource.PlayOneShot(goalNormal);
	}
	
	public void PlayGoalClear()
	{
		StartCoroutine(PlayGoalClearCoroutine());
	}

	public IEnumerator PlayGoalClearCoroutine()
	{
        yield return new WaitForSeconds(goalClearDelay);

        goalClearAudioSource.PlayOneShot(goalClear);
	}
	
	public void PlayGoalSetBigRing()
	{
		StartCoroutine(PlayGoalSetBigRingCoroutine());
	}

	public IEnumerator PlayGoalSetBigRingCoroutine()
	{
        yield return new WaitForSeconds(goalSetBigRingDelay);

        goalSetBigRingAudioSource.PlayOneShot(goalSetBigRing);
	}

	public void PlayGoalHoopMovement()
	{
        StartCoroutine(PlayGoalHoopMovementCoroutine());
	}

	public IEnumerator PlayGoalHoopMovementCoroutine()
	{
        yield return new WaitForSeconds(goalHoopMovementDelay);

        goalHoopMovementAudioSource.PlayOneShot(goalHoopMovement);
	}

    public void PlayFail()
    {
        failAudioSource.PlayOneShot(
			failCollisions[UnityEngine.Random.Range(0, failCollisions.Length)]);
    }
}
