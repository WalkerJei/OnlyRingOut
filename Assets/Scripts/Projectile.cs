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
    Player player;

    private void Awake()
    {
        if(rigidbody2D == null) rigidbody2D = GetComponent<Rigidbody2D>();

        player = GetComponent<Player>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void FixedUpdate()
    {
        OnMove();
        
    }

    void OnMove()
    {
        
        transform.Translate(Vector2.right * projectileSpeed * Time.deltaTime);
        
        //float projectileAngle = Mathf.Atan2(ProjectileDirection.y, ProjectileDirection.x) * Mathf.Rad2Deg;
        //rigidbody2D.linearVelocity = Quaternion.Euler(0,0,projectileAngle) * Vector3.forward * projectileSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        // 플레이어가 발사한 투사체, 게임 컨트롤러, 플레이어와 충돌한 경우 투사체가 사라지지 않는다
        if (damageable != null && (other.gameObject.tag == "PlayerProjectile" || other.gameObject.tag == "GameController" || other.gameObject.tag == "Player"))
           return;
        // 지형과 충돌한 경우 투사체가 사라진다
        else if(other.gameObject.tag == "Terrain")
            Destroy(gameObject);
        // 
        else if (damageable != null && other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            damageable.OnDamaged(damageValue, transform.position);
        }
    }
}
