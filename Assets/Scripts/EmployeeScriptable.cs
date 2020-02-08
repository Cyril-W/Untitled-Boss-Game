using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EmployeeScriptable", order = 1)]
public class EmployeeScriptable : ScriptableObject {
    [Header("Sprite")]
    public Sprite Sprite;
    [Header("Name")]
    public string Name;
    [Header("Question")]
    public string Question;
    [Header("Answer1")]
    public string Answer1;
    public int Delta1Resource1;
    public int Delta1Resource2;
    public int Delta1Resource3;
    [Header("Answer2")]
    public string Answer2;
    public int Delta2Resource1;
    public int Delta2Resource2;
    public int Delta2Resource3;
}