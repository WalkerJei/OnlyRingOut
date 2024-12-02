using UnityEngine;
using UnityEngine.InputSystem;

public class M16A3 : PlayerWeapon
{
    Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
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
