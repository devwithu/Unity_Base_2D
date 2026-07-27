using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class txtDamageControl : MonoBehaviour
{
	public Text txtDamage;

	public Rigidbody2D Rig;

	private void Start()
	{
		StartCoroutine(AutoDestroy());
		
	}

	public void SetInfor(int _damage)
	{
		txtDamage.text = _damage.ToString();
		AddForce();
	}

	private void AddForce()
	{
		// Add a random force to the text damage
		float randomX = Random.Range(-1f, 1f);
		float randomY = Random.Range(1f, 2f);
		Vector2 force = new Vector2(randomX, randomY);
		Rig.AddForce(force * 100f);
	}

	private IEnumerator AutoDestroy()
	{
		Destroy(gameObject, 3f);
		yield return null;
	}
}
