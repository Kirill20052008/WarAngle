using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Настройки пули")]
    public float maxLifetime = 3f;  // Макс время жизни (сек)
    public float trailClearTime = 0.2f; // Время на Trail

    private TrailRenderer trail;

    void Start()
    {
        trail = GetComponent<TrailRenderer>();

        // ✅ АВТОУНИЧТОЖЕНИЕ через maxLifetime
        Destroy(gameObject, maxLifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("💥 Попадание в: " + collision.gameObject.name);
        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        // Останавливаем Trail
        if (trail != null)
            trail.emitting = false;

        if (collision.gameObject.CompareTag("Enemy1"))
        {
            Debug.Log("💥 Попадание по красному ВРАГУ!");
        }

        // Быстрое уничтожение при попадании
        Destroy(gameObject, trailClearTime);
    }

    void OnDestroy()
    {
        // ✅ ПРОВЕРКА уничтожения (всегда срабатывает)
        Debug.Log("🗑️ Пуля уничтожена!");
    }
}
