using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResourcesManager : MonoBehaviour
{
    [Header("Resource1")]
    [SerializeField] int maxResource1Amount;
    [SerializeField] Image resource1GaugeFill;
    [SerializeField] ParticleSystem particleSystemPlusResource1;
    [SerializeField] ParticleSystem particleSystemMinusResource1;
    [Header("Resource2")]
    [SerializeField] int maxResource2Amount;
    [SerializeField] Image resource2GaugeFill;
    [SerializeField] ParticleSystem particleSystemPlusResource2;
    [SerializeField] ParticleSystem particleSystemMinusResource2;
    [Header("Resource3")]
    [SerializeField] int maxResource3Amount;
    [SerializeField] Image resource3GaugeFill;
    [SerializeField] ParticleSystem particleSystemPlusResource3;
    [SerializeField] ParticleSystem particleSystemMinusResource3;
    [Header("On Fail Event")]
    [SerializeField] UnityEvent onFailEvent;
    
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

    void CheckIfFail() {
        if (currentResource1Amount <= 0 || currentResource2Amount <= 0 || currentResource3Amount <= 0) {
            onFailEvent.Invoke();
        }
    }

    public void UpdateResource1(int deltaResource) {
        currentResource1Amount = Mathf.Clamp(currentResource1Amount + deltaResource, 0, maxResource1Amount);
        EmitParticle(1, deltaResource);
        UpdateDisplay();
        CheckIfFail();
    }

    public void UpdateResource2(int deltaResource) {
        currentResource2Amount = Mathf.Clamp(currentResource2Amount + deltaResource, 0, maxResource2Amount);
        EmitParticle(2, deltaResource);
        UpdateDisplay();
        CheckIfFail();
    }

    public void UpdateResource3(int deltaResource) {
        currentResource3Amount = Mathf.Clamp(currentResource3Amount + deltaResource, 0, maxResource3Amount);
        EmitParticle(3, deltaResource);
        UpdateDisplay();
        CheckIfFail();
    }

    public void UpdateAnswer1() {
        currentResource1Amount = Mathf.Clamp(currentResource1Amount + deltaAnswer1Resource1, 0, maxResource1Amount);
        EmitParticle(1, deltaAnswer1Resource1);
        currentResource2Amount = Mathf.Clamp(currentResource2Amount + deltaAnswer1Resource2, 0, maxResource2Amount);
        EmitParticle(2, deltaAnswer1Resource2);
        currentResource3Amount = Mathf.Clamp(currentResource3Amount + deltaAnswer1Resource3, 0, maxResource3Amount);
        EmitParticle(3, deltaAnswer1Resource3);
        UpdateDisplay();
        CheckIfFail();
    }

    public void UpdateAnswer2() {
        currentResource1Amount = Mathf.Clamp(currentResource1Amount + deltaAnswer2Resource1, 0, maxResource1Amount);
        EmitParticle(1, deltaAnswer2Resource1);
        currentResource2Amount = Mathf.Clamp(currentResource2Amount + deltaAnswer2Resource2, 0, maxResource2Amount);
        EmitParticle(2, deltaAnswer2Resource2);
        currentResource3Amount = Mathf.Clamp(currentResource3Amount + deltaAnswer2Resource3, 0, maxResource3Amount);
        EmitParticle(3, deltaAnswer2Resource3);
        UpdateDisplay();
        CheckIfFail();
    }

    void UpdateDisplay() {
        resource1GaugeFill.fillAmount = Mathf.Clamp01((float)currentResource1Amount / maxResource1Amount);
        resource2GaugeFill.fillAmount = Mathf.Clamp01((float)currentResource2Amount / maxResource2Amount);
        resource3GaugeFill.fillAmount = Mathf.Clamp01((float)currentResource3Amount / maxResource3Amount);
    }

    void EmitParticle(int resourceNumber, int deltaResource) {
        switch (resourceNumber) {
            case 1:
                if (deltaResource > 0) {
                    particleSystemPlusResource1.Emit(Mathf.Abs(deltaResource));
                } else if (deltaResource < 0) {
                    particleSystemMinusResource1.Emit(Mathf.Abs(deltaResource));
                }
                break;
            case 2:
                if (deltaResource > 0) {
                    particleSystemPlusResource2.Emit(Mathf.Abs(deltaResource));
                } else if (deltaResource < 0) {
                    particleSystemMinusResource2.Emit(Mathf.Abs(deltaResource));
                }
                break;
            case 3:
                if (deltaResource > 0) {
                    particleSystemPlusResource3.Emit(Mathf.Abs(deltaResource));
                } else if (deltaResource < 0) {
                    particleSystemMinusResource3.Emit(Mathf.Abs(deltaResource));
                }
                break;
            default:
                break;
        }
    }
}
