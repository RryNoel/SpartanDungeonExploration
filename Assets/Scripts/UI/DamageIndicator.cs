using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageIndicator : MonoBehaviour
{
    public Image image;
    public float flashSpeed;
    
    private Coroutine coroutine;

    private void Start()
    {
        // Flash 메서드를 onTakeDamage 액션에 연결, 플레이어가 대미지를 받으면 실행
        CharacterManager.Instance.Player.condition.onTakeDamage += Flash;
    }

    public void Flash()
    {
        // 이미 실행 중인 코루틴이 있으면 중지
        if(coroutine != null)
        {
            StopCoroutine(coroutine);
        }

        image.enabled = true;
        image.color = new Color(1f, 100f / 255f, 100f / 255f);
        // FadeAway 코루틴 시작
        coroutine = StartCoroutine(FadeAway());
    }

    // 이미지를 서서히 사라지게 하는 코루틴
    private IEnumerator FadeAway()
    {
        float startAlpha = 0.3f;
        float a = startAlpha;

        while(a > 0)
        {
            // 알파 값을 서서히 감소
            a -= (startAlpha / flashSpeed) * Time.deltaTime;
            // 현재 알파 값으로 이미지 색상 업데이트
            image.color = new Color(1f, 100f / 255f, 100f / 255f, a);
            // 다음 프레임까지 대기
            yield return null;
        }

        // 알파 값이 0이 되면 이미지를 비활성화
        image.enabled = false;
    }
}
