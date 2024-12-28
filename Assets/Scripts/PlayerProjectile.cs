using UnityEngine;

public class PlayerProjectile : Projectile
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        // 플레이어가 발사한 투사체, 게임 컨트롤러, 플레이어와 충돌한 경우 투사체가 사라지지 않는다
        if (damageable != null && (other.gameObject.CompareTag("PlayerProjectile") || other.gameObject.CompareTag("GameController") || other.gameObject.CompareTag("Player")))
            return;
        // 지형과 충돌한 경우 투사체가 사라진다
        else if (other.gameObject.CompareTag("Terrain"))
            Destroy(gameObject);
        // 적과 충돌한 경우 투세차는 사라지고 적을 밀쳐낸다.
        else if (damageable != null && other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            damageable.OnDamaged(damageValue, transform.position);
        }
    }
}
