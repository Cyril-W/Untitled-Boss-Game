using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] KeyCode keyCode;
    [SerializeField] UnityEvent onKeyPressed;
    [SerializeField] float timeBeforePause;
    [SerializeField] UnityEvent onGamePaused;

    public void ReloadScene() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame() {
        StartCoroutine(WaitAndPauseGame());
    }

    IEnumerator WaitAndPauseGame() {
        yield return new WaitForSeconds(timeBeforePause);
        onGamePaused.Invoke();
        Time.timeScale = 0;
    }

    public void ResumeGame(float delayBeforePause) {
        Time.timeScale = 1;
    }

    void Update() {
        if (Input.GetKeyDown(keyCode)) {
            onKeyPressed.Invoke();
        }
    }
}
