using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int Health;
	private float MoveSpeed;

	public Animator Anim;

	public List<Sprite> ListSpriteEnemy;

	public SpriteRenderer SpriteBoss;

	private int maxHealth;

	private bool isMove;

	private void Start()
	{
		RandomSprite();
		MoveSpeed = 5f;
		isMove = true;
	}

	private void Update()
	{
		MoveLeft();
	}

	public void SetValues(int _health)
	{
		maxHealth = _health;
		Health = _health;
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.CompareTag("Bullet") && !other.CompareTag("Enemy"))
		{
			Destroy(gameObject);
			return;
		}
		
		// Get the BulletControl component from the bullet
		BulletControl bullet = other.GetComponent<BulletControl>();
		
		if(bullet == null) return;
		
		GameControl.Instance.AddEFDamage(other.transform.position, this.transform);
		GameControl.Instance.AddtxtDamage(bullet.Damage, bullet.transform.position);
		
		int damage = bullet.Damage;
		Destroy(other.gameObject);
		
		Health -= damage;
		GameControl.Instance.AddScore(damage);

		SetHealthBar();

		if (Health <= 0)
		{
			Destroy(this.gameObject);
		}

		SoundManager.Instance.PlayHit();
	
	}

	private void OneHit(int _Damage)
	{
	}

	private void SetHealthBar()
	{
	}

	private void CheckDie()
	{
	}

	private void RandomSprite()
	{
		SpriteBoss.sprite = ListSpriteEnemy[Random.Range(0, ListSpriteEnemy.Count)];
	}

	private void MoveLeft()
	{
		
		if (isMove)
		{
			// Move the enemy to the left
			transform.Translate(Vector3.left * MoveSpeed * Time.deltaTime);

		}
	}
}
