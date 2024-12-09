using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    // 유닛의 체중으로 무거울수록 덜 밀려난다.
    public byte weight;
    public byte Weight
    {
        get { return weight; }
        set
        {
            if (weight >= 0)
                weight = value;
        }
    }
    
    // 유닛의 이동속도이며 높을수록 같은 거리를 더 빨리 갈 수 있다.
    public float moveSpeed;
    public float MoveSpeed
    {
        get { return moveSpeed; }
        set { moveSpeed = value; }
    }
    // 유닛의 도약력이며 높을수록 더 높이 위로 뛸 수 있다.
    public float jumpPower;
    public float JumpPower
    {
        get { return jumpPower; }
        set { jumpPower = value; }
    }

    // 유닛 이동 여부
    private bool isMove;
    public bool IsMove
    {
        get { return isMove; }
        set { isMove = value; }
    }

    // 유닛 도약 여부
    private bool isJump;
    public bool IsJump
    {
        get { return isJump; }
        set { isJump = value; }
    }

    // 유닛 장외(경기장 밖으로 추락) 여부
    private bool isDead;
    public bool IsDead
    {
        get { return isDead; }
        set { isDead = value; }
    }

    private Vector2 moveDirection;
    public Vector2 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // 유닛이 투사체에 피격당했을 때 뒤로 밀려난다
    public void OnDamaged(byte damageValue, Vector2 targetPosition)
    {
        // 
        int damageDirection = transform.position.x - targetPosition.x > 0 ? 1: -1;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(damageDirection, 1) * (damageValue / Weight), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
