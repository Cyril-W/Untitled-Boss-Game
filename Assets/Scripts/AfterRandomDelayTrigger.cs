using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AfterRandomDelayTrigger : MonoBehaviour {
    [SerializeField] bool launchAtEnable = true;
    [SerializeField] Vector2 randomSecondsToWait;
    [SerializeField] UnityEvent unityEvent;

    void OnEnable() {
        if (launchAtEnable) {
            StartTrigger();
        }
    }

    public void StartTrigger() {
        StartCoroutine(WaitBeforeTrigger());
    }

    public void StopTrigger() {
        StopAllCoroutines();
    }

    IEnumerator WaitBeforeTrigger() {
        yield return new WaitForSeconds(Random.Range(randomSecondsToWait.x, randomSecondsToWait.y));

        unityEvent.Invoke();
    }
}
