using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [Header("Time Speed")]
    [SerializeField] float timeSpeed = 2;
    [Header("Opening Time")]
    [SerializeField] int openingHour;
    [SerializeField] int openingMinute;
    [Header("Closing Time")]
    [SerializeField] int closingHour;
    [SerializeField] int closingMinute;
    [Header("Display")]
    [SerializeField] Text clockText;
    [SerializeField] Text officeHourFromText;
    [SerializeField] Text officeHourToText;
    [Header("EndOfDay Event")]
    [SerializeField] UnityEvent endOfDayEvent;

    float openingTime;
    float closingTime;
    float currentTime;

    void Start() {
        openingTime = openingHour * 60 + openingMinute;
        closingTime = closingHour * 60 + closingMinute;
        officeHourFromText.text = "From: " + DisplayNumber(openingHour) + ":" + DisplayNumber(openingMinute);
        officeHourToText.text = "To: " + DisplayNumber(closingHour) + ":" + DisplayNumber(closingMinute);

        currentTime = openingTime;
        clockText.text = DisplayTime(currentTime);
    }

    void Update()
    {
        currentTime += Time.deltaTime * timeSpeed;
        clockText.text = DisplayTime(currentTime);

        if (currentTime >= closingTime) {
            endOfDayEvent.Invoke();
        }
    }

    string DisplayTime(float time) {
        int hour = Mathf.FloorToInt(time / 60);
        int minutes = Mathf.RoundToInt(time - 60 * hour);
        return DisplayNumber(hour) + ":" + DisplayNumber(minutes);
    }

    string DisplayNumber(int number) {
        return (number < 10 ? "0" : "") + number.ToString();
    }
}
