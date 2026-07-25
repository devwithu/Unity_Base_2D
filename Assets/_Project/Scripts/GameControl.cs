using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
	private static GameControl instance;

	public PlayerControl Player;

	public GameObject Bullet;

	public GameObject txtDamage;

	public GameObject EFDamage;

	public GameObject EFBossDie;

	public GameObject BossTraining;

	public GameObject PanelWeaponds;

	public Transform ParentWeaponds;

	public GameObject PanelShield;

	public Transform ParentShield;

	public Button btWeaponds;

	public Button btShield;

	public Button btCloseItem;

	public GameObject Item;

	public GameObject tempBosStraining;

	public GameObject PrefabEnemy;

	private bool isTraining;

	private float timeAddEnemy;

	public Text txtLevel;

	public Text txtNumClick;

	public Image imgnumClick;

	private int Level;

	private int Shield;

	private int CriticalRate;

	private int CriticalDamage;

	private int numClick;

	private int tempNumClick;

	public Text txtGold;

	public Text txtGem;

	public int Gold;

	public int Gem;

	public GameObject HeroesMagic;

	public GameObject HeroesKame;

	public Sprite imIron;

	public Button btHeroesKame;

	public Button btHeroMagic;

	public Button btHeroesIron;

	public Button btEndless;

	private int Score;

	private int startHealth;

	public Text txtScore;

	public Text txtHighScore;

	public GameObject panelEndGame;

	public Text txtPopUpScore;

	public Button btCloseEndGame;

	public List<Sprite> ListSpriteBullets;

	public List<Sprite> ListSpriteWeapons;

	public List<Sprite> ListSpriteShield;

	public static GameControl Instance
	{
		get
		{
			return null;
		}
	}

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void AddEnemy(int _health)
	{
	}

	private void GetNumClick()
	{
	}

	private void GetOldNumClick()
	{
	}

	private void ChangeNumClick()
	{
	}

	private void SetRateClick()
	{
	}

	private void GetLevel()
	{
	}

	public void GetShield()
	{
	}

	private void NextLevel()
	{
	}

	public void OnMouseDown2()
	{
	}

	private void AddBullet()
	{
	}

	public void AddtxtDamage(int _damage, Vector3 _Pos)
	{
	}

	public void AddEFDamage(Vector3 _Pos, Transform _parent)
	{
	}

	private void GetGold()
	{
	}

	private void GetGem()
	{
	}

	public void BonuesGold(int _Bonues)
	{
	}

	public void BonuesGem(int _Bonues)
	{
	}

	public void AddNewBoss(Vector3 _Pos)
	{
	}

	private void AddItemWeaponds()
	{
	}

	private void AddItemShield()
	{
	}

	public void NextShield()
	{
	}

	private void ClearAllChildren(Transform _Parent)
	{
	}

	public void BuyItemShield(int _Gold)
	{
	}

	private void ClickbtWeaponds()
	{
	}

	private void ClickbtShield()
	{
	}

	private void CloseItem()
	{
	}

	private void AddHeroesMagic()
	{
	}

	private void AddHeroesKame()
	{
	}

	private void AddHeroesIron()
	{
	}

	private IEnumerator ShowbtMagic()
	{
		return null;
	}

	private IEnumerator ShowbtKame()
	{
		return null;
	}

	public void StartEndless()
	{
	}

	public void BonuesScore(int _Score)
	{
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
	}

	private void EndGame()
	{
	}

	private void GetHideScore()
	{
	}

	private void ClickCloseEndGame()
	{
	}
}
