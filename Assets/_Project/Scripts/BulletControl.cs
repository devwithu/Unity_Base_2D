using System.Collections;
using DG.Tweening;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
	public bool isMove;

	private float MoveSpeed;

	public int Damage;

	public SpriteRenderer Sprite;

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	public void SetValues(Sprite _sprite, int _damage, bool _CreateDamage)
	{
		Sprite.sprite = _sprite;
		Damage = _damage;
		isMove = true;
		MoveSpeed = 5f;
		StartCoroutine(AutoDestroy());
	}

	private void Update()
	{
		MoveRight();
	}

	private void MoveRight()
	{
		// Move the bullet to the right
		if (isMove)
		{
			//transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
			transform.DOMoveX(transform.position.x + MoveSpeed , 2f, false);
		}
	}

	private IEnumerator AutoDestroy()
	{
		yield return new WaitForSeconds(3f);
		Destroy(gameObject);
	}
}
