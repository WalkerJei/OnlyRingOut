using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour
{
    // 발사할 일반공격 탄환
    public GameObject bulletNormal;
    // 발사할 궁극기 탄환
    public GameObject bulletUltimate;
    // 공격력으로 높을수록 더 멀리 밀칠 수 있다
    public byte damageValue;
    // 사거리로 높을수록 멀리 있는 적을 공격하기 쉽다
    public float range;
    // 보유한 탄창
    public byte ammo;
    // 최대 보유 탄창 수
    public byte maxAmmo;
    // 탄창 1개당 탄환의 수
    public byte bulletPerAmmo;
    // 탄환 발사 후 차탄 발사까지의 걸리는 시간
    public float fireRate;
    // 행동 시작부터 종료까지의 걸리는 시간
    public float activeTime;
    // 행동 종료 후 행동을 다시 하는데 걸리는 시간
    public float coolDown;
    // 재장전에 걸리는 시간
    public float reloadRate;

    // 현재 보유 탄창 수
    private byte currentAmmo;
    public byte CurrentAmmo
    {
        get { return currentAmmo; }
        set { if(currentAmmo >= 0 && currentAmmo <= maxAmmo) currentAmmo = value; }
    }

    // 현재 탄환을 발사한 후 차탄 발사까지 걸리는 시간
    private float currentFireRate = 0f;
    public float CurrentFireRate
    {
        get { return currentFireRate; }
        set { if (currentFireRate >= 0f) currentFireRate = value; }
    }

    // 현재 행동 시작부터 종료까지 걸리는 시간
    private float currentActiveTime;
    public float CurrentActiveTime
    {
        get { return currentActiveTime; }
        set { if (currentActiveTime >= 0f) currentActiveTime = value; }
    }

    // 현재 행동 종료부터 행동 재개까지 걸리는 시간
    private float currentCoolDown;
    public float CurrentCoolDown
    {
        get { return currentCoolDown; }
        set { if (currentCoolDown >= 0f) currentCoolDown = value; }
    }

    // 현재 무기 재장전을 하는 데 걸리는 시간
    private float currentReloadRate;
    public float CurrentReloadRate
    {
        get { return currentReloadRate; }
        set { if (currentReloadRate >= 0f) currentReloadRate = value; }
    }

    // 무기의 조준 각도
    private float weaponAngle;
    public float WeaponAngle
    {
        get { return weaponAngle; }
        set 
        {
           weaponAngle = value;
        }
    }

    // 무기의 위치
    private Vector2 weaponPosition;
    public Vector2 WeaponPosition
    {
        get { return weaponPosition; }
        set { weaponPosition = value; }
    }

    SpriteRenderer spriteRenderer;
    Unit unit;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WeaponPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    

    

    

}
