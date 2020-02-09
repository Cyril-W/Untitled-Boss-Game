using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomStringFeeder : MonoBehaviour
{
    [SerializeField] List<string> strings;
    [SerializeField] Text stringText;

    public void PickUpString() {
        stringText.text = strings[Random.Range(0, strings.Count)];
    }
}
