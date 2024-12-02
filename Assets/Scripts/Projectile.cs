using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public float ProjectileSpeed
    {
        get { return projectileSpeed; }
        set { projectileSpeed = value; }
    }

    public byte damageValue;
    public byte DamageValue
    {
        get { return damageValue; }
        set { damageValue = value; }
    }

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

        if (damageable != null && (other.gameObject.tag == "PlayerProjectile" || other.gameObject.tag == "GameController" || other.gameObject.tag == "Player"))
           return;
        else if(other.gameObject.tag == "Terrain")
            Destroy(gameObject);
        else if (damageable != null || other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }
}
