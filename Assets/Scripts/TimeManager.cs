using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [Header("Opening Time")]
    [SerializeField] int openingHour;
    [SerializeField] int openingMinute;
    [Header("Closing Time")]
    [SerializeField] int closingHour;
    [SerializeField] int closingMinute;
    [Header("Display")]
    [SerializeField] Text text;
    [Header("EndOfDay Event")]
    [SerializeField] UnityEvent endOfDayEvent;

    float openingTime;
    float closingTime;
    float currentTime;

    void Start() {
        openingTime = openingHour * 60 + openingMinute;
        closingTime = closingHour * 60 + closingMinute;

        currentTime = openingTime;
        text.text = DisplayTime(currentTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        text.text = DisplayTime(currentTime);

        if (currentTime >= closingTime) {
            endOfDayEvent.Invoke();
        }
    }

    string DisplayTime(float time) {
        int hour = Mathf.FloorToInt(time / 60);
        int minutes = Mathf.RoundToInt(time - 60 * hour);
        return (hour < 10 ? "0" : "") + hour.ToString() + ":" + (minutes < 10 ? "0" : "") + minutes.ToString();
    }
}
