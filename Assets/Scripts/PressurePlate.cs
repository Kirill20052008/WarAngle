using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour
{
    [Header("🚀 Настройки подбрасывания")]
    public float launchForce = 10f;  // Сила подбрасывания
    public float delayTime = 1f;     // Задержка 1 секунда

    [Header("🎯 Игрок")]
    public string playerTag = "Player";  // Тег игрока

    public AudioSource UpSound;

    private bool isActivated = false;

    void OnTriggerEnter(Collider other)
    {
        // ✅ Проверяем, что это игрок
        if (other.CompareTag(playerTag) && !isActivated)
        {
            isActivated = true;
            StartCoroutine(LaunchPlayer(other.gameObject));
        }
    }

    IEnumerator LaunchPlayer(GameObject player)
    {
        Debug.Log("⏳ Зарядка плиты...");

        // ✅ Ждём 1 секунду
        yield return new WaitForSeconds(delayTime);

        // ✅ Подбрасываем игрока ВВЕРХ!
        Rigidbody playerRb = player.GetComponent<Rigidbody>();
        if (playerRb != null)
        {

            playerRb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            Debug.Log($"🚀 ИГРОК ПОДКИНУТ! Сила: {launchForce}");
            UpSound.Play();
        }

        // ✅ Деактивируем на 2 секунды (чтобы не спамил)
        yield return new WaitForSeconds(2f);
        isActivated = false;
        Debug.Log("✅ Плита готова к повторному использованию!");
    }
}
