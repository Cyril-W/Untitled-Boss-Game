using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeManager : MonoBehaviour
{
    [Header("Employees")]
    [SerializeField] List<EmployeeScriptable> employees;
    [Header("Employee")]
    [SerializeField] Image employeeImage;
    [SerializeField] Text nameText;
    [SerializeField] Text questionText;
    [SerializeField] Text answer1Text;
    [SerializeField] Text answer2Text;
    [Header("Resource Delta")]
    [SerializeField] ResourcesManager resourcesManager;

    void Start() {
        var employee = employees[Random.Range(0, employees.Count)];

        employeeImage.sprite = employee.Sprite;
        nameText.text = employee.Name;
        questionText.text = employee.Question;
        answer1Text.text = employee.Answer1;
        answer2Text.text = employee.Answer2;

        resourcesManager.SetDeltaAnswers(employee);
    }
}
