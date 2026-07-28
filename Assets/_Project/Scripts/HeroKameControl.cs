using System.Collections;
using UnityEngine;

public class HeroKameControl : MonoBehaviour
{
	private static readonly int StatusAnim = Animator.StringToHash("StatusAnim");
	public GameObject BulletMagic;

	private int Level;
	private int attackCount;

	public Sprite spriteMagic;

	public Animator Anim;

	private void Start()
	{
		Level = GameControl.Instance.Level;
		attackCount = GameControl.Instance.attackCountKame;
	}
	
	public void AddBullet()
	{
		Vector3 spawnPosition = gameObject.transform.position + new Vector3(1, 0, 0);
		GameObject bullet = Instantiate(BulletMagic, spawnPosition, Quaternion.identity);
		BulletControl bulletControl = bullet.GetComponent<BulletControl>();
		int damage = Level;
		// 크리티 확률 계산
		//int randomValue = UnityEngine.Random.Range(0, 100);
		//if (randomValue < CriticalRate)
		//{
		//	damage = damage * 2; // 크리티컬 데미지 (예: 2배)
		//}
		bulletControl.SetValues(spriteMagic, damage, false);
	}

	public void SetAnim(int _Anim)
	{
		Anim.SetInteger(StatusAnim, _Anim);
	}

	private IEnumerator AutoHide()
	{
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}

	public void CheckAttackCount()
	{
		attackCount--;
		if (attackCount <= 0)
		{
			SetAnim(2);
		}
	}

	public void AutoDestroy()
	{
		StartCoroutine(AutoHide());
	}
}
