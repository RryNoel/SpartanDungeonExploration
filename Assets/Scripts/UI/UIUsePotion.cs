using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIUsePotion : MonoBehaviour
{
    public float duration;
    public float UseTime;

    public Image ActiveOverlay;

    public PlayerController controller;

    private void Update()
    {
        if (controller.isUsePotion == true)
        {
            UseTime -= Time.deltaTime;
            ActiveOverlay.fillAmount = UseTime / duration;
        }
    }
}
