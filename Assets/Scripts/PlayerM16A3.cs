using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerM16A3 : PlayerWeapon
{
    // 마우스 좌클릭 시 일반공격 진행
    public override void NormalAttack(InputAction.CallbackContext inputAction)
    {
        // 마우스를 클릭할 떄만 실행하며 뗄 경우에는 실행되지 않는다
        if (inputAction.started)
        {
            StartCoroutine("TryNormalAttack");
        }
    }


    IEnumerator TryNormalAttack()
    {
        // 가지고 있는 탄창이 1개 이상인 경우
        if(CurrentAmmo > 0)
        {
            // 플레이어 싱글톤의 유닛 상태를 확인해 공격 상태가 아닌 경우
            if (!Player.Instance.unitState.HasFlag(Unit.UnitState.Attack))
            {
                // 공격 시작
                yield return StartCoroutine("ShootNormalAttack");
                // 액티브 타임 시작
                yield return StartCoroutine("ActiveTimeCalc");
            }
            
            else
                yield break;
        }  
    }        
    
    IEnumerator ShootNormalAttack()
    {
        // 차탄 발사 시간을 미리 변수에 담아 가비지 컬렉터 대상에서 배제
        var wfsFireRate = new WaitForSeconds(fireRate);
        // 플레이어를 공격 상태로 만든다.
        Player.Instance.unitState |= Unit.UnitState.Attack;
        // 한 개의 탄창을 소비한다.
        CurrentAmmo--;
        // 한 탄창 안에 있는 총알들을 장전한다.
        byte bullet = bulletPerAmmo;
        // 총알이 바닥날 때까지 연사한다.
        while (bullet > 0)
        {
            // 남아있는 총알을 하나 소모한다
            bullet--;
            // 총알 오브젝트를 생성해 원하는 위치로 발사한다.
            Instantiate(bulletNormal, transform.position, Quaternion.AngleAxis(WeaponAngle, Vector3.forward));
            // 차탄 발사까지 약간의 시간을 둔다.
            yield return wfsFireRate;
        }
    }
}
