using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject FadePanel;
    public Animator fadeAnimator;
    public Animator InMusic;
    public void PlayGame()
    {
        FadePanel.SetActive(true);
        fadeAnimator.SetTrigger("Fade");
        InMusic.SetTrigger("In");

        // Запускаем корутину с задержкой 2 секунды
        StartCoroutine(LoadSceneWithDelay(SceneManager.GetActiveScene().buildIndex - 1, 2));
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // Корутина с задержкой
    private IEnumerator LoadSceneWithDelay(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);  // Ждём 2 секунды
        SceneManager.LoadScene(sceneIndex);
    }
}
