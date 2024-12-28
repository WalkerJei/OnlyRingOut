using UnityEngine;

public interface IDamageable
{
    // 피해를 입었을 떄 공격력과 투사체의 위치 값을 받아 처리한다    
    void OnDamaged(byte damageValue, Vector2 targetPosition);
}

