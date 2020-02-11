using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    [SerializeField] float timeBeforePause;
    [SerializeField] UnityEvent beforeOnGamePaused;
    [SerializeField] UnityEvent afterOnGamePaused;

    public void PauseGame() {
        StartCoroutine(WaitAndPauseGame());
    }

    IEnumerator WaitAndPauseGame() {
        beforeOnGamePaused.Invoke();
        yield return new WaitForSeconds(timeBeforePause);
        afterOnGamePaused.Invoke();
        Time.timeScale = 0;
    }

    public void ResumeGame(float delayBeforePause) {
        Time.timeScale = 1;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
