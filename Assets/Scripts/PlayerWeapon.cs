using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : Weapon
{
    // 마우스 커서의 위치
    Vector2 aimDirection;
    public Vector2 AimDirection
    {
        get { return aimDirection; }
        set { aimDirection = value; }
    }

    // 마우스 움직임으로 조준
    public void Aim(InputAction.CallbackContext inputAction)
    {
        // 현재 마우스 커서의 위치를 받아서 저장
        AimDirection = Camera.main.ScreenToWorldPoint(inputAction.ReadValue<Vector2>());
        // 마우스 커서 위치에 무기 위치 값을 빼서 각도를 구한다
        WeaponAngle = Mathf.Atan2(AimDirection.y - WeaponPosition.y, AimDirection.x - WeaponPosition.x) * Mathf.Rad2Deg;

        // 플레이어가 오른쪽을 바라볼 경우
        if(Player.Instance.gameObject.GetComponent<Transform>().localScale.x > 0)
        {
            // 총구를 오른쪽으로 겨눈다
            transform.localScale = new Vector2(1, 1);
            // 마우스 커서의 Y값이 0 이상일 경우(제 1~2사분면)
            if (AimDirection.y >= 0)
            {
                // 마우스 커서의 X값이 제 1사분면 안인 경우
                if (AimDirection.x >= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, 0, 80);
                // 마우스 커서의 X값이 제 2사분면 안인 경우
                else if (AimDirection.x <= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, 80, 80);
            }
            // 마우스 커서의 Y값이 0 이하일 경우(제 3~4사분면)
            else if (AimDirection.y <= 0)
            {
                // 마우스 커서의 X값이 제 4사분면 안인 경우
                if (AimDirection.x >= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, -80, 0);
                // 마우스 커서의 X값이 제 3사분면 안인 경우
                else if (AimDirection.x <= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, -80, -80);
            }
        }
        // 플레이어가 왼쪽을 바라볼 경우
        else if(Player.Instance.gameObject.GetComponent<Transform>().localScale.x < 0)
        {
            // 총구를 왼쪽으로 겨눈다
            transform.localScale = new Vector2(-1, -1);
            // 마우스 커서의 Y값이 0 이상일 경우(제 1~2사분면)
            if (AimDirection.y >= 0)
            {
                // 마우스 커서의 X값이 제 1사분면 안인 경우
                if (AimDirection.x >= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, 100, 100);
                // 마우스 커서의 X값이 제 2사분면 안인 경우
                else if (AimDirection.x <= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, 100, 180);
            }
            // 마우스 커서의 Y값이 0 이하일 경우(제 3~4사분면)
            else if (AimDirection.y <= 0)
            {
                // 마우스 커서의 X값이 제 4사분면 안인 경우
                if (AimDirection.x >= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, -100, -100);
                // 마우스 커서의 X값이 제 3사분면 안인 경우
                else if (AimDirection.x <= 0) WeaponAngle = Mathf.Clamp(WeaponAngle, -180, -100);
            }
        }
        // 보정된 회전값을 반영해 조준
        transform.rotation = Quaternion.AngleAxis(WeaponAngle, Vector3.forward);
    }

    // 플레이어의 일반공격
    public virtual void NormalAttack(InputAction.CallbackContext inputAction)
    {

    }
}
