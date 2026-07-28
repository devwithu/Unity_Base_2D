using System.Collections;
using UnityEngine;

public class HeroIronControl : MonoBehaviour
{
    public GameObject Bullet;

    private int Level;
    private int attackCount ;

    public Sprite sprite;
    
    private void Start()
    {
        Level = GameControl.Instance.Level;
        attackCount = GameControl.Instance.attackCountIron;
        AddBullet();
    }
	
    public void AddBullet()
    {
        for (int i = 0; i < attackCount; i++)
        {
            float randomX = UnityEngine.Random.Range(-1f, 1f);
            float randomY = UnityEngine.Random.Range(-1f, 1f);

            Vector3 spawnPosition = GameControl.Instance.gameObject.transform.position + new Vector3(-7 + randomX, 1 + randomY, 0);
            GameObject bullet = Instantiate(Bullet, spawnPosition, Quaternion.identity);
            BulletControl bulletControl = bullet.GetComponent<BulletControl>();
            int damage = Level;
            bulletControl.SetValues(GameControl.Instance.imIron, damage, false);
        }
    }
    
}