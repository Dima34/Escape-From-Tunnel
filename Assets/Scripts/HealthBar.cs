using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Image HealthImage;
    [SerializeField] float ChangeSpeed = .5f;


    private void OnEnable() {
        Destroyable parent = GetComponentInParent<Destroyable>();
        parent.OnHealthChange += handleChange;
        HealthImage.fillAmount = 1;
    }

    void handleChange(float healthAmount,float MaxHealth){
        float pct = healthAmount / MaxHealth;
        print("health change handle");
        StartCoroutine(healthChangeProcessor(pct));
    }

    IEnumerator healthChangeProcessor(float pct){
        float currentHealth = HealthImage.fillAmount;
        float t = 0f;

        while(pct < HealthImage.fillAmount){

            t += Time.deltaTime;
            print("While is working, current health - " + currentHealth + " pct - " + pct);
            HealthImage.fillAmount = Mathf.Lerp(currentHealth, pct, t);
            yield return null;
        }
        
    }

    // [SerializeField] private Image foregroundImage;
    // [SerializeField] float updateSpeedSeconds = .5f;

    // private void Awake() {
    //     // GetComponentInParent<Health>()
    //     GetComponentInChildren<Health>().OnHealthPctChanged += HandleHealthChanged;
    // }

    // private void HandleHealthChanged(float pct){
    //     StartCoroutine(ChangeToPct(pct));
    // }

    // private IEnumerator ChangeToPct(float pct){
    //     float preChangePct = foregroundImage.fillAmount;
    //     float elapsed = 0f;
    //     print("Prechange is set");

    //     while (elapsed < updateSpeedSeconds){
    //         elapsed += Time.deltaTime;
    //         print(elapsed);
    //         foregroundImage.fillAmount = Mathf.Lerp(preChangePct, pct, elapsed / updateSpeedSeconds);
    //         yield return null;
    //     }

    //     foregroundImage.fillAmount = pct;
    // }

}
