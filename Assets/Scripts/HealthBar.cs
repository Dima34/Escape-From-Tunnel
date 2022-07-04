using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Text HealthText;
    [SerializeField] Image HealthImage;
    [SerializeField] float ChangeSpeed = .5f;


    private void OnEnable() {
        Destroyable parent = GetComponentInParent<Destroyable>();
        parent.OnHealthChange += handleChange;
        parent.OnHealthInit += setNumberIndiaction;
        HealthImage.fillAmount = 1;
    }

    void handleChange(float healthAmount,float MaxHealth){
        float pct = healthAmount / MaxHealth;
        StartCoroutine(healthChangeProcessor(pct, MaxHealth));
    }

    IEnumerator healthChangeProcessor(float pct, float MaxHealth){
        float currentHealth = HealthImage.fillAmount;
        float t = 0f;

        while(pct < HealthImage.fillAmount){
            t += Time.deltaTime;
            HealthImage.fillAmount = Mathf.Lerp(currentHealth, pct, t / ChangeSpeed);

            float healthInPoint = Mathf.Floor(MaxHealth * HealthImage.fillAmount);

            setNumberIndiaction(healthInPoint,MaxHealth);

            if(HealthImage.fillAmount <= 0) StartCoroutine(removeBar());
            yield return null;
        }
    }

    IEnumerator removeBar(){
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

    void setNumberIndiaction(float healthAmount, float MaxHealth){
        HealthText.text = healthAmount + " / " + MaxHealth;
    }
}
