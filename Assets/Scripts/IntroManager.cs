using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroManager : MonoBehaviour
{
    [Header("Space")]
    [SerializeField] List<int> stepsToPressSpace;
    [SerializeField] UnityEvent onSpacePressed;
    [Header("Arrow Keys")]
    [SerializeField] List<int> stepsToPressArrowKeys;
    [SerializeField] UnityEvent onArrowKeysPressed;
    [Header("Intro Completed")]
    [SerializeField] UnityEvent onIntroCompleted;
    [Header("Skip")]
    [SerializeField] UnityEvent onSkipped;

    int currentStep = 1;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            onSkipped.Invoke();
        }

        if (stepsToPressSpace.Contains(currentStep) && Input.GetKeyDown(KeyCode.Space)) {
            currentStep++;
            onSpacePressed.Invoke();
        } else if (stepsToPressArrowKeys.Contains(currentStep) && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))) {
            currentStep++;
            onArrowKeysPressed.Invoke();
        }
    }

    public void IntroCompleted() {
        onIntroCompleted.Invoke();
    }
}
