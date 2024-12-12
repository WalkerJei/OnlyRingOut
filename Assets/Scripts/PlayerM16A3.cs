using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerM16A3 : PlayerWeapon
{
    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CurrentFireRate = fireRate;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void NormalAttack(InputAction.CallbackContext inputAction)
    {
        GameObject bullet = Instantiate(bulletNormal, transform.position, Quaternion.AngleAxis(WeaponAngle, Vector3.forward));


    }
}
