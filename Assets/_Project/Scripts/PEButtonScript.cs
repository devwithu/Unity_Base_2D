using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PEButtonScript : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	private Button myButton;

	public ButtonTypes ButtonType;

	private void Start()
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}

	public void OnButtonClicked()
	{
	}
}
