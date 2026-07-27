using UnityEngine;
using UnityEngine.UI;

public class ItemControl : MonoBehaviour
{
	public Text txtLevel;

	public Text txtCost;

	public Button btBuy;

	public Image imItem;

	public typeItem typeIT;

	private int Level;

	public GameObject imLock;

	private int Cost;

	private void Start()
	{
		btBuy.onClick.AddListener(ClickItem);
	}

	public void SetInfor(typeItem _type, Sprite _spriteItem, int _Level, int _Cost)
	{
		typeIT = _type;
		imItem.sprite = _spriteItem;
		Level = _Level;
		Cost = _Cost;
		txtLevel.text = "Level " + Level.ToString();
		txtCost.text = Cost.ToString();

		ResetInfo();

	}

	public void ResetInfo()
	{
		if (Level == 1)
		{
			imLock.SetActive(false);
			btBuy.gameObject.SetActive(false);
			return;
		}
		
		if (Level <= GameControl.Instance.Level)
		{
			imLock.SetActive(false);
		}

		if (typeIT == typeItem.ItemWeapons)
		{
			btBuy.gameObject.SetActive(false);
		} 
		else if (typeIT == typeItem.ItemShield)
		{
			if (Level < GameControl.Instance.Shield + 1)
			{
				btBuy.gameObject.SetActive(false);
			}
			else if (Level == GameControl.Instance.Shield +1)
			{
				btBuy.gameObject.SetActive(true);
				
				if (Cost <= GameControl.Instance.Gold)
				{
					btBuy.interactable = true;
				}
				else
				{
					btBuy.interactable = false;
				}
			} 
			else
			{
				btBuy.gameObject.SetActive(true);
				btBuy.interactable = false;
			}
		}
	}
	
	private void ClickItem()
	{
		GameControl.Instance.PurchaseShield(Level, Cost);
		ResetInfo();
	}
}
