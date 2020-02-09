using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] UnityEvent onTypewriterStart;
    [SerializeField] UnityEvent onTypewriterStop;

    Vector2 randomDelay = new Vector2(0.03f, 0.05f);
    string fullText;
    string currentText;

    void OnEnable()
    {
        fullText = text.text;
        StartCoroutine(Typewrite());
        onTypewriterStart.Invoke();
    }

    void OnDisable() {
        StopAllCoroutines();
        text.text = fullText;
        onTypewriterStop.Invoke();
    }

    IEnumerator Typewrite() {
        for (int i = 0; i <= fullText.Length; i++) {
            currentText = fullText.Substring(0, i);
            text.text = currentText;
            yield return new WaitForSeconds(Random.Range(randomDelay.x, randomDelay.y));
        }
        onTypewriterStop.Invoke();
    }
}
