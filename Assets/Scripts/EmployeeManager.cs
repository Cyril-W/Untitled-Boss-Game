﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeManager : MonoBehaviour
{
    [Header("Employees")]
    [SerializeField] List<EmployeeScriptable> employees;
    [Header("Employee")]
    [SerializeField] Image employeeImage;
    [SerializeField] Image leftEyeImage;
    [SerializeField] Image rightEyeImage;
    [SerializeField] Text nameText;
    [SerializeField] Text questionText;
    [SerializeField] Text answer1Text;
    [SerializeField] Text response1Text;
    [SerializeField] Text answer2Text;    
    [SerializeField] Text response2Text;
    [Header("Resource Delta")]
    [SerializeField] ResourcesManager resourcesManager;

    List<EmployeeScriptable> randomEmployees;

    void Start() {
        randomEmployees = new List<EmployeeScriptable>(employees);

        GenerateEmployee();
    }

    public void GenerateEmployee() {
        var randomIndex = Random.Range(0, randomEmployees.Count);
        var employee = randomEmployees[randomIndex];
        randomEmployees.Remove(employee);
        if (randomEmployees.Count <= 0) {
            randomEmployees = new List<EmployeeScriptable>(employees);
        }

        employeeImage.sprite = employee.Sprite;
        leftEyeImage.color = employee.eyesColor;
        rightEyeImage.color = employee.eyesColor;
        nameText.text = employee.Name;
        questionText.text = employee.Question;
        answer1Text.text = employee.Answer1;
        response1Text.text = employee.Response1;
        answer2Text.text = employee.Answer2;
        response2Text.text = employee.Response2;

        resourcesManager.SetDeltaAnswers(employee);
    }
}
