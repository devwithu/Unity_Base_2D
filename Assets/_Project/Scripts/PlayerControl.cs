using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	public Animator Anim;

	private static PlayerControl instance;

	public SpriteRenderer SpriteWeaponds;

	public SpriteRenderer SpriteShield;

	public static PlayerControl Instance
	{
		get
		{
			return null;
		}
	}

	private void Awake()
	{
	}

	public void SetAnim(int _status)
	{
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
