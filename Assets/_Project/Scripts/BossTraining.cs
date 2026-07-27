using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossTraining : MonoBehaviour
{
	private static readonly int StatusAnim = Animator.StringToHash("StatusAnim");
	private bool isAddnewBoss;

	private int Health;

	public Animator Anim;

	public Image imHealth;

	public List<Sprite> ListSpriteBoss;

	public SpriteRenderer SpriteBoss;

	private void Start()
	{
		Health = 100;
		SetHealthBar();
		RandomSprite();
		
	}

	private void Update()
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		// Check if the other collider is a bullet
		if (other.CompareTag("Bullet"))
		{
			Debug.Log("Bullet hit the boss training!");
			// Get the BulletControl component from the bullet
			BulletControl bullet = other.GetComponent<BulletControl>();
			
			GameControl.Instance.AddEFDamage(other.transform.position, this.transform);
			GameControl.Instance.AddtxtDamage(bullet.Damage, bullet.transform.position);
			
			Destroy(other.gameObject);
			
			SetAnim(1);
			//Health--;
			Health -= 20;
			SetHealthBar();

			if (Health <= 0)
			{
				GameControl.Instance.AddNewBoss(this.gameObject.transform.position);
			}

			SoundManager.Instance.PlayHit();
		}
	}

	private void OneHit(int _Damage)
	{
		
		
	}

	private void SetAnim(int _sttAnim)
	{
		Anim.SetInteger(StatusAnim, _sttAnim);
	}

	private void SetHealthBar()
	{
		imHealth.fillAmount = (float)Health / 100f;
	}

	private void CheckDie()
	{
	}

	private void RandomSprite()
	{
		SpriteBoss.sprite = ListSpriteBoss[Random.Range(0, ListSpriteBoss.Count)];
	}
}
