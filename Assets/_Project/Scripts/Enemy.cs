using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int Health;

	public Animator Anim;

	public List<Sprite> ListSpriteEnemy;

	public SpriteRenderer SpriteBoss;

	private int maxHealth;

	private bool isMove;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetValues(int _health)
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
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
	}

	private void MoveLeft()
	{
	}
}
