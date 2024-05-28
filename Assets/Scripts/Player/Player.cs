using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;

    private void Awake()
    {
        // CharacterManager의 인스턴스에 이 Player 인스턴스를 설정
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
    }
}
