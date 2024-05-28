using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;
    public Image uiBar;

    private void Start()
    {
        curValue = startValue;
    }

    private void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        // 현재 값에 매개변수 값을 더하고 최대 값을 넘지 않도록 설정
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value)
    {
        // 현재 값에서 매개변수 값을 빼고 0 이하로 내려가지 않도록 설정
        curValue = Mathf.Max(curValue - value, 0);
    }
}
