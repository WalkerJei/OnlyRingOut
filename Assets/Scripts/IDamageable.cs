using UnityEngine;

public interface IDamageable
{
    void OnDamaged(byte damageValue, Vector2 targetPosition);
}

