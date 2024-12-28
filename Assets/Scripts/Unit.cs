using System;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    // 유닛의 상태로 플래그로 표현해 다중선택이 가능하다.
    [Flags]
    public enum UnitState
    {
        None = 0, // 기본 상태
        Move = 1 << 0, // 이동하는 상태로 이때 재장전과 쿨다운이 작동한다.
        Jump = 1 << 1, // 도약하는 상태로 이때 재장전과 쿨다운이 작동한다.
        Attack = 1 << 2, // 공격하는 상태로 이때 액티브타임이 작동한다.
        RingOut = 1 << 3 // 장외
    }

    public UnitState unitState;
    
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

    private Vector2 moveDirection;
    public Vector2 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    void Start()
    {
        // 게임 시작 시 유닛 초기 상태를 None으로 설정
        unitState = UnitState.None;
    }

    // 유닛이 투사체에 피격당했을 때 뒤로 밀려난다
    public void OnDamaged(byte damageValue, Vector2 targetPosition)
    {
        // 삼항 연산자로 유닛 위치에서 피격 위치를 빼는 삼항자 연산을 한다.
        int damageDirection = transform.position.x - targetPosition.x > 0 ? 1: -1;
        // 나온 값이 양수이면 피격당한 유닛은 오른쪽으로 밀려나고, 음수이면 왼쪽으로 밀려난다.
        GetComponent<Rigidbody2D>().AddForce(new Vector2(damageDirection, 1) * (damageValue / Weight), ForceMode2D.Impulse);
    }

}
