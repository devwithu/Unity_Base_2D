using System.Collections;
using UnityEngine;

public class AutoDestroyG : MonoBehaviour
{
	public float time;

	private void Start()
	{
		StartCoroutine(DestroyG());
	}

	private IEnumerator DestroyG()
	{
		yield return new WaitForSeconds(time);
		Destroy(gameObject);
	}
}
