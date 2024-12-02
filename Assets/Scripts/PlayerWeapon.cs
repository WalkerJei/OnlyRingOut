using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerWeapon : Weapon
{
    // 마우스 커서의 위치
    Vector2 aimDirection;
    public Vector2 AimDirection
    {
        get { return aimDirection; }
        set { aimDirection = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 마우스 움직임으로 조준
    public void Aim(InputAction.CallbackContext inputAction)
    {
        // 현재 마우스 커서의 위치를 받아서 저장
        AimDirection = Camera.main.ScreenToWorldPoint(inputAction.ReadValue<Vector2>());
        // 마우스 커서 위치에 무기 위치 값을 빼서 각도를 구한다
        WeaponAngle = Mathf.Atan2(AimDirection.y - WeaponPosition.y, AimDirection.x - WeaponPosition.x) * Mathf.Rad2Deg;

        if(AimDirection.x > 0)
        {
            // 무기 회전각을 제한한다.
            WeaponAngle = Mathf.Clamp(WeaponAngle, -80, 80);
            // 무기를 오른쪽으로 뒤집는다.
            transform.localScale = new Vector2(1, 1);
            // 무기를 회전시킨다.
            transform.rotation = Quaternion.AngleAxis(WeaponAngle, Vector3.forward);
        }

        else if(AimDirection.x < 0)
        {
            // 무기 회전각을 제한한다.
            WeaponAngle = Mathf.Clamp(WeaponAngle, Mathf.Clamp(WeaponAngle, -180, -100), Mathf.Clamp(WeaponAngle, 100, 180));
            // 무기를 왼쪽으로 뒤집는다.
            transform.localScale = new Vector2(-1, -1);
            // 무기를 회전시킨다. 
            transform.rotation = Quaternion.AngleAxis(WeaponAngle, Vector3.forward);
        }
    }

    public virtual void NormalAttack(InputAction.CallbackContext inputAction)
    {

    }
}
