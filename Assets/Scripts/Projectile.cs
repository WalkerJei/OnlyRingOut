using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // 투사체의 속도
    public float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    // 투사체의 공격력으로 높을수록 더 멀리 밀어낼 수 있다
    public byte damageValue;
    public byte DamageValue
    {
        get { return damageValue; }
        set { damageValue = value; }
    }

    // 투사체의 유효 사거리
    public float range;
    public float Range
    {
        get { return range; }
        set { range = value; }
    }

    private Vector2 projectileDirection;
    public Vector2 ProjectileDirection
    {
        get { return projectileDirection; }
        set { projectileDirection = value; }
    }

    new Rigidbody2D rigidbody2D = null;

    private void Awake()
    {
        if(rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        OnMove();        
    }

    void OnMove()
    {
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
    }
}
