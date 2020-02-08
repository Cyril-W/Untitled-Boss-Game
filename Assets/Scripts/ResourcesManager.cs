using UnityEngine;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    [Header("Resource1")]
    [SerializeField] int maxResource1Amount;
    [SerializeField] Image resource1GaugeFill;
    [Header("Resource2")]
    [SerializeField] int maxResource2Amount;
    [SerializeField] Image resource2GaugeFill;
    [Header("Resource3")]
    [SerializeField] int maxResource3Amount;
    [SerializeField] Image resource3GaugeFill;

    int currentResource1Amount, currentResource2Amount, currentResource3Amount;
    int deltaAnswer1Resource1, deltaAnswer1Resource2, deltaAnswer1Resource3;
    int deltaAnswer2Resource1, deltaAnswer2Resource2, deltaAnswer2Resource3;

    void Start()
    {
        currentResource1Amount = maxResource1Amount;
        currentResource2Amount = maxResource2Amount;
        currentResource3Amount = maxResource3Amount;

        UpdateDisplay();
    }

    public void SetDeltaAnswers(EmployeeScriptable employee) {
        deltaAnswer1Resource1 = employee.Delta1Resource1;
        deltaAnswer1Resource2 = employee.Delta1Resource2;
        deltaAnswer1Resource3 = employee.Delta1Resource3;

        deltaAnswer2Resource1 = employee.Delta2Resource1;
        deltaAnswer2Resource2 = employee.Delta2Resource2;
        deltaAnswer2Resource3 = employee.Delta2Resource3;
    }

    public void UpdateAnswer1() {
        currentResource1Amount = Mathf.Clamp(currentResource1Amount + deltaAnswer1Resource1, 0, maxResource1Amount);
        currentResource2Amount = Mathf.Clamp(currentResource2Amount + deltaAnswer1Resource2, 0, maxResource2Amount);
        currentResource3Amount = Mathf.Clamp(currentResource3Amount + deltaAnswer1Resource3, 0, maxResource3Amount);

        UpdateDisplay();
    }

    public void UpdateAnswer2() {
        currentResource1Amount = Mathf.Clamp(currentResource1Amount + deltaAnswer2Resource1, 0, maxResource1Amount);
        currentResource2Amount = Mathf.Clamp(currentResource2Amount + deltaAnswer2Resource2, 0, maxResource2Amount);
        currentResource3Amount = Mathf.Clamp(currentResource3Amount + deltaAnswer2Resource3, 0, maxResource3Amount);

        UpdateDisplay();
    }

    void UpdateDisplay() {
        resource1GaugeFill.fillAmount = Mathf.Clamp01((float)currentResource1Amount / maxResource1Amount);
        resource2GaugeFill.fillAmount = Mathf.Clamp01((float)currentResource2Amount / maxResource2Amount);
        resource3GaugeFill.fillAmount = Mathf.Clamp01((float)currentResource3Amount / maxResource3Amount);
    }
}
