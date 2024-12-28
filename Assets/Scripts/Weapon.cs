using NUnit.Framework.Constraints;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

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
    public byte Ammo
    {
        get { return ammo; }
        set { if (ammo >= 0 && ammo <= MaxAmmo) ammo = value; }
    }
    // 최대 보유 탄창 수
    private byte maxAmmo;
    public byte MaxAmmo
    {
        get { return maxAmmo; }
        set { if (maxAmmo >= 0 && maxAmmo <= 4) ammo = value; }
    }
    // 탄창 1개당 탄환의 수
    public byte bulletPerAmmo;
    // 탄환 발사 후 차탄 발사까지의 걸리는 시간
    public float fireRate;
    // 행동 시작부터 종료까지의 걸리는 시간
    private float activeTime;
    public float ActiveTime
    {
        get { return activeTime; }
        set { activeTime = bulletPerAmmo * fireRate; }
    }
    // 행동 종료 후 행동을 다시 하는데 걸리는 시간
    public float coolDown;
    public float CoolDown
    {
        get { return coolDown; }
        set { if (coolDown >= 0) coolDown = value; } 
    }

    // 재장전에 걸리는 시간
    public float reloadRate;
    public float ReloadRate
    {
        get { return reloadRate; }
        set { if (reloadRate >= 0) reloadRate = value; }
    }

    // 현재 보유 탄창 수
    private byte currentAmmo;
    public byte CurrentAmmo
    {
        get { return currentAmmo; }
        set { if(currentAmmo >= 0 && currentAmmo <= MaxAmmo) currentAmmo = value; }
    }

    // 무기의 조준 각도
    private float weaponAngle;
    public float WeaponAngle
    {
        get { return weaponAngle; } set { weaponAngle = value; }
    }

    // 무기의 위치
    private Vector2 weaponPosition;
    public Vector2 WeaponPosition
    {
        get { return weaponPosition; } set { weaponPosition = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        WeaponPosition = transform.position;
        // 현재 가지고 있는 총알의 수를 Ammo에 입력한 값으로 설정
        CurrentAmmo = Ammo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
 
    }

    // 액티브 타임 진행
    public IEnumerator ActiveTimeCalc()
    {
        // 액티브 타임을 변수에 담아 가비지 컬렉터 대상에서 배제
        var wfsActiveTime = new WaitForSeconds(ActiveTime);
        // 재장전을 멈춘다.
        StopCoroutine("ReloadRateCalc");
        // 액티브 타임 상태에 진입
        yield return wfsActiveTime;
        // 액티브 타임 종료 후 쿨다운에 진입
        StartCoroutine("CoolDownCalc");
        // 액티브 타임 종료 후 재장전을 시작
        StartCoroutine("ReloadRateCalc");
    }

    // 쿨다운 진행
    public IEnumerator CoolDownCalc()
    {
        // 쿨다운을 변수에 담아 가비지 컬렉터 대상에서 배제
        var wfsCoolDown = new WaitForSeconds(CoolDown);
        // 쿨다운 상태에 진입
        yield return wfsCoolDown;
        // 플레이어는 공격 중인 상태가 해제
        Player.Instance.unitState &= ~Unit.UnitState.Attack;
    }

    // 재장전 시간 계산
    public IEnumerator ReloadRateCalc()
    {
        // 탄창이 가득 차지 않았을 때
        while (currentAmmo <= maxAmmo) 
        { 
            // 재장전 시간을 변수에 담아 가비지 컬렉터 대상에서 배제
            var wfsReloadRate = new WaitForSeconds(ReloadRate);
            // 재장전 시작
            yield return wfsReloadRate;
            // 재장전을 하면서 탄창을 하나 채운다
            currentAmmo++;
        }
    }
}
