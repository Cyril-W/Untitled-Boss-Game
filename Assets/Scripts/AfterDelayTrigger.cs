using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class AfterDelayTrigger : MonoBehaviour
{
    [SerializeField] float secondsToWait;
    [SerializeField] UnityEvent unityEvent;

    public void StartTrigger() {
        StartCoroutine(WaitBeforeTrigger());
    }

    public void StopTrigger() {
        StopAllCoroutines();
    }

    IEnumerator WaitBeforeTrigger() {
        yield return new WaitForSeconds(secondsToWait);

        unityEvent.Invoke();
    }
}
