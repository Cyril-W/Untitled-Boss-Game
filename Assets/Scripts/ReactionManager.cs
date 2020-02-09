using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ReactionManager : MonoBehaviour {
    [Header("Reaction Params")]
    [SerializeField] Vector2 randomTimeBeforeAction;
    [SerializeField] Vector2 randomReactionDuration;
    [SerializeField] Vector2 randomNumberToPressKey;
    [Header("Generic Reaction Event")]
    [SerializeField] UnityEvent onKeyboardPress;
    [SerializeField] UnityEvent onSuccessEvent;
    [SerializeField] UnityEvent onFailEvent;
    [SerializeField] UnityEvent dismissRaccoonEvent;
    [Header("Reaction Event Screen")]
    [SerializeField] Image gaugeScreen;
    [SerializeField] Text textScreen;
    [SerializeField] List<Sprite> screenSprites;
    [SerializeField] Image screenImage;
    [SerializeField] UnityEvent reactionScreenEventStart;
    [SerializeField] UnityEvent reactionScreenEventStop;
    [Header("Reaction Event Phone")]
    [SerializeField] Image gaugePhone;
    [SerializeField] Text textPhone;
    [SerializeField] UnityEvent reactionPhoneEventStart;
    [SerializeField] UnityEvent reactionPhoneEventStop;
    [Header("Reaction Event Clock")]
    [SerializeField] Image gaugeClock;
    [SerializeField] Text textClock;
    [SerializeField] UnityEvent reactionClockEventStart;
    [SerializeField] UnityEvent reactionClockEventStop;

    public bool CanDismissRaccoon { get; set; }

    float currentTime;
    int randomInt;
    float nexTimeBeforeAction;
    float nextReactionDuration;
    int nextNumberToPress;
    KeyCode nextKeyToPress;
    List<KeyCode> randomKeysToPress = new List<KeyCode>(){
        KeyCode.A, KeyCode.Z, KeyCode.E, KeyCode.R, KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P,
        KeyCode.Q, KeyCode.S, KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.M,
        KeyCode.W, KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N,
        KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P
    };

    void OnEnable()
    {
        SelectNextReaction();
    }

    void OnDisable() {
        StopAllCoroutines();
    }

    void Update() {
        if (Input.GetKeyDown(nextKeyToPress) && nextNumberToPress > 0) {
            onKeyboardPress.Invoke();
            nextNumberToPress--;
        }
    }

    IEnumerator WaitUntilNextReaction() {
        yield return new WaitForSeconds(nexTimeBeforeAction);

        randomInt = Random.Range(0, 3);
        switch (randomInt) {
            case 0:
                gaugeScreen.fillAmount = 1f;
                textScreen.text = nextKeyToPress.ToString();
                screenImage.sprite = screenSprites[Random.Range(0, screenSprites.Count)];
                reactionScreenEventStart.Invoke();
                break;
            case 1:
                gaugePhone.fillAmount = 1f;
                textPhone.text = nextKeyToPress.ToString();
                reactionPhoneEventStart.Invoke();
                break;
            case 2:
                gaugeClock.fillAmount = 1f;
                textClock.text = nextKeyToPress.ToString();
                reactionClockEventStart.Invoke();
                break;
            default:
                break;
        }

        if (enabled) {
            StartCoroutine(WaitForKeyPress());
        }
    }

    IEnumerator WaitForKeyPress() {
        currentTime = nextReactionDuration;

        while (currentTime >= 0 && nextNumberToPress > 0) {        
            currentTime -= Time.deltaTime;
            switch (randomInt) {
                case 0:
                    gaugeScreen.fillAmount = currentTime / nextReactionDuration;
                    break;
                case 1:
                    gaugePhone.fillAmount = currentTime / nextReactionDuration;
                    break;
                case 2:
                    gaugeClock.fillAmount = currentTime / nextReactionDuration;
                    break;
                default:
                    break;
            }
            yield return new WaitForEndOfFrame();
        }

        if (nextNumberToPress == 0 && currentTime > 0) {
            onSuccessEvent.Invoke();
        } else {
            onFailEvent.Invoke();
            if (CanDismissRaccoon) {
                dismissRaccoonEvent.Invoke();
            }
        }

        switch (randomInt) {
            case 0:
                reactionScreenEventStop.Invoke();
                break;
            case 1:
                reactionPhoneEventStop.Invoke();
                break;
            case 2:
                reactionClockEventStop.Invoke();
                break;
            default:
                break;
        }

        SelectNextReaction();
    }

    void SelectNextReaction() {
        nexTimeBeforeAction = Random.Range(randomTimeBeforeAction.x, randomTimeBeforeAction.y);
        nextReactionDuration = Random.Range(randomReactionDuration.x, randomReactionDuration.y);
        nextNumberToPress = Mathf.RoundToInt(Random.Range(randomNumberToPressKey.x, randomNumberToPressKey.y));
        nextKeyToPress = randomKeysToPress[Random.Range(0, randomKeysToPress.Count)];

        if (enabled) {
            StartCoroutine(WaitUntilNextReaction());
        }
    }
}
