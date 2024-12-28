using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Unit
{
    private static Player instance;
    public static Player Instance
    {
        get { return instance; }
        set { instance = value; } 
    }

    // 게임 일시정지 여부
    private bool isPaused;
    public bool IsPaused
    {
        get { return isPaused; }
        set { isPaused = value; }
    }

    new Rigidbody2D rigidbody2D;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        rigidbody2D = GetComponent<Rigidbody2D>();   
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 일시정지 상태가 아니다
        IsPaused = false;
        transform.position = new Vector2(0, 0);
    }

    private void Update()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveHorizontal();
    }

    // 플레이어 이동 조작
    public void OnMove(InputAction.CallbackContext inputAction)
    {
        // A키나 D키를 눌러 벡터 값을 받아온다.
        MoveDirection = inputAction.ReadValue<Vector2>();
        // 정지해 있을 때는 유닛 상태에서 이동을 해제한다
        if (MoveDirection.x == 0) unitState &= ~UnitState.Move;
        // 움직일 때는 유닛 상태에서 이동을 선택한다.
        else unitState |= UnitState.Move;

    }

    // 실질적으로 플레이어를 움직여 준다
    public void MoveHorizontal()
    {
        // 플레이어가 장외되지 않은 상태이면서 이동 중일 때
        if (!unitState.HasFlag(UnitState.RingOut) && unitState.HasFlag(UnitState.Move))
        {
            // 오른쪽 이동
            if (MoveDirection.x > 0) transform.localScale = new Vector2(1, 1);
            // 왼쪽 이동
            else if (MoveDirection.x < 0) transform.localScale = new Vector2(-1, 1);
            // 최종적으로 플레이어를 원하는 방향으로 이동한다
            transform.Translate(MoveDirection * moveSpeed * Time.deltaTime);
        }
    }

    // 위로 도약하는 조작
    public void OnJump(InputAction.CallbackContext inputAction)
    {
        if (inputAction.started && !unitState.HasFlag(UnitState.Jump))
        {
            unitState |= UnitState.Jump;
            rigidbody2D.linearVelocity = new Vector2 (0, JumpPower);

            //rigidbody2D.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 땅에 발이 닿았는지 확인
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
            unitState &= ~UnitState.Jump;
    }
}
