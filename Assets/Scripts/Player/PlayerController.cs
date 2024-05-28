using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook; // 카메라가 아래로 바라볼 수 있는 최소 각도
    public float maxXLook; // 카메라가 위로 바라볼 수 있는 최대 각도
    private float camCurXRot; // 현재 카메라의 x축 회전 값
    public float lookSensitivity; // 마우스 감도
    private Vector2 mouseDelta; // 마우스 이동 값

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
        // 물리 업데이트마다 Move 메서드 호출
        Move();
    }

    private void LateUpdate()
    {
        // 모든 업데이트가 끝난 후 카메라 움직임 처리
        CameraLook();
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

    void CameraLook()
    {
        // 마우스 y 이동 값에 따라 카메라의 X축 회전 값 조정
        camCurXRot += mouseDelta.y * lookSensitivity;
        // X축 회전 값을 최소 및 최대 각도로 클램프
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        // 카메라 컨테이너의 로컬 회전 값을 설정
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        // 마우스 x 이동 값에 따라 플레이어의 Y축 회전 값 조정
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
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

    // Input System으로 입력 받는 OnLook 함수
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }
}
