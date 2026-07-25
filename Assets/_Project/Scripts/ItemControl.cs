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
	}

	public void SetInfor(typeItem _type, Sprite _spriteItem, int _Level, int _Cost, bool _isUnlock, bool _isShowBuy)
	{
	}

	private void ClickItem()
	{
	}
}
