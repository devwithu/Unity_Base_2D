using UnityEngine;

public class SoundManager : MonoBehaviour
{
	private static SoundManager instance;

	public AudioSource Aud;

	public AudioClip AudClick;

	public AudioClip AudHit;

	public AudioClip AudDie;

	public static SoundManager Instance
	{
		get
		{
			return null;
		}
	}

	private void Awake()
	{
	}

	public void PlayAudio(AudioClip _Aud)
	{
	}

	public void PlayClick()
	{
	}

	public void PlayHit()
	{
	}

	public void PlayDie()
	{
	}
}
