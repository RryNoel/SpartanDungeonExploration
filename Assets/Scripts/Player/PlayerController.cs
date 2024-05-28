using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    private Rigidbody _rigidbody;

    private PlayerAnimation anim;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {
        // 마우스 커서를 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    // 실질적인 움직임을 담당하는 함수
    void Move()
    {
        // (W, S) 키 입력은 y 방향 이동, (A, D) 키 입력은 x 방향 이동
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        // 점프할 때를 제외하고 y값을 초기화하여 수직 이동을 방지
        

        _rigidbody.velocity = dir;
    }

    // Input System으로 입력 받는 OnMove 함수
    public void OnMove(InputAction.CallbackContext context)
    {
        // 입력이 수행 중일 때 이동 입력 값 읽기
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
            anim.OnMoveAnim();
        }
        // 입력이 취소될 때 이동 입력 값을 0으로 초기화
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
            anim.OutMoveAnime();
        }
    }
}
