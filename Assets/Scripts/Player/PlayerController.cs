using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public float jumpPower;
    public float jumpPadPower;
    public float jumpStamina;
    public float runStamina;
    private float curSpeed;
    private float runSpeed;
    public bool canRun;
    private Vector2 curMovementInput;
    public LayerMask groundLayerMask;
    public LayerMask JumpLayerMask;
    private Coroutine runCoroutine;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook; // 카메라가 아래로 바라볼 수 있는 최소 각도
    public float maxXLook; // 카메라가 위로 바라볼 수 있는 최대 각도
    private float camCurXRot; // 현재 카메라의 x축 회전 값
    public float lookSensitivity; // 마우스 감도
    private Vector2 mouseDelta; // 마우스 이동 값
    public bool canLook = true;

    public bool isUsePotion;
    public GameObject potionDuration;
    private Coroutine speedBoostCoroutine;
    [SerializeField]
    private UIUsePotion usePotion;

    public Action inventory;
    private Rigidbody _rigidbody;

    private PlayerAnimation anim;

    [Header("ThirdCamera")]
    private bool isFirstPersonView = true;
    public Transform thirdPersonCameraPosition; // 3인칭 카메라 위치
    public Transform firstPersonCameraPosition; // 1인칭 카메라 위치

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<PlayerAnimation>();
    }

    private void Start()
    {
        // 마우스 커서를 화면 중앙에 고정
        Cursor.lockState = CursorLockMode.Locked;
        curSpeed = moveSpeed;
        runSpeed = moveSpeed * 2;
    }

    private void FixedUpdate()
    {
        // 물리 업데이트마다 Move 메서드 호출
        Move();
    }

    private void LateUpdate()
    {
        if(canLook)
        {
            // 모든 업데이트가 끝난 후 카메라 움직임 처리
            CameraLook();
        }
    }

    // 실질적인 움직임을 담당하는 함수
    void Move()
    {
        // (W, S) 키 입력은 y 방향 이동, (A, D) 키 입력은 x 방향 이동
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        // 점프할 때를 제외하고 y값을 초기화하여 수직 이동을 방지
        dir.y = _rigidbody.velocity.y;

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

    public void OnThirdCamera(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            SwitchCameraView();
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started && IsGrounded())
        {
            // 리지드바디에 위쪽으로 점프 힘을 가함
            _rigidbody.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
            CharacterManager.Instance.Player.condition.UseStamina(jumpStamina);
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
            ToggleCursor();
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && CanRun())
        {
            anim.OnRunAnim();
            moveSpeed = runSpeed;
            runCoroutine = StartCoroutine(RunStamina());

        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            StopRunning();
        }
    }

    bool CanRun()
    {
        return CharacterManager.Instance.Player.condition.uiCondition.stamina.uiBar.fillAmount > 0.01f;
    }

    private IEnumerator RunStamina()
    {
        while (CanRun())
        {
            CharacterManager.Instance.Player.condition.UseStamina(runStamina);
            yield return null;
        }
        StopRunning();
    }

    private void StopRunning()
    {
        anim.OutRunAnime();
        moveSpeed = curSpeed;
        StopCoroutine(runCoroutine);
    }

    bool IsGrounded()
    {
        // 4 개의 레이를 정의하여 플레이어 주변을 확인
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
        };

        // 모든 레이를 순회하며 레이캐스르를 실행
        for(int i = 0; i < rays.Length; i++)
        {
            // 레이캐스트가 groundLayerMask와 충돌하면 true를 반환
            if (Physics.Raycast(rays[i], 0.1f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    void ToggleCursor()
    {
        bool toggle = Cursor.lockState == CursorLockMode.Locked;
        Cursor.lockState = toggle ? CursorLockMode.None : CursorLockMode.Locked;
        canLook = !toggle;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("JumpObject") && IsJumpPaded())
        {
            _rigidbody.AddForce(Vector2.up * jumpPadPower, ForceMode.Impulse);
        }
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(collision.transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("MovingPlatform"))
        {
            transform.SetParent(null);
        }
    }

    bool IsJumpPaded()
    {
        // 4 개의 레이를 정의하여 플레이어 주변을 확인
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
        };

        // 모든 레이를 순회하며 레이캐스르를 실행
        for (int i = 0; i < rays.Length; i++)
        {
            // 레이캐스트가 groundLayerMask와 충돌하면 true를 반환
            if (Physics.Raycast(rays[i], 0.1f, JumpLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void ApplySpeedBoost(float duration)
    {
        // 기존에 실행 중인 스피드 부스트 코루틴이 있다면 중지
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine);
            ResetSpeedBoost();
        }

        // 새로운 스피드 부스트 코루틴을 시작하고 저장
        speedBoostCoroutine = StartCoroutine(SpeedBoostCoroutine(duration));
    }

    private IEnumerator SpeedBoostCoroutine(float duration)
    {
        isUsePotion = true;
        potionDuration.SetActive(true);
        moveSpeed *= 2;

        usePotion.UseTime = duration;
        yield return new WaitForSeconds(duration);

        ResetSpeedBoost();
        StopCoroutine(SpeedBoostCoroutine(duration));
    }

    private void ResetSpeedBoost()
    {
        isUsePotion = false;
        potionDuration.SetActive(false);
        moveSpeed = curSpeed;
    }

    void SwitchCameraView()
    {
        if (isFirstPersonView)
        {
            // 3인칭 시점으로 전환
            cameraContainer.position = thirdPersonCameraPosition.position;
            cameraContainer.rotation = thirdPersonCameraPosition.rotation;
        }
        else
        {
            // 1인칭 시점으로 전환
            cameraContainer.position = firstPersonCameraPosition.position;
            cameraContainer.rotation = firstPersonCameraPosition.rotation;
        }
        isFirstPersonView = !isFirstPersonView;
    }
}
