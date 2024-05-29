using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public ItemData item;

    public Button button;
    public Image icon;
    public TextMeshProUGUI quantityText;
    private Outline outline;

    public UIInventory inventory;

    public int index;
    public bool equipped;
    public int quantity;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = equipped;
    }

    // 슬롯의 아이템 정보를 UI에 설정하는 메서드
    public void Set()
    {
        icon.gameObject.SetActive(true);
        icon.sprite = item.icon;
        // 아이템 수량이 1보다 크면 텍스트를 설정하고, 그렇지 않다면 빈 문자열을 설정
        quantityText.text = quantity > 1 ? quantity.ToString() : string.Empty;

        if(outline != null)
        {
            outline.enabled = equipped;
        }
    }

    // 슬롯을 비우는 메서드
    public void Clear()
    {
        item = null;
        icon.gameObject.SetActive(false);
        quantityText.text = string.Empty;
    }

    // 슬롯 버튼이 클릭되었을 때 호출되는 메서드입니다.
    public void OnClickButton()
    {
        // 인벤토리 UI의 SelectItem 메서드를 호출하여 이 슬롯의 인덱스를 전달
        inventory.SelectItem(index);
    }
}
