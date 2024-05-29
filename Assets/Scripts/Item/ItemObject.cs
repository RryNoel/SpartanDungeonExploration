using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable
{
    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    public string GetInteractPrompt()
    {
        // 아이템 이름과 설명을 문자열로 반환
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        // 플레이어의 아이템 데이터를 현재 아이템 데이터로 설정
        CharacterManager.Instance.Player.itemData = data;
        // 플레이어의 아이템 추가 이벤트 호풀
        CharacterManager.Instance.Player.addItem?.Invoke();
        Destroy(gameObject);
    }
}
