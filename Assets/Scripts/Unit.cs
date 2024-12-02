using UnityEngine;

public class Unit : MonoBehaviour, IDamageable
{
    public byte weight;
    public byte Weight
    {
        get { return weight; }
        set
        {
            if (weight >= 0)
                weight = value;
        }
    }

    public float moveSpeed;
    public float jumpPower;

    private Vector2 moveDirection;
    public Vector2 MoveDirection
    {
        get { return moveDirection; }
        set { moveDirection = value; }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public virtual void OnDamaged(byte damageValue, Vector2 targetPosition)
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
