using UnityEngine;

public class PlayerControl : MonoSingleton<PlayerControl>
{
	public Animator Anim;
	
	private static readonly int StatusAnim = Animator.StringToHash("StatusAnim");

	public SpriteRenderer SpriteWeaponds;

	public SpriteRenderer SpriteShield;

	private void Awake()
	{
		//Anim = GetComponent<Animator>();
	}

	public void SetAnim(int _status)
	{
		Anim.SetInteger(StatusAnim, _status);
	}

	public void SetWeaponds(int _level)
	{
	}

	public void GetWeaponds()
	{
	}

	public void GetShield()
	{
	}

	public void SetShield()
	{
	}

	private void Start()
	{
	}
}
