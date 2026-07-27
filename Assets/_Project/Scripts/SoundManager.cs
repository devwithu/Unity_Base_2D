using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
	public AudioSource Aud;

	public AudioClip AudClick;

	public AudioClip AudHit;

	public AudioClip AudDie;
	
	private void Awake()
	{
	}

	public void PlayAudio(AudioClip _Aud)
	{
		Aud.PlayOneShot(_Aud);
	}

	public void PlayClick()
	{
		PlayAudio(AudClick);
	}

	public void PlayHit()
	{
		PlayAudio(AudHit);
	}

	public void PlayDie()
	{
		PlayAudio(AudDie);
	}
}
