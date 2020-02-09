using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class IntroManager : MonoBehaviour
{
    [Header("Step1-4")]
    [SerializeField] UnityEvent onKeyPressed;
    [Header("Step5")]
    [SerializeField] UnityEvent onKeysPressed;
    [Header("Step6")]
    [SerializeField] UnityEvent onIntroCompleted;
    [Header("Skip")]
    [SerializeField] UnityEvent onSkipped;

    int currentStep = 1;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            onSkipped.Invoke();
        }

        if (currentStep < 5 && Input.GetKeyDown(KeyCode.Space)) {
            currentStep++;
            onKeyPressed.Invoke();
        } else if (currentStep == 5 && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))) {
            currentStep++;
            onKeysPressed.Invoke();
        }
    }

    public void IntroCompleted() {
        onIntroCompleted.Invoke();
    }
}
