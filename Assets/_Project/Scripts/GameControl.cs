using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoSingleton<GameControl>
{
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

	public GameObject tempBossTraining;

	public GameObject PrefabEnemy;

	private bool isTraining;

	private float timeAddEnemy;

	public Text txtLevel;

	public Text txtNumClick;

	public Image imgnumClick;

	public int Level;

	public int Shield;

	private int CriticalRate;

	private int CriticalDamage;

	private int numClick;

	private int levelNumClick;

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
	
	public List<ItemControl> ListItemControlWeaponds;
	public List<ItemControl> ListItemControlShields;
	

	private void Awake()
	{
		DOTween.Init();
	}

	private void Start()
	{
		Player = PlayerControl.Instance;
		
		GetGameData();
		txtLevel.text = "Level:" + Level.ToString();
		txtGold.text = Gold.ToString();
		txtGem.text = Gem.ToString();
		txtNumClick.text = numClick.ToString() + "/" + levelNumClick.ToString();
		//imgnumClick.fillAmount = (float)numClick / (float)levelNumClick;
		
		// TODO
		CriticalRate = 10; // 10%
		
		Player.SpriteWeaponds.sprite = ListSpriteWeapons[Level - 1];
		Player.SpriteShield.sprite = ListSpriteShield[Shield - 1];
		
		btWeaponds.onClick.AddListener(ClickbtWeaponds);
		btShield.onClick.AddListener(ClickbtShield);
		btCloseItem.onClick.AddListener(CloseItem);
	}

	private void Update()
	{
	}

	private void GetGameData()
	{
		// load from `PlayerPrefs` using the `KeySave` keys, with sane defaults for first run
		Level = PlayerPrefs.GetInt(KeySave.Level, 1);
		Shield = PlayerPrefs.GetInt(KeySave.Shield, 1);
		CriticalRate = PlayerPrefs.GetInt(KeySave.Hair, 0);
		Gold = PlayerPrefs.GetInt(KeySave.Gold, 2000);
		Gem = PlayerPrefs.GetInt(KeySave.Gem, 100);
		Score = PlayerPrefs.GetInt(KeySave.HighScore, 0);
		
		numClick = PlayerPrefs.GetInt(KeySave.NumClick, 0);
		levelNumClick = Level * 10 + 500;
	}

	
	private void AddEnemy(int _health)
	{
	}

	private void GetNumClick()
	{
		numClick = PlayerPrefs.GetInt(KeySave.NumClick, 0);
	}
	
	private void AddNumClick()
	{
		numClick++;
		
		if (numClick >= levelNumClick)
		{
			NextLevel();
			return;
		}
		
		
		txtNumClick.text = numClick.ToString() + "/" + levelNumClick.ToString();
		//imgnumClick.fillAmount = (float)numClick / (float)levelNumClick;
		
		PlayerPrefs.SetInt(KeySave.NumClick, numClick);
		PlayerPrefs.Save();
	}

	private void SetRateClick()
	{
	}


	private void NextLevel()
	{
		Level++;
		numClick = 0;
		
		PlayerPrefs.SetInt(KeySave.Level, Level);
		PlayerPrefs.SetInt(KeySave.NumClick, numClick);
		PlayerPrefs.Save();
		
		txtLevel.text = "Level:" + Level.ToString();
		levelNumClick = Level * 10 + 500;

		txtNumClick.text = numClick.ToString() + "/" + levelNumClick.ToString();
		
		Player.SpriteWeaponds.sprite = ListSpriteWeapons[Level - 1];
	}
	
	public void PurchaseShield(int _level, int _cost)
	{
		if (Gold >= _cost && _level == Shield + 1)
		{
			Gold -= _cost;
			Shield++;
			
			Player.SpriteShield.sprite = ListSpriteShield[Shield - 1];
			
			PlayerPrefs.SetInt(KeySave.Shield, Shield);
			PlayerPrefs.SetInt(KeySave.Gold, Gold);
			PlayerPrefs.Save();
			
			txtGold.text = Gold.ToString();
		}
		else
		{
			Debug.Log("Not enough gold to purchase shield.");
		}
	}

	public void OnMouseDown2()
	{
		AddNumClick();
		PlayerControl.Instance.SetAnim(1);
		AddBullet();
	}

	private void AddBullet()
	{
		// instantiate a new bullet from the prefab and set its position to the player's position
		// TODO  생성되는 세로 위치를 플레이어 위치 기준으로 약간의 위 아래로 랜덤하게 생성되도록 수정 필요
		
		GameObject bullet = Instantiate(Bullet, Player.transform.position, Quaternion.identity);
		BulletControl bulletControl = bullet.GetComponent<BulletControl>();
		int damage = Level + Shield;
		// 크리티 확률 계산
		int randomValue = UnityEngine.Random.Range(0, 100);
		if (randomValue < CriticalRate)
		{
			damage = damage * 2; // 크리티컬 데미지 (예: 2배)
		}
		bulletControl.SetValues(ListSpriteBullets[Level - 1], damage, false);
	}

	public void AddtxtDamage(int _damage, Vector3 _Pos)
	{
		GameObject txtDamage = Instantiate(this.txtDamage, _Pos, Quaternion.identity);
		txtDamageControl txtDamageControl = txtDamage.GetComponent<txtDamageControl>();
		txtDamageControl.SetInfor(_damage);
		
		BonuesGold(_damage);
	}

	public void AddEFDamage(Vector3 _Pos, Transform _parent)
	{
		GameObject eFDamage = Instantiate(EFDamage, _Pos, Quaternion.identity);
		// set the parent of the effect to the specified parent transform
		eFDamage.transform.SetParent(_parent);
		
		// do tween DOFade(float to, float duration) 을 이용하여 점점 흐려지게
		// use DOTween to fade out the effect over 1 second
		SpriteRenderer spriteRenderer = eFDamage.GetComponent<SpriteRenderer>();
		// 시퀀스 생성
		Sequence mySequence = DOTween.Sequence();
		// 1초 대기 추가
		mySequence.PrependInterval(0.5f);
		// 스프라이트 페이드 (알파값 0으로 1초 동안)
		mySequence.Append(spriteRenderer.DOFade(0f, 0.5f));
		
	}

	public void BonuesGold(int _Bonues)
	{
		Gold += _Bonues;
		txtGold.text = Gold.ToString();
		PlayerPrefs.SetInt(KeySave.Gold, Gold);
		PlayerPrefs.Save();
	}

	public void BonuesGem(int _Bonues)
	{
		Gem += _Bonues;
		txtGem.text = Gem.ToString();
		PlayerPrefs.SetInt(KeySave.Gem, Gem);
		PlayerPrefs.Save();
	}

	public void AddNewBoss(Vector3 _Pos)
	{
		BossTraining bossTraining = FindObjectOfType<BossTraining>();
		if (bossTraining != null)
		{
			Destroy(bossTraining.gameObject);
			
			bossTraining.transform.position = _Pos;
			bossTraining.gameObject.SetActive(true);
		}
		
		tempBossTraining = Instantiate(BossTraining, _Pos, Quaternion.identity);

		BonuesGem(1);
	}

	private void AddItemWeaponds()
	{
		float normalizedX = 0f;
		ScrollRect scrollRect = ParentWeaponds.GetComponentInParent<ScrollRect>();
		
		if (ParentWeaponds.childCount > 0)
		{
			for (int i = ParentWeaponds.childCount - 1; i >= 0; i--)
			{
				ListItemControlWeaponds[i].ResetInfo();
			}

			normalizedX = (float)Level / (ParentWeaponds.childCount - 1);
			scrollRect.horizontalNormalizedPosition = normalizedX;
			
			return;
		}

		// 최초 생성 시에만 아이템 생성
		for (int i = 0; i < ListSpriteWeapons.Count; i++)
		{
			GameObject item = Instantiate(Item, ParentWeaponds);
			ItemControl itemControl = item.GetComponent<ItemControl>();
			
			int cost = (i + 1) * 1000; 
			itemControl.SetInfor(typeItem.ItemWeapons, ListSpriteWeapons[i], i +1, cost); 
			
			ListItemControlWeaponds.Add(itemControl);
		}
		
		normalizedX = (float)Level / (ParentWeaponds.childCount - 1);
		scrollRect.horizontalNormalizedPosition = normalizedX;

	}

	private void AddItemShields()
	{
		if (ParentShield.childCount > 0)
		{
			for (int i = ParentShield.childCount - 1; i >= 0; i--)
			{
				ListItemControlShields[i].ResetInfo();
			}

			return;
		}

		// 최초 생성 시에만 아이템 생성
		for (int i = 0; i < ListSpriteShield.Count; i++)
		{
			GameObject item = Instantiate(Item, ParentShield);
			ItemControl itemControl = item.GetComponent<ItemControl>();
			
			int cost = (i + 1) * 1000; 
			bool isUnlock = (i >= Level) ? true : false; 
			itemControl.SetInfor(typeItem.ItemShield, ListSpriteShield[i], i + 1, cost); 
			
			ListItemControlShields.Add(itemControl);
		}
	}
	
	private void ClearAllChildren(Transform _Parent)
	{
		foreach (Transform child in _Parent)
		{
			Destroy(child.gameObject);
		}
	}

	public void BuyItemShield(int _Gold)
	{
	}

	private void ClickbtWeaponds()
	{
		PanelShield.SetActive(false);
		
		PanelWeaponds.SetActive(true);
		btCloseItem.gameObject.SetActive(true);
		AddItemWeaponds();
	}

	private void ClickbtShield()
	{
		PanelWeaponds.SetActive(false);
		
		PanelShield.SetActive(true);
		btCloseItem.gameObject.SetActive(true);
		AddItemShields();
	}

	private void CloseItem()
	{
		PanelWeaponds.SetActive(false);
		PanelShield.SetActive(false);
		
		btCloseItem.gameObject.SetActive(false);
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
