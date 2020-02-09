using UnityEngine;
using UnityEngine.Events;

public class DecisionManager : MonoBehaviour
{
    [Header("Decision1")]
    [SerializeField] KeyCode keyCodeDecision1;
    [SerializeField] UnityEvent onDecision1Made;

    [Header("Decision2")]
    [SerializeField] KeyCode keyCodeDecision2;
    [SerializeField] UnityEvent onDecision2Made;

    void Update() {
        if (Input.GetKeyDown(keyCodeDecision1)) {
            onDecision1Made.Invoke();
        } else if (Input.GetKeyDown(keyCodeDecision2)) {
            onDecision2Made.Invoke();
        }
    }
}
